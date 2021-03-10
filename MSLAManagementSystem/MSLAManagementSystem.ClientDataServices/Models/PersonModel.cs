using MSLAManagementSystem.Core.ModelsInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MSLAManagementSystem.ClientDataServices.Models
{
    public class PersonModel : IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdentityCard { get; set; }
        public int? AddressId { get; set; }
        public AddressModel Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Active { get; set ; }
        public int? PhotoId { get ; set ; }
        public PhotoModel Photo { get; set; }

       // public event PropertyChangedEventHandler PropertyChanged;
    }
}
