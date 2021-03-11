using MSLAManagementSystem.ClientDataServices.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSLAManagementSystem.ClientDataServices.Interfaces
{
    public interface IPersonServiceClient
    {
        Task<IEnumerable<PersonModel>> GetAll();
        Task<PersonModel> Create(PersonModel personModel);
    }
}
