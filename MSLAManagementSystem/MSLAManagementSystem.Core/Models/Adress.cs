using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.Core.Models
{
    public class Adress: BasicModel
    {
        public string Street { get; set; }
        public string HouseNumber  { get; set; }
        public string ApartmentNumber { get; set; }
        public string Town { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string СityСode { get; set; }
    }
}
