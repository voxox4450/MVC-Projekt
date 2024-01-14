using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MVC_Projekt.Areas.Identity.Data;
using MVC_Projekt.Models;

namespace MVC_Projekt.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Adres> Adresy { get; set; }
        public DbSet<Grupa> Grupy { get; set; }
        public DbSet<Kontakt> Kontakty { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Tutaj możesz dodać niestandardowe konfiguracje dla bazy danych, jeśli są potrzebne
        }
    }
}
