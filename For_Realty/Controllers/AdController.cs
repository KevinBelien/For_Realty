using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using For_Realty.Data;
using For_Realty.Models;

namespace For_Realty.Controllers
{
    public class AdController : Controller
    {
        private readonly For_RealtyDbContext _context;

        public AdController(For_RealtyDbContext context)
        {
            _context = context;
        }

        // GET: Ad
        public async Task<IActionResult> Index()
        {
            var for_RealtyDbContext = _context.Ads.Include(a => a.RealEstateStatus).Include(a => a.RealEstateSubtype).Include(a => a.RealEstateType).Include(a => a.Town).Include(a => a.UserAccount);
            return View(await for_RealtyDbContext.ToListAsync());
        }

        // GET: Ad/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ad = await _context.Ads
                .Include(a => a.RealEstateStatus)
                .Include(a => a.RealEstateSubtype)
                .Include(a => a.RealEstateType)
                .Include(a => a.Town)
                .Include(a => a.UserAccount)
                .FirstOrDefaultAsync(m => m.AdID == id);
            if (ad == null)
            {
                return NotFound();
            }

            return View(ad);
        }

        // GET: Ad/Create
        public IActionResult Create()
        {
            ViewData["RealEstateStatusID"] = new SelectList(_context.RealEstateStatuses, "RealEstateStatusID", "Status");
            ViewData["RealEstateSubtypeID"] = new SelectList(_context.RealEstateSubtypes, "RealEstateSubtypeID", "Name");
            ViewData["RealEstateTypeID"] = new SelectList(_context.RealEstateTypes, "RealEstateTypeID", "Name");
            ViewData["TownID"] = new SelectList(_context.Towns, "TownID", "Name");
            ViewData["UserAccountID"] = new SelectList(_context.UserAccounts, "UserAccountID", "Givenname");
            return View();
        }

        // POST: Ad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdID,DateInit,Requirements,Price,Radius,UserAccountID,TownID,RealEstateTypeID,RealEstateSubtypeID,RealEstateStatusID")] Ad ad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RealEstateStatusID"] = new SelectList(_context.RealEstateStatuses, "RealEstateStatusID", "Status", ad.RealEstateStatusID);
            ViewData["RealEstateSubtypeID"] = new SelectList(_context.RealEstateSubtypes, "RealEstateSubtypeID", "Name", ad.RealEstateSubtypeID);
            ViewData["RealEstateTypeID"] = new SelectList(_context.RealEstateTypes, "RealEstateTypeID", "Name", ad.RealEstateTypeID);
            ViewData["TownID"] = new SelectList(_context.Towns, "TownID", "Name", ad.TownID);
            ViewData["UserAccountID"] = new SelectList(_context.UserAccounts, "UserAccountID", "Givenname", ad.UserAccountID);
            return View(ad);
        }

        // GET: Ad/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ad = await _context.Ads.FindAsync(id);
            if (ad == null)
            {
                return NotFound();
            }
            ViewData["RealEstateStatusID"] = new SelectList(_context.RealEstateStatuses, "RealEstateStatusID", "Status", ad.RealEstateStatusID);
            ViewData["RealEstateSubtypeID"] = new SelectList(_context.RealEstateSubtypes, "RealEstateSubtypeID", "Name", ad.RealEstateSubtypeID);
            ViewData["RealEstateTypeID"] = new SelectList(_context.RealEstateTypes, "RealEstateTypeID", "Name", ad.RealEstateTypeID);
            ViewData["TownID"] = new SelectList(_context.Towns, "TownID", "Name", ad.TownID);
            ViewData["UserAccountID"] = new SelectList(_context.UserAccounts, "UserAccountID", "Givenname", ad.UserAccountID);
            return View(ad);
        }

        // POST: Ad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdID,DateInit,Requirements,Price,Radius,UserAccountID,TownID,RealEstateTypeID,RealEstateSubtypeID,RealEstateStatusID")] Ad ad)
        {
            if (id != ad.AdID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdExists(ad.AdID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["RealEstateStatusID"] = new SelectList(_context.RealEstateStatuses, "RealEstateStatusID", "Status", ad.RealEstateStatusID);
            ViewData["RealEstateSubtypeID"] = new SelectList(_context.RealEstateSubtypes, "RealEstateSubtypeID", "Name", ad.RealEstateSubtypeID);
            ViewData["RealEstateTypeID"] = new SelectList(_context.RealEstateTypes, "RealEstateTypeID", "Name", ad.RealEstateTypeID);
            ViewData["TownID"] = new SelectList(_context.Towns, "TownID", "Name", ad.TownID);
            ViewData["UserAccountID"] = new SelectList(_context.UserAccounts, "UserAccountID", "Givenname", ad.UserAccountID);
            return View(ad);
        }

        // GET: Ad/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ad = await _context.Ads
                .Include(a => a.RealEstateStatus)
                .Include(a => a.RealEstateSubtype)
                .Include(a => a.RealEstateType)
                .Include(a => a.Town)
                .Include(a => a.UserAccount)
                .FirstOrDefaultAsync(m => m.AdID == id);
            if (ad == null)
            {
                return NotFound();
            }

            return View(ad);
        }

        // POST: Ad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ad = await _context.Ads.FindAsync(id);
            _context.Ads.Remove(ad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdExists(int id)
        {
            return _context.Ads.Any(e => e.AdID == id);
        }
    }
}
