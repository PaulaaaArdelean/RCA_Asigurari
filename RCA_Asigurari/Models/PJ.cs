using System.ComponentModel.DataAnnotations;

namespace RCA_Asigurari.Models
{
    public class PJ
    {
        public int ID { get; set; }

        [RegularExpression("^[1-9][0-9]{7}$", ErrorMessage = "CUI-ul trebuie sa fie alcatuit din 8 cifre si nu poate incepe cu 0")]
        public string CUI { get; set; }

        [Display(Name = "Tipul societatii")]
        public int? TipSocietateID { get; set; }
        public TipSocietate? TipSocietate { get; set; }

        [Display(Name = "Activitatea societatii")]
        public string ActivitateSocietate { get; set; }

        [Display(Name = "Numele societatii")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "Denumirea societatii trebuie sa aiba minim 3 caractere, sa inceapa cu majuscula si poate contine doar litere")]
        [StringLength(30, MinimumLength = 3)]
        public string NumeFirma { get; set; }


        [Display(Name = "Numele reprezentantului")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "Numele trebuie sa aiba minim 3 caractere, sa inceapa cu majuscula si poate contine doar litere")]
        [StringLength(30, MinimumLength = 3)]
        public string NumeReprezentantFirma { get; set; }


        [Display(Name = "Prenumele reprezentantului")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "Prenumele trebuie sa aiba minim 3 caractere, sa inceapa cu majuscula si poate contine doar litere")]
        [StringLength(30, MinimumLength = 3)]
        public string PrenumeReprezentantFirma { get; set; }

        [Display(Name = "Numele si prenumele reprezentantului firmei")]
        public string NumeIntregReprezentant
        {
            get
            {
                return NumeReprezentantFirma + " " + PrenumeReprezentantFirma;
            }
        }
    }
}
