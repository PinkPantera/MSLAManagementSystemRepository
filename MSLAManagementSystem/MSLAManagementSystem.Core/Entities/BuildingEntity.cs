using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.Core.Entities
{
    public class BuildingEntity: BasicEntity
    {
        public string Name { get; set; }
        public int AddressId { get; set; }
        public AddressEntity Address { get; set; }
        public int? ControlPostId { get; set; }
        public ControlPostEntity ControlPost { get; set; }
    }
}
