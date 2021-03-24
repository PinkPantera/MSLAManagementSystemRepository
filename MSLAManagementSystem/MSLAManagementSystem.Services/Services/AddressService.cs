using MSLAManagementSystem.Core;
using MSLAManagementSystem.Core.Entities;
using MSLAManagementSystem.Core.ModelsInterfaces;
using MSLAManagementSystem.Core.Services;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSLAManagementSystem.Services.Services
{
    public class AddressService : IAddressService
    {
        private readonly IUnitOfWork unitOfWork;

        public AddressService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<AddressEntity> CreateAsync(AddressEntity entity)
        {
            await unitOfWork.GetRepository<AddressEntity>().AddAsync(entity);
            await unitOfWork.CommitAsync();

            return entity;
        }

        public  async Task DeleteAsync(AddressEntity entity)
        {
            unitOfWork.GetRepository<AddressEntity>().Remove(entity);
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<AddressEntity>> GetAllAsync()
        {
            return await unitOfWork.GetRepository<AddressEntity>().GetAllAsync();
        }

        public async Task<AddressEntity> GetByIdAsync(int id)
        {
            return await unitOfWork.GetRepository<AddressEntity>().GetByIdAsync(id);
        }

        public  async Task UpdateAsync(AddressEntity entity)
        {
            var entitytoUpdate = await unitOfWork.GetRepository<AddressEntity>().GetByIdAsync(entity.Id);
            entitytoUpdate.ShortAddress= entity.ShortAddress;
            await unitOfWork.CommitAsync();
        }
    }
}
