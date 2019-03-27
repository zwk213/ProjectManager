using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using EFHelper.Model;
using ValidateHelper;

namespace ProjectModule.Model
{
    public class LinkGroup : BaseModel
    {
        public string ProjectId { get; set; }

        public string Name { get; set; }

        //用于决定用哪个字段进行关联
        [ForeignKey("GroupId")]
        public virtual List<Link> Links { get; set; }

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
