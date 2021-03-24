using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.Core.ModelsInterfaces
{
    public interface IPerson : IBasicModel
    {
        string FirstName { get; set; }
        string SecondName { get; set; }
        DateTime DateOfBirth { get; set; }
        string IdentityCard { get; set; }
        int AddressId { get; set; }
        int? PhotoId { get; set; }
        string Phone { get; set; }
        string Email { get; set; }
        bool Active { get; set; }
    }
}
