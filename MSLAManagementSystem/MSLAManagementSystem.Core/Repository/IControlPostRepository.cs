using MSLAManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSLAManagementSystem.Core.Repository
{
    public interface IControlPostRepository:IRepository<ControlPost>
    {
        //TODO
        //need to define operations specific to ControlPost
        Task<ControlPost> GetControlPostWithBuildingsByIdAsync(int id);
    }
}
