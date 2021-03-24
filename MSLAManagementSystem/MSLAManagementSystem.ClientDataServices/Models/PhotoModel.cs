using MSLAManagementSystem.Core.ModelsInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MSLAManagementSystem.ClientDataServices.Models
{
    public class PhotoModel : IPhoto, INotifyPropertyChanged
    {
        private byte[] image;

        public PhotoModel()
        { }

        public PhotoModel(PhotoModel photoModel)
        {
            if (photoModel == null)
                return;
            ImageData = photoModel.ImageData;
            CreatedDate = photoModel.CreatedDate;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public DateTime CreatedDate { get ; set ; }

        public byte[] ImageData
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
                OnPropertyChanged(nameof (ImageData));
            }
        }

        public int Id { get; set ; }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
