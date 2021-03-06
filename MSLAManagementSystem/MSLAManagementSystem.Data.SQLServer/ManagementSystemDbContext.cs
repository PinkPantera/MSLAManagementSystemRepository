﻿using Microsoft.EntityFrameworkCore;
using MSLAManagementSystem.Core.Entities;
using MSLAManagementSystem.Data.SQLServer.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.Data.SQLServer
{
    public class ManagementSystemDbContext: DbContext
    {
        public DbSet<PersonEntity> Persons { get; set; }
        public DbSet<AddressEntity> Addresses { get; set; }
        public DbSet<BuildingEntity> Buildings { get; set; }
        public DbSet<ControlPostEntity> ControlPosts { get; set; }
        public DbSet<AttendanceLogEntity> AttendanceLogs { get; set; }
        public DbSet<PhotoEntity> Photos { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        public ManagementSystemDbContext(DbContextOptions<ManagementSystemDbContext> options)
            :base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PersonConfiguration());
            builder.ApplyConfiguration(new AddressConfiguration());
            builder.ApplyConfiguration(new BuildingConfiguration());
            builder.ApplyConfiguration(new ControlPostConfiguration());
            builder.ApplyConfiguration(new AttendanceLogConfiguration());
            builder.ApplyConfiguration(new PhotoConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
