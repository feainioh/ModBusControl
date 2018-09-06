using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECInspect
{
    /// <summary>
    ///     测试结果
    /// </summary>
    class TestResult
    {
        /// <summary>
        ///    sheet条码
        /// </summary>
        public string ShtBarcode="";

        /// <summary>
        ///     NG位置
        /// </summary>
       public int PcsIndex;

       /// <summary>
       ///     整张制品结果
       /// </summary>
       public int Result;


       /// <summary>
       ///     FlowID
       /// </summary>
       public int FlowId;

       /// <summary>
       ///     测试
       /// </summary>
       public string CreateUser="TOEC";

       /// <summary>
       ///     测试时间
       /// </summary>
       public DateTime CreateDate;

    }
}
