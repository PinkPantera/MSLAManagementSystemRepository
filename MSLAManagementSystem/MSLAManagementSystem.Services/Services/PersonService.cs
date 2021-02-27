using MSLAManagementSystem.Core;
using MSLAManagementSystem.Core.Models;
using MSLAManagementSystem.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSLAManagementSystem.Services.Services
{
    public class PersonService : EntityService<Person>, IPersonService
    {
        public PersonService(IUnitOfWork unitOFWork)
            : base(unitOFWork)
        {
        }

        public override async Task Update(Person entity)
        {
            //TODO need add logic to update
            var entityToUpdate = await unitOfWork.GetRepository<Person>().GetByIdAsync(entity.Id);

            entityToUpdate.FirstName = entity.FirstName;

            await unitOfWork.CommitAsync();
        }
    }
}
