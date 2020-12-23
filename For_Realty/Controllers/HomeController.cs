using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using For_Realty.Models;
using For_Realty.Data;
using For_Realty.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace For_Realty.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly For_RealtyDbContext _context;

        public HomeController(ILogger<HomeController> logger, For_RealtyDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            ListRealEstateViewModel viewModel = new ListRealEstateViewModel();
            viewModel.RealEstateStatus = await _context.RealEstateStatuses.ToListAsync();

            viewModel.RealEstatesBuy = await _context.RealEstates
                .Include(re => re.RealEstatePictures)
                .Include(re => re.RealEstateSubtype).ThenInclude(st => st.RealEstateType)
                .Include(re => re.Town)
                .Include(re => re.RealEstateStatus)
                .Where(re => re.RealEstateStatus.Status == "Te koop")
                .OrderByDescending(re => re.DateInit).Take(6).ToListAsync();

            viewModel.RealEstatesHire = await _context.RealEstates
                .Include(re => re.RealEstatePictures)
                .Include(re => re.RealEstateSubtype).ThenInclude(st => st.RealEstateType)
                .Include(re => re.Town)
                .Include(re => re.RealEstateStatus)
                .Where(re => re.RealEstateStatus.Status == "Te huur")
                .OrderByDescending(re => re.DateInit).Take(6).ToListAsync();

            viewModel.LocalDate = TimeZoneInfo.ConvertTime(DateTime.Now,
                 TimeZoneInfo.FindSystemTimeZoneById("Central Europe Standard Time"));

            /*viewModel.ListRealEstatePictures = await _context.RealEstatePictures.Include(rep => rep.RealEstate)
                .Where(rep => rep.Title == "Front")
                .OrderByDescending(rep => rep.RealEstate.DateInit).Take(5)
                .ToListAsync();*/
            viewModel.SelectedStatus = 1;

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [AllowAnonymous]
        public IActionResult Search(ListRealEstateViewModel viewModel)
        {
            return RedirectToAction(nameof(Search), "RealEstate", viewModel) ;
        }
    }
}
