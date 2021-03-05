using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.Core.Models
{
    public class BuildingEntity: BasicEntity
    {
        public string Name { get; set; }
        public int AdressId { get; set; }
        public AdressEntity Adress { get; set; }
        public int? ControlPostId { get; set; }
        public ControlPostEntity ControlPost { get; set; }
    }
}
