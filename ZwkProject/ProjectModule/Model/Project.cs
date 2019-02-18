using System;
using System.Collections.Generic;
using System.Text;
using EFHelper.Model;
using ProjectModule.Enum;

namespace ProjectModule.Model
{
    public class Project : BaseModel
    {

        public string Name { get; set; }

        public string Logo { get; set; }

        public ProjectStatus Status { get; set; }

        public ProjectType Type { get; set; }

    }
}
