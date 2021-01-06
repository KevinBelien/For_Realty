using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace For_Realty.Models
{
    public class Ad
    {
        public int AdID { get; set; }
        public DateTime DateInit { get; set; }
        public string Requirements { get; set; }
        public Decimal Price { get; set; }

        [Range(0,999, ErrorMessage = "Radius moet tussen 0 en 999 zijn!")]
        public int Radius { get; set; }

        public int UserAccountID { get; set; }
        public UserAccount UserAccount { get; set; }

        public int TownID { get; set; }
        public Town Town { get; set; }

        public int RealEstateTypeID { get; set; }
        public RealEstateType RealEstateType { get; set; }

        public int? RealEstateSubtypeID { get; set; }
        public RealEstateSubtype RealEstateSubtype { get; set; }

        public int RealEstateStatusID { get; set; }
        public RealEstateStatus RealEstateStatus { get; set; }
    }
}
