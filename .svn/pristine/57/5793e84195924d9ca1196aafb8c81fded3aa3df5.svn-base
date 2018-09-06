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
    public partial class BadStatisticsForm : Frame
    {
        public BadStatisticsForm()
        {
            InitializeComponent();
        }

        private void BadStatisticsForm_Load(object sender, EventArgs e)
        {
            ShowSheet();
            this.btn_Clear.Focus();
        }
        
        /// <summary>
        /// 显示统计信息
        /// </summary>
        private void ShowSheet()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => { ShowSheet(); }));
            }
            else
            {
                #region Sheet统计信息
                this.textBox_SheetProdcutTestNum.Text = INIFileValue.ProductTestNum.ToString();
                this.textBox_SheetProductQualifieNum.Text = INIFileValue.ProductQualifiedNum.ToString();
                this.textBox_SheetProductUnQualifieNum.Text = INIFileValue.ProductUnQualifidNUm.ToString();
                this.textBox_SheetProdutOpen.Text = INIFileValue.ProductOpen.ToString();
                this.textBox_SheetProductShort.Text = INIFileValue.ProductShort.ToString();
                this.textBox_SheetOffsetM.Text = INIFileValue.ProductOffsetM.ToString();
                this.textBox_SheetOffsetN.Text = INIFileValue.ProductOffsetN.ToString();
                this.textBox_SheetForgetPaste.Text = INIFileValue.ProductForgetPaste.ToString();
                this.textBox_SheetPressCount.Text = INIFileValue.ProductPressCount.ToString();
                #endregion
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            MsgBox box = new MsgBox(MessageBoxButtons.YesNo);
            box.Title = "提示";
            box.ShowText = "是否清零统计数据？";
            box.BackColor = Color.LimeGreen;
            if (box.ShowDialog() == DialogResult.OK)
            {
                INIFileValue.ProductTestNum
                = INIFileValue.ProductQualifiedNum
                = INIFileValue.ProductUnQualifidNUm
                = INIFileValue.ProductOpen
                = INIFileValue.ProductShort
                = INIFileValue.ProductOffsetM
                = INIFileValue.ProductOffsetN
                = INIFileValue.ProductForgetPaste
                = INIFileValue.ProductPressCount = 0;

                ShowSheet();
            }
        }
    }
}
