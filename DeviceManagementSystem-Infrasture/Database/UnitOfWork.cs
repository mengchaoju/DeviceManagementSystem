using DeviceManagementSystem_Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManagementSystem_Infrasture.Database
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyContext myContext1;

        public UnitOfWork(MyContext myContext)
        {
            myContext1 = myContext;
        }

        public async Task<bool> SaveAsync()
        {
            return await myContext1.SaveChangesAsync() > 0;
        }
    }
}
