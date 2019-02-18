using System;
using System.Collections.Generic;
using System.Text;
using EFHelper.Model;
using ProjectModule.Enum;

namespace ProjectModule.Model
{
    public class File : BaseModel
    {
        public string ProjectId { get; set; }

        public string ScheduleId { get; set; }

        public string FolderId { get; set; }

        public string Name { get; set; }

        public string Link { get; set; }

        public string Remark { get; set; }

        public string UpdateName { get; set; }

        public FileStatus Status { get; set; }

    }
}
