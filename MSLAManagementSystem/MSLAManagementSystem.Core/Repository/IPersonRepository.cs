using MSLAManagementSystem.Core.Models;
using MSLAManagementSystem.Core.ModelsInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSLAManagementSystem.Core.Repository
{
    public interface IPersonRepository : IRepository<PersonEntity>
    {
        Task<IEnumerable<PersonEntity>> GetAllWithAddressAsync();
        Task<PersonEntity> GetByIdWithAddress(int id);
    }
}
