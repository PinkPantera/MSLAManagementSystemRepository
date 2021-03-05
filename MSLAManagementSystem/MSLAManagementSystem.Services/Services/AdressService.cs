using MSLAManagementSystem.Core;
using MSLAManagementSystem.Core.Models;
using MSLAManagementSystem.Core.ModelsInterfaces;
using MSLAManagementSystem.Core.Services;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSLAManagementSystem.Services.Services
{
    public class AdressService : IAdressService
    {
        private readonly IUnitOfWork unitOfWork;

        public AdressService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<AdressEntity> Create(AdressEntity entity)
        {
            await unitOfWork.GetRepository<AdressEntity>().AddAsync(entity);
            await unitOfWork.CommitAsync();

            return entity;
        }

        public  async Task Delete(AdressEntity entity)
        {
            unitOfWork.GetRepository<AdressEntity>().Remove(entity);
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<AdressEntity>> GetAll()
        {
            return await unitOfWork.GetRepository<AdressEntity>().GetAllAsync();
        }

        public async Task<AdressEntity> GetById(int id)
        {
            return await unitOfWork.GetRepository<AdressEntity>().GetByIdAsync(id);
        }

        public  async Task Update(AdressEntity entity)
        {
            var entitytoUpdate = await unitOfWork.GetRepository<AdressEntity>().GetByIdAsync(entity.Id);
            entitytoUpdate.Street = entity.Street;
            await unitOfWork.CommitAsync();
        }
    }
}
