using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;

namespace UpdateTool
{
    public partial class Main : Form
    {
        /// <summary>
        /// U盘更新程序目录
        /// </summary>
        private const string UDrive_UpdatePath = "EC_Update";
      
        string Update_filepath = string.Empty;//复制到文件路径

        [StructLayout(LayoutKind.Sequential)]
        public struct DEV_BROADCAST_VOLUME
        {
            public int dbcv_size;
            public int dbcv_devicetype;
            public int dbcv_reserved;
            public int dbcv_unitmask;
        }

        private delegate void dele_RichTexBoxAppendStr(string str);
        private event dele_RichTexBoxAppendStr EventAppendStr;
        protected string _showstr = string.Empty;
        /// <summary>
        /// 显示字符串（richTextBox显示用）
        /// </summary>
        private string ShowStr
        {
            set 
            {
                _showstr = value;
                if (EventAppendStr != null) EventAppendStr(_showstr);
            }
            get { return _showstr; }
        }

        NotifyIcon notifyIcon = new NotifyIcon();//最小化图标
        ContextMenuStrip context = new ContextMenuStrip();//右键菜单

        /// <summary>
        /// 插入U盘后，启动该程序，关闭需要更新的程序，
        /// 复制文件到指定位置，完成升级更新（升级）后，启动更新的程序
        /// </summary>
        public Main()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;//使Form不在任务栏上显示
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.notifyIcon.Icon = Properties.Resources.update;
            this.notifyIcon.Visible = true;//在通知区显示Form的Icon
            ToolStripMenuItem toolstrip = new ToolStripMenuItem();//子菜单
            toolstrip.Text = "退出";
            toolstrip.Click += new EventHandler(toolstrip_Click);
            context.Items.Add(toolstrip);
            notifyIcon.ContextMenuStrip = context;
            notifyIcon.MouseClick += new MouseEventHandler(notifyIcon_MouseClick);

            EventAppendStr += new dele_RichTexBoxAppendStr(Main_EventAppendStr);
            Update_filepath = AppDomain.CurrentDomain.BaseDirectory;
            if (U_DriveAlreadyIN()!= string.Empty)
            {
                Main_EventAppendStr("检测更新U盘已经插入");

                Thread startcopy = new Thread(new ThreadStart(delegate
                {
                    CopyAllFiles(Update_filepath);
                }));
                startcopy.IsBackground = true;
                startcopy.Start();
                    
            }
        }

        private void toolstrip_Click(object sender, EventArgs e)
        {
            this.Close();
        }        

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Show();
            }
        }

        protected override void WndProc(ref Message m)
        {
            // 发生设备变动
            const int WM_DEVICECHANGE = 0x0219;
            // 系统检测到一个新设备
            const int DBT_DEVICEARRIVAL = 0x8000;
            // 系统完成移除一个设备
            const int DBT_DEVICEREMOVECOMPLETE = 0x8004;
            // 逻辑卷标
            const int DBT_DEVTYP_VOLUME = 0x00000002;

            switch (m.Msg)
            {
                case WM_DEVICECHANGE:
                    switch (m.WParam.ToInt32())
                    {
                        case DBT_DEVICEARRIVAL:
                            int devType = Marshal.ReadInt32(m.LParam, 4);
                            if (devType == DBT_DEVTYP_VOLUME)
                            {
                                DEV_BROADCAST_VOLUME vol;
                                vol = (DEV_BROADCAST_VOLUME)Marshal.PtrToStructure(
                                    m.LParam, typeof(DEV_BROADCAST_VOLUME));
                                Main_EventAppendStr("插入U盘");
                                CopyAllFiles(Update_filepath);
                                //MessageBox.Show("插入U盘");//vol.dbcv_unitmask.ToString("x"));
                            }
                            break;
                        case DBT_DEVICEREMOVECOMPLETE:
                            Main_EventAppendStr("U盘退出");
                            ShowStr = "关闭升级程序，启动主程序";
                            notifyIcon.ShowBalloonTip(1000, "EC", "U盘退出\r\n请拔出U盘", ToolTipIcon.Info);
                            Thread ReadyToClose = new Thread(new ThreadStart(delegate
                                {
                                    Thread.Sleep(1000);
                                    System.Diagnostics.Process p = new System.Diagnostics.Process();
                                    p.StartInfo.FileName = Application.StartupPath + @"\ECInspect";
                                    p.Start();
                                    Environment.Exit(100);
                                }));
                            ReadyToClose.IsBackground = true;
                            ReadyToClose.Start();               
                            //MessageBox.Show("U盘退出");
                            break;
                    }
                    break;
            }
            base.WndProc(ref m);
        }

        /// <summary>
        /// 启动程序时，判断插入U盘是否包含更新目录
        /// </summary>
        /// <returns>U盘更新目录存在，则返回字符串，否则返回Empty</returns>
        public string U_DriveAlreadyIN()
        {
            List<string> u_Drive = new List<string>();
            DriveInfo[] info = DriveInfo.GetDrives();
            string path = string.Empty;
            foreach (DriveInfo d in info)
            {
                if (d.DriveType == DriveType.Removable)
                {
                    u_Drive.Add(d.Name);
                }
            }
            for (int i = 0; i < u_Drive.Count; i++)
            {
                u_Drive[i] = u_Drive[i] + UDrive_UpdatePath;
                if (Directory.Exists(u_Drive[i]))
                {
                    path = u_Drive[i];
                    break;
                }
            }
            return path;
        }

        private void CopyAllFiles(string remotepath)
        {
            notifyIcon.ShowBalloonTip(1000, "EC", "升级中···", ToolTipIcon.Info);
            try
            {
                List<string> u_Drive = new List<string>();
                DriveInfo[] info = DriveInfo.GetDrives();
                foreach (DriveInfo d in info)
                {
                    if (d.DriveType == DriveType.Removable)
                    {
                        u_Drive.Add(d.Name);
                    }
                }
                for (int i = 0; i < u_Drive.Count; i++)
                {
                    u_Drive[i] = u_Drive[i] + UDrive_UpdatePath;
                    if (!Directory.Exists(u_Drive[i])) u_Drive.RemoveAt(i);
                }
                string sourcepath = string.Empty; ;
                if (Directory.Exists(u_Drive[0]))
                {
                    sourcepath = u_Drive[0];
                    ShowStr = "u盘复制文件路径：" + sourcepath;
                    ShowStr = "更新文件路径:" + Update_filepath;
                }
                else
                {
                    ShowStr = "U盘路径丢失";
                    return;
                }
                copy(sourcepath, Update_filepath);
                ShowStr = "文件复制完毕\r\n等待U盘退出";
                for (int i = 5; i > 0; i--)
                {
                    ShowStr = string.Format("倒计时：{0}秒",i);
                    Thread.Sleep(1000);
                }
                //MessageBox.Show("点击退出U盘");
                #region U盘退出
                UsbEject.VolumeDeviceClass volumeDeviceClass = new UsbEject.VolumeDeviceClass();
                foreach (UsbEject.Volume device in volumeDeviceClass.Devices)
                {
                    // is this volume on USB disks?  
                    if (!device.IsUsb)
                        continue;

                    // is this volume a logical disk?  
                    if ((device.LogicalDrive == null) || (device.LogicalDrive.Length == 0))
                        continue;

                    device.Eject(true); // allow Windows to display any relevant UI  
                }
                ShowStr = "U盘退出";
                notifyIcon.ShowBalloonTip(1000, "EC", "升级完毕\r\n可以拔出U盘", ToolTipIcon.Info);
                #endregion
            }
            catch (Exception ex)
            {
                ShowStr = ex.Message;
            }
            finally
            {
                
            }
        }

        /// <summary>
        /// 复制文件
        /// </summary>
        /// <param name="sourcepath">源文件夹</param>
        /// <param name="remotepath">目的文件夹</param>
        private void copy(string sourcepath, string remotepath)
        {
            if (!Directory.Exists(remotepath))//先判断是否为路径，如果是路径则创建，是文件夹则过去
            {
                Directory.CreateDirectory(remotepath);
            }
            string[] files = Directory.GetFiles(sourcepath);
            List<string> ListFile = new List<string>();
            ListFile.AddRange(files);
            
            while (ListFile.Count > 0)
            {
                string file = ListFile[0];
                if (File.Exists(file))
                {
                    try
                    {
                        File.Copy(file, remotepath + @"\" + Path.GetFileName(file), true);
                        ShowStr = Path.GetFileName(file) + "\t复制成功";
                        ListFile.RemoveAt(0);
                    }
                    catch (Exception ex)
                    {
                        int waittime = 10;
                        ShowStr = Path.GetFileName(file) + "\t复制失败\r\n等待" + waittime + "毫秒继续复制";
                        Thread.Sleep(waittime);
                    }
                }
            }    

            string[] dirs = Directory.GetDirectories(sourcepath);
            foreach (string dir in dirs)
            {
                copy(dir, remotepath + @"\" + Path.GetFileName(dir));
            }
        }


        private void Main_EventAppendStr(string str)
        {
            if (richTextBox_Process.InvokeRequired)
            {
                this.richTextBox_Process.BeginInvoke((EventHandler)delegate { this.richTextBox_Process.AppendText(str+"\r\n");});
            }
            else this.richTextBox_Process.AppendText(str + "\r\n");
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon.Visible = false;//无效
            notifyIcon.Dispose();
        }
        
    }
}
