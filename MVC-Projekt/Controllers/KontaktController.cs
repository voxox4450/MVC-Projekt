using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Projekt.Data;
using MVC_Projekt.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Projekt.Controllers
{
    [Authorize(Roles = "Admin")]
    public class KontaktyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KontaktyController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var kontakty = await _context.Kontakty.Include(k => k.Grupa).Include(k => k.Adres).ToListAsync();
            return View(kontakty);
        }

        public IActionResult Dodano()
        {
            return View();
        }

        public IActionResult DodajAdres()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DodajAdres([Bind("Id,Ulica,Miasto,KodPocztowy,Kraj,KontaktId")] Adres adres)
        {
            if (ModelState.IsValid)
            {
                _context.Adresy.Add(adres);
                await _context.SaveChangesAsync();

                // Zapamiętaj ID dodanego adresu w TempData
                TempData["AdresId"] = adres.Id;

                // Przekieruj do widoku dodawania grupy
                return RedirectToAction(nameof(DodajGrupe));
            }

            return View(adres);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DodajGrupe([Bind("Id,Nazwa")] Grupa grupa)
        {
            if (ModelState.IsValid)
            {
                _context.Grupy.Add(grupa);
                await _context.SaveChangesAsync();

                // Zapamiętaj ID dodanej grupy w TempData
                TempData["GrupaId"] = grupa.Id;

                // Przekieruj do widoku dodawania kontaktu
                return RedirectToAction(nameof(DodajKontakt));
            }

            return View(grupa);
        }

        public IActionResult DodajKontakt()
        {
            // Pobierz dostępne adresy i grupy z bazy danych
            var adresy = _context.Adresy.ToList();
            var grupy = _context.Grupy.ToList();

            // Inicjuj ViewBag
            ViewBag.Adresy = new SelectList(adresy, "Id", "Ulica");
            ViewBag.Grupy = new SelectList(grupy, "Id", "Nazwa");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DodajKontakt([Bind("Id,Imie,Nazwisko,NumerTelefonu,AdresEmail,InneInformacje,GrupaId,AdresId")] Kontakt kontakt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kontakt);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Dodano));
            }

            // Jeśli ModelState.IsValid == false, ponownie pobierz dostępne adresy i grupy
            var adresy = _context.Adresy.ToList();
            var grupy = _context.Grupy.ToList();

            // Zainicjuj ViewBag
            ViewBag.Adresy = new SelectList(adresy, "Id", "Ulica", kontakt.AdresId);
            ViewBag.Grupy = new SelectList(grupy, "Id", "Nazwa", kontakt.GrupaId);

            return View(kontakt);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Zmien(int id, [Bind("Id,Imie,Nazwisko,NumerTelefonu,AdresEmail,InneInformacje,GrupaId,Adres.Ulica,Adres.Miasto,Adres.KodPocztowy,Adres.Kraj")] Kontakt kontakt)
        {
            if (id != kontakt.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(kontakt.Adres?.Ulica) && string.IsNullOrEmpty(kontakt.Adres?.Miasto) && string.IsNullOrEmpty(kontakt.Adres?.KodPocztowy) && string.IsNullOrEmpty(kontakt.Adres?.Kraj))
                {
                    kontakt.Adres = null;
                }

                try
                {
                    _context.Update(kontakt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KontaktExists(kontakt.Id))
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
            ViewBag.Grupy = new SelectList(_context.Grupy.ToList(), "Id", "Nazwa", kontakt.GrupaId);
            return View(kontakt);
        }

        public async Task<IActionResult> Usun(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kontakt = await _context.Kontakty
                .Include(k => k.Grupa)
                .Include(k => k.Adres)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kontakt == null)
            {
                return NotFound();
            }

            return View(kontakt);
        }

        [HttpPost, ActionName("Usun")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PotwierdzUsun(int id)
        {
            var kontakt = await _context.Kontakty
                .Include(k => k.Grupa)
                .Include(k => k.Adres)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (kontakt != null)
            {
                _context.Kontakty.Remove(kontakt);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool KontaktExists(int id)
        {
            return _context.Kontakty.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Grupy()
        {
            var grupy = await _context.Grupy.ToListAsync();
            return View(grupy);
        }

        public async Task<IActionResult> Adresy()
        {
            var adresy = await _context.Adresy.ToListAsync();
            return View(adresy);
        }
    }
}
