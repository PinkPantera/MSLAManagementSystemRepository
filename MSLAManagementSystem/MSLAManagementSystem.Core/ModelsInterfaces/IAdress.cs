using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.Core.ModelsInterfaces
{
    public interface IAdress : IBasicModel
    {
        int Id { get; set; }
        string Street { get; set; }
        string HouseNumber { get; set; }
        string ApartmentNumber { get; set; }
        string Town { get; set; }
        string Region { get; set; }
        string Country { get; set; }
        string СityСode { get; set; }
    }
}
