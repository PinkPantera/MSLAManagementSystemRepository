using MSLAManagementSystem.ClientDataServices.Interfaces;
using MSLAManagementSystem.ClientDataServices.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MSLAManagementSystem.ClientDataServices.ServicesClient
{
    public class PersonServiceClient : IPersonServiceClient
    {
        private ISettings settings;
        public PersonServiceClient(ISettings settings)
        {
            this.settings = settings;
        }

        public async Task<IEnumerable<PersonModel>> GetAll()
        {
            var listPersons = new List<PersonModel>();
            using (var httpClient = new HttpClient())
            {
                using (var reponce = await httpClient.GetAsync(settings.UrlPerson))
                {
                    var apiReponce = await reponce.Content.ReadAsStringAsync();
                    listPersons = JsonConvert.DeserializeObject<List<PersonModel>>(apiReponce);
                }
            }

            return listPersons;
        }
    }
}
