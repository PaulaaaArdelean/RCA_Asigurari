namespace RCA_Asigurari.Models
{
    public class Localitate
    {
        public int ID { get; set; }
        public string Localitatea { get; set; }
        public int? JudetID { get; set; }
        public Judet? Judet { get; set; }
        public ICollection<Client>? Clienti { get; set; }
        public ICollection<AdresaClient>? AdreseClienti { get; set; }
    }
}
