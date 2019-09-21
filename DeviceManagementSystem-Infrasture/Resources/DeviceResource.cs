using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceManagementSystem_Infrasture.Resources
{
    public class DeviceResource
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
        public DateTime LastMaintain { get; set; }
        public string Type { get; set; }
    }
}
