using DeviceManagementSystem_Core.Entities;
using DeviceManagementSystem_Core.Interface;
using DeviceManagementSystem_Infrasture.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManagementSystem_Infrasture.Repositery
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly MyContext myContext1;
        public DeviceRepository(MyContext myContext)
        {
            myContext1 = myContext;
        }
        public void AddDevice(Device device)
        {
            myContext1.Devices.Add(device);
            throw new NotImplementedException();
        }

        public async Task<Device> GetPostByIdAsynnc(int id)
        {
            return await myContext1.Devices.FindAsync(id);
        }

        public async Task<PageList<Device>> GetAllDevicesAsync(DeviceParameters deviceParameters)
        {
            //根据Device Name属性搜索
            //后可添加模糊搜索

            var query = myContext1.Devices.AsQueryable();
            if (string.IsNullOrEmpty(deviceParameters.Name)) {
                var Name = deviceParameters.Name.ToLowerInvariant();
                query = query = query.Where(x => x.Name.ToLowerInvariant().Contains(Name));
            };
            query= query.OrderBy(x => x.Id);
            var count = await query.CountAsync();
            var data = await query
                .Skip(deviceParameters.PageIndex * deviceParameters.PageSize)
                .Take(deviceParameters.PageSize)
                .ToListAsync();
            return new PageList<Device>(deviceParameters.PageIndex, deviceParameters.PageSize, count, data);
            throw new NotImplementedException();
        }

        public Task<Device> GetDeviceByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
