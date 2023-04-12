using System.ComponentModel.DataAnnotations;

namespace RCA_Asigurari.Models
{
    public class OfertaPF
    {
        public int ID { get; set; }
       
        [Display(Name = "Proprietarul")]
        public int? ClientID { get; set; }
        public Client? Client { get; set; }


        [RegularExpression(@"^[1-8][0-9]{2}(0[1-9]|1[0-2])(0[1-9]|[1-2][0-9]|3[0-1])(0[1-9]|[1-4][0-9]|5[0-2])[0-9]{4}$", ErrorMessage = "Un CNP (Cod Numeric Personal) este un cod numeric din 13 cifre atribuit de Guvernul României fiecărui cetățean. Codul este formatat după cum urmează: prima cifră reprezintă sexul, a doua și a treia cifră reprezintă anul nașterii, a patra și a cincea cifră reprezintă luna nașterii, a șasea și a șaptea cifră reprezintă ziua nașterii, a opta cifră reprezintă regiunea nașterii, a noua cifră reprezintă județul de naștere, iar ultimele patru cifre reprezintă ordinea înregistrării.")]
        public string CNP { get; set; }


        //[Display(Name = "Numele")]
        //[RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "Numele trebuie sa aiba minim 3 caractere, sa inceapa cu majuscula si poate contine doar litere")]
        //[StringLength(30, MinimumLength = 3)]
        //public string NumeProprietar { get; set; }

        //[Display(Name = "Prenumele")]
        //[RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "Prenumele trebuie sa aiba minim 3 caractere, sa inceapa cu majuscula si poate contine doar litere")]
        //[StringLength(30, MinimumLength = 3)]
        //public string PrenumeProprietar { get; set; }


        //[Display(Name = "Numele si prenumele proprietarului")]
        //public string NumeIntreg
        //{
        //    get
        //    {
        //        return NumeProprietar + " " + PrenumeProprietar;
        //    }
        //}

        [Display(Name = "Serie CI")]
        [RegularExpression("^[A-Z]{2}$", ErrorMessage = "Seria CI este formata din doua litere mari, care vin de regulă vin de mnemonicul județului (ex. IS-Iași ), dar nu este obligatoriu (ex. AS-Argeș)")]
        public string SerieCI { get; set; }

        [Display(Name = "Numar CI")]
        [RegularExpression("^[0-9]{6}$", ErrorMessage = "Numarul cartii de identitate trebuie sa contina 6 cifre")]
        public string NumarCI { get; set; }

        public int Varsta { get; set; }




        [Display(Name = "Numarul de identificare")]
        [RegularExpression(@"[A-HJ-NP-PR-Z0-9]{17}$", ErrorMessage = "Numarul de identificare este format din 17 caractere – cifre și litere, excluzând literele I, O și Q.")]

        public string NumarIdentificare { get; set; }
        [Display(Name = "Numarul de inmatriculare")]
        [RegularExpression(@"^[A-Z]{2}[0-9]{2}[A-Z]{3}$", ErrorMessage = "Numarul de inmatriculare are forma AA00AAA")]
        public string NrInmatriculare { get; set; }
        public string Marca { get; set; }
        public string Model { get; set; }
        [Display(Name = "Anul fabricatiei")]
        [RegularExpression(@"([0-9]{4})", ErrorMessage = "Campul {0} trebuie sa fie de forma 2001 si nu poate contine litere sau caractere speciale. {0} poate fi minim 1995 si maxim 2024")]
        [Range(1995, 2023)]

        public int AnFabricatie { get; set; }
        [Display(Name = "Capacitate cilindrica")]
        [RegularExpression(@"^[0-9]{3,4}$", ErrorMessage = "Capacitatea cilindrica este formata din 3 sau 4 cifre")]
        public int CapacitateCilindrica { get; set; }
        [Display(Name = "Serie CIV")]
        [RegularExpression(@"^\(?([A-Z]{1})\)?([0-9]{6})$", ErrorMessage = "Seria CIV trebuie sa aiba forma A123456")]

        public string SerieCIV { get; set; }
        [Display(Name = "Numar de locuri")]
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Numarul de locuri trebuie sa fie scris in cifre")]
        public int NrLocuri { get; set; }
        [RegularExpression(@"^[0-9]{3,5}$", ErrorMessage = "Masa maxima este formata din 3, 4 sau 5 cifre")]
        [Display(Name = "Masa maxima")]

        public int MasaMaxima { get; set; }
        [RegularExpression(@"^[0-9]{2,4}$", ErrorMessage = "Puterea trebuie sa fie scrisa din 2, 3 sau 4 cifre")]
        public int Putere { get; set; }

        public int? CategorieVehiculID { get; set; }
        public CategorieVehicul? CategorieVehicul { get; set; }
        public int? TipCombustibilID { get; set; }
        [Display(Name = "Tipul de combustibil")]
        public TipCombustibil? TipCombustibil { get; set; }


        public int? Pret { get; set; }
    }
}
