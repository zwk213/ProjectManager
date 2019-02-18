using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using EFHelper.Model;

namespace LogModule.Model
{
    public class OperatingLog : BaseModel
    {
        public OperatingLog()
        {
        }

        /// <summary>
        /// 摘要
        /// 格式：某个人做了某件事
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Model
        /// 涉及模型类的序列化数据
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// 操作对象编码
        /// 例如项目编码，订单编码等概念
        /// </summary>
        public string LinkId { get; set; }

    }

}
