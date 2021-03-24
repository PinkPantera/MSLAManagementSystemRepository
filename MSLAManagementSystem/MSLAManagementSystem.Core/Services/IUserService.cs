using MSLAManagementSystem.Core.Entities;
using MSLAManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSLAManagementSystem.Core.Services
{
    public interface IUserService : IEntityService<UserModel>
    {
        Task<UserModel> Authenticate(string userName, string password);
        //Task<UserEntity> Create(UserEntity user, string password);
        //void Update(UserEntity user, string password = null);
        //void Delete(int id);
        //Task<IEnumerable<UserEntity>> GetAll();
        //Task<UserEntity> GetById(int id);
    }
}
