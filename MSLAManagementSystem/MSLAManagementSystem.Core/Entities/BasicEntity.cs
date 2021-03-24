using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.Core.Entities
{
    public abstract class BasicEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
