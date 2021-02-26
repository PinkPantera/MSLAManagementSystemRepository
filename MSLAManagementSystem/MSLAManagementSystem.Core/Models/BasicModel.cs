using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.Core.Models
{
    public abstract class BasicModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
