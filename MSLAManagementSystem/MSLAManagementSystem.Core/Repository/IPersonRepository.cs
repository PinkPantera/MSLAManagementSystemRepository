using MSLAManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSLAManagementSystem.Core.Repository
{
    public interface IPersonRepository: IRepository<Person>
    {
        //TODO
        //need to define operations specific to Person
        Task<Person> GetPersonWithAdressByIdAsync(int id);
    }
}
