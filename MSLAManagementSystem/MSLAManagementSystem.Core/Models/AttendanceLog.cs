using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.Core.Models
{
    public class AttendanceLog : BasicModel
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int ControlPostId { get; set; }
        public ControlPost ControlPost { get; set; }
        public DateTime Date { get; set; }
        public int TimeBegin { get; set; }
        public int TimeEnd { get; set; }
    }
}
