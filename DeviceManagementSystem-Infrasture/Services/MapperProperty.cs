using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceManagementSystem_Infrasture.Services
{
    public class MapperProperty
    {
        public string Name { get; set; }
        //排序是否相反（日期和时间长短）
        public bool Revert { get; set; }
    }
}
