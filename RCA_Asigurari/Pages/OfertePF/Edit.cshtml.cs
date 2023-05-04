using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RCA_Asigurari.Data;
using RCA_Asigurari.Models;

namespace RCA_Asigurari.Pages.OfertePF
{
    

    public class EditModel : PageModel
    {
        private readonly RCA_Asigurari.Data.RCA_AsigurariContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public EditModel(RCA_Asigurari.Data.RCA_AsigurariContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public OfertaPF OfertaPF { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
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
            if (id == null || _context.OfertaPF == null)
            {
                return NotFound();
            }

            var ofertapf =  await _context.OfertaPF.FirstOrDefaultAsync(m => m.ID == id);
            if (ofertapf == null)
            {
                return NotFound();
            }
            OfertaPF = ofertapf;
           ViewData["CategorieVehiculID"] = new SelectList(_context.CategorieVehicul, "ID", "CategoriaVehicul");
            ViewData["ClientID"] = new SelectList(detaliiClient, "ID", "DetaliiClient", CurrentClientID);
            ViewData["TipCombustibilID"] = new SelectList(_context.TipCombustibil, "ID", "TipulCombustibil");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (/*OfertaPF.CategorieVehicul.ToString() == "autoturism" &&*/ OfertaPF.NrLocuri <= 9 && OfertaPF.MasaMaxima <= 3500)
            {
                if (OfertaPF.CapacitateCilindrica <= 1200 && OfertaPF.Varsta <= 30)
                {
                    OfertaPF.Pret = 377;
                }
                else if (OfertaPF.CapacitateCilindrica <= 1200 && OfertaPF.Varsta >= 31 && OfertaPF.Varsta <= 40)
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
                else if (OfertaPF.CapacitateCilindrica <= 1200 && OfertaPF.Varsta > 61)
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
                else if (OfertaPF.CapacitateCilindrica > 1200 && OfertaPF.CapacitateCilindrica <= 1400 && OfertaPF.Varsta >= 61)
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
                else if (OfertaPF.CapacitateCilindrica > 1400 && OfertaPF.CapacitateCilindrica <= 1600 && OfertaPF.Varsta >= 61)
                {
                    OfertaPF.Pret = 286;
                }





                else if (OfertaPF.CapacitateCilindrica > 1600 && OfertaPF.CapacitateCilindrica <= 1800 && OfertaPF.Varsta <= 30)
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
                else if (OfertaPF.CapacitateCilindrica > 1600 && OfertaPF.CapacitateCilindrica <= 1800 && OfertaPF.Varsta >= 61)
                {
                    OfertaPF.Pret = 316;
                }




                else if (OfertaPF.CapacitateCilindrica > 1800 && OfertaPF.CapacitateCilindrica <= 2000 && OfertaPF.Varsta <= 30)
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
                else if (OfertaPF.CapacitateCilindrica > 1800 && OfertaPF.CapacitateCilindrica <= 2000 && OfertaPF.Varsta >= 61)
                {
                    OfertaPF.Pret = 354;
                }





                else if (OfertaPF.CapacitateCilindrica > 2000 && OfertaPF.CapacitateCilindrica <= 2500 && OfertaPF.Varsta <= 30)
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
                else if (OfertaPF.CapacitateCilindrica > 2000 && OfertaPF.CapacitateCilindrica <= 2500 && OfertaPF.Varsta >= 61)
                {
                    OfertaPF.Pret = 498;
                }





                else if (OfertaPF.CapacitateCilindrica > 2500 && OfertaPF.Varsta <= 30)
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
                else if (OfertaPF.CapacitateCilindrica > 2500 && OfertaPF.Varsta >= 61)
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

            _context.Attach(OfertaPF).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfertaPFExists(OfertaPF.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }


                //if (/*OfertaPF.CategorieVehicul.ToString() == "autoturism" &&*/ OfertaPF.NrLocuri <= 9 && OfertaPF.MasaMaxima <= 3500)
                //{
                //    if (OfertaPF.CapacitateCilindrica <= 1200 && OfertaPF.Varsta <= 30)
                //    {
                //        OfertaPF.Pret = 377;
                //    }
                //    else if (OfertaPF.CapacitateCilindrica <= 1200 && OfertaPF.Varsta >= 31 && OfertaPF.Varsta <= 40)
                //    {
                //        OfertaPF.Pret = 243;
                //    }
                //    else if (OfertaPF.CapacitateCilindrica <= 1200 && OfertaPF.Varsta >= 41 && OfertaPF.Varsta <= 50)
                //    {
                //        OfertaPF.Pret = 237;
                //    }
                //    else if (OfertaPF.CapacitateCilindrica <= 1200 && OfertaPF.Varsta >= 51 && OfertaPF.Varsta <= 60)
                //    {
                //        OfertaPF.Pret = 245;
                //    }
                //    else if (OfertaPF.CapacitateCilindrica <= 1200 && OfertaPF.Varsta > 61)
                //    {
                //        OfertaPF.Pret = 246;
                //    }




                //    else if (OfertaPF.CapacitateCilindrica > 1200 && OfertaPF.CapacitateCilindrica <= 1400 && OfertaPF.Varsta <= 30)
                //    {
                //        OfertaPF.Pret = 374;
                //    }
                //    else if (OfertaPF.CapacitateCilindrica > 1200 && OfertaPF.CapacitateCilindrica <= 1400 && OfertaPF.Varsta >= 31 && OfertaPF.Varsta <= 40)
                //    {
                //        OfertaPF.Pret = 241;
                //    }
                //    else if (OfertaPF.CapacitateCilindrica > 1200 && OfertaPF.CapacitateCilindrica <= 1400 && OfertaPF.Varsta >= 41 && OfertaPF.Varsta <= 50)
                //    {
                //        OfertaPF.Pret = 247;
                //    }
                //    else if (OfertaPF.CapacitateCilindrica > 1200 && OfertaPF.CapacitateCilindrica <= 1400 && OfertaPF.Varsta >= 51 && OfertaPF.Varsta <= 60)
                //    {
                //        OfertaPF.Pret = 243;
                //    }
                //    else if (OfertaPF.CapacitateCilindrica > 1200 && OfertaPF.CapacitateCilindrica <= 1400 && OfertaPF.Varsta >= 61)
                //    {
                //        OfertaPF.Pret = 245;
                //    }




                //    else if (OfertaPF.CapacitateCilindrica > 1400 && OfertaPF.CapacitateCilindrica <= 1600 && OfertaPF.Varsta <= 30)
                //    {
                //        OfertaPF.Pret = 438;
                //    }
                //    else if (OfertaPF.CapacitateCilindrica > 1400 && OfertaPF.CapacitateCilindrica <= 1600 && OfertaPF.Varsta >= 31 && OfertaPF.Varsta <= 40)
                //    {
                //        OfertaPF.Pret = 282;
                //    }
                //    else if (OfertaPF.CapacitateCilindrica > 1400 && OfertaPF.CapacitateCilindrica <= 1600 && OfertaPF.Varsta >= 41 && OfertaPF.Varsta <= 50)
                //    {
                //        OfertaPF.Pret = 288;
                //    }
                //    else if (OfertaPF.CapacitateCilindrica > 1400 && OfertaPF.CapacitateCilindrica <= 1600 && OfertaPF.Varsta >= 51 && OfertaPF.Varsta <= 60)
                //    {
                //        OfertaPF.Pret = 284;
                //    }
                //    else if (OfertaPF.CapacitateCilindrica > 1400 && OfertaPF.CapacitateCilindrica <= 1600 && OfertaPF.Varsta >= 61)
                //    {
                //        OfertaPF.Pret = 286;
                //    }





                //    else if (OfertaPF.CapacitateCilindrica > 1600 && OfertaPF.CapacitateCilindrica <= 1800 && OfertaPF.Varsta <= 30)
                //    {
                //        OfertaPF.Pret = 483;
                //    }
                //    else if (OfertaPF.CapacitateCilindrica > 1600 && OfertaPF.CapacitateCilindrica <= 1800 && OfertaPF.Varsta >= 31 && OfertaPF.Varsta <= 40)
                //    {
                //        OfertaPF.Pret = 311;
                //    }
                //    else if (OfertaPF.CapacitateCilindrica > 1600 && OfertaPF.CapacitateCilindrica <= 1800 && OfertaPF.Varsta >= 41 && OfertaPF.Varsta <= 50)
                //    {
                //        OfertaPF.Pret = 318;
                //    }
                //    else if (OfertaPF.CapacitateCilindrica > 1600 && OfertaPF.CapacitateCilindrica <= 1800 && OfertaPF.Varsta >= 51 && OfertaPF.Varsta <= 60)
                //    {
                //        OfertaPF.Pret = 314;
                //    }
                //    else if (OfertaPF.CapacitateCilindrica > 1600 && OfertaPF.CapacitateCilindrica <= 1800 && OfertaPF.Varsta >= 61)
                //    {
                //        OfertaPF.Pret = 316;
                //    }




                //    else if (OfertaPF.CapacitateCilindrica > 1800 && OfertaPF.CapacitateCilindrica <= 2000 && OfertaPF.Varsta <= 30)
                //    {
                //        OfertaPF.Pret = 541;
                //    }
                //    else if (OfertaPF.CapacitateCilindrica > 1800 && OfertaPF.CapacitateCilindrica <= 2000 && OfertaPF.Varsta >= 31 && OfertaPF.Varsta <= 40)
                //    {
                //        OfertaPF.Pret = 349;
                //    }
                //    else if (OfertaPF.CapacitateCilindrica > 1800 && OfertaPF.CapacitateCilindrica <= 2000 && OfertaPF.Varsta >= 41 && OfertaPF.Varsta <= 50)
                //    {
                //        OfertaPF.Pret = 356;
                //    }
                //    else if (OfertaPF.CapacitateCilindrica > 1800 && OfertaPF.CapacitateCilindrica <= 2000 && OfertaPF.Varsta >= 51 && OfertaPF.Varsta <= 60)
                //    {
                //        OfertaPF.Pret = 351;
                //    }
                //    else if (OfertaPF.CapacitateCilindrica > 1800 && OfertaPF.CapacitateCilindrica <= 2000 && OfertaPF.Varsta >= 61)
                //    {
                //        OfertaPF.Pret = 354;
                //    }





                //    else if (OfertaPF.CapacitateCilindrica > 2000 && OfertaPF.CapacitateCilindrica <= 2500 && OfertaPF.Varsta <= 30)
                //    {
                //        OfertaPF.Pret = 762;
                //    }
                //    else if (OfertaPF.CapacitateCilindrica > 2000 && OfertaPF.CapacitateCilindrica <= 2500 && OfertaPF.Varsta >= 31 && OfertaPF.Varsta <= 40)
                //    {
                //        OfertaPF.Pret = 491;
                //    }
                //    else if (OfertaPF.CapacitateCilindrica > 2000 && OfertaPF.CapacitateCilindrica <= 2500 && OfertaPF.Varsta >= 41 && OfertaPF.Varsta <= 50)
                //    {
                //        OfertaPF.Pret = 502;
                //    }
                //    else if (OfertaPF.CapacitateCilindrica > 2000 && OfertaPF.CapacitateCilindrica <= 2500 && OfertaPF.Varsta >= 51 && OfertaPF.Varsta <= 60)
                //    {
                //        OfertaPF.Pret = 495;
                //    }
                //    else if (OfertaPF.CapacitateCilindrica > 2000 && OfertaPF.CapacitateCilindrica <= 2500 && OfertaPF.Varsta >= 61)
                //    {
                //        OfertaPF.Pret = 498;
                //    }





                //    else if (OfertaPF.CapacitateCilindrica > 2500 && OfertaPF.Varsta <= 30)
                //    {
                //        OfertaPF.Pret = 1021;
                //    }
                //    else if (OfertaPF.CapacitateCilindrica > 2500 && OfertaPF.Varsta >= 31 && OfertaPF.Varsta <= 40)
                //    {
                //        OfertaPF.Pret = 658;
                //    }
                //    else if (OfertaPF.CapacitateCilindrica > 2500 && OfertaPF.Varsta >= 41 && OfertaPF.Varsta <= 50)
                //    {
                //        OfertaPF.Pret = 673;
                //    }
                //    else if (OfertaPF.CapacitateCilindrica > 2500 && OfertaPF.Varsta >= 51 && OfertaPF.Varsta <= 60)
                //    {
                //        OfertaPF.Pret = 663;
                //    }
                //    else if (OfertaPF.CapacitateCilindrica > 2500 && OfertaPF.Varsta >= 61)
                //    {
                //        OfertaPF.Pret = 668;
                //    }
                //}





                //else if (OfertaPF.NrLocuri > 9 && OfertaPF.NrLocuri <= 40)

                //{
                //    OfertaPF.Pret = 502;
                //}
                //else if (OfertaPF.NrLocuri > 40)

                //{
                //    OfertaPF.Pret = 1269;
                //}
                //else if (OfertaPF.MasaMaxima <= 3500)

                //{
                //    OfertaPF.Pret = 343;
                //}
                //else if (OfertaPF.MasaMaxima > 3500 && OfertaPF.MasaMaxima <= 15999)

                //{
                //    OfertaPF.Pret = 502;
                //}
                //else if (OfertaPF.MasaMaxima > 16000)

                //{
                //    OfertaPF.Pret = 1250;
                //}



            }

            return RedirectToPage("./Index");
        }

        private bool OfertaPFExists(int id)
        {
          return (_context.OfertaPF?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
