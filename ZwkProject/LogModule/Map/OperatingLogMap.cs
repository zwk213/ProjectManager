using System;
using System.Collections.Generic;
using System.Text;
using LogModule.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogModule.Map
{
    public class OperatingLogMap : IEntityTypeConfiguration<OperatingLog>
    {
        public void Configure(EntityTypeBuilder<OperatingLog> builder)
        {
            builder.ToTable("l_operating_log");
            builder.Property(p => p.PrimaryKey).HasColumnName("primary_key");
            builder.Property(p => p.CreateDate).HasColumnName("create_date").HasColumnType("datetime");
            builder.Property(p => p.CreateBy).HasColumnName("create_by");
            builder.Property(p => p.UpdateDate).HasColumnName("update_date").HasColumnType("datetime");
            builder.Property(p => p.UpdateBy).HasColumnName("update_by");

            builder.Property(p => p.Summary).HasColumnName("summary");
            builder.Property(p => p.Model).HasColumnName("model");
            builder.Property(p => p.LinkId).HasColumnName("link_id");
        }
    }


}
