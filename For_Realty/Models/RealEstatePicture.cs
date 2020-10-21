using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace For_Realty.Models
{
    public class RealEstatePicture
    {
        public int RealEstatePictureID { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }

        public int RealEstateID { get; set; }
        public RealEstate RealEstate { get; set; }
    }
}
