using DeviceManagementSystem_Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManagementSystem_Core.Interface
{
    public interface IDeviceRepository
    {
        Task<PageList<Device>> GetAllDevicesAsync(DeviceParameters deviceParameters);
        void AddDevice(Device device);
        Task<Device> GetDeviceByIdAsync(int id);
    }

}
