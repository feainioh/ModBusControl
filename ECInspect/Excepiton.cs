using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECInspect
{
    #region 异常类
    /// <summary>
    /// PLC复位
    /// </summary>
    class ResetPLC : ApplicationException
    {
        internal ResetPLC(string msg)
            : base(msg)
        { }
    }

    /// <summary>
    /// 段取取消
    /// </summary>
    class PrepareCancle : ApplicationException
    {
        internal PrepareCancle(string msg)
            : base(msg)
        {

        }
    }

    /// <summary>
    /// EC反馈异常
    /// </summary>
    class ECAnswerErr : ApplicationException
    {
        internal ECAnswerErr(string msg)
            : base(msg)
        {

        }
    }

    /// <summary>
    /// 条码枪异常
    /// </summary>
    class ScanErr : ApplicationException
    {
        internal ScanErr(string msg)
            :base(msg)
        {

        }
    }

    /// <summary>
    /// 读取条码为空异常
    /// </summary>
    class OtherErr : ApplicationException
    {
        internal OtherErr(string msg)
            : base(msg)
        {

        }
    }
    #endregion
}
