using System;
using System.Collections.Generic;
using System.Text;
using EFHelper.Model;

namespace ProjectModule.Model
{
    public class Link : BaseModel
    {
        public string ProjectId { get; set; }

        public string Name { get; set; }

        public string Href { get; set; }

        public string Remark { get; set; }

    }
}
