using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSLAManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.Data.SQLServer.Configuration
{
    public class AttendanceLogConfiguration : IEntityTypeConfiguration<AttendanceLog>
    {
        public void Configure(EntityTypeBuilder<AttendanceLog> builder)
        {
            builder.HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.Date)
                .IsRequired();

            builder
                .Property(m => m.TimeBegin)
                .IsRequired();

            builder
                .Property(m => m.TimeEnd)
                .IsRequired();

            builder
                .HasOne(m => m.Person)
                .WithMany(a => a.AttendanceLogs)
                .HasForeignKey(m => m.PersonId);

            builder
                .HasOne(m => m.ControlPost)
                .WithMany(a => a.AttendanceLogs)
                .HasForeignKey(m => m.ControlPostId);
 
            builder
                .ToTable("AttendanceLogs");
        }
    }
}
