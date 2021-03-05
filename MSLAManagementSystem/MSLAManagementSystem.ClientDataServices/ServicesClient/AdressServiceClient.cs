using MSLAManagementSystem.ClientDataServices.Interfaces;
using MSLAManagementSystem.ClientDataServices.Models;
using MSLAManagementSystem.Core.Models;
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
    public class AdressServiceClient : IAdressServiceClient
    {
        private ISettings settings;
        public AdressServiceClient(ISettings settings)
        {
            this.settings = settings;
        }

        public async Task<IEnumerable<AdressModel>> GetAll()
        {
            var listAdresses = new List<AdressModel>();
            using (var httpClient = new HttpClient())
            {
                using (var reponce = await httpClient.GetAsync(settings.UrlAdress))
                {
                    var apiReponce = await reponce.Content.ReadAsStringAsync();
                    listAdresses = JsonConvert.DeserializeObject<List<AdressModel>>(apiReponce);
                }
            }

            return listAdresses;
        }
    }
}
