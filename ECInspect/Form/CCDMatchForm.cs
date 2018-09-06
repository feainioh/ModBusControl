using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Euresys.Open_eVision_1_2;
using System.Threading;

namespace ECInspect
{
    public partial class CCDMatchForm : Frame
    {
        private PicturePanelC paintCut = null;
        private Bitmap CurrentBitmap = null;//当前CCD抓取的图片
        private Rectangle ROI;//感兴趣区域的位置及大小
        private Bitmap ClipBitmap = null;//截取的图片

        Logs log = Logs.LogsT();

        public CCDMatchForm()
        {
            InitializeComponent();
        }

        private void CCDMatchForm_Load(object sender, EventArgs e)
        {
            GlobalVar.CCD.Event_ImageGrab += new BaslerCCD.dele_ImageGrab(CCD_Event_ImageGrab);
            GlobalVar.CCD.OneShot();
            this.WindowRefresh.Stop();
        }

        private void CCD_Event_ImageGrab(Bitmap e)
        {
            CurrentBitmap = e;
            if (this.pictureBox_Image.InvokeRequired)
            {
                this.pictureBox_Image.Invoke(new Action(delegate {CCD_Event_ImageGrab(e);}));
            }
            else
            {
                this.pictureBox_Image.Image = e;
            }
        }

        private void CCDMatchForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            GlobalVar.CCD.Event_ImageGrab -= CCD_Event_ImageGrab;
            this.WindowRefresh.Start();
        }


        #region 鼠标操作

        int winbeginx = 0;
        int winbeginy = 0;
        bool enter = false;

        int rightClickX = 0; //右击坐标
        int rightClickY = 0;
        private void pictureBox_Image_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.pictureBox_Image.Image == null)
                    return;
                if (e.Button == MouseButtons.Right)  //右键处理
                {
                    rightClickX = e.X;
                    rightClickY = e.Y;
                    enter = false;
                    return;
                }
                foreach (Control ctr in this.pictureBox_Image.Controls)//仅仅允许，一种类型存在一个实例
                {
                    if (ctr is PicturePanelC)
                    {
                        PicturePanelC ppc = (PicturePanelC)ctr;
                        if ((this.radioButton_ROI.Checked && ppc.PaintType == PicType.ROI) ||
                            (this.radioButton_Exclude.Checked && ppc.PaintType == PicType.Exclude))
                            return;
                    }
                }

                if (this.radioButton_ROI.Checked)
                {
                    this.paintCut = new PicturePanelC();
                    this.paintCut.PaintType = PicType.ROI;
                }
                else
                {
                    this.paintCut = new PicturePanelC(this.pictureBox_Image.Image);
                    this.paintCut.PaintType = PicType.Exclude;
                }
                this.paintCut.Event_RegionChanged += new PicturePanelC.dele_ROIChanged(paintCut_Event_ROIChanged);
                this.paintCut.Event_SelectedType += new PicturePanelC.dele_SelectedType(paintCut_Event_Selected);
                enter = true;
                winbeginx = e.X;
                winbeginy = e.Y;
            }
            catch { }
        }

        private void pictureBox_Image_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right) //右键不处理
                    return;
                if (this.pictureBox_Image.Image == null)
                    return;
                if (enter)
                {
                    this.paintCut.WinX = winbeginx;
                    this.paintCut.WinY = winbeginy;
                    if (e.X - winbeginx < 0 || e.Y - winbeginy < 0)
                        return;
                    this.paintCut.Winwidth = e.X - winbeginx;
                    this.paintCut.Winheight = e.Y - winbeginy;
                    DrawpaintRectangle();
                }
            }
            catch { }
        }

        public void DrawpaintRectangle()
        {
            try
            {
                if (paintCut != null)
                {
                    paintCut.Location = new Point(paintCut.WinX, paintCut.WinY);
                    paintCut.Size = new Size(paintCut.Winwidth, paintCut.Winheight);
                    paintCut.Refresh();
                    if (!this.pictureBox_Image.Controls.Contains(paintCut))  //添加图片区域
                    {
                        this.pictureBox_Image.Controls.Add(paintCut);
                    }
                    this.paintCut.paintRectangle();
                    this.pictureBox_Image.Update();
                }
            }
            catch { }
        }

        private void pictureBox_Image_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.pictureBox_Image.Image == null)
                    return;
                if (e.Button == MouseButtons.Right) //右键不处理
                    return;
                if (enter)
                {
                    try
                    {
                        enter = false;
                        int pwidth = e.X - winbeginx;
                        int pheight = e.Y - winbeginy;
                        this.paintCut.WinX = winbeginx;
                        this.paintCut.WinY = winbeginy;
                        this.paintCut.Winwidth = pwidth;
                        this.paintCut.Winheight = pheight;
                        this.paintCut.setPicturepoint(this.pictureBox_Image.Height, this.pictureBox_Image.Width);
                        if (paintCut.Winwidth < 20 || paintCut.Winheight < 20)
                        {
                            this.pictureBox_Image.Controls.Remove(this.paintCut);
                            this.paintCut = null;
                            return;
                        }
                        this.paintCut.paintRectangle();
                        paintCut_Event_ROIChanged(this.paintCut);
                        this.paintCut = null;
                    }
                    catch
                    {
                        MessageBox.Show("添加目标失败", "ERROR");
                    }
                }
            }
            catch { }
        }
        #endregion

        private void btn_Learn_Click(object sender, EventArgs e)
        {
            float light;
            bool result = false;//学习的结果
            if (float.TryParse(this.textBox_LightBalance.Text, out light)) result = ROI_Confirm(this.ROI, light);
            else log.AddERRORLOG("LightBalace 文本框不是数字");

            this.label_LearnResult.Text = result ? "成功" : "失败";
            this.label_LearnResult.ForeColor = result ? Color.LightGreen : Color.Red;
        }

        private void paintCut_Event_ROIChanged(PicturePanelC ppc)
        {
            if (this.radioButton_Exclude.Checked)
            {
                this.ClipBitmap = (Bitmap)ppc.DontCareImage.Clone();
            }
            else this.ROI = new Rectangle(ppc.Location, ppc.Size);
        }

        private void paintCut_Event_Selected(PicType type)
        {
            if (type == PicType.ROI) this.radioButton_ROI.Checked = true;
            else if (type == PicType.Exclude) this.radioButton_Exclude.Checked = true;
        }

        private bool ROI_Confirm(Rectangle rect, float lightbalance)
        {
            try
            {
                this.pictureBox_Image.Invalidate();
                Bitmap bmp = CurrentBitmap.Clone(new Rectangle(0, 0, CurrentBitmap.Width, CurrentBitmap.Height), CurrentBitmap.PixelFormat);
                this.ClipBitmap.Save(Application.StartupPath + @"\log\pic\" + DateTime.Now.ToBinary() + ".png");
                this.pictureBox_Image.Image = GlobalVar.FindModel.FindLearnPattern(bmp, rect, this.ClipBitmap, lightbalance);//学习ROI模型
                GlobalVar.FindModel.ShapeFind(ref bmp);
                EFoundPattern[] result = GlobalVar.FindModel.m_FindResult;
                if (result.Length > 0)
                {
                    INIFileValue.MarkX_Std = result[0].Center.X;
                    INIFileValue.MarkY_Std = result[0].Center.Y;
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("绘制ROI异常:" + ex.Message);
                log.AddERRORLOG("绘制ROI异常:" + ex.Message);
                return false;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            INIFileValue.FindModelFile = Application.StartupPath + @"\Config\Find.FND";
            if (GlobalVar.FindModel.SaveFindModel(INIFileValue.FindModelFile))
            {
                double RealX = GlobalVar.c_Modbus.HoldingRegisters.AxisX_RealLocation.Value;//实际位置
                double RealY = GlobalVar.c_Modbus.HoldingRegisters.AxisY_RealLocation.Value;//实际位置
                //INIFileValue.AxisX_Std = RealX / GlobalVar.ConverRate;
                //INIFileValue.AxisY_Std = RealY / GlobalVar.ConverRate;
                //myFunction.WriteIniString(INIFileValue.gl_inisection_CCD, INIFileValue.gl_iniKey_AxisX_Std, INIFileValue.AxisX_Std.ToString());//当前X轴坐标
                //myFunction.WriteIniString(INIFileValue.gl_inisection_CCD, INIFileValue.gl_iniKey_AxisY_Std, INIFileValue.AxisY_Std.ToString());//当前Y轴坐标

                myFunction.WriteIniString(INIFileValue.gl_inisection_CCD, INIFileValue.gl_iniKey_MarkX_Std, INIFileValue.MarkX_Std.ToString());//当前Mark点X坐标
                myFunction.WriteIniString(INIFileValue.gl_inisection_CCD, INIFileValue.gl_iniKey_MarkY_Std, INIFileValue.MarkY_Std.ToString());//当前Mark点Y坐标

                myFunction.WriteIniString(INIFileValue.gl_inisection_OpeneVision, INIFileValue.gl_iniKey_MatchFile, INIFileValue.FindModelFile);
            }
        }

        private void btn_Optimization_Click(object sender, EventArgs e)
        {
            Thread thd = new Thread(new ThreadStart(delegate {
                //float light;
                //for (int i = -100; i < 100; i++)
                //{
                //    if (!this.Visible) break;
                //    light = i * 0.01f;
                //    if (this.textBox_LightBalance.InvokeRequired)
                //    {
                //        this.textBox_LightBalance.Invoke(new Action(delegate { this.textBox_LightBalance.Text = light.ToString(); }));
                //    }
                //    else this.textBox_LightBalance.Text = light.ToString();

                //    if (this.pictureBox_Image.InvokeRequired)
                //    {
                //        this.pictureBox_Image.Invoke(new Action(delegate
                //        {
                //            ROI_Confirm(this.ROI, light);
                //        }));
                //    }
                //    else ROI_Confirm(this.ROI, light);

                //    Thread.Sleep(500);
                //}
            }));
            thd.IsBackground = true;
            thd.Start();
        }

    }
}
