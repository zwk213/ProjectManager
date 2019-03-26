using System;
using System.Collections.Generic;
using System.Text;
using EFHelper.Model;
using ProjectModule.Enum;
using ValidateHelper;

namespace ProjectModule.Model
{
    public class Link : BaseModel
    {
        public string ProjectId { get; set; }

        public string GroupId { get; set; }

        public string Name { get; set; }

        public string Href { get; set; }

        public string Remark { get; set; }

        public override void Validate()
        {
            base.Validate();
            ProjectId.HasValue("项目编码不能为空").MaxLength(50, "项目编码限制长度50");
            Name.HasValue("链接名称不能为空").MaxLength(50, "链接名称限制长度50");
            Href.HasValue("链接地址不能为空").MaxLength(200, "链接地址限制长度200");
            //Remark.HasValue("").MaxLength(50, "");
        }

        public void UpdateFrom(Link link)
        {
            base.UpdateFrom(link);
            //ProjectId = link.ProjectId;
            //GroupId = link.GroupId;
            Name = link.Name;
            Href = link.Href;
            Remark = link.Remark;
        }


    }
}
