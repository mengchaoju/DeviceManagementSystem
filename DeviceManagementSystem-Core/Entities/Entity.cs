using DeviceManagementSystem_Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceManagementSystem_Core.Entities
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}
