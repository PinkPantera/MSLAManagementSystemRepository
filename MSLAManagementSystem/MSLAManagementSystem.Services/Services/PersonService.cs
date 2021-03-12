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
            try
            {
                await unitOfWork.GetRepository<PersonEntity>().AddAsync(entity);

                await unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                //TODO add logging 
            }

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
            var personToUpdate = await ((IPersonRepository)unitOfWork.GetRepository<PersonEntity>())
                .GetByIdWithAddress(entity.Id);

            personToUpdate.FirstName = entity.FirstName;
            personToUpdate.SecondName = entity.SecondName;
            personToUpdate.AddressId = entity.AddressId;
            personToUpdate.DateOfBirth = entity.DateOfBirth;
            personToUpdate.IdentityCard = entity.IdentityCard;
            personToUpdate.Phone = entity.Phone;
            personToUpdate.Email = entity.Email;
            personToUpdate.Address.ShortAddress = entity.Address.ShortAddress;
            personToUpdate.Address.Town = entity.Address.Town;
            personToUpdate.Address.CityCode = entity.Address.CityCode;
            personToUpdate.Address.Region = entity.Address.Region;
            personToUpdate.Address.Country = entity.Address.Country;

            await unitOfWork.CommitAsync();
        }
    }
}
