using System;
using System.Collections.Generic;
using System.Text;
using EFHelper.Model;

namespace ProjectModule.Model
{
    public class Folder : BaseModel
    {

        public string ProjectId { get; set; }

        public string ScheduleId { get; set; }

        public string ParentId { get; set; }

        public string Name { get; set; }

    }
}
