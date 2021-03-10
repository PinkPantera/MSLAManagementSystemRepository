using MSLAManagementSystem.Core.Models;
using MSLAManagementSystem.Core.ModelsInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSLAManagementSystem.Core.Services
{
    public interface IPersonService: IEntityService<PersonEntity>
    {
        //TODO 
        //needs to define the operations which our projet are required

        Task<IEnumerable<PersonEntity>> GetAllWithAddressAsync();
    }
}
