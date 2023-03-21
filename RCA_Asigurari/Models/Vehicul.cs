namespace RCA_Asigurari.Models
{
    public class Vehicul
    {
        public int ID { get; set; }


        public int? OfertaID { get; set; }
        public Oferta? Oferte { get; set; }

    }
}
