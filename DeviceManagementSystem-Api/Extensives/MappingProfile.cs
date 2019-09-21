using AutoMapper;
using DeviceManagementSystem_Core.Entities;
using DeviceManagementSystem_Infrasture.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManagementSystem_Api.Extensives
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Device, DeviceResource>();
            CreateMap<DeviceResource, Device>();
        }

    }
}
