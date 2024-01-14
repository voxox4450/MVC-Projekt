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

        public IActionResult Dodaj()
        {
            ViewBag.Grupy = new SelectList(_context.Grupy.ToList(), "Id", "Nazwa");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Dodaj([Bind("Id,Imie,Nazwisko,NumerTelefonu,AdresEmail,InneInformacje,GrupaId,Adres.Ulica,Adres.Miasto,Adres.KodPocztowy,Adres.Kraj,Grupa.Nazwa")] Kontakt kontakt)
        {
            if (ModelState.IsValid)
            {
                // Sprawdzenie czy wprowadzono własną nazwę grupy
                if (!string.IsNullOrEmpty(kontakt.Grupa?.Nazwa))
                {
                    // Sprawdzanie czy taka grupa już istnieje
                    var existingGroup = await _context.Grupy.FirstOrDefaultAsync(g => g.Nazwa == kontakt.Grupa.Nazwa);
                    if (existingGroup == null)
                    {
                        // Dodawanie nowej grupy
                        kontakt.GrupaId = 0; // Ustawienie na zero, aby EF Core zrozumiał, że to jest nowa grupa
                        _context.Grupy.Add(kontakt.Grupa);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        // Ustawienie istniejącej grupy
                        kontakt.GrupaId = existingGroup.Id;
                    }
                }

                // Sprawdzanie czy adres jest pusty, jeśli tak, ustaw adres na null
                if (string.IsNullOrEmpty(kontakt.Adres?.Ulica) && string.IsNullOrEmpty(kontakt.Adres?.Miasto) && string.IsNullOrEmpty(kontakt.Adres?.KodPocztowy) && string.IsNullOrEmpty(kontakt.Adres?.Kraj))
                {
                    kontakt.Adres = null;
                }

                _context.Add(kontakt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Grupy = new SelectList(_context.Grupy.ToList(), "Id", "Nazwa", kontakt.GrupaId);
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
                // Sprawdzanie czy adres jest pusty, jeśli tak, ustaw adres na null
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
            var kontakt = await _context.Kontakty.FindAsync(id);
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
