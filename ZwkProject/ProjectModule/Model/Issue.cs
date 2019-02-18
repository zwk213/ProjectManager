using System;
using System.Collections.Generic;
using System.Text;
using EFHelper.Model;
using ProjectModule.Enum;

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
    }
}
