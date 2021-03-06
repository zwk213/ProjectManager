﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectModule.Model;

namespace ProjectModule.Map
{
    public class IssueMap : IEntityTypeConfiguration<Issue>
    {
        public void Configure(EntityTypeBuilder<Issue> builder)
        {
            builder.ToTable("p_issue");
            builder.HasKey(p => p.PrimaryKey);

            builder.Property(p => p.PrimaryKey).HasColumnName("primary_key");
            builder.Property(p => p.CreateDate).HasColumnName("create_date").HasColumnType("datetime");
            builder.Property(p => p.CreateBy).HasColumnName("create_by");
            builder.Property(p => p.UpdateDate).HasColumnName("update_date").HasColumnType("datetime");
            builder.Property(p => p.UpdateBy).HasColumnName("update_by");

            builder.Property(p => p.ProjectId).HasColumnName("project_id");
            builder.Property(p => p.ScheduleId).HasColumnName("schedule_id");
            builder.Property(p => p.ScheduleName).HasColumnName("schedule_name");
            builder.Property(p => p.Summary).HasColumnName("summary");
            builder.Property(p => p.Detail).HasColumnName("detail");
            builder.Property(p => p.CreateName).HasColumnName("create_name");
            builder.Property(p => p.PrincipalId).HasColumnName("principal_id");
            builder.Property(p => p.PrincipalName).HasColumnName("principal_name");
            builder.Property(p => p.Status).HasColumnName("status");
            builder.Property(p => p.Priority).HasColumnName("priority");
        }
    }
}
