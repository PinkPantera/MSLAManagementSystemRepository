using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSLAManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.Data.SQLServer.Configuration
{
    public class BuildingConfiguration : IEntityTypeConfiguration<Building>
    {
        public void Configure(EntityTypeBuilder<Building> builder)
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
                 .Property(m => m.Number)
                 .IsRequired()
                 .HasMaxLength(10);

            builder
                .Property(m => m.Street)
                .IsRequired()
                .HasMaxLength(40);

            builder
                .Property(m => m.Region)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(m => m.Town)
                .IsRequired()
                .HasMaxLength(40);

            builder
                .Property(m => m.Country)
                .IsRequired()
                .HasMaxLength(40);

            builder
                .Property(m => m.СityСode)
                .IsRequired()
                .HasMaxLength(10);

            builder
                .HasOne(m => m.ControlPost)
                .WithMany(a => a.Buildings)
                .HasForeignKey(m => m.ControlPostId);

            builder
                .ToTable("Buildings");

        }
    }
}
