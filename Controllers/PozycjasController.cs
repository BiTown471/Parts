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
    public class PozycjasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PozycjasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pozycjas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pozycja.ToListAsync());
        }

        // GET: Pozycjas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pozycja = await _context.Pozycja
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pozycja == null)
            {
                return NotFound();
            }

            return View(pozycja);
        }

        // GET: Pozycjas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pozycjas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,nazwa")] Pozycja pozycja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pozycja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pozycja);
        }

        // GET: Pozycjas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pozycja = await _context.Pozycja.FindAsync(id);
            if (pozycja == null)
            {
                return NotFound();
            }
            return View(pozycja);
        }

        // POST: Pozycjas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,nazwa")] Pozycja pozycja)
        {
            if (id != pozycja.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pozycja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PozycjaExists(pozycja.ID))
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
            return View(pozycja);
        }

        // GET: Pozycjas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pozycja = await _context.Pozycja
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pozycja == null)
            {
                return NotFound();
            }

            return View(pozycja);
        }

        // POST: Pozycjas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pozycja = await _context.Pozycja.FindAsync(id);
            _context.Pozycja.Remove(pozycja);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PozycjaExists(int id)
        {
            return _context.Pozycja.Any(e => e.ID == id);
        }
    }
}
