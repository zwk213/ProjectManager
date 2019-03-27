using System;
using System.Collections.Generic;
using System.Text;
using EFHelper.Model;
using ProjectModule.Enum;
using ValidateHelper;

namespace ProjectModule.Model
{
    public class User : BaseModel
    {

        public string ProjectId { get; set; }

        public string GroupId { get; set; }

        /// <summary>
        /// 用户表中的编码
        /// </summary>
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Company { get; set; }

        public string Remark { get; set; }

        public UserStatus Status { get; set; }

        public override void Validate()
        {
            base.Validate();
            ProjectId.HasValue("项目编码不能为空").MaxLength(50, "项目编码限制长度50");
            GroupId.HasValue("用户组不能为空").MaxLength(50, "用户组限制长度50");
            UserId.HasValue("用户编码不能为空").MaxLength(50, "用户编码限制长度50");
            UserName.HasValue("用户名不能为空").MaxLength(50, "用户名限制长度50");
            Phone.HasValue("手机号不能为空").MaxLength(50, "手机号限制长度50");
            Email.HasValue("邮箱不能为空").MaxLength(50, "邮箱限制长度50");
            Company.HasValue("公司不能为空").MaxLength(50, "公司限制长度50");
        }

        public void UpdateFrom(User user)
        {
            base.UpdateFrom(user);
            Remark = user.Remark;
        }



    }
}
