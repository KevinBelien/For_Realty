using For_Realty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace For_Realty.ViewModels
{
    public class ListAdViewModel
    {
        public List<Ad> Ads { get; set; }
        public UserAccount User { get; set; }
    }
}
