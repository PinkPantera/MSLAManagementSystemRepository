using MSLAManagementSystem.Core;
using MSLAManagementSystem.Core.Models;
using MSLAManagementSystem.Core.ModelsInterfaces;
using MSLAManagementSystem.Core.Repository;
using MSLAManagementSystem.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSLAManagementSystem.Services.Services
{
    public class PersonService : IPersonService
    {
        private readonly IUnitOfWork unitOfWork;

        public PersonService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<PersonEntity> Create(PersonEntity entity)
        {
            await unitOfWork.GetRepository<PersonEntity>().AddAsync(entity);
            await unitOfWork.CommitAsync();

            return entity;
        }

        public async Task Delete(PersonEntity entity)
        {
            unitOfWork.GetRepository<PersonEntity>().Remove(entity);
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<PersonEntity>> GetAll()
        {
            return await unitOfWork.GetRepository<PersonEntity>().GetAllAsync();
        }

        public async Task<PersonEntity> GetById(int id)
        {
            return await unitOfWork.GetRepository<PersonEntity>().GetByIdAsync(id);
        }

        public async Task<IEnumerable<PersonEntity>> GetAllWithAddressAsync()
        {
          return await ((IPersonRepository)unitOfWork.GetRepository<PersonEntity>())
                .GetAllWithAddressAsync();
        }

        public  async Task Update(PersonEntity entity)
        {
            //TODO need add logic to update
            var entityToUpdate = await unitOfWork.GetRepository<PersonEntity>().GetByIdAsync(entity.Id);

            entityToUpdate.FirstName = entity.FirstName;

            await unitOfWork.CommitAsync();
        }
    }
}
