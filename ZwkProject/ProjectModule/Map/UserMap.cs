using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectModule.Model;

namespace ProjectModule.Map
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("p_user");
            builder.Property(p => p.PrimaryKey).HasColumnName("primary_key");
            builder.Property(p => p.CreateDate).HasColumnName("create_date").HasColumnType("datetime");
            builder.Property(p => p.CreateBy).HasColumnName("create_by");
            builder.Property(p => p.UpdateDate).HasColumnName("update_date").HasColumnType("datetime");
            builder.Property(p => p.UpdateBy).HasColumnName("update_by");

            builder.Property(p => p.ProjectId).HasColumnName("project_id");
            builder.Property(p => p.UserId).HasColumnName("user_id");
            builder.Property(p => p.UserName).HasColumnName("user_name");
            builder.Property(p => p.Post).HasColumnName("post");
            builder.Property(p => p.Phone).HasColumnName("phone");
            builder.Property(p => p.Email).HasColumnName("email");
            builder.Property(p => p.Company).HasColumnName("company");
            builder.Property(p => p.Remark).HasColumnName("remark");
            builder.Property(p => p.Status).HasColumnName("status");
        }
    }
}
