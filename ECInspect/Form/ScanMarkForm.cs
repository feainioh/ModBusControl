using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ECInspect
{
    public partial class ScanMarkForm : Frame
    {
        Thread regulate_TH ;      

        public ScanMarkForm()
        {
            InitializeComponent();
        }

        private void btn_MoveToScanPoint_Click(object sender, EventArgs e)
        {
            string barcode = "";
            if (GlobalVar.gl_Scan.StartScan( ref barcode)) textBox_Barcode.Text = barcode;
        }

        private void either_Scan_Event_BtnClick(object sender, LeftRightSide lr)
        {
            switch (lr)
            {
                case LeftRightSide.Left:
                    GlobalVar.c_Modbus.AddMsgList(GlobalVar.c_Modbus.Coils.ScanPosition, false);
                    break;
                case LeftRightSide.Right:
                    GlobalVar.c_Modbus.AddMsgList(GlobalVar.c_Modbus.Coils.ScanPosition, true);
                    break;
            }
        }

        private void btn_ScanPoint_Click(object sender, EventArgs e)
        {
            if (btn_ScanPoint.Text == "连续扫码")
            {
                regulate_TH = new Thread(regulator);
                regulate_TH.IsBackground = true;
                regulate_TH.Start();
                btn_ScanPoint.Text = "取消";
            }
            else
            {
                regulate_TH.Abort();
                btn_ScanPoint.Text = "连续扫码";
            }
            
        }

        private  void regulator()
        {
            string barcode = "";
            GlobalVar.gl_Scan.ScanForTest(ref barcode);
            this.BeginInvoke(new Action(() =>
            {
                textBox_Barcode.Text = barcode;
            }));
        }
    }
}
