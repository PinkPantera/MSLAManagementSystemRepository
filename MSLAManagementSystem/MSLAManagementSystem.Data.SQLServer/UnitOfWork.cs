using MSLAManagementSystem.Core;
using MSLAManagementSystem.Core.Models;
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
        private bool disposed = false;
        //private IPersonRepository personRepository;
        //private IAdressRepository adressRepository;
        //private IBuildingRepository buildingRepository;
        //private IControlPostRepository controlPostRepository;
        //private IAttendanceLogRepository attendanceLogRepository;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();


        public UnitOfWork(ManagementSystemDbContext context)
        {
            this.context = context;
        }

        //public IPersonRepository Persons => personRepository ??= new PersonRepository(context);

        //public IAdressRepository Adresses => adressRepository ??= new AdressRepository(context);

        //public IBuildingRepository Buildings => buildingRepository ??= new BuildingRepository(context);

        //public IControlPostRepository ControlPosts => controlPostRepository ??= new ControlPostRepository(context);

        //public IAttendanceLogRepository AttendanceLogs => attendanceLogRepository ??= new AttendanceLogRepository(context);

        public async Task<int> CommitAsync()
        {
            return await context.SaveChangesAsync();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : BasicModel
        {
            var type = typeof(TEntity);

            if (!repositories.ContainsKey(type))
            {
                var repository = new Repository<TEntity>(context);
                repositories.Add(typeof(TEntity), repository);
            }

            return (IRepository<TEntity>)repositories[type];
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    repositories.Clear();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}