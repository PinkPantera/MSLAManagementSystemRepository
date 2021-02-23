using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSLAManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.Data.SQLServer.Configuration
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
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
               .Property(m => m.SecondName)
               .IsRequired()
               .HasMaxLength(50);

            builder
               .HasOne(m => m.Adress)
               .WithMany(a => a.Persons)
               .HasForeignKey(m => m.AdressId);

            builder
                .Property(m => m.Age)
                .IsRequired();
           
            builder
                .Property(m => m.Email)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(m => m.Phone)
                .IsRequired()
                .HasMaxLength(20);

            builder
                .ToTable("Persons");
        }
    }
}
