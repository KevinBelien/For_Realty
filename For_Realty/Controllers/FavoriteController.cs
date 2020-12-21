using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using For_Realty.Data;
using For_Realty.Models;
using For_Realty.ViewModels;
using Microsoft.AspNetCore.Identity;
using For_Realty.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;

namespace For_Realty.Controllers
{
    public class FavoriteController : Controller
    {
        private readonly For_RealtyDbContext _context;
        private readonly UserManager<AccountUser> _userManager;


        public FavoriteController(For_RealtyDbContext context, UserManager<AccountUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Favorite
        [Authorize(Roles = "AccountAdmin")]
        public async Task<IActionResult> Index()
        {
            ListFavoritesViewModel viewModel = new ListFavoritesViewModel();
            viewModel.User = GetUser();
            viewModel.Favorites = await _context.Favorites
                .Include(f => f.RealEstate).ThenInclude(re => re.Agency)
                .Include(f => f.RealEstate).ThenInclude(re => re.RealEstateSubtype).ThenInclude(st => st.RealEstateType)
                .Include(f => f.RealEstate).ThenInclude(re => re.Town)
                .Include(f => f.RealEstate).ThenInclude(re => re.RealEstatePictures)
                .Include(f => f.RealEstate).ThenInclude(re => re.RealEstateStatus)
                .Where(f => f.UserAccountID == viewModel.User.UserAccountID).ToListAsync();

            return View(viewModel);
        }

        // GET: Favorite/Delete/5
        public Task<IActionResult> DeleteFavorite(int? realEstateID)
        {
            return DeleteFavoriteConfirmed(realEstateID);
        }

        // POST: Favorite/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "AccountAdmin")]
        public async Task<IActionResult> DeleteFavoriteConfirmed(int? realEstateID)
        {
            if (realEstateID == null)
            {
                return NotFound();
            }

            ListFavoritesViewModel viewModel = new ListFavoritesViewModel();
            viewModel.User = GetUser();
            var favorite = _context.Favorites.Where(f => f.UserAccountID == viewModel.User.UserAccountID)
                .Where(f => f.RealEstateID == realEstateID).FirstOrDefault();

            if (favorite == null)
            {
                return NotFound();
            }

            _context.Favorites.Remove(favorite);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), "Favorite");
        }
        private bool FavoriteExists(int id)
        {
            return _context.Favorites.Any(e => e.FavoriteID == id);
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
