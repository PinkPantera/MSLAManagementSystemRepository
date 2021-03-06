﻿using MSLAManagementSystem.Core.ModelsInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.Core.Entities
{
    public class UserEntity : BasicEntity, IUser
    {
        public string FirstName { get; set ; }
        public string LastNAme { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordKey { get; set; }
    }
}
