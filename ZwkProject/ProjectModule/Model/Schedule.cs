using System;
using System.Collections.Generic;
using System.Text;
using EFHelper.Model;
using ProjectModule.Enum;
using ValidateHelper;

namespace ProjectModule.Model
{
    public class Schedule : BaseModel
    {

        public string ProjectId { get; set; }

        public string Name { get; set; }

        public string Remark { get; set; }

        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }

        public override void Validate()
        {
            base.Validate();
            Name.HasValue("节点名称必填").MaxLength(50, "节点名称限制长度50");
            Remark.HasValue("节点内容必填").MaxLength(50, "节点内容限制长度50");
        }

        public void UpdateFrom(Schedule model)
        {
            base.UpdateFrom(model);
            Name = model.Name;
            Remark = model.Remark;
            Start = model.Start;
            End = model.End;
        }

    }

}
