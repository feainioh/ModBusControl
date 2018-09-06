using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace ECInspect
{
    //测试使用的窗口
    public partial class COMM_EC : Form
    {
        private Logs log = Logs.LogsT();

        public COMM_EC()
        {
            InitializeComponent();
        }

        private void COMM_EC_Load(object sender, EventArgs e)
        {
           
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            string str = this.textBox_Send.Text = this.textBox_Send.Text.Replace(" ", "").ToUpper();

            GlobalVar.m_ECTest.SendMsg(str);
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            GlobalVar.m_ECTest.Reset();
        }

        private void btn_Test_Click(object sender, EventArgs e)
        {

        }
    }
}
