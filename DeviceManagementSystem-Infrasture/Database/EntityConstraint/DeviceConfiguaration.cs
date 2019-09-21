using DeviceManagementSystem_Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceManagementSystem_Infrasture.Database.EntityConstraint
{
    public class DeviceConfiguaration: IEntityTypeConfiguration<Device>
    {

        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
//            builder.Property(x => x.LastMaintain).IsRequired();
//            builder.Property(x => x.Owner).IsRequired().HasMaxLength(50);
        }
    };
}
