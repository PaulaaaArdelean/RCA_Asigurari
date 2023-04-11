namespace RCA_Asigurari.Models
{
    public class Judet
    {
        public int ID { get; set; }
        public string Judetul { get; set; }
        public ICollection<Localitate>? Localitati { get; set; }
        public ICollection<Client>? Clienti { get; set; }
       
        public ICollection<AdresaClient>? AdreseClienti { get; set; }
       
    }
}
