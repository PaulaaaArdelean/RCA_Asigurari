using System.ComponentModel.DataAnnotations;

namespace RCA_Asigurari.Models
{
    public class TipAsigurat
    {
        public int ID { get; set; }

        [Display(Name = "Tipul asiguratului")]
        

        public string TipulAsigurat { get; set; }
         public ICollection<Client>? Clienti { get; set; }
    }
}
