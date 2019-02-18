using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserModule.Model;

namespace UserModule.Map
{
    public class UserInGroupMap : IEntityTypeConfiguration<UserInGroup>
    {
        public void Configure(EntityTypeBuilder<UserInGroup> builder)
        {
            builder.ToTable("u_user_in_group");
            builder.Property(p => p.PrimaryKey).HasColumnName("primary_key");
            builder.Property(p => p.CreateDate).HasColumnName("create_date").HasColumnType("datetime");
            builder.Property(p => p.CreateBy).HasColumnName("create_by");
            builder.Property(p => p.UpdateDate).HasColumnName("update_date").HasColumnType("datetime");
            builder.Property(p => p.UpdateBy).HasColumnName("update_by");

            builder.Property(p => p.UserId).HasColumnName("user_id");
            builder.Property(p => p.UserName).HasColumnName("user_name");
            builder.Property(p => p.GroupId).HasColumnName("group_id");
            builder.Property(p => p.GroupName).HasColumnName("group_name");
        }
    }
}
