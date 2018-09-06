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
    public partial class MarkChangeSetForm : Frame
    {
        public MarkChangeSetForm()
        {
            InitializeComponent();
        }

        private void MarkChangeSetForm_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Yellow;

            #region 初始化值
            this.textBox_AlarmTimeInterval.Text = INIFileValue.AlarmIntervalDay.ToString();
            this.textBox_AlarmStartHour.Text = INIFileValue.AlarmHour.ToString();
            this.textBox_AlarmStartMinute.Text = INIFileValue.AlarmMinute.ToString();
            this.textBox_ResidualTime.Text = INIFileValue.ProductMarkLeftTime.ToString();
            this.textBox_MarkTotalCount.Text = INIFileValue.MarkTotalCount.ToString();
            this.textBox_MarkCountLeft.Text = (INIFileValue.MarkTotalCount - INIFileValue.MarkCount).ToString();
            #endregion
        }

        private void MarkChangeSetForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MsgBox box = new MsgBox(MessageBoxButtons.YesNo);
            box.Title = "保存";
            box.ShowText = "打标器更换设定值是否保存";
            box.BackColor = Color.LimeGreen;
            if (box.ShowDialog() == DialogResult.OK)
            {
                INIFileValue.AlarmIntervalDay = Convert.ToInt16(this.textBox_AlarmTimeInterval.Text);
                INIFileValue.AlarmHour = Convert.ToInt16(this.textBox_AlarmStartHour.Text);
                INIFileValue.AlarmMinute = Convert.ToInt16(this.textBox_AlarmStartMinute.Text);
                INIFileValue.MarkTotalCount = Convert.ToInt32(this.textBox_MarkTotalCount.Text);
                INIFileValue.MarkCount = 0;//清零
                INIFileValue.MarkChangeTime = DateTime.Now;

                myFunction myfunction = new myFunction();
                myfunction.SaveSheet();
            }
        }

        /// <summary>
        /// 文本框点击
        /// </summary>
        /// <param name="sender">文本框</param>
        /// <param name="Value">值</param>
        /// <param name="DecimalDigits">小数位数</param>
        /// <param name="Max">最大值</param>
        /// <param name="Min">最小值</param>
        /// <returns></returns>
        private bool TextClick(object sender, ref double Value, int DecimalDigits = 1, double Max = 999d, double Min = 0d)
        {
            try
            {
                this.WindowRefresh.Stop();

                TextBox tb = (TextBox)sender;
                //鼠标相对于屏幕的坐标
                Point p1 = MousePosition;
                //鼠标相对于窗体的坐标
                Point p2 = this.PointToClient(p1);

                Keyboard keyboard = new Keyboard(p1, Max, Min, DecimalDigits);
                if (keyboard.ShowDialog() == DialogResult.OK)
                {
                    Value = (double)keyboard.RealValue;
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                this.WindowRefresh.Start();
            }
        }

        private void textBox_AlarmTimeInterval_Click(object sender, EventArgs e)
        {
            double d = 0d;
            if (TextClick(sender, ref d, 0, 99, 1))
            {
                this.textBox_AlarmTimeInterval.Text = d.ToString();
            }
        }

        private void textBox_AlarmStartHour_Click(object sender, EventArgs e)
        {
            double d = 0d;
            if (TextClick(sender, ref d, 0, 24, 0))
            {
                this.textBox_AlarmStartHour.Text = d.ToString();
            }
        }

        private void textBox_AlarmStartMinute_Click(object sender, EventArgs e)
        {
            double d = 0d;
            if (TextClick(sender, ref d, 0, 60, 1))
            {
                this.textBox_AlarmStartMinute.Text = d.ToString();
            }
        }

        private void textBox_MarkTotalCount_Click(object sender, EventArgs e)
        {
            double d = 0d;
            if (TextClick(sender, ref d, 0, 9999, 1))
            {
                this.textBox_MarkTotalCount.Text = d.ToString();
            }
        }

    }
}
