using For_Realty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace For_Realty.ViewModels
{
    public class ListFavoritesViewModel
    {
        public List<Favorite> Favorites { get; set; }
        public UserAccount User { get; set; }
    }
}
