using MSLAManagementSystem.Core.ModelsInterfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MSLAManagementSystem.Core.Models
{
    public class AddressEntity: BasicEntity, IAddress
    {
        public string ShortAddress { get; set; }
        public string Town { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string CityCode { get; set; }
    }
}
