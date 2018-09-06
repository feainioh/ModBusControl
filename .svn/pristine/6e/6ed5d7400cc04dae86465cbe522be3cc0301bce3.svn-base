using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECInspect
{
    /// <summary>
    /// 统计信息
    /// </summary>
    partial class INIFileValue
    {
        /// <summary>
        /// 制品检测张数
        /// </summary>
        internal static int ProductTestNum = 0;
        /// <summary>
        /// 合格制品数
        /// </summary>
        internal static int ProductQualifiedNum = 0;
        /// <summary>
        /// 不合格制品数
        /// </summary>
        internal static int ProductUnQualifidNUm = 0;
        /// <summary>
        /// 断路
        /// </summary>
        internal static int ProductOpen = 0;
        /// <summary>
        /// 短路（包括绝缘）
        /// </summary>
        internal static int ProductShort = 0;
        /// <summary>
        /// 冲裁偏移M
        /// </summary>
        internal static int ProductOffsetM = 0;
        /// <summary>
        /// 冲裁偏移N
        /// </summary>
        internal static int ProductOffsetN = 0;
        /// <summary>
        /// 补材漏贴BY
        /// </summary>
        internal static int ProductForgetPaste = 0;
        /// <summary>
        /// 压合次数
        /// </summary>
        internal static int ProductPressCount = 0;

        #region Mark相关
        /// <summary>
        /// 打标器运行剩下时间(天)
        /// </summary>
        internal static int ProductMarkLeftTime
        {
            get
            {
                int days = (DateTime.Now - INIFileValue.MarkChangeTime).Days;
                days = AlarmIntervalDay - days;
                return days > 0 ? days : 0;
            }
        }
        /// <summary>
        /// 打标器上次更换时间
        /// </summary>
        internal static DateTime MarkChangeTime;
        /// <summary>
        /// 报警启动时间(小时)
        /// </summary>
        internal static int AlarmHour;
        /// <summary>
        /// 报警启动时间(分钟)
        /// </summary>
        internal static int AlarmMinute; 
        /// <summary>
        /// 报警时间间隔(天)
        /// </summary>
        internal static int AlarmIntervalDay;
        /// <summary>
        /// 已经打标的次数
        /// </summary>
        internal static int MarkCount;
        /// <summary>
        /// 允许打标的总数
        /// </summary>
        internal static int MarkTotalCount;
        #endregion
    }
}
