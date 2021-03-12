using MSLAManagementSystem.Core.ModelsInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MSLAManagementSystem.ClientDataServices.Models
{
    public class PhotoModel : IPhoto
    {
        public PhotoModel()
        { }

        public PhotoModel(PhotoModel photoModel)
        {
            if (photoModel == null)
                return;
            ImageData = photoModel.ImageData;
            CreatedDate = photoModel.CreatedDate;
        }

        public byte[] ImageData { get; set; }
        public DateTime CreatedDate { get ; set ; }

    }
}
