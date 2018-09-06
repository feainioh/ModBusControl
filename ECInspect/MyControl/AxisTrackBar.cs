using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace ECInspect
{
    /// <summary>
    /// 轴
    /// </summary>
    [ToolboxItem(false)]
    public partial class AxisTrackBar : UserControl
    {
        #region 属性窗口
        private Axis m_AxisName = Axis.X;
        /// <summary>
        /// 名称
        /// </summary>
        [Category("自定义属性"), Browsable(true)]
        public Axis AxisName
        {
            get { return this.m_AxisName; }
            set 
            {
                this.m_AxisName = value;
                string name = string.Empty;
                switch (m_AxisName)
                { 
                    case Axis.Carry:
                        name = "搬运";
                        break;
                    case Axis.Dot:
                        name = "打点";
                        break;
                    case Axis.CCD:
                        name = "相机";
                        break;
                    default:
                        name = value.ToString();
                        break;
                }
                this.label_AxisName.Text = name + ":";
            }
        }

        /// <summary>
        /// 轴的实际位置【真实值*100】
        /// </summary>
        [Category("自定义属性"), Browsable(true), Description("轴的实际位置【不需要*100】")]
        public double AxisRealValue
        {
            get { return this.trackBar_Axis.Value; }
            set 
            {
                if (value > this.AxisMaxValue || value < this.AxisMinValue) throw new Exception("轴的实际值设置无效");
                int rate;
                if (this.m_AxisName == Axis.Carry) rate = GlobalVar.ConverRate_Carry;
                else rate = GlobalVar.ConverRate;

                this.trackBar_Axis.Value = Convert.ToInt32(value * rate);
                this.textBox_Axis.Text = value.ToString("#0.00");
            }
        }

        /// <summary>
        /// 轴的最大值【真实值*100】
        /// </summary>
        [Category("自定义属性"), Browsable(true), Description("轴的最大值【真实值*100】")]
        public int AxisMaxValue
        {
            get { return this.trackBar_Axis.Maximum; }
            set
            {
                if (value <= 0) throw new Exception("轴最大值设定无效");
                this.trackBar_Axis.Maximum = value;
            }
        }

        /// <summary>
        /// 轴的最小值【真实值*100】
        /// </summary>
        [Category("自定义属性"), Browsable(true), Description("轴的最小值【真实值*100】")]
        public int AxisMinValue
        {
            get { return this.trackBar_Axis.Minimum; }
            set
            {
                this.trackBar_Axis.Minimum = value;
            }
        }
        #endregion
        
        private Stopwatch AxisWatch = new Stopwatch();//拖动滑块时，定时刷新
        public delegate void dele_TextClick(object sender);//委托-文本框点击
        public event dele_TextClick Event_TextClick;
        public delegate void dele_AxisRun(double TargetPlace);//委托-轴运行到目的地
        public event dele_AxisRun Event_AxisRun;

        public AxisTrackBar()
        {
            InitializeComponent();
        }

        private void btn_Run_Click(object sender, EventArgs e)
        {
            AxisRun();
        }

        /// <summary>
        /// 轴运行
        /// </summary>
        private void AxisRun()
        {
            double target;
            if (double.TryParse(this.textBox_Axis.Text, out target))
            {
                Console.WriteLine("{0}\tMove To:{1}", DateTime.Now.ToString("HH:mm:ss:fff"), target);
                if (this.Event_AxisRun != null) this.Event_AxisRun(target);
            }
            else
            {
                MessageBox.Show("不是数字，无法执行");
            }
        }

        private void trackBar_Axis_Scroll(object sender, EventArgs e)
        {
            this.textBox_Axis.Text = (this.trackBar_Axis.Value * 0.001).ToString("#0.00");
            if (AxisWatch.ElapsedMilliseconds > 100)
            {
                AxisRun();
                AxisWatch.Restart();
            }
        }
       
        private void trackBar_Axis_MouseDown(object sender, MouseEventArgs e)
        {
            AxisWatch.Start();
            btn_Run.Enabled = false;
        }

        private void trackBar_Axis_MouseUp(object sender, MouseEventArgs e)
        {
            AxisWatch.Start();
            btn_Run.Enabled = true;
        }

        private void textBox_Axis_Click(object sender, EventArgs e)
        {
            if (this.Event_TextClick != null) this.Event_TextClick(sender);
        }
    }
}
