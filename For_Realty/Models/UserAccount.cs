using For_Realty.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace For_Realty.Models
{
    public class UserAccount
    {
        public int UserAccountID { get; set; }
        public string Givenname { get; set; }
        public string Surname { get; set; }
        public string FullName => $"{Givenname} {Surname}";
        public string City { get; set; }
        public string ZIP { get; set; }
        public string Street { get; set; }
        public string HouseNr { get; set; }

        public string UserID { get; set; }
        public AccountUser AccountUser { get; set; }

        public ICollection<Ad> Ads { get; set; }
        public ICollection<Favorite> Favorites { get; set; }
    }
}
