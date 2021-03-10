using MSLAManagementSystem.Core.Models;
using MSLAManagementSystem.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.Data.SQLServer.Repositories
{
    public class PhotoRepositiry:Repository<PhotoEntity>, IPhotoRepository
    {

        private ManagementSystemDbContext managementSystemDbContext
        {
            get { return context as ManagementSystemDbContext; }

        }

        public PhotoRepositiry(ManagementSystemDbContext context)
            : base(context)
        {

        }
    }
}
