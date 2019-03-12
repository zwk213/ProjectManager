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

        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }

    }

}
