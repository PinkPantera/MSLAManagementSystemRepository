using MSLAManagementSystem.Core.Models;
using MSLAManagementSystem.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.Data.SQLServer.Repositories
{
    public class AttendanceLogRepository : Repository<AttendanceLog>, IAttendanceLogRepository
    {
        public AttendanceLogRepository(ManagementSystemDbContext context)
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
