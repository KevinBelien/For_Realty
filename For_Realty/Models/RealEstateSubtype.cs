using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace For_Realty.Models
{
    public class RealEstateSubtype
    {
        public int RealEstateSubtypeID { get; set; }
        public string Name { get; set; }

        public int RealEstateTypeID { get; set; }
        public RealEstateType RealEstateType { get; set; }

        public ICollection<Ad> Ads { get; set; }
        public ICollection<RealEstate> RealEstates { get; set; }
    }
}
