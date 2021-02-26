using Microsoft.EntityFrameworkCore;
using MSLAManagementSystem.Core.Models;
using MSLAManagementSystem.Data.SQLServer.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.Data.SQLServer
{
    public class ManagementSystemDbContext: DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<ControlPost> ControlPosts { get; set; }
        public DbSet<AttendanceLog> AttendanceLogs { get; set; }

        public ManagementSystemDbContext(DbContextOptions<ManagementSystemDbContext> options)
            :base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PersonConfiguration());
            builder.ApplyConfiguration(new AdressConfiguration());
            builder.ApplyConfiguration(new BuildingConfiguration());
            builder.ApplyConfiguration(new ControlPostConfiguration());
            builder.ApplyConfiguration(new AttendanceLogConfiguration());
        }
    }
}
