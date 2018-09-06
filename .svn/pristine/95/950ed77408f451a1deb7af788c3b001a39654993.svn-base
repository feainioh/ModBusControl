using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ECInspect
{
    public partial class MsgBox : Form
    {
        /// <summary>
        /// 获取窗体是否已经显示
        /// </summary>
        internal static bool IsShow { get { return m_IsShow; } }
        /// <summary>
        /// 是否已经显示【已经显示，则忽略后续的】
        /// </summary>
        private static bool m_IsShow = false;
        /// <summary>
        /// 是否取消显示
        /// </summary>
        private bool Cancel = false;

        /// <summary>
        /// 显示的标题
        /// </summary>
        internal string Title
        {
            set { this.label_Title.Text = value; }
        }

        /// <summary>
        /// 显示的字符串
        /// </summary>
        internal string ShowText
        {
            set { this.label_Content.Text = value; }
        }

        internal Color BackColor
        {
            set { this.groupBoxEx1.BackColor = value; }
        }

        /// <summary>
        /// 需要判断的线圈
        /// </summary>
        private Coil m_Coil = null;
        /// <summary>
        /// 需要判断线圈的值
        /// </summary>
        private bool m_CoilValue = false;

        /// <summary>
        /// 检查是否已经显示，已经显示则返回取消
        /// </summary>
        private void CheckIsShow()
        {
            if (m_IsShow) this.Cancel = true; ;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ConfirmBtnText">确定按钮字符串</param>
        /// <param name="btn"></param>
        public MsgBox(string ConfirmBtnText)
        {
            InitializeComponent();

            this.btn_Confirm.Text = ConfirmBtnText;
            this.btn_Confirm.Location = new Point((this.Width - this.btn_Confirm.Width) / 2, this.btn_Confirm.Location.Y);
            this.btn_Cancel.Visible = false;

            CheckIsShow();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="BtnText">确定按钮字符串</param>
        /// <param name="CancelBtnText">取消按钮字符串</param>
        public MsgBox(string ConfirmBtnText, string CancelBtnText)
        {
            InitializeComponent();

            this.btn_Confirm.Text = ConfirmBtnText;
            this.btn_Cancel.Text = CancelBtnText;

            CheckIsShow();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="btn">按钮</param>
        public MsgBox(MessageBoxButtons btn = MessageBoxButtons.OK)
        {
            InitializeComponent();

            switch (btn)
            {
                case MessageBoxButtons.OK:
                    this.btn_Confirm.Text = "确认";
                    this.btn_Confirm.Location = new Point((this.Width - this.btn_Confirm.Width) / 2, this.btn_Confirm.Location.Y);
                    this.btn_Cancel.Visible = false;
                    break;
                case MessageBoxButtons.YesNo:

                    break;
            }

            CheckIsShow();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="coil">线圈</param>
        /// <param name="value">线圈判断的值</param>
        /// <param name="btn">按钮</param>
        internal MsgBox(Coil coil, bool value, MessageBoxButtons btn = MessageBoxButtons.OK)
        {
            InitializeComponent();

            this.m_Coil = coil;
            this.m_CoilValue = value;

            switch (btn)
            {
                case MessageBoxButtons.OK:
                    this.btn_Confirm.Text = "确认";
                    this.btn_Confirm.Location = new Point((this.Width - this.btn_Confirm.Width) / 2, this.btn_Confirm.Location.Y);
                    this.btn_Cancel.Visible = false;
                    break;
                case MessageBoxButtons.YesNo:

                    break;
            }

            CheckIsShow();
        }

        private void MsgBox_Load(object sender, EventArgs e)
        {
            m_IsShow = true;
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (GlobalVar.c_Modbus != null && !GlobalVar.c_Modbus.Coils.StartLeft.Value) return;
            if (this.m_Coil != null && this.m_Coil.Value != this.m_CoilValue) return;

            this.DialogResult = DialogResult.OK;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (GlobalVar.c_Modbus != null && !GlobalVar.c_Modbus.Coils.StartLeft.Value) return;

            this.DialogResult = DialogResult.Cancel;
        }

        private void MsgBox_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!Cancel) m_IsShow = false;
        }

        private void MsgBox_Shown(object sender, EventArgs e)
        {
            if (Cancel) this.DialogResult = DialogResult.Cancel;
        }
    }
}
