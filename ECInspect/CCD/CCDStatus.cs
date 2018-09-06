using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECInspect
{
    /// <summary>
    /// 相机状态
    /// </summary>
    enum CCDStatus : byte
    {
        /// <summary>
        /// 连接丢失
        /// </summary>
        ConnectionLost,
        /// <summary>
        /// 相机开启
        /// </summary>
        CameraOpened,
        /// <summary>
        /// 相机关闭
        /// </summary>
        CameraClosed
    }

    enum CCDGrabStatus : byte
    {
        /// <summary>
        /// 开始
        /// </summary>
        Start,
        /// <summary>
        /// 停止
        /// </summary>
        Stop
    }
}
