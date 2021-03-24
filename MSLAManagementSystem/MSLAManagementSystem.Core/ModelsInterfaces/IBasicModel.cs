using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.Core.ModelsInterfaces
{
    public interface IBasicModel
    {
        int Id { get; set; }
        DateTime CreatedDate { get; set; }
    }
}
