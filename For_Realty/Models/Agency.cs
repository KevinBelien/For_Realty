using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace For_Realty.Models
{
    public class Agency
    {
        public int AgencyID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string HouseNr { get; set; }
        public string Street { get; set; }
        public string ZIP { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string BIV { get; set; }
        public string Logo { get; set; }

        public ICollection<RealEstate> RealEstates { get; set; }

    }
}
