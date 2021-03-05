using MSLAManagementSystem.Core;
using MSLAManagementSystem.Core.Models;
using MSLAManagementSystem.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSLAManagementSystem.Services.Services
{
    public abstract class EntityService<TEntity> : IEntityService<TEntity> where TEntity : class
    {
        protected readonly IUnitOfWork unitOfWork;

        public EntityService(IUnitOfWork unitOFWork)
        {
            this.unitOfWork = unitOFWork;
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            await unitOfWork.GetRepository<TEntity>().AddAsync(entity);
            await unitOfWork.CommitAsync();

            return entity;
        }

        public async Task Delete(TEntity entity)
        {
            unitOfWork.GetRepository<TEntity>().Remove(entity);
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await unitOfWork.GetRepository<TEntity>().GetAllAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await unitOfWork.GetRepository<TEntity>().GetByIdAsync(id);
        }

        public abstract Task Update(TEntity entity);
    }
}
