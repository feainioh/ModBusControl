using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Euresys.Open_eVision_1_2;
using System.Drawing;
using System.IO;

namespace ECInspect
{
    partial class OpeneVision
    {
        private EPatternFinder m_find = null;
        internal EFoundPattern[] m_FindResult;
        /// <summary>
        /// Find ROI的尺寸
        /// </summary>
        internal Size FindROISize { get { return m_find.LearningDone ?  new Size(228, 245) : new Size(-1, -1); } }

        /// <summary>
        /// 初始化Find
        /// </summary>
        /// <param name="strTemplateFile">模版文件</param>
        internal void InitFind(string strTemplateFile)
        {
            m_find = new EPatternFinder();
            if (!string.IsNullOrEmpty(strTemplateFile) && File.Exists(strTemplateFile)) m_find.Load(strTemplateFile);
            m_find.Interpolate = true;
            m_find.MaxInstances = 1;
            m_find.MinScore = GlobalVar.MinScore;
            m_find.ContrastMode = EFindContrastMode.Normal;

        }

        /// <summary>
        /// 保存匹配模型
        /// </summary>
        /// <param name="path">匹配模型的保存路径</param>
        internal bool SaveFindModel(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    string folder = System.Windows.Forms.Application.StartupPath + @"\Log\eVision";
                    if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
                    File.Copy(path, string.Format(@"{0}\{1}.FND", folder, DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")));
                    File.Delete(path);
                }
                m_find.Save(path);
                return true;
            }
            catch (Exception ex)
            {
                log.AddERRORLOG("保存匹配模型失败:" + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Find学习ROI【返回绘制ROI后的图形】
        /// </summary>
        /// <param name="image">图像</param>
        /// <param name="rect">ROI</param>
        /// <param name="dontcare">忽略区域</param>
        /// <param name="lightbalance">光平衡</param>
        internal Bitmap FindLearnPattern(Bitmap bmp, Rectangle rect, Bitmap dontcare, float lightbalance = 0)
        {
            EImageBW8 bw8 = ConvertBitmapToEImageBW8(bmp);
            EImageBW8 bw8dontcare = ConvertBitmapToEImageBW8(dontcare);
            _FindLearnPattern(bw8, rect, bw8dontcare, lightbalance);
            #region 模型绘图
            using (Graphics gp = Graphics.FromImage(bmp))
            {
                Color centerpen = Color.FromArgb(250, 37, 69);
                Color modepen = Color.FromArgb(0, 255, 0);
                m_find.Draw(gp, new ERGBColor(centerpen.R, centerpen.G, centerpen.B));    //中心十字
                m_find.DrawModel(gp, new ERGBColor(modepen.R, modepen.G, modepen.B)); //特征点
            }
            #endregion
            return bmp;
        }

        private void _FindLearnPattern(EImageBW8 bw8, Rectangle rect, EImageBW8 dontcare, float lightbalance = 0)
        {
            EBW8ImageRoi1.Attach(bw8);
            EBW8ImageRoi1.SetPlacement(rect.Location.X + 1, rect.Location.Y + 1, rect.Width - 8, rect.Height - 8);

            m_find.PatternType = EPatternType.ConsistentEdges; //EPatternType.ContrastingRegions;
            m_find.MinScore = GlobalVar.MinScore;
            m_find.Learn(EBW8ImageRoi1, dontcare);
            if (lightbalance > -1.0 && lightbalance < 1.0f) m_find.LightBalance = lightbalance;
        }

        #region Find定位
        internal bool ShapeFind(ref Bitmap bmp)
        {
            EImageBW8 bw8=ConvertBitmapToEImageBW8(bmp);

            m_FindResult = m_find.Find(bw8);         
            #region 目标绘图
            if (m_FindResult.Length > 0)
            {
                m_FindResult[0].DrawFeaturePoints = true;
                using (Graphics gp = Graphics.FromImage(bmp))
                {
                    m_FindResult[0].Draw(gp);
                }
            }
            #endregion
            return m_FindResult.Length > 0;
        }
        #endregion
    }
}
