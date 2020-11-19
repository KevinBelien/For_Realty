using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace For_Realty.Models
{
    public class HeatingType
    {
        public int HeatingTypeID { get; set; }
        public string Name { get; set; }
        public ICollection<RealEstate> RealEstates { get; set; }
    }
}
