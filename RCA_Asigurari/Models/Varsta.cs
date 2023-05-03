namespace RCA_Asigurari.Models
{
    public class Varsta
    {
        public int ID { get; set; }
        public int Varstaa { get; set; }
       
        public ICollection<OfertaPF>? OfertePF { get; set; }

    }
}
