using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace ECInspect
{
    public partial class SystemForm : Frame
    {
        public SystemForm()
        {
            InitializeComponent();          
        }

        private void SystemForm_Load(object sender, EventArgs e)
        {
            myFunction myfunction = new myFunction();
            string ver = "当前版本:"+ myfunction.GetVersion();
            if (GlobalVar.PCSoftware != null && GlobalVar.PCSoftware.NeedUpdate) ver += "\r\n升级版本:" + GlobalVar.PCSoftware.Download_Ver;

            this.label_Ver.Text = ver;
            byte[] plcver = GlobalVar.c_Modbus.HoldingRegisters.PLCVer.GetByte();
            this.label_PLCVer.Text = "PLC版本:" + Encoding.Default.GetString(ModbusTool.WordTwo(plcver, 0, plcver.Length)).Trim('\0');
        }

        private void btn_ShutdownComputer_Click(object sender, EventArgs e)
        {
            if (!Password()) return;// 输入密码
            RunCMD("shutdown -s -t 0");
        }

        private void btn_RestartComputer_Click(object sender, EventArgs e)
        {
            if (!Password()) return;// 输入密码
            RunCMD("shutdown -r -t 0");
        }

        private void btn_Shutdown_Click(object sender, EventArgs e)
        {
            if (!GlobalVar.c_Modbus.Coils.StartLeft.Value) return;
            if (!Password()) return;// 输入密码

            GlobalVar.SoftWareShutDown = true;
            Environment.Exit(0);
        }

        private void RunCMD(string cmdorder)
        {
            if (!GlobalVar.c_Modbus.Coils.StartLeft.Value) return;

            Process myProcess = new Process();
            myProcess.StartInfo.FileName = "cmd.exe";
            myProcess.StartInfo.UseShellExecute = false;
            myProcess.StartInfo.RedirectStandardInput = true;
            myProcess.StartInfo.RedirectStandardOutput = true;
            myProcess.StartInfo.RedirectStandardError = true;
            myProcess.StartInfo.CreateNoWindow = true; myProcess.Start();
            myProcess.StandardInput.WriteLine(cmdorder);
        }


        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (GlobalVar.PCSoftware.NeedUpdate) GlobalVar.PCSoftware.PCUpdate();
        }
  
        private void btn_ICT_Click(object sender, EventArgs e)
        {
            try//增加密码--[2018.5.24 lqz]
            {
                if ((DateTime.Now - GlobalVar.LastEnterPassword).TotalMinutes > 3)
                {
                    if (!Password()) return;// 输入密码
                    GlobalVar.LastEnterPassword = DateTime.Now;
                }
                ShowFrame(ClickBtn.ICT);
            }
            catch { }
        }

        private void btn_PLC_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalVar.PLCWindow = true;
                if ((DateTime.Now - GlobalVar.LastEnterPassword).TotalMinutes > 3)
                {
                    if (!Password()) return;// 输入密码
                    GlobalVar.LastEnterPassword = DateTime.Now;
                }
                ShowFrame(ClickBtn.PLC, true);
            }
            catch (Exception ex)
            {
                ;
            }
            finally
            {
                GlobalVar.PLCWindow = false;
            }
        }

        /// <summary>
        /// 输入密码
        /// </summary>
        private bool Password()
        {
            using (Keyboard form = new Keyboard(true))
            {
                form.WindowState = FormWindowState.Maximized;
                form.TopLevel = false;
                form.Parent = this;
                form.MdiParent = this.MdiParent;
                if (form.ShowDialog() == DialogResult.OK) return true;
                else return false;
            }
        }

        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="cb">按钮</param>
        /// <param name="NeedPassword">是否需要密码</param>
        private void ShowFrame(ClickBtn cb, bool NeedPassword = false)
        {
            if (!NeedPassword && !GlobalVar.c_Modbus.Coils.StartLeft.Value) return;

            Frame form = null;
            switch (cb)
            {
                case ClickBtn.ICT:
                    form = new ICTForm();
                    break;
                case ClickBtn.PLC:
                    form = new PLCInterface();
                    break;
                default:
                    //默认窗口，测试用···
                    form = new Frame();
                    break;
            }
            form.TopLevel = false;
            form.Parent = this;
            form.MdiParent = this.MdiParent;
            form.ShowDialog();
        }
    }
}
