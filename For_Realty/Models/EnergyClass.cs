using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace For_Realty.Models
{
    public class EnergyClass
    {
        public int EnergyClassID { get; set; }
        public string Letter { get; set; }
        public ICollection<RealEstate> RealEstates { get; set; }
    }
}
