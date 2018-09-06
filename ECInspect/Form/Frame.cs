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
    public partial class Frame : Form
    {
        private float X; private float Y;

        /// <summary>
        /// 更新窗体数据的定时器
        /// </summary>
        protected Timer WindowRefresh = new Timer();

        public Frame()
        {
            InitializeComponent();

            //this.Resize += new EventHandler(Form_Resize);

            X = this.Width;
            Y = this.Height;
            setTag(this);


            this.Disposed += new EventHandler(AxisInterface_Disposed);

            WindowRefresh.Interval = GlobalVar.TimerInterval;
        }

        private void Frame_Load(object sender, EventArgs e)
        {
            foreach (var item in this.splitContainer.Panel1.Controls)//如果包含选择框，则将右下方的提示框显示出来
            {
                if (item is Either)
                {
                    this.panel_Explain.Visible = true;
                    break;
                }
            }
        }

        #region 字体大小随窗体变化
        private void setTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ":" + con.Height + ":" + con.Left + ":" + con.Top + ":" + con.Font.Size;
                if (con.Controls.Count > 0)
                    setTag(con);
            }
        }
        private void setControls(float newx, float newy, Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                string[] mytag = con.Tag.ToString().Split(new char[] { ':' });
                float a = Convert.ToSingle(mytag[0]) * newx;
                con.Width = (int)a;
                a = Convert.ToSingle(mytag[1]) * newy;
                con.Height = (int)(a);
                a = Convert.ToSingle(mytag[2]) * newx;
                con.Left = (int)(a);
                a = Convert.ToSingle(mytag[3]) * newy;
                con.Top = (int)(a);
                Single currentSize = Convert.ToSingle(mytag[4]) * newy;
                con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                if (con.Controls.Count > 0)
                {
                    setControls(newx, newy, con);
                }
            }
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            // throw new Exception("The method or operation is not implemented.");
            float newx = (this.Width) / X;
            //  float newy = (this.Height - this.statusStrip1.Height) / (Y - y);
            float newy = this.Height / Y;
            setControls(newx, newy, this);
            //this.Text = this.Width.ToString() +" "+ this.Height.ToString();

        }
        #endregion

        private void AxisInterface_Disposed(object sender, EventArgs e)
        {
            this.WindowRefresh.Stop();
        }

        private void btn_Return_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frame_Activated(object sender, EventArgs e)
        {
            StartRefresh();
            this.btn_Return.Focus();//聚焦此按钮，避免聚焦到其他控件
        }

        private void Frame_Deactivate(object sender, EventArgs e)
        {
            StopRefresh();
        }

        /// <summary>
        /// 开始刷新
        /// </summary>
        protected void StartRefresh()
        {
            this.WindowRefresh.Start();
        }

        /// <summary>
        /// 重置刷新，先停止然后开始刷新
        /// </summary>
        protected void ReStartRefresh()
        {
            this.WindowRefresh.Stop(); 
            this.WindowRefresh.Start();
        }

        /// <summary>
        /// 停止刷新
        /// </summary>
        protected void StopRefresh()
        {
            this.WindowRefresh.Stop();
        }

        /// <summary>
        /// 弹框【确认或者取消】
        /// </summary>
        /// <param name="text">内容</param>
        /// <param name="backcolor">背景色</param>
        /// <returns></returns>
        protected bool MsgBox(string text, Color backcolor, MessageBoxButtons btn)
        {
            MsgBox box = new MsgBox(btn);
            box.Title = "提示";
            box.ShowText = text;
            box.BackColor = backcolor;
            if (box.ShowDialog() == DialogResult.OK) return true;
            else return false;
        }
    }
}
