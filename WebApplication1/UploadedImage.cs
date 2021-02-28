using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageUploader.Models
{
    public class UploadedImage
    {
        public UploadedImage(string name)
        {
            this.ImageName = name;
            
        }
        public string ImageName { get; set; }
        public DateTime TimeAdded { get; set; }
    }
}
