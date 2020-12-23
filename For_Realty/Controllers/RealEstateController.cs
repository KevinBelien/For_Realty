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
        //public async Task<IActionResult> Index()
        //{
        //    ListRealEstateViewModel viewModel = new ListRealEstateViewModel();
        //    viewModel.RealEstateStatus = await _context.RealEstateStatuses.ToListAsync();

        //    viewModel.RealEstates = await _context.RealEstates.ToListAsync();

        //    viewModel.LocalDate = TimeZoneInfo.ConvertTime(DateTime.Now,
        //         TimeZoneInfo.FindSystemTimeZoneById("Central Europe Standard Time"));

        //    /*viewModel.ListRealEstatePictures = await _context.RealEstatePictures.Include(rep => rep.RealEstate)
        //        .Where(rep => rep.Title == "Front")
        //        .OrderByDescending(rep => rep.RealEstate.DateInit).Take(5)
        //        .ToListAsync();*/

        //    return View(viewModel);
        //}

        // GET: RealEstateController/Details/5
        public async Task<IActionResult> Details(int? id)
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

            viewModel.UserAccount = GetUser();

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
        public async Task<IActionResult> CreateFavorite(DetailsRealEstateViewModel viewModel, int id)
        {

            if (viewModel.UserAccount.UserAccountID == 0)
            {
                viewModel = new DetailsRealEstateViewModel();
                string accountId = _userManager.GetUserId(HttpContext.User);
                viewModel.UserAccount = _context.UserAccounts.Where(a => a.UserID == accountId).FirstOrDefault();
            }

            Favorite favorite = new Favorite()
            {
                UserAccountID = viewModel.UserAccount.UserAccountID,
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
        public Task<IActionResult> DeleteFavorite(int realEstateID)
        {
            return DeleteFavoriteConfirmed(realEstateID);
        }

        // POST: RealEstateController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "AccountAdmin")]
        public async Task<IActionResult> DeleteFavoriteConfirmed(int realEstateID)
        {

            DetailsRealEstateViewModel viewModel = new DetailsRealEstateViewModel();
            viewModel.UserAccount = GetUser();
            var favorite = _context.Favorites.Where(f => f.UserAccountID == viewModel.UserAccount.UserAccountID)
                .Where(f => f.RealEstateID == realEstateID).FirstOrDefault();

            if (favorite == null)
            {
                return NotFound();
            }

            _context.Favorites.Remove(favorite);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), "RealEstate", new { id = realEstateID });
        }

        public async Task<IActionResult> Search(ListRealEstateViewModel viewModel)
        {
            viewModel.RealEstateStatus = await _context.RealEstateStatuses.ToListAsync();

            IQueryable<RealEstate> queryableEstates = _context.RealEstates.AsQueryable();

            if (viewModel.SelectedStatus != null)
            {
                queryableEstates = queryableEstates.Where(e => e.RealEstateStatusID == viewModel.SelectedStatus);
            }
            if (!string.IsNullOrEmpty(viewModel.TownSearch))
            {
                queryableEstates = queryableEstates.Where(e => e.Town.Name.StartsWith(viewModel.TownSearch) || e.Town.ZIP.StartsWith(viewModel.TownSearch));
            }

            viewModel.RealEstates = await queryableEstates
                .Include(e => e.Town)
                .Include(e => e.RealEstateStatus)
                .Include(e => e.RealEstateSubtype).ThenInclude(e => e.RealEstateType)
                .Include(e => e.RealEstatePictures)
                .Include(e => e.Agency)
                .ToListAsync();

            return View("Index", viewModel);

        }

        private UserAccount GetUser()
        {
            string accountId = _userManager.GetUserId(HttpContext.User);
            return _context.UserAccounts.Where(a => a.UserID == accountId)
                .Include(u => u.Favorites)
                .ThenInclude(f => f.RealEstate)
                .FirstOrDefault();
        }
    }
}
