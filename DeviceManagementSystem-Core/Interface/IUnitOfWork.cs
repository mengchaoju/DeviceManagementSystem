using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManagementSystem_Core.Interface
{
    public interface IUnitOfWork
    {
        Task<bool> SaveAsync();
    }
}
