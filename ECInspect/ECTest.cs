using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;

namespace ECInspect
{
    /// <summary>
    /// 指令
    /// </summary>
    class ECOrder
    {
        #region TS指令
        private const string TS = "TS";//指令的前缀
        #region PC发送给EC       
        private const string StartTest = "START";
        /// <summary>
        /// 开始测试指令，前面需要追加数量
        /// </summary>
        protected string Order_StartTest { get { return TS + StartTest; } }
        
        private const string Reset = "RESET";
        /// <summary>
        /// 复位指令
        /// </summary>
        protected string Order_Reset { get { return TS + Reset; } }
        
        private const string TRLON = "TRLON";
        /// <summary>
        /// 非接触ON
        /// </summary>
        protected string Order_TRLON { get { return TS + TRLON; } }
        
        private const string TRLOFF = "TRLOFF";
        /// <summary>
        /// 非接触OFF
        /// </summary>
        protected string Order_TRLOFF { get { return TS + TRLOFF; } }
        #endregion

        #region EC发送给PC        
        private const string Retry = "RETRY";
        /// <summary>
        /// 重试检查动作要求
        /// MAC的情况，警告表示后返回原点的动作
        /// </summary>
        protected string Order_Retry { get { return TS + Retry; } }

        private const string End = "END";
        /// <summary>
        /// EC测试完毕
        /// </summary>
        protected string Order_End { get { return TS + End; } }
        #endregion

        #region EC应答PC
          /// <summary>
        /// 错误
        /// </summary>
        protected const string AnswerWrong = "0";
        /// <summary>
        /// 正常
        /// </summary>
        protected const string AnswerOK = "1";
        /// <summary>
        /// 个数错误
        /// </summary>
        protected const string AnswerWrongNum = "3";
        #endregion
        #endregion
    }

    class ECTest : ECOrder
    {       
        /// <summary>
        /// 连接EC检查机的串口
        /// </summary>
        private SerialPort EC_SerialPort;

        public delegate void dele_RunStatus(string str, EC_RunType type);//EC的运行状态
        public event dele_RunStatus Event_RunStatus;

        /// <summary>
        /// 暂停测试
        /// </summary>
        internal bool TestPause = false;
        /// <summary>
        /// 是否中断测试
        /// </summary>
        private bool isAbortTest = false;

        private bool m_InTest = false;
        /// <summary>
        /// 是否在测试中
        /// </summary>
        internal bool InTest { get { return m_InTest; } }
        /// <summary>
        /// 消息是否错误
        /// </summary>
        private bool IsError = false;
        /// <summary>
        /// 等待测试结果
        /// </summary>
        private AutoResetEvent TRWait = new AutoResetEvent(false);
        /// <summary>
        /// 尝试重新测试【收到EC反馈重新测试后，置为true】
        /// </summary>
        private bool RetryStart = false;
        /// <summary>
        ///本轮测试NG项【以收到TSEND为止】
        /// </summary>
        private Dictionary<int, EC_NGItem> Result_Dic = new Dictionary<int, EC_NGItem>();
        /// <summary>
        /// 显示用的测试结果
        /// </summary>
        private List<EC_TestResultItem> TestResult_Show = new List<EC_TestResultItem>();

        /// <summary>
        /// 最后的异常信息
        /// </summary>
        private string LastErr = string.Empty;

        private Logs log = Logs.LogsT();
        private myFunction myfunction = new myFunction();
        private object lockRecv = new object();//接收消息锁
        private object lockSend = new object();//发送消息锁

        /// <summary>
        /// EC主机应答结果
        /// </summary>
        private ECMsgReply MsgReply = ECMsgReply.None;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="PortName">串口名称</param>
        public ECTest(string PortName)
        {
            try
            {
                EC_SerialPort = new SerialPort(PortName);
                EC_SerialPort.BaudRate = 38400;
                EC_SerialPort.DataBits = 8;
                EC_SerialPort.StopBits = StopBits.One;
                EC_SerialPort.Parity = Parity.None;

                EC_SerialPort.NewLine = "\r\n";

                EC_SerialPort.DataReceived += new SerialDataReceivedEventHandler(EC_SerialPort_DataReceived);

                EC_SerialPort.Open();

                EC_SerialPort.DiscardOutBuffer();
                EC_SerialPort.DiscardInBuffer();
                EC_SerialPort.WriteTimeout = 50;
                EC_SerialPort.RtsEnable = true;
                EC_SerialPort.DtrEnable = true;
                Console.WriteLine("EC DSR:" + EC_SerialPort.DsrHolding);

                Reset();
            }
            catch (Exception ex)
            {
                log.AddERRORLOG("EC电测主机  初始化串口失败:" + ex.Message);
            }
        }

        /// <summary>
        /// 设置接触测试ON/OFF   不使用
        /// </summary>
        internal int SetTRL()
        {
            return SendMsg("00" + (INIFileValue.Product_TRL == 1 ? Order_TRLOFF : Order_TRLON));
        }

        /// <summary>
        /// 开始测试【返回本次测试是否全部OK】
        /// </summary>
        internal EC_TestResult StartTest()
        {
            try
            {
                isAbortTest = false;
                m_InTest = true;
                RetryStart = false;
                RunStatus("主机开始测试", EC_RunType.Normal);
                do
                {
                    while (TestPause) Thread.Sleep(500);
                    if (RetryStart)
                    {
                        RetryStart = false;
                        //SendMsg("00" + this.Order_Reset);
                        Thread.Sleep(500);
                        RunStatus("主机测试重试", EC_RunType.Normal);
                    }
                    if (SendMsg(INIFileValue.Product_GROUP.ToString("00") + Order_StartTest) != 0) throw new Exception("发送消息给测试主机失败");
                    CheckTRTrigger(60000);//超时60秒,等待测试结果，以收到TS为止
                }
                while (RetryStart);
                RunStatus("主机测试结束", EC_RunType.Normal);

                //bool AllPass = true;//是否全部Pass
                //foreach (EC_TestResultItem item in this.TestResult_Show)
                //{
                //    if (item.Item != EC_NGItem.PASS) AllPass = false;
                //}
                if (this.Result_Dic.Count == 0)
                {
                    RunStatus("全部测试OK", EC_RunType.Normal);
                    return EC_TestResult.OK;        //全部OK
                }
                else return EC_TestResult.FAIL;
            }
            catch (Exception ex)
            {
                RunStatus(ex.Message, EC_RunType.Error);
                this.LastErr = ex.Message;
                return EC_TestResult.ERROR;
            }
            finally
            {
                m_InTest = false;
                IsError = false;
                this.Result_Dic.Clear();//清空当前测试结果
            }
        }

        /// <summary>
        /// 检查测试是否超时
        /// </summary>
        /// <param name="nTimeout">等待时间（单位：毫秒）</param>
        private void CheckTRTrigger(int nTimeout)
        {
            if (!TRWait.WaitOne(nTimeout)) throw new TimeoutException("EC测试超时");
            if (isAbortTest) throw new Exception("中断测试");
            if (IsError) throw new Exception("出现错误");
        }

        /// <summary>
        /// 中断测试
        /// </summary>
        internal void AbortTest()
        {
            isAbortTest = true;
            TRWait.Set();
        }

        private void EC_SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            lock (lockRecv)
            {
                SerialPort sp = (SerialPort)sender;
                string RecvMsg = sp.ReadTo("\r\n");
                Console.Write(string.Format("[{0}]\tRev:\t{1} | ", DateTime.Now.ToString("HH:mm:ss:fff"), RecvMsg));
                RunStatus("Rev:" + RecvMsg, EC_RunType.CommInfo);
                byte[] Recvbyte = Encoding.Default.GetBytes(RecvMsg);
                foreach (byte item in Recvbyte)
                {
                    Console.Write(item.ToString("X2") + " ");
                }
                Console.WriteLine();
                
                int Search = Array.IndexOf(Recvbyte, (byte)3);
                if (Search != -1)//EC主动发送消息
                {
                    Answer(true);//应答EC测试主机
                    byte[] value = new byte[Search - 1];
                    Array.Copy(Recvbyte, 1, value, 0, value.Length);
                    RecvMsg = Encoding.Default.GetString(value);
                }

                AnalysisRecv(RecvMsg);
            }
        }

        /// <summary>
        /// 解析接收的消息
        /// </summary>
        /// <param name="str">接收的字符串</param>
        private void AnalysisRecv(string str)
        {
            try
            {
                switch (str.Trim())
                {
                    case AnswerOK:
                        MsgReply = ECMsgReply.OK;
                        return;
                    case AnswerWrong:
                        MsgReply = ECMsgReply.Error;
                        throw new ECAnswerErr("EC主机反馈30");//接收到30
                    case AnswerWrongNum:
                        MsgReply = ECMsgReply.Error;
                        throw new ECAnswerErr("检查前检测个数错误警告\r\n检测装置与测试机的检测数量不同");// ("EC主机反馈33 【个数错误】");//接收到33
                }

                int Index = str.IndexOf("LA");//LA的序号
                if (Index != -1)
                {
                    string range = str.Substring(0, Index);//截取LA以前的序号，该序号为范围
                    string value = str.Substring(Index + 2);//截取LA以后的数据
                    StringBuilder temp = new StringBuilder(value.Length * 4);
                    for (int i = 0; i < value.Length; i++)
                    {
                        int dec = Convert.ToInt32(value[i].ToString(), 16);//十六进制转十进制
                        temp.Append(Convert.ToString(dec, 2).PadLeft(4, '0'));//十进制转二进制
                    }
                    string result = temp.ToString();
                    if (range == "01")      //序号1-25
                    {
                        AddResult(result, 1);
                    }
                    else if (range == "02") //序号26-50
                    {
                        AddResult(result, 26);
                    }
                    else throw new Exception("ADRS只能为“01”和“02”");//ADRS只能为“01”和“02”
                }
            }
            catch (Exception ex)
            {
                log.AddERRORLOG("EC异常:" + ex.Message);
                this.LastErr = ex.Message;
                this.IsError = true;
                if (ex is ECAnswerErr)
                {
                    RunStatus(ex.Message, EC_RunType.Error);
                    TRWait.Set();
                }
            }
            finally
            {
                if (str.Contains(Order_Retry))
                {
                    RetryStart = true;
                    TRWait.Set();
                } 
                else if (str.Contains(Order_End))
                {
                    if (!SummaryResult(str))//组合 测试数据
                    {
                        this.LastErr = "测试结果数量不一致";
                        this.IsError = true;   //数量不一致时，需要进一步处理···
                    }
                    TRWait.Set();
                }
            }
        }

        /// <summary>
        /// 总结测试数据【数量正常 返回True】
        /// </summary>
        private bool SummaryResult(string str)
        {
            try
            {
                int OKNum = Convert.ToInt32(str.Substring(0, 2));
                if (this.TestResult_Show.Count == 0)//首次测试完毕直接添加
                {
                    for (int i = 0; i < INIFileValue.Product_GROUP; i++)
                    {
                        if (Result_Dic.ContainsKey(i)) this.TestResult_Show.Add(new EC_TestResultItem(this.Result_Dic[i]));
                        else this.TestResult_Show.Add(new EC_TestResultItem(EC_NGItem.PASS));
                    }
                }
                else
                {
                    for (int i = 0; i < INIFileValue.Product_GROUP; i++)
                    {
                        this.TestResult_Show[i].ChangeResult(Result_Dic.ContainsKey(i) ? this.Result_Dic[i] : EC_NGItem.PASS);
                    }
                }
                if ((OKNum + this.Result_Dic.Count) == INIFileValue.Product_GROUP) return true;
                else throw new Exception(string.Format("数量不一致，请检查\tOK:{0}\tNG:{1}\tTotal:{2}", OKNum, this, Result_Dic.Count, INIFileValue.Product_GROUP));
            }
            catch (Exception ex)
            {
                log.AddERRORLOG("总结异常:" + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 增加测试结果队列
        /// </summary>
        /// <param name="Value">需要解析的数据</param>
        /// <param name="StartIndex">开始的序号</param>
        private void AddResult(string Value,int StartIndex)
        {
            EC_NGItem Type = GetResultType(Value);
            Value = Value.Substring(3);
            Value = myFunction.StrReverse(Value);//反转字符串，便于分析结果
            int Max = 0;//数组截取长度判断的最大值
            if (StartIndex == 1) Max = INIFileValue.Product_GROUP >= 25 ? 25 : INIFileValue.Product_GROUP;
            else Max = INIFileValue.Product_GROUP - 25;

            StartIndex -= 1;//减去1位，方便匹配数组
            int Index = 0;//实际的序号
            for (int i = 0; i < Max; i++)
            {
                Index = i + StartIndex;
                if (Value[i] == '1' && !this.Result_Dic.ContainsKey(Index))
                {
                    Result_Dic.Add(Index, Type);
                    log.AddCommLOG(string.Format("序号:{0}\tNG:{1}", Index, Type.ToString()));
                }
            }        
        }

        private EC_NGItem GetResultType(string type)
        { 
            type = type.Substring(0,3);
            switch (type)
            {
                case "000":
                    return EC_NGItem.LEAK;
                case "001":
                    return EC_NGItem.SHORT;
                case "010":
                    return EC_NGItem.OPEN;
                case "011":
                    return EC_NGItem.OFFSET_M;
                case "100":
                    return EC_NGItem.OFFSET_N;
                case "101":
                    return EC_NGItem.ForgetPaste;
                case "110":
                    return EC_NGItem.NG;
                default:
                    throw new ArgumentOutOfRangeException("未知的检查结果类型");
            }
        }
                
        /// <summary>
        /// 发送指令 【全部需要答复】  0：代表发送正常
        /// </summary>
        /// <param name="msg">指令</param>
        internal int SendMsg(string msg)
        {
            lock (lockSend)
            {
                MsgReply = ECMsgReply.None;

                string str = msg.Replace(" ", "").ToUpper();
                RunStatus("Send:" + str, EC_RunType.CommInfo);
                Byte[] b = Encoding.Default.GetBytes(str);
                List<byte> lb = new List<byte>();
                lb.Add(0x02);//起始符号ST
                lb.AddRange(b);//发送内容
                lb.Add(0x03);//结束符号ET
                lb.AddRange(Encoding.Default.GetBytes(CalculateChecksum(lb.ToArray())));//SUM运算
                lb.AddRange(new byte[] { 0x0D, 0x0A });//回车换行
                b = lb.ToArray();

                SPSendByte(b);

                DateTime startTime = DateTime.Now;
                int _count = 0; //每秒+1，当==3时超时
                do
                {
                    if (isAbortTest) throw new Exception("中断测试");
                    //--如果超時尚未等到回復，超時退出 ---- 每隔一秒钟重发一次
                    TimeSpan TS = DateTime.Now - startTime;
                    if (TS.TotalMilliseconds > 1000)
                    {
                        startTime = DateTime.Now;
                        if (_count >= 3)
                        {
                            ////MessageBox.Show("指令：[" + str.Replace("\r\n", "") + "]未收到回復，已執行超時終止，請重新執行發送動作！",
                            ////    "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                            log.AddERRORLOG("EC 三次重发没有收到，清除发送字符串" + msg);
                            MsgReply = ECMsgReply.None;
                            //m_inCommunication = false;
                            return 3;
                        }
                        else
                        {
                            SPSendByte(b);
                        }
                        _count++;
                    }
                }
                while (MsgReply == ECMsgReply.None);
                return 0;
            }
        }

        private string CalculateChecksum(string dataToCalculate)
        {
            byte[] byteToCalculate = Encoding.ASCII.GetBytes(dataToCalculate);
            int checksum = 0;
            foreach (byte chData in byteToCalculate)
            {
                checksum += chData;
            }
            checksum &= 0xff;
            return checksum.ToString("X2");
        }

        private string CalculateChecksum(byte[] byteToCalculate)
        {
            int checksum = 0;
            foreach (byte chData in byteToCalculate)
            {
                checksum += chData;
            }
            checksum &= 0xff;

            //Console.WriteLine("CalculateChecksum:{0}", checksum.ToString("X2"));

            return checksum.ToString("X2");
        }

        /// <summary>
        /// 应答
        /// </summary>
        /// <param name="isOK"></param>
        private void Answer(bool isOK = true)
        {
            string str = isOK ? "1" : "0";

            Byte[] b = Encoding.Default.GetBytes(str);
            List<byte> lb = new List<byte>();
            lb.Add(0x02);//起始符号ST
            lb.AddRange(b);//发送内容
            lb.AddRange(new byte[] { 0x0D, 0x0A });//回车换行
            b = lb.ToArray();

            SPSendByte(b);
        }

        /// <summary>
        /// 复位
        /// </summary>
        internal void Reset()
        {
            byte[] ba = new byte[] { 0x02, 0x30, 0x30, 0x54, 0x53, 0x52, 0x45, 0x53, 0x45, 0x54, 0x03, 0x38, 0x46, 0x0D, 0x0A };
            SPSendByte(ba);
        }

        /// <summary>
        /// 串口发送数组
        /// </summary>
        /// <param name="bt"></param>
        private void SPSendByte(byte [] bt)  //未收到，重发
        {
            try
            {
                TRWait.Reset();
                Console.Write(string.Format("[{0}]\tSend:\t{1} | ", DateTime.Now.ToString("HH:mm:ss:fff"), Encoding.Default.GetString(bt).Trim('\n').Trim('\r')));
                foreach (byte item in bt)
                {
                    Console.Write(item.ToString("X2") + " ");
                }
                Console.WriteLine();

                EC_SerialPort.RtsEnable = false;
                //if (EC_SerialPort.IsOpen) EC_SerialPort.Write(bt, 0, bt.Length);
                if (EC_SerialPort.IsOpen)
                {
                    foreach (byte b in bt)
                    {
                        EC_SerialPort.Write(new byte[] { b }, 0, 1);
                        Thread.Sleep(5);
                    }
                    //EC_SerialPort.Write(bt, 0, bt.Length);
                }
                else throw new Exception("连接EC测试的串口未打开！");
                EC_SerialPort.RtsEnable = true;
            }
            catch (Exception ex)
            {
                RunStatus(ex.Message, EC_RunType.Error);
            }
        }

        private void RunStatus(string str, EC_RunType type)
        {
            if (this.Event_RunStatus != null) this.Event_RunStatus(str, type);
        }

        public override string ToString()
        {
            return this.EC_SerialPort.PortName;
        }

        /// <summary>
        /// 获取本轮的测试结果【如果开启图替：单个制品测试PASS一次即认为单个PASS】
        /// </summary>
        /// <returns></returns>
        internal EC_TestResultItem[] GetTestResult()
        {
            return this.TestResult_Show.ToArray();
        }

        /// <summary>
        /// 清除记录的测试结果
        /// </summary>
        internal void ClearAllTestResult()
        {
            this.Result_Dic.Clear();
            this.TestResult_Show.Clear();
        }

        /// <summary>
        /// 获取异常信息
        /// </summary>
        /// <returns></returns>
        internal string GetLastErr()
        {
            return LastErr;
        }

        internal void Dispose()
        {
            if (this.EC_SerialPort.IsOpen)
                this.EC_SerialPort.Close();
        }

    }
}
