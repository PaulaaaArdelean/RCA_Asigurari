using System.ComponentModel.DataAnnotations;

namespace RCA_Asigurari.Models
{
    public class CategorieVehicul
    {
        public int ID { get; set; }
        [Display(Name = "Categorie")]
        public string CategoriaVehicul { get; set; }
       // public ICollection<Vehicul>? Vehicule { get; set; }
       public ICollection<Oferta>? Oferte { get; set; }

    }
}
