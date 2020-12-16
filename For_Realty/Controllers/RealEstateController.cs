using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using For_Realty.Data;
using For_Realty.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace For_Realty.Controllers
{
    public class RealEstateController : Controller
    {
        private readonly For_RealtyDbContext _context;

        public RealEstateController(For_RealtyDbContext context)
        {
            _context = context;
        }

        // GET: RealEstateController
        public ActionResult Index()
        {
            return View();
        }

        // GET: RealEstateController/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            DetailsRealEstateViewModel viewModel = new DetailsRealEstateViewModel();
            if (id == null)
            {
                return NotFound();
            }

            viewModel.RealEstate = await _context.RealEstates
                .Include(re => re.RealEstatePictures)
                .Include(re => re.RealEstateType).ThenInclude(t => t.RealEstateSubtypes)
                .Include(re => re.Town)
                .Include(re => re.RealEstateStatus)
                .Include(re => re.HeatingType)
                .Include(re => re.Favorites)
                .Include(re => re.Agency).ThenInclude(a => a.RealEstates)
                .Include(re => re.EnergyClass)
                .FirstOrDefaultAsync(r => r.RealEstateID == id);
            //viewModel.EstateSubtype = await _context.RealEstateSubtypes
            //    .Where(st => st.RealEstateSubtypeID == viewModel.RealEstate.RealEstateType.RealEstateSubtypes)
            //viewModel.AgencyRealEstates = await _context.RealEstates.Where(re => re.AgencyID == viewModel.RealEstate.AgencyID).ToListAsync();

            if (viewModel.RealEstate == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // GET: RealEstateController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RealEstateController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RealEstateController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RealEstateController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RealEstateController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RealEstateController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


    }
}
