using System;
using System.Collections.Generic;
using System.Text;
using EFHelper.Model;

namespace UserModule.Model
{
    public class UserInGroup : BaseModel
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string GroupId { get; set; }

        public string GroupName { get; set; }
    }

}
