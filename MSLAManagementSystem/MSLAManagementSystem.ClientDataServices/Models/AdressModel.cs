using MSLAManagementSystem.Core.ModelsInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.ClientDataServices.Models
{
    public class AdressModel : IAdress
    {   
        public int Id { get ; set; }
        public string Street { get ; set; }
        public string HouseNumber { get; set ; }
        public string ApartmentNumber { get; set; }
        public string Town { get; set ; }
        public string Region { get ; set ; }
        public string Country { get ; set ; }
        public string СityСode { get; set; }

        public DateTime CreatedDate { get ; set ; }
    }
}
