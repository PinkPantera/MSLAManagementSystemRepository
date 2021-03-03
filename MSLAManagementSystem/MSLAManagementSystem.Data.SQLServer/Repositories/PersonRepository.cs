using Microsoft.EntityFrameworkCore;
using MSLAManagementSystem.Core.Models;
using MSLAManagementSystem.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MSLAManagementSystem.Data.SQLServer.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        private ManagementSystemDbContext managementSystemDbContext
        {
            get { return context as ManagementSystemDbContext; }

        }

        public PersonRepository(ManagementSystemDbContext context)
            :base(context)
        {

        }
        public async Task<IEnumerable<Person>> GetAllWithAdressAsync()
        {
            return await managementSystemDbContext.Persons
                .Include(p => p.Adress)
                .ToListAsync();
        }
    }
}
