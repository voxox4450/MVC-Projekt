using Microsoft.AspNetCore.Mvc;
using MVC_Projekt.Models;

namespace MVC_Projekt.Controllers
{
    public class ContactsController : Controller
    {
        // Akcja wyświetlająca formularz dodawania kontaktu
        public ActionResult Create()
        {
            return View();
        }

        // Akcja przetwarzająca dane z formularza dodawania kontaktu
        [HttpPost]
        public ActionResult Create(Contact contact)
        {
            // Tutaj możesz dodać kod obsługi dodawania kontaktu do bazy danych
            // np. używając Entity Framework
            // DbContext.Add(contact);
            // DbContext.SaveChanges();

            // Przekierowanie po dodaniu kontaktu
            return RedirectToAction("Index", "Home");
        }
    }
}
