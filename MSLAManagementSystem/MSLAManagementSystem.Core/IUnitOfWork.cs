using MSLAManagementSystem.Core.Models;
using MSLAManagementSystem.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSLAManagementSystem.Core
{
   public interface IUnitOfWork: IDisposable
    {
        //IPersonRepository Persons { get; }
        //IAdressRepository Adresses { get; }
        //IBuildingRepository Buildings { get; }
        //IControlPostRepository ControlPosts { get; }
        //IAttendanceLogRepository AttendanceLogs { get; }
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;


        Task<int> CommitAsync();
    }
}
