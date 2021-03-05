using MSLAManagementSystem.Core.Models;
using MSLAManagementSystem.Core.ModelsInterfaces;
using MSLAManagementSystem.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.Data.SQLServer.Repositories
{
    public class AdressRepository: Repository<AdressEntity>, IAdressRepository
    {
        private ManagementSystemDbContext managementSystemDbContext
        {
            get { return context as ManagementSystemDbContext; }

        }

        public AdressRepository(ManagementSystemDbContext context)
            : base(context)
        {

        }
    }
}
