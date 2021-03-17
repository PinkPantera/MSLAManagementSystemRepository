using MSLAManagementSystem.ClientDataServices.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSLAManagementSystem.ClientDataServices.Interfaces
{
    public interface IPersonServiceClient
    {
        Task<IEnumerable<PersonModel>> GetAllAsync();
        Task<PersonModel> UpdateAsync(PersonModel personModel);
        Task<PersonModel> CreateAsync(PersonModel personModel);
        Task DeleteAsync(PersonModel personModel);
    }
}
