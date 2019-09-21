 using DeviceManagementSystem_Core.Entities;
using DeviceManagementSystem_Infrasture.Database.EntityConfigurations;
using DeviceManagementSystem_Infrasture.Database.EntityConstraint;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceManagementSystem_Infrasture.Database
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new DeviceConfiguaration());

        }

        public DbSet<Device> Devices { get; set; }
    }
}
