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
                    DetaliiClient = x.NumeIntreg + " " + x.NumeFirma
                });

            ViewData["PretID"] = new SelectList(_context.Oferta, "ID", "Pret");
            ViewData["ClientID"] = new SelectList(detaliiClient, "ID", "DetaliiClient", CurrentClientID);
            ViewData["CategorieVehiculID"] = new SelectList(_context.CategorieVehicul, "ID", "CategoriaVehicul");
            ViewData["TipCombustibilID"] = new SelectList(_context.TipCombustibil, "ID", "TipulCombustibil");
            return Page();
        }

        [BindProperty]
        public OfertaPF OfertaPF { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.OfertaPF == null || OfertaPF == null)
            {
                return Page();
            }

            if (/*OfertaPF.CategorieVehicul.ToString() == "autoturism" &&*/ OfertaPF.NrLocuri <= 9 && OfertaPF.MasaMaxima <= 3500)
            {
                if (OfertaPF.CapacitateCilindrica <= 1200)
                {
                    OfertaPF.Pret = 377;
                }
                else if (OfertaPF.CapacitateCilindrica > 1200 && OfertaPF.CapacitateCilindrica <= 1400)
                {
                    OfertaPF.Pret = 374;
                }
                else if (OfertaPF.CapacitateCilindrica > 1400 && OfertaPF.CapacitateCilindrica <= 1600)
                {
                    OfertaPF.Pret = 438;
                }
                else if (OfertaPF.CapacitateCilindrica > 1600 && OfertaPF.CapacitateCilindrica <= 1800)
                {
                    OfertaPF.Pret = 483;
                }
                else if (OfertaPF.CapacitateCilindrica > 1800 && OfertaPF.CapacitateCilindrica <= 2000)
                {
                    OfertaPF.Pret = 541;
                }
                else if (OfertaPF.CapacitateCilindrica > 2000 && OfertaPF.CapacitateCilindrica <= 2500)
                {
                    OfertaPF.Pret = 762;
                }
                else if (OfertaPF.CapacitateCilindrica > 2500)
                {
                    OfertaPF.Pret = 1021;
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
