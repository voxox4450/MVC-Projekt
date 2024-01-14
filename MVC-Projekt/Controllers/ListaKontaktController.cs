using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Projekt.Data;
using MVC_Projekt.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class ListaKontaktController : Controller
{
    private readonly ApplicationDbContext _context;

    public ListaKontaktController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var kontakty = await _context.Kontakty.Include(k => k.Grupa).Include(k => k.Adres).ToListAsync();
        return View(kontakty);
    }
}
