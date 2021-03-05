using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MSLAManagementSystem.Core.Models
{
    public class ControlPostEntity: BasicEntity
    {
        public int AdressId { get; set; }
        public AdressEntity Adress { get; set; }
        public string Phone { get; set; }
        public ICollection<BuildingEntity> Buildings { get;} = new Collection<BuildingEntity>();
        public ICollection<AttendanceLogEntity> AttendanceLogs { get; } = new Collection<AttendanceLogEntity>();
    }
}
