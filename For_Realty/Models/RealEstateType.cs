using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace For_Realty.Models
{
    public class RealEstateType
    {
        public int RealEstateTypeID { get; set; }
        public string Name { get; set; }

        public ICollection<Ad> Ads { get; set; }
        public ICollection<RealEstate> RealEstates { get; set; }
        public ICollection<RealEstateSubtype> RealEstateSubtypes { get; set; }
    }
}
