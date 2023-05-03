using System.ComponentModel.DataAnnotations;

namespace RCA_Asigurari.Models
{
    public class CategorieVehicul
    {
        public int ID { get; set; }
        [Display(Name = "Categorie")]
        public string CategoriaVehicul { get; set; }
    
       public ICollection<OfertaPF>? OfertePF { get; set; }
        public ICollection<OfertaPJ>? OfertePJ { get; set; }


    }
}
