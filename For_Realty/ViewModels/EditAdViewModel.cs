using For_Realty.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace For_Realty.ViewModels
{
    public class EditAdViewModel
    {
        public Ad Ad { get; set; }
        public List<RealEstateStatus> StatusList { get; set; }

        [BindProperty]
        public int SelectedStatus { get; set; }
        public SelectList Towns { get; set; }
        public SelectList Types { get; set; }
    }
}
