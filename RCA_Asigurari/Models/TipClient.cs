using System.ComponentModel.DataAnnotations;

namespace RCA_Asigurari.Models
{
    public class TipClient
    {
        public int ID { get; set; }
        [Display(Name = "Tipul de asigurat")]

        public string TipulClientului { get; set; }
        public ICollection<Client>? Clienti { get; set; }

    }
}
