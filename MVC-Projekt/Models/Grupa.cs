namespace MVC_Projekt.Models
{
    public class Grupa
    {
        public int Id { get; set; }

        public string Nazwa { get; set; }

        public List<Kontakt> Kontakty { get; set; }
    }
}
