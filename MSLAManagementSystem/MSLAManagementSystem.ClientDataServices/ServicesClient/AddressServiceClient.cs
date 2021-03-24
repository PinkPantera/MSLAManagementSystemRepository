using MSLAManagementSystem.ClientDataServices.Interfaces;
using MSLAManagementSystem.ClientDataServices.Models;
using MSLAManagementSystem.Core.Entities;
using MSLAManagementSystem.Core.ModelsInterfaces;
using MSLAManagementSystem.Core.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MSLAManagementSystem.ClientDataServices.ServicesClient
{
    public class AddressServiceClient : IAddressServiceClient
    {
        private ISettings settings;
        public AddressServiceClient(ISettings settings)
        {
            this.settings = settings;
        }

        public async Task<IEnumerable<AddressModel>> GetAll()
        {
            var listAddresses = new List<AddressModel>();
            using (var httpClient = new HttpClient())
            {
                using (var reponce = await httpClient.GetAsync(settings.UrlAddress))
                {
                    var apiReponce = await reponce.Content.ReadAsStringAsync();
                    listAddresses = JsonConvert.DeserializeObject<List<AddressModel>>(apiReponce);
                }
            }

            return listAddresses;
        }
    }
}
