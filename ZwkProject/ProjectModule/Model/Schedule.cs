using System;
using System.Collections.Generic;
using System.Text;
using EFHelper.Model;
using ProjectModule.Enum;

namespace ProjectModule.Model
{
    public class Schedule : BaseModel
    {
        public string ProjectId { get; set; }

        public string Name { get; set; }

        public string Remark { get; set; }

        public Priority Priority { get; set; }

        public ScheduleStatus Status { get; set; }

    }
}
