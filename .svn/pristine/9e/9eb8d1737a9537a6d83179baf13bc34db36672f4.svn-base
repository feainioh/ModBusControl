using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ECInspect
{
    public class Scan
    {
        Thread open_TH;
        SerialPort _serialPort = new SerialPort();
        public Scan(string ScanName)
        {
            _serialPort.PortName = ScanName;
            _serialPort.BaudRate = 115200;
            _serialPort.Parity = Parity.None;
            _serialPort.DataBits = 8;
            _serialPort.StopBits = StopBits.One;
            _serialPort.Handshake = Handshake.None;
            _serialPort.RtsEnable = true;
            _serialPort.DtrEnable = true;
            _serialPort.ReadTimeout = 2000;
            openPort();
        }

        private void open_OutTime()
        {
            int i = 0;
            while (true) 
            {
                i++;
                if (_serialPort.IsOpen) return;
                Thread.Sleep(1000);
                if (i > 5) 
                {
                    return;
                    throw new ScanErr("打开条码枪异常");
                    
                }
            }
        }
        /// <summary>
        /// 打开串口资源
        /// <returns>返回bool类型</returns>
        /// </summary>
        public bool openPort()
        {
            bool ok = false;
            //如果串口是打开的，先关闭
            if (_serialPort.IsOpen)
                _serialPort.Close();
            try
            {
                open_TH = new Thread(open_OutTime);
                open_TH.IsBackground = true;
                open_TH.Start();
                //打开串口
                _serialPort.Open();
            }
            catch (Exception Ex)
            {
                MsgBox("打开条码枪异常:"+Ex.Message,Color.Red,MessageBoxButtons.OK);
                if(_serialPort.IsOpen)open_TH.Abort();
            }
            if (_serialPort.IsOpen) open_TH.Abort();
            return ok;
        }

        public void ScanForTest(ref string barcode)
        {
            string result = "";
            byte[] byteArry_startScan = new byte[3];
            byteArry_startScan[0] = 0x16;
            byteArry_startScan[1] = 0x54;
            byteArry_startScan[2] = 0x0D;
            for (; ; )   //read time 3s
            {
                _serialPort.DiscardInBuffer();
                _serialPort.ReadTimeout = 500;
                byteArry_startScan[1] = 0x54;
                _serialPort.Write(byteArry_startScan, 0, 3);
                try
                {
                    Thread.Sleep(100);
                    byte[] byteArray = new byte[_serialPort.BytesToRead];
                    string totalstr = _serialPort.ReadTo("\r\n");
                    if (totalstr.Length > 4)
                    {
                        result = totalstr;
                        break;
                    }
                }
                catch (Exception ex)
                {
                    if (ex is TimeoutException) { barcode = "扫码超时!"; continue; }
                    MsgBox("扫码失败:" + ex.Message, Color.Red, MessageBoxButtons.OK);
                    break;
                }
                byteArry_startScan[1] = 0x55;
                _serialPort.Write(byteArry_startScan, 0, 3);
            }
            barcode = result;

        }

        public bool StartScan()
        {
            bool result = false;
            byte[] byteArry_startScan = new byte[3];
            byteArry_startScan[0] = 0x16;
            byteArry_startScan[1] = 0x54;
            byteArry_startScan[2] = 0x0D;
            try
            {
                for (int i = 0; i < 3; i++)   //read time 3s
                {
                    _serialPort.DiscardInBuffer();
                    _serialPort.ReadTimeout = 500;
                    byteArry_startScan[1] = 0x54;
                    _serialPort.Write(byteArry_startScan, 0, 3);
                    try
                    {
                        Thread.Sleep(100);
                        byte[] byteArray = new byte[_serialPort.BytesToRead];
                        string totalstr = _serialPort.ReadTo("\r\n");
                        if (totalstr.Length > 4)
                        {
                            GlobalVar.gl_Barcode = "";
                            GlobalVar.gl_Barcode = totalstr;
                            result = true;
                            break;
                        }
                    }
                    catch(Exception ex)
                    {
                        if (ex is TimeoutException) { continue; }
                        
                        MsgBox("扫码失败:" + ex.Message, Color.Red, MessageBoxButtons.OK);
                        break;
                    }
                    byteArry_startScan[1] = 0x55;
                    _serialPort.Write(byteArry_startScan, 0, 3);
                }
            }
            catch { }
            return result;
        }

        public bool StartScan(ref string barcode)
        {
            bool result = false;
            byte[] byteArry_startScan = new byte[3];
            byteArry_startScan[0] = 0x16;
            byteArry_startScan[1] = 0x54;
            byteArry_startScan[2] = 0x0D;
            try
            {
                for (int i = 0; i < 3; i++)   //read time 3s
                {
                    _serialPort.DiscardInBuffer();
                    _serialPort.ReadTimeout = 500;
                    byteArry_startScan[1] = 0x54;
                    _serialPort.Write(byteArry_startScan, 0, 3);
                    try
                    {
                        Thread.Sleep(100);
                        byte[] byteArray = new byte[_serialPort.BytesToRead];
                        string totalstr = _serialPort.ReadTo("\r\n");
                        if (totalstr.Length > 4)
                        {
                            barcode = totalstr;
                            result = true;
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ex is TimeoutException) { barcode = "扫码超时!"; continue; }
                        MsgBox("扫码失败:" + ex.Message, Color.Red, MessageBoxButtons.OK);
                        break;
                    }
                    byteArry_startScan[1] = 0x55;
                    _serialPort.Write(byteArry_startScan, 0, 3);
                }
            }
            catch { }
            return result;
        }

        /// <summary>
        /// 弹框【确认或者取消】
        /// </summary>
        /// <param name="text">内容</param>
        /// <param name="backcolor">背景色</param>
        /// <returns></returns>
        protected bool MsgBox(string text, Color backcolor, MessageBoxButtons btn)
        {
            MsgBox box = new MsgBox(btn);
            box.Title = "错误";
            box.ShowText = text;
            box.BackColor = backcolor;
            if (box.ShowDialog() == DialogResult.OK) return true;
            else return false;
        }
    }
    public class SerialClass

    {

        SerialPort _serialPort = null;

        //定义委托

        public delegate void SerialPortDataReceiveEventArgs(object sender, SerialDataReceivedEventArgs e, byte[] bits);

        //定义接收数据事件

        public event SerialPortDataReceiveEventArgs DataReceived;

        //定义接收错误事件

        //public event SerialErrorReceivedEventHandler Error;

        //接收事件是否有效 false表示有效

        public bool ReceiveEventFlag = false;

        #region 获取串口名

        private string protName;

        public string PortName

        {

            get { return _serialPort.PortName; }

            set

            {

                _serialPort.PortName = value;

                protName = value;

            }

        }

        #endregion

        #region 获取比特率

        private int baudRate;

        public int BaudRate

        {

            get { return _serialPort.BaudRate; }

            set

            {

                _serialPort.BaudRate = value;

                baudRate = value;

            }

        }

        #endregion

        #region 默认构造函数

        /// <summary>

        /// 默认构造函数，操作COM1，速度为9600，没有奇偶校验，8位字节，停止位为1 "COM1", 9600, Parity.None, 8, StopBits.One

        /// </summary>

        public SerialClass()

        {

            _serialPort = new SerialPort();

        }

        #endregion

        #region 构造函数

        /// <summary>

        /// 构造函数,

        /// </summary>

        /// <param name="comPortName"></param>

        public SerialClass(string comPortName)

        {

            _serialPort = new SerialPort(comPortName);

            _serialPort.BaudRate = 115200;

            _serialPort.Parity = Parity.None;

            _serialPort.DataBits = 8;

            _serialPort.StopBits = StopBits.One;

            _serialPort.Handshake = Handshake.None;

            _serialPort.RtsEnable = true;

            _serialPort.DtrEnable = true;

            _serialPort.ReadTimeout = 2000;

            setSerialPort();

        }

        #endregion

        #region 构造函数,可以自定义串口的初始化参数

        /// <summary>

        /// 构造函数,可以自定义串口的初始化参数

        /// </summary>

        /// <param name="comPortName">需要操作的COM口名称</param>

        /// <param name="baudRate">COM的速度</param>

        /// <param name="parity">奇偶校验位</param>

        /// <param name="dataBits">数据长度</param>

        /// <param name="stopBits">停止位</param>

        public SerialClass(string comPortName, int baudRate, Parity parity, int dataBits, StopBits stopBits)

        {

            _serialPort = new SerialPort(comPortName, baudRate, parity, dataBits, stopBits);

            _serialPort.RtsEnable = true;  //自动请求

            _serialPort.ReadTimeout = 3000;//超时

            setSerialPort();

        }

        #endregion


        #region 设置串口参数

        /// <summary>

        /// 设置串口参数

        /// </summary>

        /// <param name="comPortName">需要操作的COM口名称</param>

        /// <param name="baudRate">COM的速度</param>

        /// <param name="dataBits">数据长度</param>

        /// <param name="stopBits">停止位</param>

        public void setSerialPort(string comPortName, int baudRate, int dataBits, int stopBits)

        {

            if (_serialPort.IsOpen)

                _serialPort.Close();

            _serialPort.PortName = comPortName;

            _serialPort.BaudRate = baudRate;

            _serialPort.Parity = Parity.None;

            _serialPort.DataBits = dataBits;

            _serialPort.StopBits = (StopBits)stopBits;

            _serialPort.Handshake = Handshake.None;

            _serialPort.RtsEnable = false;

            _serialPort.ReadTimeout = 3000;

            _serialPort.NewLine = "/r/n";

            setSerialPort();

        }

        #endregion

        #region 设置接收函数

        /// <summary>

        /// 设置串口资源,还需重载多个设置串口的函数

        /// </summary>

        void setSerialPort()

        {

            if (_serialPort != null)

            {

                //设置触发DataReceived事件的字节数为1

                _serialPort.ReceivedBytesThreshold = 1;

                //接收到一个字节时，也会触发DataReceived事件

                _serialPort.DataReceived += new SerialDataReceivedEventHandler(_serialPort_DataReceived);

                //接收数据出错,触发事件

                _serialPort.ErrorReceived += new SerialErrorReceivedEventHandler(_serialPort_ErrorReceived);

                //打开串口

                //openPort();

            }

        }

        #endregion

        #region 打开串口资源

        /// <summary>

        /// 打开串口资源

        /// <returns>返回bool类型</returns>

        /// </summary>

        public bool openPort()

        {

            bool ok = false;

            //如果串口是打开的，先关闭

            if (_serialPort.IsOpen)

                _serialPort.Close();

            try

            {

                //打开串口

                _serialPort.Open();

                ok = true;

            }

            catch (Exception Ex)

            {

                throw Ex;

            }

            return ok;

        }

        #endregion

        #region 关闭串口

        /// <summary>

        /// 关闭串口资源,操作完成后,一定要关闭串口

        /// </summary>

        public void closePort()

        {

            //如果串口处于打开状态,则关闭

            if (_serialPort.IsOpen)

                _serialPort.Close();

        }

        #endregion

        #region 接收串口数据事件

        /// <summary>

        /// 接收串口数据事件

        /// </summary>

        /// <param name="sender"></param>

        /// <param name="e"></param>

        void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)

        {

            //禁止接收事件时直接退出

            if (ReceiveEventFlag)

            {

                return;

            }

            try

            {

                System.Threading.Thread.Sleep(20);

                byte[] _data = new byte[_serialPort.BytesToRead];

                _serialPort.Read(_data, 0, _data.Length);

                if (_data.Length == 0) { return; }

                if (DataReceived != null)

                {

                    DataReceived(sender, e, _data);

                }

                //_serialPort.DiscardInBuffer();  //清空接收缓冲区  

            }

            catch (Exception ex)

            {

                throw ex;

            }

        }

        #endregion

        #region 接收数据出错事件

        /// <summary>

        /// 接收数据出错事件

        /// </summary>

        /// <param name="sender"></param>

        /// <param name="e"></param>

        void _serialPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)

        {

        }

        #endregion

        #region 发送数据string类型

        public void SendData(string data)

        {

            //发送数据

            //禁止接收事件时直接退出

            if (ReceiveEventFlag)

            {

                return;

            }

            if (_serialPort.IsOpen)

            {

                _serialPort.Write(data);

            }

        }

        #endregion

        #region 发送数据byte类型

        /// <summary>

        /// 数据发送

        /// </summary>

        /// <param name="data">要发送的数据字节</param>

        public void SendData(byte[] data, int offset, int count)

        {

            //禁止接收事件时直接退出

            if (ReceiveEventFlag)

            {

                return;

            }

            try

            {

                if (_serialPort.IsOpen)

                {

                    //_serialPort.DiscardInBuffer();//清空接收缓冲区

                    _serialPort.Write(data, offset, count);

                }

            }

            catch (Exception ex)

            {

                throw ex;

            }

        }

        #endregion

        #region 发送命令

        /// <summary>

        /// 发送命令

        /// </summary>

        /// <param name="SendData">发送数据</param>

        /// <param name="ReceiveData">接收数据</param>

        /// <param name="Overtime">超时时间</param>

        /// <returns></returns>

        public int SendCommand(byte[] SendData, ref byte[] ReceiveData, int Overtime)

        {



            if (_serialPort.IsOpen)

            {

                try

                {

                    ReceiveEventFlag = true;        //关闭接收事件

                    _serialPort.DiscardInBuffer();  //清空接收缓冲区                

                    _serialPort.Write(SendData, 0, SendData.Length);

                    int num = 0, ret = 0;

                    System.Threading.Thread.Sleep(10);

                    ReceiveEventFlag = false;      //打开事件

                    while (num++ < Overtime)

                    {

                        if (_serialPort.BytesToRead >= ReceiveData.Length)

                            break;

                        System.Threading.Thread.Sleep(10);

                    }



                    if (_serialPort.BytesToRead >= ReceiveData.Length)

                    {

                        ret = _serialPort.Read(ReceiveData, 0, ReceiveData.Length);

                    }

                    else

                    {

                        ret = _serialPort.Read(ReceiveData, 0, _serialPort.BytesToRead);

                    }

                    ReceiveEventFlag = false;      //打开事件

                    return ret;

                }

                catch (Exception ex)

                {

                    ReceiveEventFlag = false;

                    throw ex;

                }

            }

            return -1;

        }

        #endregion

        #region 获取串口

        /// <summary>

        /// 获取所有已连接短信猫设备的串口

        /// </summary>

        /// <returns></returns>

        public string[] serialsIsConnected()

        {

            List<string> lists = new List<string>();

            string[] seriallist = getSerials();

            foreach (string s in seriallist)

            {

            }

            return lists.ToArray();

        }

        #endregion

        #region 获取当前全部串口资源

        /// <summary>

        /// 获得当前电脑上的所有串口资源

        /// </summary>

        /// <returns></returns>

        public string[] getSerials()

        {

            return SerialPort.GetPortNames();

        }

        #endregion

        #region 字节型转换16

        /// <summary>

        /// 把字节型转换成十六进制字符串

        /// </summary>

        /// <param name="InBytes"></param>

        /// <returns></returns>

        public static string ByteToString(byte[] InBytes)

        {

            string StringOut = "";

            foreach (byte InByte in InBytes)

            {

                StringOut = StringOut + String.Format("{0:X2} ", InByte);

            }

            return StringOut;

        }

        #endregion

        #region 十六进制字符串转字节型

        /// <summary>

        /// 把十六进制字符串转换成字节型(方法1)

        /// </summary>

        /// <param name="InString"></param>

        /// <returns></returns>

        public static byte[] StringToByte(string InString)

        {

            string[] ByteStrings;

            ByteStrings = InString.Split(" ".ToCharArray());

            byte[] ByteOut;

            ByteOut = new byte[ByteStrings.Length];

            for (int i = 0; i <= ByteStrings.Length - 1; i++)

            {

                //ByteOut[i] = System.Text.Encoding.ASCII.GetBytes(ByteStrings[i]);

                ByteOut[i] = Byte.Parse(ByteStrings[i], System.Globalization.NumberStyles.HexNumber);

                //ByteOut[i] =Convert.ToByte("0x" + ByteStrings[i]);

            }

            return ByteOut;

        }

        #endregion

        #region 十六进制字符串转字节型

        /// <summary>

        /// 字符串转16进制字节数组(方法2)

        /// </summary>

        /// <param name="hexString"></param>

        /// <returns></returns>

        public static byte[] strToToHexByte(string hexString)

        {

            hexString = hexString.Replace(" ", "");

            if ((hexString.Length % 2) != 0)

                hexString += " ";

            byte[] returnBytes = new byte[hexString.Length / 2];

            for (int i = 0; i < returnBytes.Length; i++)

                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);

            return returnBytes;

        }

        #endregion

        #region 字节型转十六进制字符串

        /// <summary>

        /// 字节数组转16进制字符串

        /// </summary>

        /// <param name="bytes"></param>

        /// <returns></returns>

        public static string byteToHexStr(byte[] bytes)

        {

            string returnStr = "";

            if (bytes != null)

            {

                for (int i = 0; i < bytes.Length; i++)

                {

                    returnStr += bytes[i].ToString("X2");

                }

            }

            return returnStr;

        }

        #endregion

    }
}
