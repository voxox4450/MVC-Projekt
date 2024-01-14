using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Projekt.Data;
using MVC_Projekt.Models;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Imie,Nazwisko,NumerTelefonu,AdresEmail,InneInformacje,GrupaId")] Kontakt kontakt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kontakt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kontakt);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kontakt = await _context.Kontakty.FindAsync(id);
            if (kontakt == null)
            {
                return NotFound();
            }
            return View(kontakt);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Imie,Nazwisko,NumerTelefonu,AdresEmail,InneInformacje,GrupaId")] Kontakt kontakt)
        {
            if (id != kontakt.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
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
            return View(kontakt);
        }

        public async Task<IActionResult> Delete(int? id)
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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kontakt = await _context.Kontakty.FindAsync(id);
            if (kontakt != null)
            {
                _context.Kontakty.Remove(kontakt);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KontaktExists(int id)
        {
            return _context.Kontakty.Any(e => e.Id == id);
        }

        // Dodaj nową akcję dla grup
        public async Task<IActionResult> Grupy()
        {
            var grupy = await _context.Grupy.ToListAsync();
            return View(grupy);
        }

        // Dodaj nową akcję dla adresów
        public async Task<IActionResult> Adresy()
        {
            var adresy = await _context.Adresy.ToListAsync();
            return View(adresy);
        }
    }
}
