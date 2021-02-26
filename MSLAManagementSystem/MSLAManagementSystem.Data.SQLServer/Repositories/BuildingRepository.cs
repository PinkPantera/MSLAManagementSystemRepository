using MSLAManagementSystem.Core.Models;
using MSLAManagementSystem.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.Data.SQLServer.Repositories
{
    public class BuildingRepository : Repository<Building>, IBuildingRepository
    {
        public BuildingRepository(ManagementSystemDbContext context)
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
    }
}
