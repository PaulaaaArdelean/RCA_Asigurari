using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RCA_Asigurari.Data;
using RCA_Asigurari.Models;

namespace RCA_Asigurari.Pages.OfertePF
{
    public class CreateModel : PageModel
    {
        private readonly RCA_Asigurari.Data.RCA_AsigurariContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CreateModel(RCA_Asigurari.Data.RCA_AsigurariContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager; 
        }

        public IActionResult OnGet()
        {
            var userEmail = User.Identity.Name;
            int CurrentClientID = _context.Client.First(client => client.Email == userEmail).ID;

            var userName = _userManager.GetUserName(User);

            var detaliiClient = _context.Client
                .Where(c => c.Email == userName)
                .Select(x => new
                {
                    x.ID,
                    DetaliiClient = x.NumeProprietar /*+ " " + x.NumeFirma*/
                });
          
            var cnp1 = _context.OfertaPF

                   .Select(x => new
                   {
                       x.ID,
                       cnp = x.CNP
                   });
            ViewData["PretID"] = new SelectList(_context.Oferta, "ID", "Pret");
            ViewData["CategorieVehiculID"] = new SelectList(_context.CategorieVehicul, "ID", "CategoriaVehicul");
            ViewData["ClientID"] = new SelectList(detaliiClient, "ID", "DetaliiClient", CurrentClientID);
            ViewData["TipCombustibilID"] = new SelectList(_context.TipCombustibil, "ID", "TipulCombustibil");

            return Page();
        }

        [BindProperty]
        public OfertaPF OfertaPF { get; set; } = default!;

       
        //Calculam varsta din CNP
                    //public int CalculateAgeFromCNP(string cnp)
                    //{
                    //    int year = int.Parse(cnp.Substring(1, 2));
                    //    int month = int.Parse(cnp.Substring(3, 2));
                    //    int day = int.Parse(cnp.Substring(5, 2));
                    //    int gender = int.Parse(cnp.Substring(0, 1));

                    //    if (gender == 1 || gender == 2)
                    //    {
                    //        year += 1900;
                    //    }
                    //    else if (gender == 3 || gender == 4)
                    //    {
                    //        year += 1800;
                    //    }
                    //    else if (gender == 5 || gender == 6)
                    //    {
                    //        year += 2000;
                    //    }

                    //    DateTime birthDate = new DateTime(year, month, day);
                    //    DateTime currentDate = DateTime.Now;

                    //    int age = currentDate.Year - birthDate.Year;

                    //    if (birthDate > currentDate.AddYears(-age))
                    //    {
                    //        age--;
                    //    }

                    //    return age;
                    //}




        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.OfertaPF == null || OfertaPF == null)
            {
                return Page();
            }

            if (/*OfertaPF.CategorieVehicul.ToString() == "autoturism" &&*/ OfertaPF.NrLocuri <= 9 && OfertaPF.MasaMaxima <= 3500 )
            {
                if (OfertaPF.CapacitateCilindrica <= 1200 && OfertaPF.Varsta <= 30)
                {
                    OfertaPF.Pret = 377;
                }
                else if (OfertaPF.CapacitateCilindrica <= 1200 && OfertaPF.Varsta >=31 && OfertaPF.Varsta <= 40)
                {
                    OfertaPF.Pret = 243;
                }
                else if (OfertaPF.CapacitateCilindrica <= 1200 && OfertaPF.Varsta >= 41 && OfertaPF.Varsta <= 50)
                {
                    OfertaPF.Pret = 237;
                }
                else if (OfertaPF.CapacitateCilindrica <= 1200 && OfertaPF.Varsta >= 51 && OfertaPF.Varsta <= 60)
                {
                    OfertaPF.Pret = 245;
                }
                else if (OfertaPF.CapacitateCilindrica <= 1200 && OfertaPF.Varsta > 61 )
                {
                    OfertaPF.Pret = 246;
                }




                else if (OfertaPF.CapacitateCilindrica > 1200 && OfertaPF.CapacitateCilindrica <= 1400 && OfertaPF.Varsta <= 30)
                {
                    OfertaPF.Pret = 374;
                }
                else if (OfertaPF.CapacitateCilindrica > 1200 && OfertaPF.CapacitateCilindrica <= 1400 && OfertaPF.Varsta >= 31 && OfertaPF.Varsta <= 40)
                {
                    OfertaPF.Pret = 241;
                }
                else if (OfertaPF.CapacitateCilindrica > 1200 && OfertaPF.CapacitateCilindrica <= 1400 && OfertaPF.Varsta >= 41 && OfertaPF.Varsta <= 50)
                {
                    OfertaPF.Pret = 247;
                }
                else if (OfertaPF.CapacitateCilindrica > 1200 && OfertaPF.CapacitateCilindrica <= 1400 && OfertaPF.Varsta >= 51 && OfertaPF.Varsta <= 60)
                {
                    OfertaPF.Pret = 243;
                }
                else if (OfertaPF.CapacitateCilindrica > 1200 && OfertaPF.CapacitateCilindrica <= 1400 && OfertaPF.Varsta >= 61 )
                {
                    OfertaPF.Pret = 245;
                }




                else if (OfertaPF.CapacitateCilindrica > 1400 && OfertaPF.CapacitateCilindrica <= 1600 && OfertaPF.Varsta <= 30)
                {
                    OfertaPF.Pret = 438;
                }
                else if (OfertaPF.CapacitateCilindrica > 1400 && OfertaPF.CapacitateCilindrica <= 1600 && OfertaPF.Varsta >= 31 && OfertaPF.Varsta <= 40)
                {
                    OfertaPF.Pret = 282;
                }
                else if (OfertaPF.CapacitateCilindrica > 1400 && OfertaPF.CapacitateCilindrica <= 1600 && OfertaPF.Varsta >= 41 && OfertaPF.Varsta <= 50)
                {
                    OfertaPF.Pret = 288;
                }
                else if (OfertaPF.CapacitateCilindrica > 1400 && OfertaPF.CapacitateCilindrica <= 1600 && OfertaPF.Varsta >= 51 && OfertaPF.Varsta <= 60)
                {
                    OfertaPF.Pret = 284;
                }
                else if (OfertaPF.CapacitateCilindrica > 1400 && OfertaPF.CapacitateCilindrica <= 1600 && OfertaPF.Varsta >= 61 )
                {
                    OfertaPF.Pret = 286;
                }





                else if (OfertaPF.CapacitateCilindrica > 1600 && OfertaPF.CapacitateCilindrica <= 1800 && OfertaPF.Varsta <= 30 )
                {
                    OfertaPF.Pret = 483;
                }
                else if (OfertaPF.CapacitateCilindrica > 1600 && OfertaPF.CapacitateCilindrica <= 1800 && OfertaPF.Varsta >= 31 && OfertaPF.Varsta <= 40)
                {
                    OfertaPF.Pret = 311;
                }
                else if (OfertaPF.CapacitateCilindrica > 1600 && OfertaPF.CapacitateCilindrica <= 1800 && OfertaPF.Varsta >= 41 && OfertaPF.Varsta <= 50)
                {
                    OfertaPF.Pret = 318;
                }
                else if (OfertaPF.CapacitateCilindrica > 1600 && OfertaPF.CapacitateCilindrica <= 1800 && OfertaPF.Varsta >= 51 && OfertaPF.Varsta <= 60)
                {
                    OfertaPF.Pret = 314;
                }
                else if (OfertaPF.CapacitateCilindrica > 1600 && OfertaPF.CapacitateCilindrica <= 1800 && OfertaPF.Varsta >= 61 )
                {
                    OfertaPF.Pret = 316;
                }




                else if (OfertaPF.CapacitateCilindrica > 1800 && OfertaPF.CapacitateCilindrica <= 2000 && OfertaPF.Varsta <=30 )
                {
                    OfertaPF.Pret = 541;
                }
                else if (OfertaPF.CapacitateCilindrica > 1800 && OfertaPF.CapacitateCilindrica <= 2000 && OfertaPF.Varsta >= 31 && OfertaPF.Varsta <= 40)
                {
                    OfertaPF.Pret = 349;
                }
                else if (OfertaPF.CapacitateCilindrica > 1800 && OfertaPF.CapacitateCilindrica <= 2000 && OfertaPF.Varsta >= 41 && OfertaPF.Varsta <= 50)
                {
                    OfertaPF.Pret = 356;
                }
                else if (OfertaPF.CapacitateCilindrica > 1800 && OfertaPF.CapacitateCilindrica <= 2000 && OfertaPF.Varsta >= 51 && OfertaPF.Varsta <= 60)
                {
                    OfertaPF.Pret = 351;
                }
                else if (OfertaPF.CapacitateCilindrica > 1800 && OfertaPF.CapacitateCilindrica <= 2000 && OfertaPF.Varsta >= 61 )
                {
                    OfertaPF.Pret = 354;
                }





                else if (OfertaPF.CapacitateCilindrica > 2000 && OfertaPF.CapacitateCilindrica <= 2500 && OfertaPF.Varsta <=30 )
                {
                    OfertaPF.Pret = 762;
                }
                else if (OfertaPF.CapacitateCilindrica > 2000 && OfertaPF.CapacitateCilindrica <= 2500 && OfertaPF.Varsta >= 31 && OfertaPF.Varsta <= 40)
                {
                    OfertaPF.Pret = 491;
                }
                else if (OfertaPF.CapacitateCilindrica > 2000 && OfertaPF.CapacitateCilindrica <= 2500 && OfertaPF.Varsta >= 41 && OfertaPF.Varsta <= 50)
                {
                    OfertaPF.Pret = 502;
                }
                else if (OfertaPF.CapacitateCilindrica > 2000 && OfertaPF.CapacitateCilindrica <= 2500 && OfertaPF.Varsta >= 51 && OfertaPF.Varsta <= 60)
                {
                    OfertaPF.Pret = 495;
                }
                else if (OfertaPF.CapacitateCilindrica > 2000 && OfertaPF.CapacitateCilindrica <= 2500 && OfertaPF.Varsta >= 61 )
                {
                    OfertaPF.Pret = 498;
                }





                else if (OfertaPF.CapacitateCilindrica > 2500 && OfertaPF.Varsta <=30 )
                {
                    OfertaPF.Pret = 1021;
                }
                else if (OfertaPF.CapacitateCilindrica > 2500 && OfertaPF.Varsta >= 31 && OfertaPF.Varsta <= 40)
                {
                    OfertaPF.Pret = 658;
                }
                else if (OfertaPF.CapacitateCilindrica > 2500 && OfertaPF.Varsta >= 41 && OfertaPF.Varsta <= 50)
                {
                    OfertaPF.Pret = 673;
                }
                else if (OfertaPF.CapacitateCilindrica > 2500 && OfertaPF.Varsta >= 51 && OfertaPF.Varsta <= 60)
                {
                    OfertaPF.Pret = 663;
                }
                else if (OfertaPF.CapacitateCilindrica > 2500 && OfertaPF.Varsta >= 61 )
                {
                    OfertaPF.Pret = 668;
                }
        }





            else if (OfertaPF.NrLocuri > 9 && OfertaPF.NrLocuri <= 40)

            {
                OfertaPF.Pret = 502;
            }
            else if (OfertaPF.NrLocuri > 40)

            {
                OfertaPF.Pret = 1269;
            }
            else if (OfertaPF.MasaMaxima <= 3500)

            {
                OfertaPF.Pret = 343;
            }
            else if (OfertaPF.MasaMaxima > 3500 && OfertaPF.MasaMaxima <= 15999)

            {
                OfertaPF.Pret = 502;
            }
            else if (OfertaPF.MasaMaxima > 16000)

            {
                OfertaPF.Pret = 1250;
            }



            _context.OfertaPF.Add(OfertaPF);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
