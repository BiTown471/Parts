using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Parts.Data;
using Parts.Models;

namespace Parts.Controllers
{
    public class ProduktiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProduktiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Produkties
        public async Task<IActionResult> Index()
        {
            return View(await _context.Produkty.ToListAsync());
        }

        // GET: Produkties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produkty = await _context.Produkty
                .FirstOrDefaultAsync(m => m.ID == id);
            if (produkty == null)
            {
                return NotFound();
            }

            return View(produkty);
        }

        // GET: Produkties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produkties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,nazwa,cena,ilość_magazynowa")] Produkty produkty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produkty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produkty);
        }

        // GET: Produkties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produkty = await _context.Produkty.FindAsync(id);
            if (produkty == null)
            {
                return NotFound();
            }
            return View(produkty);
        }

        // POST: Produkties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,nazwa,cena,ilość_magazynowa")] Produkty produkty)
        {
            if (id != produkty.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produkty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProduktyExists(produkty.ID))
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
            return View(produkty);
        }

        // GET: Produkties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produkty = await _context.Produkty
                .FirstOrDefaultAsync(m => m.ID == id);
            if (produkty == null)
            {
                return NotFound();
            }

            return View(produkty);
        }

        // POST: Produkties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produkty = await _context.Produkty.FindAsync(id);
            _context.Produkty.Remove(produkty);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProduktyExists(int id)
        {
            return _context.Produkty.Any(e => e.ID == id);
        }
    }
}
