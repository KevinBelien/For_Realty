using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace For_Realty.Models
{
    public class Favorite
    {
        public int FavoriteID { get; set; }

        public int RealEstateID { get; set; }
        public RealEstate RealEstate { get; set; }

        public int UserAccountID { get; set; }
        public UserAccount UserAccount { get; set; }
    }
}
