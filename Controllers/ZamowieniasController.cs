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
    public class ZamowieniasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ZamowieniasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Zamowienias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zamowienia.ToListAsync());
        }
        // GET: Zamowienias
        public IActionResult IndexZaKliPr()
        {
            var alist = from Za in _context.Zamowienia
                        join Kli in _context.Klienci on Za.ID_klienta equals Kli.ID
                        join Pr in _context.Produkty on Za.ID_Produktu equals Pr.ID
                        //where s.G_ID == 1
                        select new ViewModelZaKliPr
                        {
                            ZamowieniaVMm = Za,
                            KlienciVm = Kli,
                            ProduktyVm = Pr
                        };

            return View(alist.ToList());
        }

        // GET: Zamowienias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zamowienia = await _context.Zamowienia
                .FirstOrDefaultAsync(m => m.ID == id);
            if (zamowienia == null)
            {
                return NotFound();
            }

            return View(zamowienia);
        }

        // GET: Zamowienias/Create
        public IActionResult Create()
        {
            /* start*/
            IEnumerable<SelectListItem> itemsKli = _context.Klienci.Select(kli => new SelectListItem
            {
                Value = kli.ID.ToString(),
                Text = kli.nazwa
                

            }); ;
            IEnumerable<SelectListItem> itemsPr = _context.Produkty.Select(Pr => new SelectListItem
            {
                Value = Pr.ID.ToString(),
                Text = Pr.nazwa

            }); ;



            if (itemsKli != null)
            {
                ViewBag.dataKli = itemsKli;
            }
            if (itemsPr != null)
            {
                ViewBag.dataPr = itemsPr;
            }

            /* end */
            return View();
        }

        // POST: Zamowienias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ID_klienta,ID_Produktu,ilość,suma_zamowienia")] Zamowienia zamowienia)
        {
            if (ModelState.IsValid)
            {
                int IdKli = Int32.Parse(Request.Form["dataKli"]);
                int IdPr = Int32.Parse(Request.Form["dataPr"]);

                if (zamowienia.ilość < _context.Produkty.Find(IdPr).ilość_magazynowa)
                {
                    /* start */

                    zamowienia.ID_klienta = IdKli;
                    zamowienia.ID_Produktu = IdPr;
                    var cena = _context.Produkty.Find(IdPr).cena;
                    zamowienia.suma_zamowienia = zamowienia.ilość * cena;

                    var IloscPr = _context.Produkty.Find(IdPr);
                    IloscPr.ilość_magazynowa -= zamowienia.ilość;
                    /*end*/
                    _context.Add(zamowienia);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(IndexZaKliPr));
                }
                else
                {
                    return RedirectToAction(nameof(IndexZaKliPr));
                }
            }
            return View(zamowienia);
        }

        // GET: Zamowienias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            
            var zamowienia = await _context.Zamowienia.FindAsync(id);
            var nazwaPR = _context.Produkty.Find(zamowienia.ID_Produktu).nazwa;
            ViewBag.nazwaPR = nazwaPR;

            if (zamowienia == null)
            {
                return NotFound();
            }


            return View(zamowienia);
        }

        // POST: Zamowienias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ID_klienta,ID_Produktu,ilość,suma_zamowienia")] Zamowienia zamowienia)
        {
            if (id != zamowienia.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (zamowienia.ilość > 0)
                    {
                        

                       
                        int Old = (from za in _context.Zamowienia
                                  where za.ID == zamowienia.ID
                                  select  za.ilość).First();
                        _context.Update(zamowienia);
                        

                        int i = _context.Produkty.Find(zamowienia.ID_Produktu).ilość_magazynowa;
                        i -= zamowienia.ilość;
                        var IloscPr = _context.Produkty.Find(zamowienia.ID_Produktu);
                        if (i >= 0) { 
                            int roznica = Old - zamowienia.ilość ; 
                            
                            IloscPr.ilość_magazynowa += roznica;
                        }
                        else
                        {
                            zamowienia.ilość -= i;
                            IloscPr.ilość_magazynowa = 0;
                        }
                        zamowienia.suma_zamowienia = zamowienia.ilość * IloscPr.cena;
                        _context.Update(zamowienia); 
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        return RedirectToAction(nameof(IndexZaKliPr));
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZamowieniaExists(zamowienia.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(IndexZaKliPr));
            }
            return View(zamowienia);
        }

        // GET: Zamowienias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zamowienia = await _context.Zamowienia
                .FirstOrDefaultAsync(m => m.ID == id);
            if (zamowienia == null)
            {
                return NotFound();
            }

            return View(zamowienia);
        }

        // POST: Zamowienias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zamowienia = await _context.Zamowienia.FindAsync(id);
            _context.Zamowienia.Remove(zamowienia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexZaKliPr));
        }

        private bool ZamowieniaExists(int id)
        {
            return _context.Zamowienia.Any(e => e.ID == id);
        }
    }
}
