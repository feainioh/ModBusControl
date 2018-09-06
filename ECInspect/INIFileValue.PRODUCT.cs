using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ECInspect
{
    partial class INIFileValue
    {
        #region Product.ini文件读取的值
        /// <summary>
        /// 步骤数
        /// </summary>
        public static int Product_N;
        /// <summary>
        /// 等于1时为X轴移动，Y轴移动时该行不要
        /// </summary>
        public static int Product_MAC_XY = 0;

        /// <summary>
        /// 治具名称
        /// </summary>
        public static string Product_NAME = "NONAME";
        /// <summary>
        /// 每次测几PCS
        /// </summary>
        public static int Product_GROUP;
        /// <summary>
        /// 一张有几PUNCH
        /// </summary>
        public static int Product_OKURI;
        /// <summary>
        /// PUNCH间距
        /// </summary>
        public static double Product_PITCH;
        /// <summary>
        /// 不反转测为0，反转测为1
        /// </summary>
        public static int Product_TOMBO;
        /// <summary>
        /// 取像点X坐标
        /// </summary>
        public static double Product_MARK_X_STD;
        /// <summary>
        /// 取像点Y坐标
        /// </summary>
        public static double Product_MARK_Y_STD;
        /// <summary>
        /// 接触检查为0，非接触检查为1
        /// </summary>
        public static int Product_TRL;
        /// <summary>
        /// 涂替功能打开为1，关闭为0
        /// </summary>
        public static int Product_NK;

        /// <summary>
        /// 治具补正距离
        /// </summary>
        public static double Product_JIGU_OFFSET;
        /// <summary>
        /// 找点模式，第一个点的偏移距离
        /// </summary>
        public static double Product_SEARCH_OFFSET;

        /// <summary>
        /// 画像取点延时时间
        /// </summary>
        public static double Product_CM_DELAY;
        /// <summary>
        /// 相机取像重复次数
        /// </summary>
        public static int Product_CM_RETRY;
        /// <summary>
        /// 1为取像一次，2为每PUNCH都取像
        /// </summary>
        public static int Product_CM_MODE;

        public static int Product_AL_MARK;
        /// <summary>
        /// 同一位置重复测试为0，不重复测试为1
        /// </summary>
        public static int Product_AL_MODE;
        /// <summary>
        /// 复测时，每次测试偏移距离
        /// </summary>
        public static double Product_AL_FINE;
        /// <summary>
        /// 复测检查次数
        /// </summary>
        public static int Product_AL_NUM;

        /// <summary>
        /// 打标功能关闭为0，打标功能打开为1
        /// </summary>
        public static int Product_STAMP_ENABLE;
        /// <summary>
        /// 打标器下降时间（单位 毫秒）
        /// </summary>
        public static int Product_STAMP_ON;
        /// <summary>
        /// 打标器通气时间（单位 毫秒）
        /// </summary>
        public static int Product_AIR_BROW;
        /// <summary>
        /// 打标1对多功能，值对应的是相应的PCS数
        /// </summary>
        public static int Product_STAMP_TON;

        /// <summary>
        /// 改变显示区块大小为1，不改变为0 （默认30mm*20mm）
        /// </summary>
        public static int Product_VIEW_MODE;
        /// <summary>
        /// 改变显示区块长度为多少mm
        /// </summary>
        public static int Product_VIEW_MARK_X;
        /// <summary>
        /// 改变显示区块宽度为多少mm
        /// </summary>
        public static int Product_VIEW_MARK_Y;

        /// <summary>
        /// 打标的坐标 单位10μm
        /// </summary>
        public static Dictionary<int, Point[]> MarkPoint = new Dictionary<int, Point[]>();
        /// <summary>
        /// 显示区块的坐标 单位10μm
        /// </summary>
        public static List<Point> BlockPoint = new List<Point>();
        internal static string MType="TO1";
        #endregion
    }
}
