using Microsoft.EntityFrameworkCore;
using MSLAManagementSystem.Core.Models;
using MSLAManagementSystem.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSLAManagementSystem.Data.SQLServer.Repositories
{
    public class ControlPostRepository: Repository<ControlPost>, IControlPostRepository
    {
        public ControlPostRepository(ManagementSystemDbContext context)
          : base(context)
        {

        }

        public ManagementSystemDbContext ManagementSystemDbContext
        {
            get
            {
                return context as ManagementSystemDbContext;
            }
        }

       public async Task<ControlPost> GetControlPostWithBuildingsByIdAsync(int id)
        {
            return await ManagementSystemDbContext
                .ControlPosts
                .Include(t => t.Buildings)
                .FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
