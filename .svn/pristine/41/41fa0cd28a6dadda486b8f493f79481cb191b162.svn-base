using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ECInspect.MyControl
{
    public partial class AxisCCD : AxisInterface
    {
        public AxisCCD()
        {
            InitializeComponent();
            WindowRefresh.Tick += new EventHandler(WindowRefresh_Tick);
        }

        private void textBox_DotAxisWaitMarkPoint_Click(object sender, EventArgs e)
        {
           
            double d = 0d;
            if (TextClick(sender, ref d, 2, (double)INIFileValue.CCDAxisRange.MAX, (double)INIFileValue.CCDAxisRange.MIN))
            {
                this.textBox_CCDAxisWaitCenterPhotoPosition.Text = d.ToString();
                int Rate = 640;
                double Location = d + INIFileValue.Product_MARK_X_STD;
                GlobalVar.c_Modbus.AddMsgList(GlobalVar.c_Modbus.HoldingRegisters.CCD_TargetPoint, (int)(Location * Rate));
                myFunction.WriteIniString(INIFileValue.gl_inisection_CCDOrigin, INIFileValue.gl_iniKey_CCDOrigin_X, this.textBox_CCDAxisWaitCenterPhotoPosition.Text);
                GlobalVar.gl_origin_X = d;
            }
        }

        private void AxisCCD_Load(object sender, EventArgs e)
        {
            base.axisTrackBar.AxisMaxValue = INIFileValue.CCDAxisRange.MAX * 640;
            base.axisTrackBar.AxisMinValue = INIFileValue.CCDAxisRange.MIN * 640;
            if (GlobalVar.CCDEnable)
            {
                this.groupBoxEx_CCD.Visible = true;
                this.label_Dis.Text = string.Format("{0} =", INIFileValue.Product_MARK_X_STD);
            }
        }
        private void WindowRefresh_Tick(object sender, EventArgs e)
        {
            Console.WriteLine(this.m_AxisName.ToString() + "子窗体刷新");
            UpdateValue();
        }
        private void UpdateValue()
        {

            double CCDAxisWaitMarkPoint = GlobalVar.c_Modbus.HoldingRegisters.CCD_TargetPoint.Value;
            CCDAxisWaitMarkPoint *= GlobalVar.ConverRate_CCD;

            this.textBox_XAxisPhotoPosition.Text = CCDAxisWaitMarkPoint.ToString("#0.00");
            this.textBox_CCDAxisWaitCenterPhotoPosition.Text = GlobalVar.gl_origin_X.ToString("#0.00");
        }
    }   
}
