using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.Core.Models
{
    public class AttendanceLogEntity : BasicEntity
    {
        public DateTime Date { get; set; }
        public int TimeBegin { get; set; }
        public int TimeEnd { get; set; }
        public int PersonId { get; set; }
        public PersonEntity Person { get; set; }
        public int? ControlPostId { get; set; }
        public ControlPostEntity ControlPost { get; set; }
    }
}
