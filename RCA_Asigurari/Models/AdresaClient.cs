using System.ComponentModel.DataAnnotations;

namespace RCA_Asigurari.Models
{
    public class AdresaClient
    {
        public int ID { get; set; }

        [Display(Name = "Judetul")]
        public int JudetID { get; set; }
        public Judet? Judet { get; set; }


        [Display(Name = "Localitatea")]
        public int LocalitateID { get; set; }
        public Localitate? Localitate { get; set; }


        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "Numele strazii trebuie sa inceapa cu majuscula si sa aiba minim 2 caractere")]
        [StringLength(30, MinimumLength = 2)]
        public string Strada { get; set; }


        public string Numar { get; set; }


        [Display(Name = "Codul postal")]
        [RegularExpression("^[0-9]{6}$", ErrorMessage = "Codul postal trebuie sa contina 6 cifre")]
        public string CodPostal { get; set; }



        [RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,3}$", ErrorMessage = "Datele introduse de dumneavoastra nu am forma unui email.")]

        public string Email { get; set; }



        [RegularExpression(@"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Telefonul trebuie sa fie de forma '0722-123-123' sau '0722.123.123' sau '0722 123 123'")]
        public string Telefon { get; set; }
        public string Adresa
        {
            get
            {
                return " jud. " + (Judet?.Judetul ?? "") + ", loc. " + (Localitate?.Localitatea ?? "") + ", nr. " + (Numar ?? "") + ", strada " + (Strada ?? "") + ", " + (CodPostal ?? "");
            }
        }
    }
}
