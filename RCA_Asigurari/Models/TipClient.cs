namespace RCA_Asigurari.Models
{
    public class TipClient
    {
        public int ID { get; set; }
        public string TipulClientului { get; set; }
        public ICollection<Client>? Clienti { get; set; }

    }
}
