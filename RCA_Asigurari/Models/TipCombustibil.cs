using System.ComponentModel.DataAnnotations;

namespace RCA_Asigurari.Models
{
    public class TipCombustibil
    {
        public int ID { get; set; }

        [Display(Name = "Tipul de combustibil")]
        [RegularExpression(@"(benzina|motorina|hibrid|electric)$", ErrorMessage = "Tipul de combustibil poate fi benzina, motorina, hibrid sau electric")]

        public string TipulCombustibil { get; set; }
       //public ICollection<Vehicul>? Vehicule { get; set; }
        public ICollection<OfertaPF>? OfertePF { get; set; }
        public ICollection<OfertaPJ>? OfertePJ { get; set; }

    }
}
