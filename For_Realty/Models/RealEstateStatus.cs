using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace For_Realty.Models
{
    public class RealEstateStatus
    {
        public int RealEstateStatusID { get; set; }
        public string Status { get; set; }
        public ICollection<Ad> Ads { get; set; }
        public ICollection<RealEstate> RealEstates { get; set; }
    }
}
