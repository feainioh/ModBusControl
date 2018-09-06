using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECInspect
{
    /// <summary>
    /// 配置文件
    /// </summary>
    partial class INIFileValue
    {
        //---------Config.ini文件保存参数-------Section和Key-------
        #region SANTEC文件

        #region COM
        public const string gl_inisection_COM = "COM";      //串口
        public const string gl_iniKey_EC_COM = "EC";
        public const string gl_iniKey_PLC_COM = "PLC";
        public const string gl_iniKey_ReadCard_COM = "ReadCard";
        public const string gl_iniKey_Scan_COM = "Scan";
        #endregion
        #region AXIS
        public const string gl_inisection_AXIS = "AXIS";    //轴
        public const string gl_iniKey_DotAxis_Max = "Dot_MAX";
        public const string gl_iniKey_DotAxis_Min = "Dot_MIN";
        public const string gl_iniKey_XAxis_Max = "X_MAX";
        public const string gl_iniKey_XAxis_Min = "X_MIN";
        public const string gl_iniKey_YAxis_Max = "Y_MAX";
        public const string gl_iniKey_YAxis_Min = "Y_MIN";
        public const string gl_iniKey_CarryAxis_Max = "Carry_MAX";
        public const string gl_iniKey_CarryAxis_Min = "Carry_MIN";
        public const string gl_iniKey_CCDAxis_Max = "CCD_MAX";
        public const string gl_iniKey_CCDAxis_Min = "CCD_MIN";
        #endregion
        #region CCD
        public const string gl_inisection_CCD = "CCD";      //相机
        public const string gl_iniKey_CCDSN = "CCDSN";
        public const string gl_iniKey_AxisX_Std = "AxisX_Std";//制作模版时，X轴位置
        public const string gl_iniKey_AxisY_Std = "AxisY_Std";//制作模版时，Y轴位置
        public const string gl_iniKey_MarkX_Std = "MarkX_Std";//制作模版时，抓取的Mark点X
        public const string gl_iniKey_MarkY_Std = "MarkY_Std";//制作模版时，抓取的Mark点Y
        #endregion
        #region OpeneVision
        public const string gl_inisection_OpeneVision = "OpeneVision"; //OpeneVision
        public const string gl_iniKey_MatchFile = "MatchFile";
        #endregion
        #region BarcodeGun
        public const string gl_inisection_BarcodeGun = "BarcodeGun";
        public const string gl_iniKey_BarcodeGunEnable = "BarcodeGunEnable";
        public const string gl_inisection_BarcodeScan = "BarcodeScan";
        public const string gl_iniKey_BarcodeScanEnable = "BarcodeScanEnable";
        #endregion

        #region dot radian
        public const string gl_inisection_Tan = "Tan";
        public const string gl_iniKey_Dot_Coordinate_Angle = "Dot_Coordinate_Angle";
        #endregion

        #region UPdateSql
        public const string gl_inisection_UpdateSql = "SQL";
        public const string gl_iniKey_UpdateSql = "UpdateSql";
        public const string gl_iniKey_SqlName = "SqlName";
        public const string gl_iniKey_FlowId = "FlowId";
        #endregion
        #region CCD_Origin
        public const string gl_inisection_CCDOrigin = "CCD_Origin";
        public const string gl_iniKey_CCDOrigin_X = "Origin_X";
        public const string gl_iniKey_CCDOrigin_Y = "Origin_Y";
        #endregion
        #endregion

        #region Product文件

        #region 步骤情况
        public const string gl_inisection_STEP = "步骤情况";        //步骤
        public const string gl_iniKey_N = "N";
        public const string gl_iniKey_MAC_XY = "MAC_XY";
        #endregion
        #region 制品情况
        public const string gl_inisection_PRODUCT = "制品情况";  //制品情况
        public const string gl_iniKey_NAME = "NAME";
        public const string gl_iniKey_GROUP = "GROUP";
        public const string gl_iniKey_OKURI = "OKURI";
        public const string gl_iniKey_PITCH = "PITCH";
        public const string gl_iniKey_TOMBO = "TOMBO";
        public const string gl_iniKey_MARK_X_STD = "MARK_X_STD";
        public const string gl_iniKey_MARK_Y_STD = "MARK_Y_STD";
        public const string gl_iniKey_TRL = "TRL";
        public const string gl_iniKey_NK = "NK";
        #endregion
        #region OFFSET情况
        public const string gl_inisection_OFFSET = "OFFSET情况";  //OFFSET情况
        public const string gl_iniKey_JIGU_OFFSET = "JIGU_OFFSET";
        public const string gl_iniKey_SEARCH_OFFSET = "SEARCH_OFFSET";
        #endregion
        #region 画像模式
        public static string gl_inisection_Image = "画像模式";      //画像模式
        public const string gl_iniKey_CM_DELAY = "CM_DELAY";
        public const string gl_iniKey_CM_RETRY = "CM_RETRY";
        public const string gl_iniKey_CM_MODE = "CM_MODE";
        #endregion
        #region 找点设定
        public const string gl_inisection_POINTSET = "找点设定";  //找点设定
        public const string gl_iniKey_AL_MARK = "AL_MARK";
        public const string gl_iniKey_AL_MODE = "AL_MODE";
        public const string gl_iniKey_AL_FINE = "AL_FINE";
        public const string gl_iniKey_AL_NUM = "AL_NUM";
        #endregion
        #region 打标设定
        public const string gl_inisection_MARKSET = "打标设定";  //打标设定
        public const string gl_iniKey_STAMP_ENABLE = "STAMP_ENABLE";
        public const string gl_iniKey_STAMP_ON = "STAMP_ON";
        public const string gl_iniKey_AIR_BROW = "AIR_BROW";
        public const string gl_iniKey_STAMP_TON = "STAMP_TON";
        #endregion
        #region 打标设定
        public const string gl_inisection_VIEWSET = "显示区块设定";  //显示区块设定
        public const string gl_iniKey_VIEW_MODE = "VIEW_MODE";
        public const string gl_iniKey_VIEW_MARK_X = "VIEW_MARK_X";
        public const string gl_iniKey_VIEW_MARK_Y = "VIEW_MARK_Y";
        #endregion
        #region 位置设定 单位10μm
        public const string gl_inisection_LOCATIONSET = "位置设定单位10um";  //位置设定 单位10μm
        #endregion

        #endregion
    }
}
