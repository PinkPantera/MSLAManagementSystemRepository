﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.Core.ModelsInterfaces
{
    public interface IAddress : IBasicModel
    {
        int Id { get; set; }
        string ShortAddress{ get; set; }
        string Town { get; set; }
        string Region { get; set; }
        string Country { get; set; }
        string СityСode { get; set; }
    }
}