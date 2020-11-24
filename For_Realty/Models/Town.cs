using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace For_Realty.Models
{
    public class Town
    {
        public int TownID { get; set; }
        public string Name { get; set; }
        public string ZIP { get; set; }

        public ICollection<RealEstate> RealEstates { get; set; }
        public ICollection<Ad> Ads { get; set; }
    }
}
