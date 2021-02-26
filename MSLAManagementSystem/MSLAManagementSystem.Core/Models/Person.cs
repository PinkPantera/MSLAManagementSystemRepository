using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MSLAManagementSystem.Core.Models
{
    public class Person: BasicModel
    {
        public Person()
        {
            AttendanceLogs = new Collection<AttendanceLog>();
        }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int Age { get; set; }
        public string IdentityCard { get; set; }
        public int? AdressId { get; set; }
        public Adress Adress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public ICollection<AttendanceLog> AttendanceLogs { get; set; } 
    }
}
