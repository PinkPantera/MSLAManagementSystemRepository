using Microsoft.EntityFrameworkCore;
using MSLAManagementSystem.Core.Common;
using MSLAManagementSystem.Core.Entities;
using MSLAManagementSystem.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSLAManagementSystem.Data.SQLServer.Repositories
{
    public class UserRepository : Repository<UserEntity>, IUserRepository
    {
        private ManagementSystemDbContext managementSystemDbContext
        {
            get { return context as ManagementSystemDbContext; }

        }

        public UserRepository(ManagementSystemDbContext context)
            : base(context)
        {

        }

        public async Task<UserEntity> Authenticate(string userName, string passwordString)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(passwordString))
                return null;

            var user = await managementSystemDbContext.Users.SingleOrDefaultAsync(u => u.UserName == userName);

            if (user == null)
                return null;

            var password = new Password(passwordString, user.PasswordKey);

            if (!user.PasswordHash.SequenceEqual(password.Hash))
                return null;

          //      if (!Security.IsPasswordCorrect(passwordString, user.PasswordHash, user.PasswordSalt))
         //           return null;

            return user;
        }

        //public async Task<UserEntity> Create(UserEntity user, string passwordString)
        //{
        //    //if (string.IsNullOrEmpty(passwordString))
        //    //    throw new Exception("Password is required");
        //    //var userFind = await managementSystemDbContext.Users.SingleOrDefaultAsync(u => u.UserName == user.UserName);
        //    //if (userFind != null)
        //    //    throw new Exception($" UserName {user.UserName} is already exist");

        //    //var password = new Password(passwordString);

        //    //user.PasswordHash = password.Hash;
        //    //user.PasswordKey = password.Key;

        //    await managementSystemDbContext.Users.AddAsync(user);
        //    return await managementSystemDbContext.Users.SingleOrDefaultAsync(u => u.UserName == user.UserName);
        //}
    }
}
