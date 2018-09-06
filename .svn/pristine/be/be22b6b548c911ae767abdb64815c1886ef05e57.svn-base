using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Euresys.Open_eVision_1_2;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace ECInspect
{
    class Match_OpeneVision
    {
        private EMatcher m_match = null;
        private EROIC24 EC24Image1Roi2 = new EROIC24(); // EROIC24 instance
        /// <summary>
        /// ROI的尺寸
        /// </summary>
        internal Size ROISize { get { return m_match.PatternLearnt ? new Size(m_match.PatternWidth, m_match.PatternHeight) : new Size(-1, -1); } }

        public List<PointF[]> ResultProfile { get { return null; } }
        public List<PositionInfo> m_lsMatchResult = new List<PositionInfo> { };
        public float MinScore
        {
            set { m_match.MinScore = value; }
        }
        public float MaxAngle
        {
            set { m_match.MaxAngle = value; }
        }
        public float MinAngle
        {
            set { m_match.MinAngle = value; }
        }
        /// <summary>
        /// 异常信息
        /// </summary>
        internal Exception LastError;

        Logs log = Logs.LogsT();

        public Match_OpeneVision() { InitMatch(); }
        public Match_OpeneVision(string strTemplateFile)
        {
            InitMatch();
            if (File.Exists(strTemplateFile)) m_match.Load(strTemplateFile);            
        }

        /// <summary>
        /// 初始化匹配
        /// </summary>
        private void InitMatch()
        {
            m_match = new EMatcher();
            m_match.MaxPositions = 1;//结果数量
            m_match.MaxScaleX = 1.10f;
            m_match.MaxScaleY = 1.10f;
            m_match.MinScaleX = 0.90f;
            m_match.MinScaleY = 1;
            //m_match.MinAngle = 0;
            //m_match.MaxAngle = 200;
            m_match.MinScore = 0.5f;
        }

        /// <summary>
        /// 保存匹配模型
        /// </summary>
        /// <param name="path">匹配模型的保存路径</param>
        internal bool Save(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    string folder = Application.StartupPath+@"\Log\Match";
                    if(!Directory.Exists(folder)) Directory.CreateDirectory(folder);
                    File.Copy(path, string.Format(@"{0}\{1}.MCH", folder, DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")));
                    File.Delete(path);
                }
                m_match.Save(path);
                return true;
            }
            catch (Exception ex)
            {
                log.AddERRORLOG("保存匹配模型失败:" + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 学习ROI
        /// </summary>
        /// <param name="image"></param>
        /// <param name="ppc"></param>
        internal void LearnPattern(Image image,PicturePanelC ppc)
        {
            Bitmap bitmap = new Bitmap(image);
            EImageC24 image24 = ConvertBitmapToEImageC24(bitmap);
            _LearnPattern(image24, ppc);
        }
        /// <summary>
        /// 学习ROI
        /// </summary>
        /// <param name="image"></param>
        /// <param name="ppc"></param>
        internal void LearnPattern(EROIBW8 bw8, PicturePanelC ppc)
        {
            _LearnPattern(bw8, ppc);
        } 
        /// <summary>
        /// 学习ROI
        /// </summary>
        /// <param name="image"></param>
        /// <param name="ppc"></param>
        internal void LearnPattern(EImageC24 image24, PicturePanelC ppc)
        {
            _LearnPattern(image24, ppc);
        }
        private void _LearnPattern(EBaseROI image24, PicturePanelC ppc)
        {
            EC24Image1Roi2.Attach(image24);
            EC24Image1Roi2.SetPlacement(ppc.Location.X + 1, ppc.Location.Y + 1, ppc.Width - 8, ppc.Height - 8);

            m_match.LearnPattern(EC24Image1Roi2);//学习ROI模型
            m_match.DontCareThreshold = 80;
        }
        #region 条码解析模块
        /// <summary>
        /// 从图片中获得DecodeString
        /// </summary>
        /// <param name="imagePath"></param>
        /// <returns></returns>
        public bool GetDecodeStrbyPath(string imagePath, int DeviceID)
        {
            try
            {
                if ((imagePath.Length == 0) || (!File.Exists(imagePath)))
                { return false; }
                EMatrixCodeReader EMatrixCodeReader1 = new EMatrixCodeReader(); // EMatrixCodeReader instance
                EMatrixCodeReader1.TimeOut = 3000000;

                EMatrixCode EMatrixCodeReader1Result = null; // EMatrixCode               
                EImageBW8 EBW8Image1 = new EImageBW8(); // EImageBW8 instance
                EBW8Image1.Load(imagePath);
                EMatrixCodeReader1Result = EMatrixCodeReader1.Read(EBW8Image1);
                //GlobalVar.gl_str_decode[DeviceID] = EMatrixCodeReader1Result.DecodedString;
                return true;
            }
            catch
            {
                return false;
                throw;
            }

        }


        /// <summary>
        /// 从EImageBW8中获得DecodeString
        /// </summary>
        /// <param name="EImageBW8"></param>
        /// <param name="Redecode">是否需要重复解析</param>
        /// <returns></returns>
        public string GetDecodeStrbyEImageBW8(EImageBW8 EBW8Image1)
        {
            EImageBW8 image_bak = new EImageBW8(EBW8Image1);
            for (int i = 0; i < 7; i++)
            {
                EMatrixCodeReader EMatrixCodeReader1 = new EMatrixCodeReader(); // EMatrixCodeReader instance
                EMatrixCode EMatrixCodeReader1Result = null; // EMatrixCode instance
                try
                {
                    EMatrixCodeReader1.TimeOut = GlobalVar.gl_decode_timeout;
                    #region 对图片进行其他处理 ----没有经过验证，无用

                    //定义数组保存位图
                    //int bytes = Math.Abs(bmpdata_src.Stride) * bmp.Height;
                    //byte[] rgbvalues = new byte[bytes];
                    ////复制RGB值到数组
                    //System.Runtime.InteropServices.Marshal.Copy(pScan0, rgbvalues, 0, bytes);
                    //将每个像素的第三个值设为255. A 24bpp的位图将变红
                    //for (int counter = 2; counter < rgbvalues.Length; counter += 3)
                    //{
                    //    rgbvalues[counter] = 255;
                    //}
                    //把RGB值拷回位图
                    //System.Runtime.InteropServices.Marshal.Copy(rgbvalues, 0, ptr, bytes);
                    //解锁
                    //bmp.UnlockBits(bmpdata_src);
                    //绘制更新了的位图
                    //DrawImage(bmp, 0, 150);

                    #endregion

                    EMatrixCodeReader1Result = EMatrixCodeReader1.Read(image_bak);
                    return EMatrixCodeReader1Result.DecodedString;
                }
                catch
                {
                    switch (i)
                    {
                        case 0:
                            image_bak = EImageBW8GainOff(EBW8Image1, float.Parse("1.00"), float.Parse("80.0"));
                            image_bak = EImageBW8GainOff(EBW8Image1, float.Parse("0.543"), float.Parse("0.0"));
                            break;
                        case 1:
                            image_bak = EImageBW8GainOff(EBW8Image1, float.Parse("0.643"), float.Parse("0.0"));
                            image_bak = EImageBW8GainOff(EBW8Image1, float.Parse("0.0"), float.Parse("99.0"));
                            break;
                        case 2:
                            image_bak = EImageBW8GainOff(EBW8Image1, float.Parse("1.443"), float.Parse("0.0"));
                            image_bak = EImageBW8GainOff(EBW8Image1, float.Parse("0.0"), float.Parse("9.6"));
                            break;
                        case 3:
                            image_bak = EImageBW8GainOff(EBW8Image1, float.Parse("1.243"), float.Parse("0.0"));
                            image_bak = EImageBW8GainOff(EBW8Image1, float.Parse("0.0"), float.Parse("28.0"));
                            break;
                        case 4:
                            image_bak = EImageBW8GainOff(EBW8Image1, float.Parse("1.30"), float.Parse("0.0"));
                            image_bak = EImageBW8GainOff(EBW8Image1, float.Parse("0.0"), float.Parse("48.0"));
                            break;
                        case 5:
                            image_bak = EImageBW8GainOff(EBW8Image1, float.Parse("0.643"), float.Parse("0.0"));
                            image_bak = EImageBW8GainOff(EBW8Image1, float.Parse("0.0"), float.Parse("118.0"));
                            break;
                        case 6:
                            image_bak = EImageBW8GainOff(EBW8Image1, float.Parse("0.443"), float.Parse("0.0"));
                            image_bak = EImageBW8GainOff(EBW8Image1, float.Parse("0.0"), float.Parse("129.0"));
                            break;
                    }
                }
            }
            return "";
        }

        public EImageBW8 ConvertBitmapToEImageBW8(Bitmap bmp)
        {
            EImageBW8 EBW8Image1 = new EImageBW8(bmp.Width, bmp.Height); // EImageBW8 instance
            try
            {
                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                //锁定位图
                System.Drawing.Imaging.BitmapData bmpdata_src = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                //获取首行地址
                IntPtr pScan0 = bmpdata_src.Scan0;
                unsafe
                {
                    try
                    {
                        for (int Height = 0; Height < bmpdata_src.Height; Height++)
                        {
                            byte* pSrc = (byte*)pScan0;
                            pSrc += bmpdata_src.Stride * Height;
                            byte* pDest = (byte*)EBW8Image1.GetImagePtr(0, Height);
                            for (int Width = 0; Width < bmpdata_src.Width; Width++)
                            {
                                //pDest[0] = (byte)(pSrc[0] * 0.299 + pSrc[1] * 0.587 + pSrc[2] * 0.114);
                                pDest[0] = (byte)(pSrc[0] * 0.3 + pSrc[1] * 0.6 + pSrc[2] * 0.1);
                                pSrc += 3;
                                pDest++;
                            }
                        }
                    }
                    catch { }
                }
                bmp.UnlockBits(bmpdata_src);
            }
            catch { }
            return EBW8Image1;
        }

        public static EImageC24 ConvertBitmapToEImageC24(Bitmap bmp)
        {
            EImageC24 eimageC24 = new EImageC24(bmp.Width, bmp.Height); // EImageC24 instance
            try
            {
                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                //锁定位图
                System.Drawing.Imaging.BitmapData bmpdata_src = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                //获取首行地址
                IntPtr pScan0 = bmpdata_src.Scan0;
                unsafe
                {
                    try
                    {
                        for (int Height = 0; Height < bmpdata_src.Height; Height++)
                        {
                            byte* pSrc = (byte*)pScan0;
                            pSrc += bmpdata_src.Stride * Height;
                            byte* pDest = (byte*)eimageC24.GetImagePtr(0, Height);
                            for (int Width = 0; Width < bmpdata_src.Width; Width++)
                            {
                                pDest[0] = (byte)(pSrc[0]);
                                pDest[1] = (byte)(pSrc[1]);
                                pDest[2] = (byte)(pSrc[2]);
                                pSrc += 3;
                                pDest += 3;
                            }
                        }
                    }
                    catch { }
                }
                bmp.UnlockBits(bmpdata_src);
            }
            catch { }
            return eimageC24;
        }

        /// <summary>
        /// 图片均衡操作，将传入图片自动转换
        /// 图片(forexample:a.bmp)另存为同文件夹下面的_a.bmp
        /// </summary>
        /// <param name="ImagePath"></param>
        public void QualizerImage(string imagePath)
        {
            try
            {
                if ((imagePath.Length == 0) || (!File.Exists(imagePath)))
                { return; }
                EImageBW8 EBW8ImageOrig = new EImageBW8(); // EImageBW8 instance
                EImageBW8 EBW8ImageDest = new EImageBW8(); // EImageBW8 instance
                EBW8ImageOrig.SetSize(512, 512);
                // Make image black
                EasyImage.Oper(EArithmeticLogicOperation.Copy, new EBW8(0), EBW8ImageOrig);
                EBW8ImageOrig.Load(imagePath);
                EBW8ImageDest.SetSize(512, 512);
                // Make image black
                EasyImage.Oper(EArithmeticLogicOperation.Copy, new EBW8(0), EBW8ImageDest);
                EBW8ImageDest.SetSize(EBW8ImageOrig);
                EasyImage.Equalize(EBW8ImageOrig, EBW8ImageDest);
                //EBW8ImageOrig.Dispose();
                EBW8ImageDest.Save(ImageSaveAsPath(imagePath));
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 图片均衡操作，将传入图片自动转换，imgWidth：设定图片宽度，imgHeight图片设定高度
        /// 图片(forexample:a.bmp)另存为同文件夹下面的_a.bmp
        /// </summary>
        /// <param name="ImagePath"></param>
        public void QualizerImage(string ImagePath, int imgWidth, int imgHeight)
        {
            try
            {
                if ((ImagePath.Length == 0) || (!File.Exists(ImagePath)))
                { return; }
                EImageBW8 EBW8ImageOrig = new EImageBW8(); // EImageBW8 instance
                EImageBW8 EBW8ImageDest = new EImageBW8(); // EImageBW8 instance
                EBW8ImageOrig.SetSize(imgWidth, imgHeight);
                // Make image black
                EasyImage.Oper(EArithmeticLogicOperation.Copy, new EBW8(0), EBW8ImageOrig);
                EBW8ImageOrig.Load(ImagePath);
                EBW8ImageDest.SetSize(imgWidth, imgHeight);
                // Make image black
                EasyImage.Oper(EArithmeticLogicOperation.Copy, new EBW8(0), EBW8ImageDest);
                EBW8ImageDest.SetSize(EBW8ImageOrig);
                EasyImage.Equalize(EBW8ImageOrig, EBW8ImageDest);
                EBW8ImageOrig.Dispose();
                //EBW8ImageDest.Save(ImagePath);
                EBW8ImageDest.Save(ImageSaveAsPath(ImagePath));
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 灰度&对比度处理，图片另存为imagePath\_*.*
        /// 图片(forexample:a.bmp)另存为同文件夹下面的_a.bmp
        /// </summary>
        /// <param name="ImagePath"></param>
        /// <param name="Val_gain"></param>
        /// <param name="Val_offSet"></param>
        public EImageBW8 EImageBW8GainOff(EImageBW8 ImageSource, float Val_gain, float Val_offSet)
        {
            EImageBW8 EBW8ImageDest = new EImageBW8(ImageSource.Width, ImageSource.Height); // EImageBW8 instance
            try
            {
                EasyImage.GainOffset(ImageSource, EBW8ImageDest, Val_gain, Val_offSet);
            }
            catch { }
            return EBW8ImageDest;
        }

        private string ImageSaveAsPath(string ImagePath)
        {
            try
            {
                string Folderpath = ImagePath.Substring(0, ImagePath.LastIndexOf('\\') + 1);
                string ImageName = ImagePath.Substring(ImagePath.LastIndexOf('\\') + 1);
                string resultPath = Folderpath + "_" + ImageName;
                return resultPath;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region 形状分析模块
        public void ShapeMatch(EImageBW8 bw8, ref List<PositionInfo> _Resultlist)
        {
            _ShapeMatch(bw8, ref _Resultlist);
        }
        public void ShapeMatch(EImageC24 EC24Image1, ref List<PositionInfo> _Resultlist)
        {
            _ShapeMatch(EC24Image1, ref _Resultlist);
        }
        public void ShapeMatch(Bitmap bmp, ref List<PositionInfo> _Resultlist)
        {
            try
            {
                EImageC24 EC24Image1 = new EImageC24(); // EImageC24 instance
                EROIC24 EC24Image1Roi1 = new EROIC24(); // EROIC24 instance
                EC24Image1.SetSize(bmp.Width, bmp.Height);
                EC24Image1 = ConvertBitmapToEImageC24(bmp);

                _ShapeMatch(EC24Image1, ref _Resultlist);
            }
            catch (EException)
            {
                // Insert exception handling code here
            }
        }
        private void _ShapeMatch(EROIBW8 bw8, ref List<PositionInfo> _Resultlist)
        {
            try
            {
                m_match.Match(bw8);
                for (int i = 0; i < m_match.NumPositions; i++)
                {
                    PositionInfo info = new PositionInfo();
                    EMatchPosition pos = m_match.GetPosition(i);
                    info.CenterX = pos.CenterX;
                    info.CenterY = pos.CenterY;
                    info.angle = pos.Angle;
                    info.scaleX = pos.ScaleX;
                    info.scaleY = pos.ScaleY;
                    info.score = pos.Score;
                    _Resultlist.Add(info);
                }
            }
            catch (EException)
            {
                // Insert exception handling code here
            }
        }
        private void _ShapeMatch(EROIC24 EC24Image1, ref List<PositionInfo> _Resultlist)
        {
            try
            {
                m_match.Match(EC24Image1);
                for (int i = 0; i < m_match.NumPositions; i++)
                {
                    PositionInfo info = new PositionInfo();
                    EMatchPosition pos = m_match.GetPosition(i);
                    info.CenterX = pos.CenterX;
                    info.CenterY = pos.CenterY;
                    info.angle = pos.Angle;
                    info.scaleX = pos.ScaleX;
                    info.scaleY = pos.ScaleY;
                    info.score = pos.Score;
                    _Resultlist.Add(info);
                }
            }
            catch (EException)
            {
                // Insert exception handling code here
            }
        }
        #endregion
    }

    public class PositionInfo
    {
        public float CenterX;
        public float CenterY;
        public float angle;
        public float scaleX;
        public float scaleY;
        public float score;    //得分越高，模拟度越高
    }
}
