using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceManagementSystem_Core.Entities
{
    public class Device : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
        public DateTime LastMaintain { get; set; }
        public string Type { get; set; }
    }
}
