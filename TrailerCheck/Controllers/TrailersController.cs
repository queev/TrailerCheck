using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrailerCheck.Data;
using TrailerCheck.Models;

namespace TrailerCheck.Controllers
{
    public class TrailersController : Controller
    {
        private readonly TrailerCheckContext _context;

        public TrailersController(TrailerCheckContext context)
        {
            _context = context;    
        }

        // GET: Trailers
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            var trailers = from t in _context.Trailers
                           select t;
            if (!String.IsNullOrEmpty(searchString))
            {
                trailers = trailers.Where(t => t.SerialNumber.Contains(searchString));
            }

            return View(await trailers.AsNoTracking().ToListAsync());
        }

        // GET: Trailers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trailer = await _context.Trailers
                .Include(t => t.Registrations)
                    .ThenInclude(r => r.Owner)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);

            if (trailer == null)
            {
                return NotFound();
            }

            return View(trailer);
        }

        // GET: Trailers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trailers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SerialNumber,ProductGroup,Description,YearOfManufacture")] Trailer trailer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(trailer);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View(trailer);
        }

        // GET: Trailers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trailer = await _context.Trailers.SingleOrDefaultAsync(m => m.ID == id);
            if (trailer == null)
            {
                return NotFound();
            }
            return View(trailer);
        }

        // POST: Trailers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var trailerToUpdate = await _context.Trailers.SingleOrDefaultAsync(t => t.ID == id);
            if (await TryUpdateModelAsync<Trailer>(
                trailerToUpdate,
                "",
                t => t.SerialNumber, t => t.ProductGroup, t => t.Description, t => t.YearOfManufacture))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            return View(trailerToUpdate);
        }

        // GET: Trailers/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trailer = await _context.Trailers
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);
            if (trailer == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }

            return View(trailer);
        }

        // POST: Trailers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trailer = await _context.Trailers
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);
            if (trailer == null)
            {
                return RedirectToAction("Index");
            }

            try
            {
                _context.Trailers.Remove(trailer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
        }
    }
}
