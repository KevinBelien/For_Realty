﻿using For_Realty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace For_Realty.ViewModels
{
    public class DetailsRealEstateViewModel
    {
        public RealEstate RealEstate { get; set; }
        public UserAccount UserAccount { get; set; }
    }
}
