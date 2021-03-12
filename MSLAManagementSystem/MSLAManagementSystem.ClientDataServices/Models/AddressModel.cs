using MSLAManagementSystem.Core.ModelsInterfaces;
using System;

namespace MSLAManagementSystem.ClientDataServices.Models
{
    public class AddressModel : IAddress
    {
        public AddressModel()
        { }

        public AddressModel(AddressModel addressModel)
        {
            Id = addressModel.Id;
            ShortAddress = addressModel.ShortAddress;
            Town = addressModel.Town;
            Region = addressModel.Region;
            Country = addressModel.Country;
            CityCode = addressModel.CityCode;
            CreatedDate = addressModel.CreatedDate;
        }

        public int Id { get; set; }
        public string ShortAddress { get; set; }
        public string Town { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string CityCode { get; set; }

        public DateTime CreatedDate { get; set; }

        public override string ToString()
        {
                return $" {ShortAddress} \n {CityCode}, {Town} {Region} {Country}";
            }
        }
    }
