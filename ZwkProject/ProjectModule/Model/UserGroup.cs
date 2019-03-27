using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using EFHelper.Model;
using ValidateHelper;

namespace ProjectModule.Model
{
    public class UserGroup : BaseModel
    {
        public string ProjectId { get; set; }

        public string Name { get; set; }

        [ForeignKey("GroupId")]
        public virtual List<User> Users { get; set; }

        public override void Validate()
        {
            base.Validate();
            ProjectId.HasValue("项目编码不能为空").MaxLength(50, "项目编码限制长度50");
            Name.HasValue("组名不能为空").MaxLength(50, "组名限制长度50");
        }

        public void UpdateFrom(User user)
        {
            base.UpdateFrom(user);
        }

    }
}
