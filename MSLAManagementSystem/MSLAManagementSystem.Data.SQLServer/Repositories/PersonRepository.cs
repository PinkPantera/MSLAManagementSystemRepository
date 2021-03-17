using Microsoft.EntityFrameworkCore;
using MSLAManagementSystem.Core.Models;
using MSLAManagementSystem.Core.ModelsInterfaces;
using MSLAManagementSystem.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MSLAManagementSystem.Data.SQLServer.Repositories
{
    public class PersonRepository : Repository<PersonEntity>, IPersonRepository
    {
        private ManagementSystemDbContext managementSystemDbContext
        {
            get { return context as ManagementSystemDbContext; }

        }

        public PersonRepository(ManagementSystemDbContext context)
            : base(context)
        {

        }

        public async Task<IEnumerable<PersonEntity>> GetAllActiveWithAddressAsync()
        {
            return await managementSystemDbContext.Persons
                .Where(p => p.Active)
                .Include(p => p.Address)
                .Include(p => p.Photo)
                .ToListAsync();
        }

        public async Task<PersonEntity> GetByIdActiveWithAddressAsync(int id)
        {
            return await managementSystemDbContext.Persons
                .Where(p => p.Active)
                .Include(p => p.Address)
                .Include(p => p.Photo)
                .FirstOrDefaultAsync(p => p.AddressId == id);
        }

    }
}
