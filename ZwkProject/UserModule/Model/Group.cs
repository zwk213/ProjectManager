using System;
using System.Collections.Generic;
using System.Text;
using EFHelper.Model;
using UserModule.Enum;

namespace UserModule.Model
{
    public class Group : BaseModel
    {
        public string GroupName { get; set; }

        public string ParentId { get; set; }

        public string ParentName { get; set; }

        public GroupType Type { get; set; }

        public virtual List<UserInGroup> Users { get; set; }
    }
}
