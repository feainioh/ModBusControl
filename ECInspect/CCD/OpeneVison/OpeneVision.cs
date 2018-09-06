using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Euresys.Open_eVision_1_2;
using System.Drawing;
using System.Drawing.Imaging;

namespace ECInspect
{
    partial class OpeneVision
    {  
        /// <summary>
        /// 异常信息
        /// </summary>
        internal Exception LastError;

        private EROIC24 EC24Image1Roi1 = new EROIC24(); // EROIC24 instance
        private EROIBW8 EBW8ImageRoi1 = new EROIBW8();  // EROIBW8 instance

        Logs log = Logs.LogsT();

        public OpeneVision() {  }

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
    }
}
