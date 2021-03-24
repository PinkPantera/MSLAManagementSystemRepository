using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSLAManagementSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.Data.SQLServer.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(m => m.LastNAme)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(m => m.LastNAme)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(m => m.UserName)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(m => m.PasswordHash)
                .IsRequired();

            builder
                .Property(m => m.PasswordKey)
                .IsRequired();

            builder
              .Property(m => m.CreatedDate)
              .HasDefaultValueSql("GETDATE()");

            builder
                .ToTable("Users");
        }
    }
}
