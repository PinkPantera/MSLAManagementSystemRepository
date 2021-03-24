using MSLAManagementSystem.Core.Entities;
using MSLAManagementSystem.Core.ModelsInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.Core.Models
{
    public class UserModel : BasicEntity, IUser
    {
        public string FirstName { get; set; }
        public string LastNAme { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
