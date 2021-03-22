using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.Core.ModelsInterfaces
{
    public interface IUser
    {
        string FirstName { get; set; }
        string LastNAme { get; set; }
        string UserName { get; set; }
        byte[] PasswordHash { get; set; }
        byte[] PasswordSalt { get; set; }

    }
}
