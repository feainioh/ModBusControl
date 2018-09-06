using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections.Concurrent;
using System.Speech.Synthesis;

namespace ECInspect
{
    /// <summary>
    /// 文字转换为语音播报
    /// </summary>
    sealed class TextSpeech
    {
        /// <summary>
        /// 等待播放的语音队列
        /// </summary>
        private ConcurrentQueue<string> SpeechQueue = new ConcurrentQueue<string>();
        /// <summary>
        /// 实际语音发声
        /// </summary>
        private SpeechSynthesizer m_speak = new SpeechSynthesizer();

        private static TextSpeech Speaker;
        private TextSpeech() 
        {
            Thread Thd_Speaker = new Thread(ThreadSpeak);
            Thd_Speaker.IsBackground = true;
            Thd_Speaker.Name = "语音播报线程";
            Thd_Speaker.Start();
        }

        /// <summary>
        /// 获取语音播报
        /// </summary>
        /// <returns></returns>
        public static TextSpeech GetSpeaker()
        {
            if (Speaker == null) Speaker = new TextSpeech();
            return Speaker;
        }

        /// <summary>
        /// 加入语音播放
        /// </summary>
        /// <param name="Text"></param>
        public void AddSpeech(string Text)
        {
            #region 根据时间智能修改发音【因为只安装了一种语言包，故无法修改】
            //foreach (var item in m_speak.GetInstalledVoices().Select(v => v.VoiceInfo))//显示已经安装的语言包
            //{
            //    Console.WriteLine("Name:{0},Gender:{1},Age:{2}", item.Description, item.Gender, item.Age);
            //}
            //DateTime time = DateTime.Now;
            //if (time.Hour >= 6 && time.Hour < 8) m_speak.SelectVoiceByHints(VoiceGender.Neutral, VoiceAge.Child);
            //else if (time.Hour >= 8 && time.Hour < 10) m_speak.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Teen);
            //else if (time.Hour >= 10 && time.Hour < 12) m_speak.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Teen);
            //else if (time.Hour >= 12 && time.Hour < 14) m_speak.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Adult);
            //else if (time.Hour >= 14 && time.Hour < 16) m_speak.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult);
            //else if (time.Hour >= 16 && time.Hour < 18) m_speak.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Senior);
            //else m_speak.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Senior);
            #endregion

            SpeechQueue.Enqueue(Text);
        }

        private void ThreadSpeak()
        {
            int PresentSpeak;
            while (!GlobalVar.SoftWareShutDown)
            {
                try
                {
                    if (!SpeechQueue.IsEmpty)
                    {
                        PresentSpeak = SpeechQueue.Count;
                        Speak(PresentSpeak);
                        PresentSpeak = 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("语音播放异常:"+ex.Message);
                }
                finally
                {
                    Thread.Sleep(100);
                }
            }
        }

        private void Speak(int PresentSpeak)
        {
            string text = string.Empty;
            for (int i = 0; i < PresentSpeak; i++)
            {
                if (SpeechQueue.TryDequeue(out text))
                {
                    //同步朗读
                    m_speak.Speak(text);
                }
            }
        }

        /// <summary>
        /// 暂停播放
        /// </summary>
        public void Pause()
        {
            try
            {
                m_speak.Pause();
            }
            catch { }
        }

        /// <summary>
        /// 恢复播放
        /// </summary>
        public void Resume()
        {
            try
            {
                m_speak.Resume();
            }
            catch { }
        }

        /// <summary>
        /// 清除剩下的未播放
        /// </summary>
        public void Clear()
        {
            try
            {
                string str = string.Empty;
                while (SpeechQueue.Count > 0)
                {
                    SpeechQueue.TryDequeue(out str);
                }
            }
            catch { }
        }
    }
}
