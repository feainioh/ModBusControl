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
    /// <summary>
    /// 主窗体上显示的测试小框[不在工具栏显示]
    /// </summary>
    [ToolboxItem(false)]
    public partial class TestPanel : UserControl
    {
        #region 属性窗口
        /// <summary>
        /// 显示的字符串
        /// </summary>
        [Category("自定义属性"),Browsable(true),Description("小框显示的信息")]
        public string ShowText
        {
            get { return this.label_Show.Text; }
            set
            {
                this.label_Show.Text = value;
            }
        }

        /// <summary>
        /// 设置文本的字体
        /// </summary>
        internal Font TextFont
        {
            set { this.label_Show.Font = value; }
            get { return this.label_Show.Font; }
        }

        /// <summary>
        /// 背景色
        /// </summary>
        [Category("自定义属性"), Browsable(false)]
        public Color PanelBackColor
        {
            set { this.groupBoxEx1.BackColor = value; }
        }
        
        #endregion
        
        public TestPanel()
        {
            InitializeComponent();
        }
        public TestPanel(int Width, int Height)
        {
            InitializeComponent();
            this.Size = new Size(Width, Height);
        }

        private void TestPanel_Load(object sender, EventArgs e)
        {

        }

        private void label_Show_Click(object sender, EventArgs e)
        {
            return;
            if (!this.label_Show.Font.Underline) this.label_Show.Font = new Font(this.label_Show.Font, FontStyle.Bold | FontStyle.Underline);
            else this.label_Show.Font = new Font(this.label_Show.Font, FontStyle.Bold);
            //MessageBox.Show(string.Format("Color:{0}\tText:{1}", this.groupBoxEx1.BackColor, this.label_Show.Text));
            this.Invalidate();
        }
    }
}
