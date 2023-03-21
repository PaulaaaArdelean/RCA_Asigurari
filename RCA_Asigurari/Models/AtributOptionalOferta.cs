using System.ComponentModel.DataAnnotations;

namespace RCA_Asigurari.Models
{
    public class AtributOptionalOferta
    {
        public int ID { get; set; }
        public int OfertaID { get; set; }
        public Oferta Oferta { get; set; }
        public int AtributOptionalID { get; set; }
        [Display(Name = "Optional")]

        public AtributOptional AtributOptional { get; set; }
    }
}
