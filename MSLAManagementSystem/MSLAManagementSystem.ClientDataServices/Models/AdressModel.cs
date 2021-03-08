using MSLAManagementSystem.Core.ModelsInterfaces;
using System;

namespace MSLAManagementSystem.ClientDataServices.Models
{
    public class AdressModel : IAdress
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public string Town { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string СityСode { get; set; }

        public DateTime CreatedDate { get; set; }

        public override string ToString()
        {
            var addres = HouseNumber;
            if (!string.IsNullOrEmpty(ApartmentNumber))
            {
                addres = $" {ApartmentNumber}, {addres}";
            }

                return $" {addres} {Street} \n {СityСode}, {Town} {Region} {Country}";
            }
        }
    }
