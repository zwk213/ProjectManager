using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectModule.Model;

namespace ProjectModule.Map
{
    public class ScheduleMap : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.ToTable("p_schedule");
            builder.Property(p => p.PrimaryKey).HasColumnName("primary_key");
            builder.Property(p => p.CreateDate).HasColumnName("create_date").HasColumnType("datetime");
            builder.Property(p => p.CreateBy).HasColumnName("create_by");
            builder.Property(p => p.UpdateDate).HasColumnName("update_date").HasColumnType("datetime");
            builder.Property(p => p.UpdateBy).HasColumnName("update_by");

            builder.Property(p => p.ProjectId).HasColumnName("project_id");
            builder.Property(p => p.Name).HasColumnName("name");
            builder.Property(p => p.Remark).HasColumnName("remark");

            builder.Property(p => p.Start).HasColumnName("start").HasColumnType("datetime");
            builder.Property(p => p.End).HasColumnName("end").HasColumnType("datetime");
        }
    }
}
