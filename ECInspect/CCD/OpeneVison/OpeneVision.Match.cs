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
    partial class OpeneVision
    {
        private EMatcher m_match = null;
        /// <summary>
        /// Match ROI的尺寸
        /// </summary>
        internal Size MatchROISize { get { return m_match.PatternLearnt ? new Size(m_match.PatternWidth, m_match.PatternHeight) : new Size(-1, -1); } }

        public float MatchMinScore
        {
            set { m_match.MinScore = value; }
        }
        public float MatchMaxAngle
        {
            set { m_match.MaxAngle = value; }
        }
        public float MatchMinAngle
        {
            set { m_match.MinAngle = value; }
        }
      
        /// <summary>
        /// 初始化匹配
        /// </summary>
        /// <param name="strTemplateFile">模版文件</param>
        internal void InitMatch(string strTemplateFile)
        {
            m_match = new EMatcher();
            m_match.MaxPositions = 1;//结果数量
            m_match.MaxScaleX = 1.10f;
            m_match.MaxScaleY = 1.10f;
            m_match.MinScaleX = 0.90f;
            m_match.MinScaleY = 1;
            //m_match.MinAngle = 0;
            //m_match.MaxAngle = 200;
            m_match.MinScore = GlobalVar.MinScore;

            if (!string.IsNullOrEmpty(strTemplateFile) && File.Exists(strTemplateFile)) m_match.Load(strTemplateFile);
        }

        /// <summary>
        /// 保存匹配模型
        /// </summary>
        /// <param name="path">匹配模型的保存路径</param>
        internal bool SaveMatchModel(string path)
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
        /// Match学习ROI
        /// </summary>
        /// <param name="image"></param>
        /// <param name="ppc"></param>
        internal void MatchLearnPattern(Image image,PicturePanelC ppc)
        {
            Bitmap bitmap = new Bitmap(image);
            EImageC24 image24 = ConvertBitmapToEImageC24(bitmap);
            _MatchLearnPattern(image24, ppc);
        }
        /// <summary>
        /// Match学习ROI
        /// </summary>
        /// <param name="image"></param>
        /// <param name="ppc"></param>
        internal void MatchLearnPattern(EROIBW8 bw8, PicturePanelC ppc)
        {
            _MatchLearnPattern(bw8, ppc);
        } 
        /// <summary>
        /// Match学习ROI
        /// </summary>
        /// <param name="image"></param>
        /// <param name="ppc"></param>
        internal void MatchLearnPattern(EImageC24 image24, PicturePanelC ppc)
        {
            _MatchLearnPattern(image24, ppc);
        }
        private void _MatchLearnPattern(EBaseROI image24, PicturePanelC ppc)
        {
            EC24Image1Roi1.Attach(image24);
            EC24Image1Roi1.SetPlacement(ppc.Location.X + 1, ppc.Location.Y + 1, ppc.Width - 8, ppc.Height - 8);

            m_match.LearnPattern(EC24Image1Roi1);//学习ROI模型
            m_match.DontCareThreshold = 80;
        }


        #region 匹配定位
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
