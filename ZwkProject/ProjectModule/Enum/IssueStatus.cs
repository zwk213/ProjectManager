using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectModule.Enum
{
    public enum IssueStatus
    {
        /// <summary>
        /// 待处理
        /// </summary>
        New = 0,

        /// <summary>
        /// 待复测
        /// </summary>
        WaitValidate = 1,

        /// <summary>
        /// 已处理
        /// </summary>
        Processed = 2,

        /// <summary>
        /// 暂停
        /// </summary>
        Suspend = 3,

        /// <summary>
        /// 取消
        /// </summary>
        Cancel = 4,

    }
}
