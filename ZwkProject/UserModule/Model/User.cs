using System;
using System.Collections.Generic;
using EFHelper.Model;
using UserModule.Enum;

namespace UserModule.Model
{
    public class User : BaseModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string HeadImage { get; set; }

        public UserType Type { get; set; }

        public UserStatus Status { get; set; }

        public virtual List<UserInGroup> Groups { get; set; }

    }
}
