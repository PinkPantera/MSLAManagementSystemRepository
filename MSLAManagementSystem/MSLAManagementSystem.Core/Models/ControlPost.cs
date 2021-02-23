using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MSLAManagementSystem.Core.Models
{
    public class ControlPost: BasicModel
    {
        public int AdressId { get; set; }
        public Adress Adress { get; set; }
        public string Phone { get; set; }
        public ICollection<Building> Buildings { get;} = new Collection<Building>();
        public ICollection<AttendanceLog> AttendanceLogs { get; } = new Collection<AttendanceLog>();
    }
}
