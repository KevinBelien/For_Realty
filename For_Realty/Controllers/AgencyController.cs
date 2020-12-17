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

        // GET: AgencyController/Details/5
        //public async Task<ActionResult> Details(int? id)
        //{
        //    ListAgencyViewModel viewModel = new ListAgencyViewModel();

        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    viewModel.Agency = await _context.Agencies
        //        .Include(a => a.RealEstates)
        //        .FirstOrDefaultAsync(a => a.AgencyID == id);

        //    if (viewModel.Agency == null)
        //    {
        //        return NotFound();
        //    }

        //    return PartialView("_AgencyDetailPartial", viewModel);
        //}

        // GET: AgencyController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AgencyController/Create
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

        // GET: AgencyController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AgencyController/Edit/5
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

        // GET: AgencyController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AgencyController/Delete/5
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
