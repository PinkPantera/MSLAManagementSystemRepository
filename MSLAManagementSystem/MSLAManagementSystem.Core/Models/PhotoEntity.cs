using MSLAManagementSystem.Core.ModelsInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.Core.Models
{
    public class PhotoEntity : BasicEntity, IPhoto
    {
        public byte[] ImageData { get; set; }
    }
}
