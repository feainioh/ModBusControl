using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ECInspect
{
    public partial class RevBarcodeGunScan : UserControl
    {
        private Logs log = Logs.LogsT();
        private Color Default_BackColor = SystemColors.InactiveCaption;//默认的背景色

        public delegate void dele_UpdatePcsBarcode(string barcode);
        public event dele_UpdatePcsBarcode Event_Update_PcsBarcode;//更新Pcs条码
        public delegate void dele_UpdateBackColor(Color backcolor);
        public event dele_UpdateBackColor Event_Update_BackColor;//更新背景色

        private string _Barcode = string.Empty;
        /// <summary>
        /// 扫描的条码
        /// </summary>
        public string Barcode { get { return _Barcode; } }

        public RevBarcodeGunScan()
        {
            InitializeComponent();

            this.textBox_Barcode.GotFocus += new EventHandler(textBox_Barcode_GotFocus);
            this.textBox_Barcode.LostFocus += new EventHandler(textBox_Barcode_LostFocus);
        }

        private void textBox_Barcode_GotFocus(object sender, EventArgs e)
        {
            if (this.label_ScanGif.Image != Properties.Resources.BarcodeGunRun)
                this.label_ScanGif.Image = Properties.Resources.BarcodeGunRun;
        }

        private void textBox_Barcode_LostFocus(object sender, EventArgs e)
        {
            if (this.label_ScanGif.Image != Properties.Resources.BarcodeGunStop)
                this.label_ScanGif.Image = Properties.Resources.BarcodeGunStop;
        }

        private void RevBarcodeGunScan_Load(object sender, EventArgs e)
        {
            //this.maskedTextBox_BarcodeLenghth.Text = GlobalVar.BarcodeLength.ToString();
            this.ActiveControl = this.textBox_Barcode;
        }

        private void textBox_Barcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                TextBox tb = (TextBox)sender;
                tb.SelectAll();

                //bool LengthRight = tb.TextLength == GlobalVar.BarcodeLength;
                //log.AddCommLOG(string.Format("本次扫描：{0}\t条码长度是否满足要求:{1}",tb.Text,LengthRight));
                //if (!LengthRight)
                //{
                //    tb.Text = string.Empty;
                //    return;//不满足要求的条码则清空条码
                //}

                GlobalVar.gl_Barcode=this._Barcode = tb.Text;
                UpdateBarcode(tb.Text);
                GlobalVar.c_Modbus.CoilMsgSync(GlobalVar.c_Modbus.Coils.BarocodeReady, true);
                this.Visible = false;
            }
        }

        /// <summary>
        /// 更新Pcs条码的事件
        /// </summary>
        /// <param name="Barcode">条码</param>
        private void UpdateBarcode(string Barcode)
        {
            if (this.Event_Update_PcsBarcode != null) this.Event_Update_PcsBarcode(Barcode);
        }

        /// <summary>
        /// 更新背景色
        /// </summary>
        /// <param name="color">颜色</param>
        private void UpdateBackColor(Color color)
        {
            if (this.Event_Update_BackColor != null) this.Event_Update_BackColor(color);
        }

        /// <summary>
        /// 显示异常信息
        /// </summary>
        /// <param name="errstr">异常信息字符串</param>
        /// <param name="CountDown">倒计时</param>
        private DialogResult ErrMsg(string errstr, int CountDown = -1)
        {
            log.AddERRORLOG(string.Format("【接收条码枪异常 弹框】\t" + errstr));
            MsgBox msgbox = new MsgBox();
            msgbox.ShowText = errstr;           
            msgbox.TopMost = true;
            return msgbox.ShowDialog();
        }

        /// <summary>
        /// 清空
        /// </summary>
        public void ClearAll()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(delegate { ClearAll(); }));
            }
            else
            {
                this._Barcode = string.Empty;
                this.label_BarcodeInfo.Text = "----";
                this.textBox_Barcode.Text = string.Empty;
                this.textBox_Barcode.Focus();
            }
        }

        private void maskedTextBox_BarcodeLenghth_TextChanged(object sender, EventArgs e)
        {
            //if (byte.TryParse(this.maskedTextBox_BarcodeLenghth.Text, out GlobalVar.BarcodeLength))
            //{
            //    myFunction.WriteIniString(GlobalVar.gl_inisection_Barcode, GlobalVar.gl_iniKey_BarcodeLength, GlobalVar.BarcodeLength.ToString());
            //}
            //else ErrMsg(GlobalVar.SoftWareTextContent.BarcodeLengthErr, 5);
        }
    }
}
