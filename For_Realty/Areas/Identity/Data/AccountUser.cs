﻿using For_Realty.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace For_Realty.Areas.Identity.Data
{
    public class AccountUser: IdentityUser
    {
        [PersonalData]
        public UserAccount UserAccount { get; set; }
    }
}
