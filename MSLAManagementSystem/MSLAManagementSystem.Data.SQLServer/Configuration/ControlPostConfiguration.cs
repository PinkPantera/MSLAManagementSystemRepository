﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSLAManagementSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.Data.SQLServer.Configuration
{
    public class ControlPostConfiguration : IEntityTypeConfiguration<ControlPostEntity>
    {
        public void Configure(EntityTypeBuilder<ControlPostEntity> builder)
        {
            builder.HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.Phone)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(m => m.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

            builder
                .ToTable("ControlPosts");
        }
    }
}
