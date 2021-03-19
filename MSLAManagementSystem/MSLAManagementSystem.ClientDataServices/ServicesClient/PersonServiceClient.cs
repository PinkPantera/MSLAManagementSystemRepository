using MSLAManagementSystem.ClientDataServices.Interfaces;
using MSLAManagementSystem.ClientDataServices.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MSLAManagementSystem.ClientDataServices.Extensions;

namespace MSLAManagementSystem.ClientDataServices.ServicesClient
{
    public class PersonServiceClient : IPersonServiceClient
    {
        private ISettings settings;
        public PersonServiceClient(ISettings settings)
        {
            this.settings = settings;
        }

        public async Task<PersonModel> CreateAsync(PersonModel personModel)
        {
            using (var httpClient = new HttpClient())
            {
                return await httpClient.PostAsync(settings.UrlPerson, personModel);
            }
        }

        public async Task<PersonModel> UpdateAsync(PersonModel personModel)
        {
            using (var httpClient = new HttpClient())
            {
              
                return await httpClient.PutAsync(settings.UrlPerson, personModel);
            }
        }

        public async Task<IEnumerable<PersonModel>> GetAllAsync()
        {
            IEnumerable<PersonModel> listPersons;
            using (var httpClient = new HttpClient())
            {
                listPersons = await httpClient.GetAsync<PersonModel>(settings.UrlPerson);
            }

            return listPersons;
        }

        public async Task DeleteAsync(PersonModel personModel)
        {
            using (var httpClient = new HttpClient())
            {
                await httpClient.DeleteByIdAsync(settings.UrlPerson, personModel.Id);
            }
        }
    }
}
