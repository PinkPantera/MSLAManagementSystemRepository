using MSLAManagementSystem.Core;
using MSLAManagementSystem.Core.Entities;
using MSLAManagementSystem.Core.ModelsInterfaces;
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

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class 
        {
            var type = typeof(TEntity);

            if (!repositories.ContainsKey(type))
            {
                IRepository<TEntity> repository;
                if (type == typeof(PersonEntity))
                {
                    var tmp = new PersonRepository(context);
                    repository = (IRepository<TEntity>)tmp;
                }
                else
                {
                    repository = new Repository<TEntity>(context);
                }

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