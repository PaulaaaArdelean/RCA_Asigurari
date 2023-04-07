using System.ComponentModel.DataAnnotations;

namespace RCA_Asigurari.Models
{
    public class PF
    {
        public int ID { get; set; }

        [RegularExpression(@"^[1-8][0-9]{2}(0[1-9]|1[0-2])(0[1-9]|[1-2][0-9]|3[0-1])(0[1-9]|[1-4][0-9]|5[0-2])[0-9]{4}$", ErrorMessage = "Un CNP (Cod Numeric Personal) este un cod numeric din 13 cifre atribuit de Guvernul României fiecărui cetățean. Codul este formatat după cum urmează: prima cifră reprezintă sexul, a doua și a treia cifră reprezintă anul nașterii, a patra și a cincea cifră reprezintă luna nașterii, a șasea și a șaptea cifră reprezintă ziua nașterii, a opta cifră reprezintă regiunea nașterii, a noua cifră reprezintă județul de naștere, iar ultimele patru cifre reprezintă ordinea înregistrării.")]
        public string CNP { get; set; }


        [Display(Name = "Numele")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "Numele trebuie sa aiba minim 3 caractere, sa inceapa cu majuscula si poate contine doar litere")]
        [StringLength(30, MinimumLength = 3)]
        public string NumeProprietar { get; set; }

        [Display(Name = "Prenumele")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "Prenumele trebuie sa aiba minim 3 caractere, sa inceapa cu majuscula si poate contine doar litere")]
        [StringLength(30, MinimumLength = 3)]
        public string PrenumeProprietar { get; set; }



        [Display(Name = "Numele si prenumele proprietarului")]
        public string NumeIntreg
        {
            get
            {
                return NumeProprietar + " " + PrenumeProprietar;
            }
        }



        [Display(Name = "Serie CI")]
        [RegularExpression("^[A-Z]{2}$", ErrorMessage = "Seria CI este formata din doua litere mari, care vin de regulă vin de mnemonicul județului (ex. IS-Iași ), dar nu este obligatoriu (ex. AS-Argeș)")]
        public string SerieCI { get; set; }


        [Display(Name = "Numar CI")]
        [RegularExpression("^[0-9]{6}$", ErrorMessage = "Numarul cartii de identitate trebuie sa contina 6 cifre")]
        public string NumarCI { get; set; }


        public string Varsta { get; set; }

    }
}
