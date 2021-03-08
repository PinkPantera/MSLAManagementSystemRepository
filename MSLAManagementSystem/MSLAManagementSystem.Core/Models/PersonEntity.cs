using MSLAManagementSystem.Core.ModelsInterfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MSLAManagementSystem.Core.Models
{
    public class PersonEntity: BasicEntity, IPerson
    {
        public PersonEntity()
        {
            AttendanceLogs = new Collection<AttendanceLogEntity>();
        }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdentityCard { get; set; }
        public int? AdressId { get; set; }
        public AdressEntity Adress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }

        public ICollection<AttendanceLogEntity> AttendanceLogs { get; set; }
        
    }
}
