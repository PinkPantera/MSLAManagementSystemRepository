using MSLAManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSLAManagementSystem.Core.Repository
{
    public interface IUserRepository
    {
        Task<UserEntity> Authenticate(string userName, string password);
        Task<UserEntity> Create(UserEntity user, string password);

        void Update(UserEntity user, string password = null);
        void Delete(int id);
        Task<IEnumerable<UserEntity>> GetAllUserAsync();
        Task<UserEntity> GetUserById(int id);
    }
}
