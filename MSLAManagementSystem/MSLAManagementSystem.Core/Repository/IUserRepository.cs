using MSLAManagementSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSLAManagementSystem.Core.Repository
{
    public interface IUserRepository: IRepository<UserEntity>
    {
        Task<UserEntity> Authenticate(string userName, string password);
        //void Update(UserEntity user, string password = null);
        //void Delete(int id);
        //Task<IEnumerable<UserEntity>> GetAllUserAsync();
        //Task<UserEntity> GetUserById(int id);
    }
}
