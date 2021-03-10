using MSLAManagementSystem.Core.ModelsInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MSLAManagementSystem.ClientDataServices.Models
{
    public class PhotoModel : IPhoto, INotifyPropertyChanged
    {
        public byte[] ImageData { get; set; }
        public DateTime CreatedDate { get ; set ; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
