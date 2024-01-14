using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace MVC_Projekt.Models
{
    public class Kontakt
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Imię jest wymagane.")]
        public string Imie { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane.")]
        public string Nazwisko { get; set; }

        public string NumerTelefonu { get; set; }

        public string AdresEmail { get; set; }

        public string InneInformacje { get; set; }

        public int? GrupaId { get; set; }

        [ForeignKey("GrupaId")]
        public Grupa Grupa { get; set; }

        public Adres Adres { get; set; }
    }
}
