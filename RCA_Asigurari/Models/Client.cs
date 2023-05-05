﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace RCA_Asigurari.Models
{
    public class Client
    {
        public int ID { get; set; }
        [Display(Name = "Numele si prenumele proprietarului")]
        [RegularExpression(@"^[A-ZĂÂÎȘȚăâîșț]+[a-zA-ZĂÂÎȘȚăâîșț\s-]*$", ErrorMessage = "Numele trebuie sa aiba minim 3 caractere, sa inceapa cu majuscula si poate contine doar litere")]
        [StringLength(30, MinimumLength = 3)]
        public string NumeProprietar { get; set; }
        [Display(Name = "Judet")]
        public int JudetID { get; set; }
        public Judet? Judet { get; set; }


        [Display(Name = "Localitate")]
        [RegularExpression(@"^[A-ZĂÂÎȘȚăâîșț]+[a-zA-ZĂÂÎȘȚăâîșț\s-]*$", ErrorMessage = "Numele localității trebuie să înceapă cu majusculă și să aibă minim 2 caractere")]
        public string Localitate { get; set; }

        [RegularExpression(@"^[A-ZĂÂÎȘȚăâîșț]+[a-zA-ZĂÂÎȘȚăâîșț\s-]*$", ErrorMessage = "Numele strazii trebuie sa inceapa cu majuscula si sa aiba minim 2 caractere")]
        [StringLength(30, MinimumLength = 2)]
        public string Strada { get; set; }


        public string Numar { get; set; }


        [Display(Name = "Cod postal")]
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
                return " jud. " + (Judet?.Judetul ?? "") + ", loc. " + (/*Localitate?.*/Localitate ?? "") + ", nr. " + (Numar ?? "") + ", strada " + (Strada ?? "") + ", " + (CodPostal ?? "");
                //return " jud. " + (Judet ?? "") + ", loc. " + (Localitate ?? "") + ", nr. " + (Numar ?? "") + ", strada " + (Strada ?? "") + ", " + (CodPostal ?? "");

            }
        }

        //[Display(Name = "Tipul de client: ")]
        //[BindProperty]
        //public string? RadioButtonClient { get; set; }
        //public string[]? RadioButtonClienti = new[] { "Persoana fizica", "Persoana juridica" };

        [Display(Name = "Tipul clientului")]
        public int? TipClientID { get; set; }
        public TipClient? TipClient { get; set; }

        public ICollection<OfertaPF>? OfertePF { get; set; }
        public ICollection<OfertaPJ>? OfertePJ { get; set; }

      




    }
}
