using MSLAManagementSystem.Core;
using MSLAManagementSystem.Core.Repository;
using MSLAManagementSystem.Data.SQLServer.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSLAManagementSystem.Data.SQLServer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ManagementSystemDbContext context;
        private IPersonRepository personRepository;
        private IAdressRepository adressRepository;
        private IBuildingRepository buildingRepository;
        private IControlPostRepository controlPostRepository;
        private IAttendanceLogRepository attendanceLogRepository;

        public UnitOfWork(ManagementSystemDbContext context)
        {
            this.context = context;
        }

        public IPersonRepository Persons => personRepository ??= new PersonRepository(context);

        public IAdressRepository Adresses => adressRepository ??= new AdressRepository(context);

        public IBuildingRepository Buildings => buildingRepository ??= new BuildingRepository(context);

        public IControlPostRepository ControlPosts => controlPostRepository ??= new ControlPostRepository(context);

        public IAttendanceLogRepository AttendanceLogs => attendanceLogRepository ??= new AttendanceLogRepository(context);

        public async Task<int> CommitAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
