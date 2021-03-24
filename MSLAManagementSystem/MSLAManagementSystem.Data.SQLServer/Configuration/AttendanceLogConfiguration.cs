using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSLAManagementSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.Data.SQLServer.Configuration
{
    public class AttendanceLogConfiguration : IEntityTypeConfiguration<AttendanceLogEntity>
    {
        public void Configure(EntityTypeBuilder<AttendanceLogEntity> builder)
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
                .Property(m => m.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

            builder
                .HasOne(m => m.Person)
                .WithMany(a => a.AttendanceLogs)
                .HasForeignKey(m => m.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(m => m.ControlPost)
                .WithMany(a => a.AttendanceLogs)
                .HasForeignKey(m => m.ControlPostId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .ToTable("AttendanceLogs");
        }
    }
}
