using For_Realty.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace For_Realty.ViewModels
{
    public class ListRealEstateViewModel
    {
        public List<RealEstate> RealEstates { get; set; }
        public List<RealEstateStatus> RealEstateStatus { get; set; }
        [BindProperty]
        public int? SelectedStatus { get; set; }
        public string TownSearch { get; set; }
        public List<RealEstate> RealEstatesBuy { get; set; }
        public List<RealEstate> RealEstatesHire { get; set; }
        public List<RealEstatePicture> ListRealEstatePictures { get; set; }
        public DateTime LocalDate { get; set; }
    }
}
