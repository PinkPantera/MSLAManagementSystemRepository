using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSLAManagementSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.Data.SQLServer.Configuration
{
    public class AddressConfiguration : IEntityTypeConfiguration<AddressEntity>
    {
        public void Configure(EntityTypeBuilder<AddressEntity> builder)
        {

            builder.HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.ShortAddress)
                .IsRequired()
                .HasMaxLength(140);

            builder
                .Property(m => m.Region)
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
                .Property(m => m.CityCode)
                .IsRequired()
                .HasMaxLength(10);

            builder
                .Property(m => m.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

            builder
                .ToTable("Addresses");
        }
    }
}
