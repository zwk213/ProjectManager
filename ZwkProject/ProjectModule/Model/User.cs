using System;
using System.Collections.Generic;
using System.Text;
using EFHelper.Model;
using ProjectModule.Enum;

namespace ProjectModule.Model
{
    public class User : BaseModel
    {

        public string ProjectId { get; set; }

        /// <summary>
        /// 用户表中的编码
        /// </summary>
        public string UserId { get; set; }

        public string UserName { get; set; }
        
        public string Phone { get; set; }

        public string Email { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        public string Post { get; set; }

        public string Company { get; set; }

        public string Remark { get; set; }

        public UserStatus Status { get; set; }

    }
}
