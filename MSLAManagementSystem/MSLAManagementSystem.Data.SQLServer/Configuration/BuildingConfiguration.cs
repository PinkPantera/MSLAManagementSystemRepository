using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSLAManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.Data.SQLServer.Configuration
{
    public class BuildingConfiguration : IEntityTypeConfiguration<BuildingEntity>
    {
        public void Configure(EntityTypeBuilder<BuildingEntity> builder)
        {
            builder.HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(m => m.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

            builder
                .HasOne(m => m.ControlPost)
                .WithMany(a => a.Buildings)
                .HasForeignKey(m => m.ControlPostId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .ToTable("Buildings");

        }
    }
}
