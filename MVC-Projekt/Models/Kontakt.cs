using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Projekt.Models
{
    public class Kontakt
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Imię jest wymagane.")]
        public string? Imie { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane.")]
        public string? Nazwisko { get; set; }

        public string? NumerTelefonu { get; set; }

        public string? AdresEmail { get; set; }

        public string? InneInformacje { get; set; }

        public int GrupaId { get; set; }

        [ForeignKey("GrupaId")]
        public Grupa? Grupa { get; set; }

        // Klucz obcy do Adres
        public int AdresId { get; set; }

        [ForeignKey("AdresId")]
        public Adres? Adres { get; set; }
    }
}
