using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

namespace UpdateTool
{
    public partial class MsgBox : Form
    {
        /// <summary>
        /// 倒计时，默认值为3秒
        /// </summary>
        public int count = 3;
        /// <summary>
        /// 对话框返回值，默认为OK
        /// </summary>
        public DialogResult dialog_result = DialogResult.OK;
        private bool start_countdown = false;
        /// <summary>
        ///是否启动页面的倒计时关闭 
        /// </summary>
        public bool isStart_CountDown
        {
            set 
            {
                start_countdown = value;
                Thread start = new Thread(new ThreadStart(delegate
                {
                    try
                    {
                        CountDown(count);
                        this.DialogResult = dialog_result;
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action(() => { this.Close(); }));
                        }
                        else this.Close();
                    }
                    catch { }
                    }));
                start.IsBackground = true;
                start.Start();
            }
        }
        AutoResetEvent ContinueCountDown = new AutoResetEvent(false);//继续倒计时

        public Color strForeColor = Color.Black;

        private string _showstr = string.Empty;
        /// <summary>
        /// 显示字符串（MsgBox显示用）
        /// </summary>
        public string ShowStr
        {
            set
            {
                _showstr = value;
                if (EventShowErr != null) EventShowErr(value);
            }
            get { return _showstr; }
        }
        internal delegate void dele_ShowErr(string str);
        internal event dele_ShowErr EventShowErr;
        
        public MsgBox()
        {
            InitializeComponent();
        }

        private void MsgBox_Load(object sender, EventArgs e)
        {
            this.label_Err.ForeColor = strForeColor;
            this.label_Err.Text = ShowStr;
            EventShowErr += new dele_ShowErr(MsgBox_EventShowErr);
            ContinueCountDown.Set();
        }

        private void MsgBox_EventShowErr(string str)
        {
            if (this.label_Err.InvokeRequired)
            {
                this.label_Err.Invoke((EventHandler)delegate
                {
                    this.label_Err.Text = str;
                });
            }
            else this.label_Err.Text = str;
        }

        /// <summary>
        /// 启动倒计时方法
        /// </summary>
        /// <param name="InitialValue">倒计时初始值</param>
        private void CountDown(int InitialValue)
        {
            try
            {
                ContinueCountDown.WaitOne();
                while (InitialValue-- > 0)
                {
                    if (this.btn_OK.InvokeRequired)
                    {
                        this.btn_OK.Invoke((EventHandler)delegate { this.btn_OK.Text = "OK(" + InitialValue + ")"; });
                    }
                    else this.btn_OK.Text = "OK(" + InitialValue + ")";
                    Thread.Sleep(1000);
                }
            }
            catch (Exception xe)
            {
                ;
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void MsgBox_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        #region 关闭窗口
        [DllImport("user32.dll", EntryPoint = "FindWindow", CharSet = CharSet.Auto)]
        private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int PostMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        public const int WM_CLOSE = 0x10;
        private void KillMessageBox()
        {
            //按照MessageBox的标题，找到MessageBox的窗口
            IntPtr ptr = FindWindow(null, "提示");
            if (ptr != IntPtr.Zero)
            {
                //找到则关闭MessageBox窗口
                PostMessage(ptr, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
            }
        }
        #endregion
    }
}
