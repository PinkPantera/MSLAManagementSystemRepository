using MSLAManagementSystem.ClientDataServices.Interfaces;
using MSLAManagementSystem.ClientDataServices.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
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
                var personString = JsonConvert.SerializeObject(personModel);
                var contentData = new StringContent(personString, System.Text.Encoding.UTF8, "application/json");
                var reponse = await httpClient.PostAsync(settings.UrlPerson, contentData);
                var result = reponse.IsSuccessStatusCode;

                if (!result)
                {
                    var errorsStr = await reponse.Content.ReadAsStringAsync();

                    throw new Exception($"Can't creat person: \n {errorsStr}");
                }

                var resultStr = await reponse.Content.ReadAsStringAsync();
                var createdPerson = JsonConvert.DeserializeObject<PersonModel>(resultStr);
                return createdPerson;
            }
        }

        public async Task<PersonModel> UpdateAsync(PersonModel personModel)
        {
            using (var httpClient = new HttpClient())
            {
                var personString = JsonConvert.SerializeObject(personModel);
                var contentData = new StringContent(personString, System.Text.Encoding.UTF8, "application/json");
                var reponse = await httpClient.PutAsync(settings.UrlPerson, contentData);
                var result = reponse.IsSuccessStatusCode;

                if (!result)
                {
                    var errorsStr = await reponse.Content.ReadAsStringAsync();

                    throw new Exception($"Can't update person: \n {errorsStr}");
                }

                var resultStr = await reponse.Content.ReadAsStringAsync();
                var updatedPerson = JsonConvert.DeserializeObject<PersonModel>(resultStr);
                return updatedPerson;
            }
        }

        public async Task<IEnumerable<PersonModel>> GetAllAsync()
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

        public async Task DeleteAsync(PersonModel personModel)
        {
            using (var httpClient = new HttpClient())
            {
               


                //var personString = JsonConvert.SerializeObject(personModel);
                //// var contentData = new StringContent(personModel.Id, System.Text.Encoding.UTF8, "application/json");
                //var txt = settings.UrlPerson + "/" + personModel.Id;
                await httpClient.DeleteByIdAsync(settings.UrlPerson, personModel.Id);
            }
        }
    }
}
