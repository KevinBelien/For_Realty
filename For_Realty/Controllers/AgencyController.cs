using For_Realty.Data;
using For_Realty.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using For_Realty.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace For_Realty.Controllers
{
    public class AgencyController : Controller
    {
        private readonly For_RealtyDbContext _context;

        public AgencyController(For_RealtyDbContext context)
        {
            _context = context;
        }


        // GET: AgencyController
        [AllowAnonymous]
        public async Task<ActionResult> Index()
        {
            ListAgencyViewModel viewModel = new ListAgencyViewModel();
            viewModel.AgencyList = await _context.Agencies.Include(a => a.RealEstates).ToListAsync();
            return View(viewModel);
        }
    }
}
