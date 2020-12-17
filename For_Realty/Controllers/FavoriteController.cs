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
    public class FavoriteController : Controller
    {
        private readonly For_RealtyDbContext _context;

        public FavoriteController(For_RealtyDbContext context)
        {
            _context = context;
        }

        // GET: Favorite
        public async Task<IActionResult> Index()
        {
            var for_RealtyDbContext = _context.Favorites.Include(f => f.RealEstate).Include(f => f.UserAccount);
            return View(await for_RealtyDbContext.ToListAsync());
        }

        // GET: Favorite/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favorite = await _context.Favorites
                .Include(f => f.RealEstate)
                .Include(f => f.UserAccount)
                .FirstOrDefaultAsync(m => m.FavoriteID == id);
            if (favorite == null)
            {
                return NotFound();
            }

            return View(favorite);
        }

        // GET: Favorite/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: Favorite/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FavoriteID,RealEstateID,UserAccountID")] Favorite favorite)
        {
            if (ModelState.IsValid)
            {
                _context.Add(favorite);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RealEstateID"] = new SelectList(_context.RealEstates, "RealEstateID", "Description", favorite.RealEstateID);
            ViewData["UserAccountID"] = new SelectList(_context.UserAccounts, "UserAccountID", "Givenname", favorite.UserAccountID);
            return View(favorite);
        }

        // GET: Favorite/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favorite = await _context.Favorites.FindAsync(id);
            if (favorite == null)
            {
                return NotFound();
            }
            ViewData["RealEstateID"] = new SelectList(_context.RealEstates, "RealEstateID", "Description", favorite.RealEstateID);
            ViewData["UserAccountID"] = new SelectList(_context.UserAccounts, "UserAccountID", "Givenname", favorite.UserAccountID);
            return View(favorite);
        }

        // POST: Favorite/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FavoriteID,RealEstateID,UserAccountID")] Favorite favorite)
        {
            if (id != favorite.FavoriteID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(favorite);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FavoriteExists(favorite.FavoriteID))
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
            ViewData["RealEstateID"] = new SelectList(_context.RealEstates, "RealEstateID", "Description", favorite.RealEstateID);
            ViewData["UserAccountID"] = new SelectList(_context.UserAccounts, "UserAccountID", "Givenname", favorite.UserAccountID);
            return View(favorite);
        }

        // GET: Favorite/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favorite = await _context.Favorites
                .Include(f => f.RealEstate)
                .Include(f => f.UserAccount)
                .FirstOrDefaultAsync(m => m.FavoriteID == id);
            if (favorite == null)
            {
                return NotFound();
            }

            return View(favorite);
        }

        // POST: Favorite/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var favorite = await _context.Favorites.FindAsync(id);
            _context.Favorites.Remove(favorite);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FavoriteExists(int id)
        {
            return _context.Favorites.Any(e => e.FavoriteID == id);
        }
    }
}
