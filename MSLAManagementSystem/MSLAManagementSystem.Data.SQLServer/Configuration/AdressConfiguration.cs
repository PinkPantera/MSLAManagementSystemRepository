using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSLAManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.Data.SQLServer.Configuration
{
    public class AdressConfiguration : IEntityTypeConfiguration<Adress>
    {
        public void Configure(EntityTypeBuilder<Adress> builder)
        {

            builder.HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.ApartmentNumber)
                .IsRequired()
                .HasMaxLength(10);

            builder
                .Property(m => m.HouseNumber)
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
                .ToTable("Adresses");
        }
    }
}
