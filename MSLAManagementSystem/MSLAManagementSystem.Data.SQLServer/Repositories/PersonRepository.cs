using Microsoft.EntityFrameworkCore;
using MSLAManagementSystem.Core.Models;
using MSLAManagementSystem.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSLAManagementSystem.Data.SQLServer.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(ManagementSystemDbContext context)
            : base(context)
        { }

        public ManagementSystemDbContext ManagementSystemDbContext
        {
            get
            {
                return context as ManagementSystemDbContext;
            }
        }

        public async Task<Person> GetPersonWithAdressByIdAsync(int id)
        {
            return await ManagementSystemDbContext
                 .Persons
                 .Include(t => t.Adress)
                 .SingleOrDefaultAsync(t => t.Id == id);
        }
    }
}
