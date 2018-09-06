using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Euresys.Open_eVision_1_2;
using System.Threading;
using System.Collections;
using System.IO;
using System.Drawing.Drawing2D;

namespace ECInspect
{
    public partial class PicturePanelC : PictureBox
    {
        delegate void dele_showBmpDialog(Bitmap obj);

        public delegate void dele_SelectedType(PicType type);
        public event dele_SelectedType Event_SelectedType;//选中当前的块的类型

        private myFunction myfunc = new myFunction();
        public bool SizeNew = false;
        public bool SizeNewenter = false;
        public bool Moveenter = false;

        //测试信息变量
        public string m_product_type = "";
        public bool m_inAnalysis = false;  //判断是否解析完成
        public string m_decodeStr = "";    //解析条码
        public int m_AnalysisResult_barcode = -1;  //条码解析分析结果
        public int m_AnalysisResult_shape = -1;  //形状解析结果
        public PicType PaintType = PicType.ROI;
        private Image ParentImage = null;//需要截取的图片，来自于上一级窗体
        /// <summary>
        /// 忽略完成的图像
        /// </summary>
        public Bitmap DontCareImage { get { return m_DontCareImage; } }
        private Bitmap m_DontCareImage = null;//忽略的图像

        public PicturePanelC()
        {
            InitializeComponent();
            //bmp = new Bitmap(this.Width, this.Height);
            this.BackColor = Color.Transparent;
        }
        public PicturePanelC(Image img)
        {
            InitializeComponent();
            this.ParentImage = img;
            this.BackColor = Color.Transparent;
        }

        private void updatePictureBox(Bitmap bmp)
        {
            try
            {
                this.BackgroundImage = bmp;
                this.Refresh();
            }
            catch { }
        }
        private Bitmap GetValidAreaForAnalysis()
        {
            Bitmap bmp2 = new Bitmap(this.Width, this.Height);
            try
            {
                lock (GlobalVar.gl_bmp_TotalSheet)
                {
                    Bitmap _bmp2 = (Bitmap)GlobalVar.gl_bmp_TotalSheet.Clone();
                    bmp2 = myfunc.copyImage(_bmp2, PicX, PicY, Picwidth, Picheight);
                }
            }
            catch { }
            return bmp2;
        }
        #region 鼠标操作
        private void PicturePanelC_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_inAnalysis) { return; }
            try
            {
                if (SizeNewenter)
                {
                    if (e.X < 20 || e.Y < 20)  //不能无限缩小
                        return;
                    this.Width = e.X;
                    this.Height = e.Y;
                    this.Winwidth = this.Width;
                    this.Winheight = this.Height;
                    this.setPicturepoint(this.Parent.Height, this.Parent.Width);
                    this.paintRectangle();
                    this.Parent.Update();
                    return;
                }
                if (Moveenter)
                {
                    this.Location = new Point(this.Location.X + e.X - clickX, this.Location.Y + e.Y - clickY);   //移动panel  
                    this.WinX = this.Location.X;
                    this.WinY = this.Location.Y;
                    this.setPicturepoint(this.Parent.Height, this.Parent.Width);
                    this.paintRectangle();
                    this.Parent.Update();
                    return;
                }
                if (e.X > this.Width - 14 && e.X < this.Width && e.Y > this.Height - 14 && e.Y < this.Height) 
                {
                    this.Cursor = Cursors.SizeNWSE;   //鼠标移动到放大缩小边界
                    SizeNew = true;
                }
                else
                {
                    this.Cursor = Cursors.SizeAll;
                    SizeNew = false;
                }
            }
            catch { }
        }

        public int clickX = 0;  //按下的点坐标
        public int clickY = 0;
        private void PicturePanelC_MouseDown(object sender, MouseEventArgs e)
        {
            if (m_inAnalysis) { return; }
            try
            {
                if (SizeNew)  //如果在放大区域，则移动时控制放大缩小
                {
                    SizeNewenter = true;
                    return;
                }
                this.BringToFront();//多个PicturePanelC存在时，置顶当前选中的
                if (this.Event_SelectedType != null) this.Event_SelectedType(this.PaintType);
                Moveenter = true;
                clickX = e.X;
                clickY = e.Y;
            }
            catch { }
        }

        private void PicturePanelC_MouseUp(object sender, MouseEventArgs e)
        {
            if (m_inAnalysis) { return; }
            try
            {
                SizeNewenter = false;
                Moveenter = false;
                this.Cursor = Cursors.Default;
                RegionChange();
            }
            catch { }
        }
        #endregion

        #region 绘制解析区域

        public int PicX = 0;  //PictureBox中图片坐标
        public int PicY = 0;
        public int Picwidth = 0;
        public int Picheight = 0;
        public int WinX = 0;  //PictureBox相对坐标
        public int WinY = 0;
        public int Winwidth = 0;
        public int Winheight = 0;
        public int sequence = 0;
        public void setPicturepoint(int BoxH, int BoxW) //计算截图像素值
        {
            try
            {
                if (GlobalVar.gl_bmp_TotalSheet == null)
                    return;
                PicX = (int)((double)WinX / BoxW * GlobalVar.gl_bmp_TotalSheet.Width + 0.5);
                PicY = (int)((double)WinY / BoxH * GlobalVar.gl_bmp_TotalSheet.Height + 0.5);
                Picwidth = (int)((double)Winwidth / BoxW * GlobalVar.gl_bmp_TotalSheet.Width + 0.5);
                Picheight = (int)((double)Winheight / BoxH * GlobalVar.gl_bmp_TotalSheet.Height + 0.5);
            }
            catch { }
        }

        public void paintRectangle()
        {
            try
            {
                if (this.Width < 3 || this.Height < 3)  // 有长宽小于1时会报错
                    return;
                Bitmap bmp = new Bitmap(this.Width, this.Height);
                Rectangle bmpsize = new Rectangle(0, 0, bmp.Width, bmp.Height);
                //Graphics g = this.CreateGraphics();
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.Transparent);
                    Color col_edge = Color.White;
                    #region 画边
                    Pen dragpen = new Pen(Color.LimeGreen, 3);
                    g.DrawRectangle(dragpen, bmpsize.Width - 14, bmpsize.Height - 14, 12, 12);//绘制拖拽小框
                    switch (this.PaintType)
                    {
                        case PicType.ROI:
                            col_edge = Color.Yellow;
                            Pen pen_ROI = new Pen(col_edge, 3);
                            g.DrawRectangle(pen_ROI, 1, 1, bmpsize.Width - 8, bmpsize.Height - 8);
                            break;
                        case PicType.Exclude:
                            col_edge = Color.Red;
                            Pen pen_Exclude = new Pen(col_edge, 3);
                            g.DrawRectangle(pen_Exclude, 1, 1, bmpsize.Width - 8, bmpsize.Height - 8);//外框
                            Rectangle dontcare = new Rectangle(3, 3, bmpsize.Width - 12, bmpsize.Height - 12);//椭圆的外矩形
                            SolidBrush sb = new SolidBrush(pen_Exclude.Color);
                            g.FillEllipse(sb, dontcare);//内圆

                            this.m_DontCareImage = (Bitmap)this.ParentImage.Clone();
                            using (Graphics gp = Graphics.FromImage(this.m_DontCareImage))
                            {
                                sb = new SolidBrush(Color.Black);
                                dontcare.X += this.Location.X;
                                dontcare.Y += this.Location.Y;
                                gp.FillEllipse(sb,dontcare);
                            }
                            break;
                    }
                    #endregion
                }
                dele_showBmpDialog dele = new dele_showBmpDialog(updatePictureBox);
                Invoke(dele, bmp);
            }
            catch (Exception ex) { Console.WriteLine("Paint Err:" + ex.Message); }
        }
        #endregion

        public delegate void dele_ROIChanged(PicturePanelC ppc);
        public event dele_ROIChanged Event_RegionChanged;

        /// <summary>
        /// Region改变
        /// </summary>
        private void RegionChange()
        {
            if (this.Event_RegionChanged != null) this.Event_RegionChanged(this);
        }

    }

    //根据CircleF中圆心的X值排序
    public class TargetSortNumComparer : IComparer<PositionInfo>
    {
        public int Compare(PositionInfo circle1, PositionInfo circle2)
        {
            return ((new CaseInsensitiveComparer()).Compare(circle1.CenterX, circle2.CenterX));
        }
    }

    public class ListCountNumComparer : IComparer<List<PositionInfo>>
    {
        public int Compare(List<PositionInfo> list1, List<PositionInfo> list2)
        {
            return ((new CaseInsensitiveComparer()).Compare(list2.Count, list1.Count));
        }
    }

    public enum PicType : byte
    {
        /// <summary>
        /// 感兴趣区域
        /// </summary>
        ROI,
        /// <summary>
        /// 排除区域
        /// </summary>
        Exclude
    }
}
