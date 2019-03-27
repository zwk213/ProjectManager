using System;
using System.Collections.Generic;
using EFHelper.Model;
using UserModule.Enum;
using ValidateHelper;

namespace UserModule.Model
{
    public class User : BaseModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Company { get; set; }

        public string HeadImage { get; set; }

        public UserType Type { get; set; }

        public UserStatus Status { get; set; }

        public override void Validate()
        {
            base.Validate();
            UserName.HasValue("用户名不能为空").MaxLength(50, "用户名限制长度50");
            Password.HasValue("密码不能为空").MaxLength(200, "密码限制长度50");
            Phone.HasValue("手机号不能为空").MaxLength(50, "手机号限制长度50");
            Email.HasValue("邮箱不能为空").MaxLength(200, "邮箱限制长度200");
            Company.HasValue("公司不能为空").MaxLength(200, "公司限制长度200");
            HeadImage.HasValue("头像不能为空").MaxLength(200, "头像限制长度200");
            //Remark.HasValue("").MaxLength(50, "");
        }

        public void UpdateFrom(User user)
        {
            base.UpdateFrom(user);
            //ProjectId = link.ProjectId;
            //GroupId = link.GroupId;
            UserName = user.UserName;
            Password = user.Password;
            Phone = user.Phone;
            Email = user.Email;
            Company = user.Company;
            HeadImage = user.HeadImage;
            Type = user.Type;
            Status = user.Status;
        }

    }
}
