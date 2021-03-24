using MSLAManagementSystem.Core.Entities;
using MSLAManagementSystem.Core.ModelsInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSLAManagementSystem.Core.Repository
{
    public interface IPersonRepository : IRepository<PersonEntity>
    {
        Task<IEnumerable<PersonEntity>> GetAllActiveWithAddressAsync();
        Task<PersonEntity> GetByIdActiveWithAddressAsync(int id);


    }
}
