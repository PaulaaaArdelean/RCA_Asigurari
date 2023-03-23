using System.ComponentModel.DataAnnotations;

namespace RCA_Asigurari.Models
{
    public class PersoanaJuridica
    {
        public int ID { get; set; }
        [Display(Name = "Proprietarul")]

        public int? ClientID { get; set; }
        public Client? Client { get; set; }
        [Display(Name ="Tipul de societate")]
        public int? TipSocietateID { get; set; }
           public TipSocietate? TipSocietate { get; set; }
        [Display(Name = "Județul")]

        public int? JudetID { get; set; }
        public Judet? Judet { get; set; }
        [Display(Name = "Localitatea")]
        public int? LocalitateID { get; set; }
        public Localitate? Localitate { get; set; }
    }
}
