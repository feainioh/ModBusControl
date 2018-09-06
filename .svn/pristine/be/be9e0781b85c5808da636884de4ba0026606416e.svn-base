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
    public partial class AxisPeel : AxisInterface
    {
        public AxisPeel()
        {
            InitializeComponent();
            WindowRefresh.Tick += new EventHandler(WindowRefresh_Tick);
        }

        private void WindowRefresh_Tick(object sender, EventArgs e)
        {
            Console.WriteLine(this.m_AxisName.ToString() + "子窗体刷新");
            UpdateValue();
        }

        private void UpdateValue()
        {  
            double DotPeelSpeed = GlobalVar.c_Modbus.HoldingRegisters.AxisPeel_Speed.Value;
            DotPeelSpeed /= GlobalVar.ConverRate;

            this.textBox_MoveSpeed.Text = DotPeelSpeed.ToString("#0.00");
        }

    }
}
