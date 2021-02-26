using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.Core.Models
{
    public class Building: BasicModel
    {
        public string Name { get; set; }
        public int AdressId { get; set; }
        public Adress Adress { get; set; }
        public int? ControlPostId { get; set; }
        public ControlPost ControlPost { get; set; }
    }
}
