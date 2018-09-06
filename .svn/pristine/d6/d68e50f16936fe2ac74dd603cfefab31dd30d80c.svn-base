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
    [ToolboxItem(false)]
    public partial class AxisX : AxisInterface
    {
        public AxisX()
        {
            InitializeComponent();
            WindowRefresh.Tick += new EventHandler(WindowRefresh_Tick);
        }

        private void AxisX_Load(object sender, EventArgs e)
        {
            base.axisTrackBar.AxisMaxValue = INIFileValue.DotAxisRange.MAX * GlobalVar.ConverRate;
            base.axisTrackBar.AxisMinValue = INIFileValue.DotAxisRange.MIN * GlobalVar.ConverRate;
        }

        private void WindowRefresh_Tick(object sender, EventArgs e)
        {
            Console.WriteLine(this.m_AxisName.ToString() + "子窗体刷新");
            UpdateValue();
        }

        private void UpdateValue()
        {
            double XAxisAssemblePoint = GlobalVar.c_Modbus.HoldingRegisters.AxisX_AssemblyLocation.Value;
            XAxisAssemblePoint /=GlobalVar.ConverRate;

            this.textBox_XAxis_AssemblyPosition.Text = XAxisAssemblePoint.ToString("#0.00");
        }

        private void textBox_XAxis_AssemblyPosition_Click(object sender, EventArgs e)
        {
            ChangePLCValue(sender, GlobalVar.c_Modbus.HoldingRegisters.AxisX_AssemblyLocation, 2, this.axisTrackBar.AxisMaxValue / GlobalVar.ConverRate, this.axisTrackBar.AxisMinValue / GlobalVar.ConverRate);
        }

    }
}
