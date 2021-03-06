﻿using MSLAManagementSystem.ClientDataServices.Models;
using MSLAManagementSystem.Core.ModelsInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSLAManagementSystem.ClientDataServices.Interfaces
{
    public interface IAddressServiceClient
    {
        Task<IEnumerable<AddressModel>> GetAll();
    }

}
