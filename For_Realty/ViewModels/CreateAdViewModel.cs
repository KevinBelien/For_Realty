using For_Realty.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace For_Realty.ViewModels
{
    public class CreateAdViewModel
    {
        public Ad Ad{ get; set; }
        public List<RealEstateStatus> StatusList { get; set; }

        [BindProperty]
        public int SelectedStatus { get; set; }
        public IEnumerable<SelectListItem> Towns { get; set; }
        public IEnumerable<SelectListItem> Types { get; set; }

    }
}
