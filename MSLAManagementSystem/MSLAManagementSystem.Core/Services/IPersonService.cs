using MSLAManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSLAManagementSystem.Core.Services
{
    public interface IPersonService: IEntityService<Person>
    {
        //TODO 
        //needs to define the operations which our projet are required

        Task<IEnumerable<Person>> GetAllWithAdress();
        //Task<Person> GetPersonById(int id);
        //Task<Person> CreatPerson(Person person);
        //Task<Person> UpadtePerson(Person person);
        //Task DeletePerson(Person person);
    }
}
