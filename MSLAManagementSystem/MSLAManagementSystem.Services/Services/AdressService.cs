using MSLAManagementSystem.Core;
using MSLAManagementSystem.Core.Models;
using MSLAManagementSystem.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSLAManagementSystem.Services.Services
{
    public class AdressService : EntityService<Adress>, IAdressService
    {
        public  AdressService(IUnitOfWork unitOfWork)
            :base(unitOfWork)
        {

        }

        public override async Task Update(Adress entity)
        {
            var entitytoUpdate = await unitOfWork.GetRepository<Adress>().GetByIdAsync(entity.Id);
            entitytoUpdate.Street = entity.Street;
            await unitOfWork.CommitAsync();
        }
    }
}
