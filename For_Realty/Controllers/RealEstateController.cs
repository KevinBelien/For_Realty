using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using For_Realty.Areas.Identity.Data;
using For_Realty.Data;
using For_Realty.Models;
using For_Realty.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace For_Realty.Controllers
{
    public class RealEstateController : Controller
    {
        private readonly For_RealtyDbContext _context;
        private readonly UserManager<AccountUser> _userManager;

        public RealEstateController(For_RealtyDbContext context, UserManager<AccountUser> userManager)
        {
            _context = context;
            _userManager = userManager;

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
                .Include(re => re.RealEstateSubtype).ThenInclude(t => t.RealEstateType)
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
        public Task<IActionResult> CreateFavorite(int id)
        {
            DetailsRealEstateViewModel viewModel = new DetailsRealEstateViewModel();
            string accountId = _userManager.GetUserId(HttpContext.User);
            viewModel.UserAccount = _context.UserAccounts.Where(a => a.UserID == accountId).FirstOrDefault();

            //return RedirectToAction(nameof(Details), "RealEstate", new { id = id });
            return CreateFavorite(viewModel, id);
        }

        // POST: RealEstateController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="AccountAdmin")]
        public async Task<IActionResult> CreateFavorite(DetailsRealEstateViewModel viewmodel, int id)
        {
            if (viewmodel.UserAccount.UserAccountID == 0)
            {
                viewmodel = new DetailsRealEstateViewModel();
                string accountId = _userManager.GetUserId(HttpContext.User);
                viewmodel.UserAccount = _context.UserAccounts.Where(a => a.UserID == accountId).FirstOrDefault();
            }


            Favorite favorite = new Favorite()
            {
                UserAccountID = viewmodel.UserAccount.UserAccountID,
                RealEstateID = id
            };

           List<Favorite> favorites = await _context.Favorites.ToListAsync();
            if (!favorites.Contains(favorite))
            {
                _context.Favorites.Add(favorite);
                await _context.SaveChangesAsync();
            }
                return RedirectToAction(nameof(Details),"RealEstate", new { id = id});
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
