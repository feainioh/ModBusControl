using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;

namespace ECInspect
{
    /// <summary>
    /// 射频卡 消息类型【值为命令】
    /// </summary>
    enum CardMsgType : byte
    {
        /// <summary>
        /// 读取卡号
        /// </summary>
        GetCardNum = 0x07,
        /// <summary>
        /// 认证
        /// </summary>
        Authentication = 0x08,
        /// <summary>
        /// 读取块数据
        /// </summary>
        ReadBlockData = 0x09
    }

    /// <summary>
    /// 射频卡 消息发送
    /// </summary>
    struct CardMsgSend
    {
        /// <summary>
        /// 开始符
        /// </summary>
        const byte STX = 0X40;
        #region 发送帧
        /// <summary>
        /// 命令字
        /// </summary>
        readonly byte CMD;
        /// <summary>
        /// 数据长度
        /// </summary>
        readonly byte[] DataLength;
        /// <summary>
        /// 数据
        /// </summary>
        readonly byte [] Data;
        /// <summary>
        /// 校验字
        /// </summary>
        byte[] CheckStr;
        #endregion
        /// <summary>
        /// 终止符
        /// </summary>
        const byte ETX = 0X0D;

        public CardMsgSend(byte cmd,byte[] data)
        {
            CMD = cmd;
            DataLength  = new byte[2];//= BitConverter.GetBytes((short)data.Length);
            short m = (short)data.Length;
            DataLength[0] = (byte)((m & 0xff00) >> 8);
            DataLength[1] = (byte)(m & 0xff);
            Data = data;

            CheckStr = new byte[] { 0x00, 0x00 };
        }

        /// <summary>
        /// 获取字符串
        /// </summary>
        /// <returns></returns>
        internal byte[] GetMsg()
        {
            List<byte> str = new List<byte>();
            str.Add(STX);
            str.Add(CMD);
            str.AddRange(DataLength);
            str.AddRange(Data);
            
            //CheckStr = myFunction.CheckString(str.ToArray());

            str.AddRange(CheckStr);
            str.Add(ETX);

            return str.ToArray();
        }
    }

    /// <summary>
    /// 射频卡 消息接收
    /// </summary>
    struct CardMsgRev
    { 
      /// <summary>
        /// 开始符
        /// </summary>
        internal const byte STX = 0X40;
        #region 发送帧
        /// <summary>
        /// 命令字
        /// </summary>
        readonly byte CMD;
        /// <summary>
        /// 状态
        /// </summary>
        readonly byte Status;
        /// <summary>
        /// 数据长度
        /// </summary>
        readonly byte[] DataLength;
        /// <summary>
        /// 数据
        /// </summary>
        readonly byte [] Data;
        /// <summary>
        /// 校验字
        /// </summary>
        byte[] CheckStr;
        #endregion
        /// <summary>
        /// 终止符
        /// </summary>
        internal const byte ETX = 0X0D;

        public CardMsgRev(byte cmd, byte status, byte[] data)
        {
            CMD = cmd;
            Status = status;
            DataLength = BitConverter.GetBytes((short)data.Length);
            Data = data;

            CheckStr = new byte[] { 0x00, 0x00 };
        }

        /// <summary>
        /// 获取字符串的校验
        /// </summary>
        /// <returns></returns>
        internal byte[] GetCheck()
        {
            List<byte> str = new List<byte>();
            str.Add(STX);
            str.Add(CMD);
            str.Add(Status);
            str.AddRange(DataLength);
            str.AddRange(Data);
            
            return myFunction.CheckString(str.ToArray());
        }
    }

    /// <summary>
    /// 读卡器
    /// </summary>
    class CardReader
    {
        private Logs log = Logs.LogsT();

        /// <summary>
        /// 串口
        /// </summary>
        private SerialPort SP;

        public CardReader(string PortName)
        {
            try
            {
                SP = new SerialPort(PortName);
                SP.BaudRate = 115200;
                SP.DataBits = 8;
                SP.StopBits = StopBits.One;
                SP.Parity = Parity.None;

                SP.NewLine = "\r\n";

                SP.Open();

                SP.DiscardOutBuffer();
                SP.DiscardInBuffer();
                SP.ReadTimeout = 1000;
                SP.WriteTimeout = 50;
            }
            catch (Exception ex)
            {
                log.AddERRORLOG("读卡器串口初始化失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 获取卡号
        /// </summary>
        private bool GetCardNum()
        {
            if (!SP.IsOpen) return false;
            SP.DiscardInBuffer();
            CardMsgSend data = new CardMsgSend((byte)CardMsgType.GetCardNum, new byte[] { 0x0 });
            SP.Write(data.GetMsg(), 0, data.GetMsg().Length);
            string msg = string.Empty;
            return ReadMsgFromSP(CardMsgType.GetCardNum, ref msg);
        }

        /// <summary>
        /// 认证
        /// </summary>
        private bool Authentication()
        {
            if (!SP.IsOpen) return false;
            SP.DiscardInBuffer();
            CardMsgSend data = new CardMsgSend((byte)CardMsgType.Authentication, new byte[] { 0x00, 0x00, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff });
            SP.Write(data.GetMsg(), 0, data.GetMsg().Length);
            string msg = string.Empty;
            return ReadMsgFromSP(CardMsgType.Authentication, ref msg);
        }

        /// <summary>
        /// 读取块数据
        /// </summary>
        private bool ReadBlockData(ref string str)
        {
            if (!SP.IsOpen) return false;
            SP.DiscardInBuffer();
            CardMsgSend data = new CardMsgSend((byte)CardMsgType.ReadBlockData, new byte[] { 0X01 });
            SP.Write(data.GetMsg(), 0, data.GetMsg().Length);
            string msg = string.Empty;
            return ReadMsgFromSP(CardMsgType.ReadBlockData, ref str);
        }

        /// <summary>
        /// 主动从串口里读取消息
        /// </summary>
        /// <param name="mt"></param>
        private bool ReadMsgFromSP(CardMsgType mt,ref string Msg)
        {
            try
            {
                byte read;
                List<byte> allread = new List<byte>();//所有读取的数据
                read = ReadByte(ref allread);
                if ( read!= CardMsgRev.STX) throw new Exception("接收的起始符，内容不正确");
                read = ReadByte(ref allread);
                if (read != (byte)mt) throw new Exception("接收的命令符，内容不正确");
                read = ReadByte(ref allread);
                if (read != 0) throw new Exception("接收的状态符，异常" + read);
                byte len1 = ReadByte(ref allread);
                byte len2 = ReadByte(ref allread);
                byte[] length = new byte[] { len2, len1 };
                int len = BitConverter.ToInt16(length, 0);
                byte[] data = new byte[len];
                SP.Read(data, 0, data.Length);
                Msg = Encoding.Default.GetString(data).Trim('\0');
                allread.AddRange(data);
                int sum = 0;
                int xor = 0;
                foreach (byte item in allread)
                {
                    sum += item;
                    xor ^= item;
                }
                byte sumcheck = (byte)(sum & 0xff);//只取低位，抛弃高位
                byte[] Check = new byte[2];
                SP.Read(Check, 0, Check.Length);//需要检查校验符是否正确
                if (sumcheck != Check[0] ||
                    xor != Check[1]) throw new Exception("校验失败");//校验失败
                if (SP.ReadByte() != CardMsgRev.ETX) ;//结束符异常可以忽略
                return true;
            }
            catch (Exception ex)
            {
                log.AddCommLOG("读取卡异常:" + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 读取一个字节，加入链表
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private byte ReadByte(ref List<byte> list)
        {
            byte read = (byte)SP.ReadByte();
            list.Add(read);
            return read;
        }

        /// <summary>
        /// 读取一次卡
        /// </summary>
        /// <returns></returns>
        internal string ReadOnce()
        {
            string msg = string.Empty;
            if (GetCardNum() &&
                Authentication())
            {
                if (ReadBlockData(ref msg))
                    return msg.Replace('\0', ' ').Trim();
                else
                {
                    log.AddERRORLOG("读取块数据失败");
                    return string.Empty;
                }
            }
            else return string.Empty;
        }

        public void Dispose()
        {
            try
            {
                if (this.SP.IsOpen) this.SP.Close();
            }
            catch { }
        }
    }
}
