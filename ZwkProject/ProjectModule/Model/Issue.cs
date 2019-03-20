using System;
using System.Collections.Generic;
using System.Text;
using EFHelper.Model;
using ProjectModule.Enum;
using ValidateHelper;

namespace ProjectModule.Model
{
    public class Issue : BaseModel
    {

        public string ScheduleId { get; set; }
        public string ScheduleName { get; set; }

        public string ProjectId { get; set; }

        public string Summary { get; set; }

        public string Detail { get; set; }

        public IssueStatus Status { get; set; }

        public Priority Priority { get; set; }

        public string CreateName { get; set; }

        public string PrincipalId { get; set; }

        public string PrincipalName { get; set; }

        public override void Validate()
        {
            base.Validate();
            ScheduleId.HasValue("时间节点编码不能为空").MaxLength(50, "时间节点编码限制长度50");
            ScheduleName.HasValue("时间节点不能为空").MaxLength(50, "时间节点限制长度50");
            ProjectId.HasValue("项目编码不能为空").MaxLength(50, "项目编码限制长度50");
            Summary.HasValue("问题摘要不能为空").MaxLength(50, "问题摘要限制长度200");
            //Detail.HasValue("问题详情不能为空").MaxLength(50, "问题详情限制长度200");
            CreateName.HasValue("创建人不能为空").MaxLength(50, "创建人限制长度50");
            PrincipalId.HasValue("负责人编码不能为空").MaxLength(50, "负责人编码限制长度50");
            PrincipalName.HasValue("负责人不能为空").MaxLength(50, "负责人限制长度50");
        }

        public void UpdateFrom(Issue issue)
        {
            base.UpdateFrom(issue);
            ScheduleId = issue.ScheduleId;
            ScheduleName = issue.ScheduleName;
            //ProjectId = issue.ProjectId;
            Summary = issue.Summary;
            Detail = issue.Detail;
            Status = issue.Status;
            Priority = issue.Priority;
            //CreateName = issue.CreateName;
            PrincipalId = issue.PrincipalId;
            PrincipalName = issue.PrincipalName;
        }

    }
}
