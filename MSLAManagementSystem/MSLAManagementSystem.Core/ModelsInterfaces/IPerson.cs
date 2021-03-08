using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.Core.ModelsInterfaces
{
    public interface IPerson : IBasicModel
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string SecondName { get; set; }
        DateTime DateOfBirth { get; set; }
        string IdentityCard { get; set; }
        int? AdressId { get; set; }
        string Phone { get; set; }
        string Email { get; set; }
        bool Active { get; set; }
    }
}
