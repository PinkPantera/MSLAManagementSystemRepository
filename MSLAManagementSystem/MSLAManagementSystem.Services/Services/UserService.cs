using MSLAManagementSystem.Core;
using MSLAManagementSystem.Core.Common;
using MSLAManagementSystem.Core.Entities;
using MSLAManagementSystem.Core.Models;
using MSLAManagementSystem.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSLAManagementSystem.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task<UserModel> Authenticate(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<UserModel> CreateAsync(UserModel entity)
        {
            if (string.IsNullOrEmpty(entity.Password))
                throw new Exception("Password is required");

            var userFind = await unitOfWork.GetRepository<UserEntity>().SinglOrDefaulAsync(u => u.UserName == entity.UserName);
            
            if (userFind != null)
                throw new Exception($" UserName {entity.UserName} is already exist");

            var password = new Password(entity.Password);


            var userEntity = new UserEntity
            {
                FirstName = entity.FirstName,
                LastNAme= entity.LastNAme,
                UserName = entity.UserName,
                PasswordHash = password.Hash,
                PasswordKey = password.Key
            };

            try
            {
                await unitOfWork.GetRepository<UserEntity>().AddAsync(userEntity);
                await unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                //TODO add logging 
            }

            entity.Id = userEntity.Id;

            return entity;
        }

        public Task DeleteAsync(UserModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UserModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
