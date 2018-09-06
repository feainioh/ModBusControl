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
    [ToolboxItem(false)]
    public partial class AxisCarry : AxisInterface
    {
        public AxisCarry()
        {
            InitializeComponent();
            WindowRefresh.Tick += new EventHandler(WindowRefresh_Tick);
        }

        private void AxisCarry_Load(object sender, EventArgs e)
        {
            base.axisTrackBar.AxisMaxValue = INIFileValue.CarryAxisRange.MAX * GlobalVar.ConverRate_Carry;
            base.axisTrackBar.AxisMinValue = INIFileValue.CarryAxisRange.MIN * GlobalVar.ConverRate_Carry;
        }

        private void WindowRefresh_Tick(object sender, EventArgs e)
        {
            Console.WriteLine(this.m_AxisName.ToString() + "子窗体刷新");
            UpdateValue();
        }

        private void UpdateValue()
        {
            double CarryAxisFeedPosition = GlobalVar.c_Modbus.HoldingRegisters.AxisCarry_FeedLocation.Value;
            CarryAxisFeedPosition /= GlobalVar.ConverRate_Carry;
            double CarryAxisBlankPosition = GlobalVar.c_Modbus.HoldingRegisters.AxisCarry_BlankLocation.Value;
            CarryAxisBlankPosition /= GlobalVar.ConverRate_Carry;

            this.textBox_CarryAxisFeedPosition.Text = CarryAxisFeedPosition.ToString("#0.00");
            this.textBox_CarryAxisBlankPosition.Text = CarryAxisBlankPosition.ToString("#0.00");
        }

        private void textBox_CarryAxisFeedPosition_Click(object sender, EventArgs e)
        {
            ChangePLCValue(sender, GlobalVar.c_Modbus.HoldingRegisters.AxisCarry_FeedLocation, 2, this.axisTrackBar.AxisMaxValue, this.axisTrackBar.AxisMinValue);
        }

        private void textBox_CarryAxisBlankPosition_Click(object sender, EventArgs e)
        {
            ChangePLCValue(sender, GlobalVar.c_Modbus.HoldingRegisters.AxisCarry_BlankLocation, 2, this.axisTrackBar.AxisMaxValue, this.axisTrackBar.AxisMinValue);
        }        
    }
}
