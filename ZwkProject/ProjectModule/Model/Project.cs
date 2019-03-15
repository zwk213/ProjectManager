using System;
using System.Collections.Generic;
using System.Text;
using EFHelper.Model;
using ProjectModule.Enum;
using ValidateHelper;

namespace ProjectModule.Model
{
    public class Project : BaseModel
    {

        public string Name { get; set; }

        public string Logo { get; set; }

        public ProjectStatus Status { get; set; }

        public ProjectType Type { get; set; }

        /// <summary>
        /// 验证模型是否符合要求
        /// </summary>
        public void Validate()
        {
            PrimaryKey.HasValue("主键必填").MaxLength(50, "主键最大长度50");
            Name.HasValue("姓名必填").MaxLength(50, "姓名最大长度50");
            Logo.HasValue("Logo必填").MaxLength(50, "Logo最大长度50");
        }

        /// <summary>
        /// 从指定模型类更新数据
        /// 只更新需要更新的字段
        /// </summary>
        /// <param name="project"></param>
        public void UpdateFrom(Project project)
        {
            Name = project.Name;
            Logo = project.Logo;
            Status = project.Status;
            Type = project.Type;
            UpdateBy = project.UpdateBy;
            UpdateDate = project.UpdateDate;
        }

    }
}
