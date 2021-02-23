using MSLAManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSLAManagementSystem.Core.Services
{
    public interface IAdressService
    {
        //TODO 
        //needs to define the operations which our projet are required

        Task<IEnumerable<Adress>> GetAllAdresses();
        Task<Adress> GetAdressById(int id);
        Task<Adress> CreatAdress(Adress adress);
        Task<Adress> UpadteAdress(Adress adress);
        Task DeleteAdress(Adress adress);
    }
}
