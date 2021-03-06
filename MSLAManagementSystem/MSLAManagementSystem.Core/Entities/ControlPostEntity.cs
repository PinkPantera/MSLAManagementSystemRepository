﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MSLAManagementSystem.Core.Entities
{
    public class ControlPostEntity: BasicEntity
    {
        public int AddressId { get; set; }
        public AddressEntity Address { get; set; }
        public string Phone { get; set; }
        public ICollection<BuildingEntity> Buildings { get;} = new Collection<BuildingEntity>();
        public ICollection<AttendanceLogEntity> AttendanceLogs { get; } = new Collection<AttendanceLogEntity>();
    }
}
