using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ECInspect
{
    public partial class FilesSelect : Form
    {
        /// <summary>
        /// 根目录
        /// </summary>
        private string RootDIr = string.Empty;
        private string m_SelectedFile = string.Empty;
        /// <summary>
        /// 已经选择的文件
        /// </summary>
        internal string SelectedFile { get { return RootDIr + m_SelectedFile.Trim() + ".txt"; } }

        public FilesSelect()
        {
            InitializeComponent();
        }
        
        public FilesSelect(string [] files)
        {
            InitializeComponent();

            RefreshListView(files);
        }
        
        private void FilesSelect_Load(object sender, EventArgs e)
        {

        }

        private void btn_ReadUDisk_Click(object sender, EventArgs e)
        {
            try
            {
                myFunction myfunction = new myFunction();
                string[] files = new string[]{};
                string err = string.Empty;//异常信息
                if (!myfunction.Read_UDisk(ref files, ref err)) throw new Exception(err);
                RefreshListView(files);
            }
            catch (Exception ex)
            {
                ErrMsgBox(ex.Message);
            }        
        }

        /// <summary>
        /// 更换数据显示
        /// </summary>
        /// <param name="files"></param>
        private void RefreshListView(string[] files)
        {
            int Length = this.listView_Files.Width;

            this.listView_Files.Clear();
            this.listView_Files.BeginUpdate();
            foreach (string str in files)
            {
                string FileName = Path.GetFileNameWithoutExtension(str);
                listView_Files.Items.Add(new ListViewItem(FileName.PadRight(Length)));
                this.RootDIr = Directory.GetDirectoryRoot(str);
            }
            this.listView_Files.EndUpdate();
        }

        /// <summary>
        /// 异常弹框
        /// </summary>
        /// <param name="errmsg">异常内容</param>
        /// <param name="title">异常标题</param>
        /// <returns></returns>
        private DialogResult ErrMsgBox(string errmsg, string title = "异常")
        {
            MsgBox box = new MsgBox();
            box.Title = title;
            box.ShowText = errmsg;
            return box.ShowDialog();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (this.listView_Files.SelectedItems.Count == 0) return;

            this.m_SelectedFile = this.listView_Files.SelectedItems[0].Text;

            this.DialogResult = DialogResult.OK;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
