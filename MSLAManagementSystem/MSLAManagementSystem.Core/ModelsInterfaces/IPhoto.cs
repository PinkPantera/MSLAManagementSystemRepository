using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.Core.ModelsInterfaces
{
    public interface IPhoto : IBasicModel
    {
        byte[] ImageData { get; set; }
    }
}
