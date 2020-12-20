using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace For_Realty.Models
{
    public partial class Favorite
    {
        public override bool Equals(object obj)
        {
            return obj is Favorite favorite &&
                   RealEstateID == favorite.RealEstateID &&
                   UserAccountID == favorite.UserAccountID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(RealEstateID, UserAccountID);
        }
    }
}
