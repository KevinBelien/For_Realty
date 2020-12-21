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
    public class AdController : Controller
    {
        private readonly For_RealtyDbContext _context;
        private readonly UserManager<AccountUser> _userManager;

        public AdController(For_RealtyDbContext context, UserManager<AccountUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Ad
        [Authorize]
        public async Task<IActionResult> Index()
        {
            ListAdViewModel viewModel = new ListAdViewModel();
            viewModel.User = GetUser();
            viewModel.Ads = await _context.Ads
                    .Include(s => s.RealEstateType)
                    .Include(a => a.Town)
                    .Include(a => a.RealEstateStatus)
                    .Include(a => a.UserAccount)
                .Where(a => a.UserAccountID == viewModel.User.UserAccountID).ToListAsync();

            return View(viewModel);
        }

        // GET: Ad/Create
        public async Task<IActionResult> Create()
        {
            string accountId = _userManager.GetUserId(HttpContext.User);

            CreateAdViewModel viewModel = new CreateAdViewModel
            {
                Ad = new Ad() { UserAccountID = _context.UserAccounts.Where(a => a.UserID == accountId).FirstOrDefault().UserAccountID },
                StatusList = await _context.RealEstateStatuses.ToListAsync(),
                Towns = new SelectList(_context.Towns, "TownID", "Name"),
                Types = new SelectList(_context.RealEstateTypes, "RealEstateTypeID", "Name"),
                SelectedStatus = 1
            };

            return View(viewModel);
        }

        // POST: Ad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(CreateAdViewModel viewModel)
        {
           
            if (ModelState.IsValid)
            {
                viewModel.Ad.DateInit = DateTime.Now;
                //viewModel.Ad.RealEstateStatus = _context.RealEstateStatuses.Where(s => s.RealEstateStatusID == viewModel.SelectedStatusID).FirstOrDefault();
                viewModel.Ad.RealEstateStatusID = viewModel.SelectedStatus;
                _context.Add(viewModel.Ad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            viewModel.StatusList = await _context.RealEstateStatuses.ToListAsync();
            viewModel.Towns = new SelectList(_context.Towns, "TownID", "Name");
            viewModel.Types = new SelectList(_context.RealEstateTypes, "RealEstateTypeID", "Name");
            
            return View(viewModel);
        }

        // GET: Ad/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ad ad = await _context.Ads
                .Include(a => a.RealEstateStatus)
                .Include(a => a.RealEstateType)
                .Include(a => a.Town)
                .SingleOrDefaultAsync(x => x.AdID == id);
            if (ad == null)
            {
                return NotFound();
            }
            EditAdViewModel viewModel = new EditAdViewModel
            {
                Ad = ad,
                SelectedStatus = ad.RealEstateStatus.RealEstateStatusID,
                StatusList = await _context.RealEstateStatuses.ToListAsync(),
                Towns = new SelectList(_context.Towns, "TownID", "Name"),
                Types = new SelectList(_context.RealEstateTypes, "RealEstateTypeID", "Name"),
            };
            return View(viewModel);
        }

        // POST: Ad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, EditAdViewModel viewModel)
        {
            if (id != viewModel.Ad.AdID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                viewModel.Ad.DateInit = DateTime.Now;
                //viewModel.Ad.RealEstateStatus = _context.RealEstateStatuses.Where(s => s.RealEstateStatusID == viewModel.SelectedStatusID).FirstOrDefault();
                viewModel.Ad.RealEstateStatusID = viewModel.SelectedStatus;

                _context.Update(viewModel.Ad);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Ad/Delete/5
        public Task<IActionResult> Delete(int? id)
        {
            return DeleteConfirmed(id);
        }

        // POST: Ad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "AccountAdmin")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id  == null)
            {
                return NotFound();
            }

            var ad = await _context.Ads.FindAsync(id);

            if (ad == null)
            {
                return NotFound();

            }

            _context.Ads.Remove(ad);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        private bool AdExists(int id)
        {
            return _context.Ads.Any(e => e.AdID == id);
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
