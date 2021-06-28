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
    public class PracowniciesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PracowniciesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pracownicies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pracownicy.ToListAsync());
        }

        //GET: Pracownicies
        public IActionResult IndexPraPoz()
        {
            var alist = from pr in _context.Pracownicy
                        join poz in _context.Pozycja on pr.ID_pozycja equals poz.ID
                        //where s.G_ID == 1
                        select new ViewModelPracownicy
                        {
                            PracownicyDM = pr,
                            pozycjaDM = poz,

                        };

            return View(alist.ToList());
        }

        // GET: Pracownicies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pracownicy = await _context.Pracownicy
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pracownicy == null)
            {
                return NotFound();
            }

            return View(pracownicy);
        }

        //// GET: Pracownicies/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // GET: Pracownicies/Create
        public IActionResult Create()
        {
            /* start*/
            IEnumerable<SelectListItem> items = _context.Pozycja.Select(poz => new SelectListItem
            {
                Value = poz.ID.ToString(),
                Text = poz.nazwa

            }); ;



            if (items != null)
            {
                ViewBag.data = items;
            }

            /* end */
            return View();
        }

        // POST: Pracownicies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,imie,nazwisko,email,haslo,wypłata,ID_pozycja")] Pracownicy pracownicy)
        {
            if (ModelState.IsValid)
            {
                /* start */
                int selDesc = Int32.Parse(Request.Form["data"]);
                pracownicy.ID_pozycja = selDesc;
                /*end*/
                _context.Add(pracownicy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexPraPoz));
            }
            return View(pracownicy);
        }

        // GET: Pracownicies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            IEnumerable<SelectListItem> items = _context.Pozycja.Select(poz => new SelectListItem
            {
                Value = poz.ID.ToString(),
                Text = poz.nazwa

            }); ;



            if (items != null)
            {
                ViewBag.data = items;
            }
            if (id == null)
            {
                return NotFound();
            }

            var pracownicy = await _context.Pracownicy.FindAsync(id);
            if (pracownicy == null)
            {
                return NotFound();
            }
            return View(pracownicy);
        }

        // POST: Pracownicies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,imie,nazwisko,email,haslo,wypłata,ID_pozycja")] Pracownicy pracownicy)
        {
            if (id != pracownicy.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    int selDesc = Int32.Parse(Request.Form["data"]);
                    pracownicy.ID_pozycja = selDesc;
                    _context.Update(pracownicy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PracownicyExists(pracownicy.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(IndexPraPoz));
            }
            return View(pracownicy);
        }

        // GET: Pracownicies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pracownicy = await _context.Pracownicy
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pracownicy == null)
            {
                return NotFound();
            }

            return View(pracownicy);
        }

        // POST: Pracownicies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pracownicy = await _context.Pracownicy.FindAsync(id);
            _context.Pracownicy.Remove(pracownicy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexPraPoz));
        }

        private bool PracownicyExists(int id)
        {
            return _context.Pracownicy.Any(e => e.ID == id);
        }
    }
}
