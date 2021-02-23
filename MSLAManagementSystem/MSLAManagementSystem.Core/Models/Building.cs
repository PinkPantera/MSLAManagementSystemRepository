using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.Core.Models
{
    public class Building: BasicModel
    {
        public string Name { get; set; }
        public string Street{ get; set; }
        public string Number { get; set; }
        public string Town { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string СityСode { get; set; }
        public int ControlPostId { get; set; }
        public ControlPost ControlPost { get; set; }
    }
}
