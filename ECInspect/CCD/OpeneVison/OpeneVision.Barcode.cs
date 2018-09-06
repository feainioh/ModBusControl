using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Euresys.Open_eVision_1_2;
using System.IO;

namespace ECInspect
{
    partial class OpeneVision
    {
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
        #endregion
    }
}
