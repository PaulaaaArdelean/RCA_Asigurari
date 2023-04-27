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

namespace RCA_Asigurari.Pages.OfertePJ
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
            var client = _context.Client.FirstOrDefault(c => c.Email == userEmail);

            if (client == null)
            {
                return NotFound(); // or handle the scenario in some other way
            }
            int CurrentClientID = client.ID;
            //int CurrentClientID = _context.Client.First(client => client.Email == userEmail).ID;



            var userName = _userManager.GetUserName(User);

            var detaliiClient = _context.Client
                 .Where(c => c.Email == userName)
                 .Select(x => new
                 {
                     x.ID,
                     DetaliiClient = x.NumeProprietar
                 });

            ViewData["CategorieVehiculID"] = new SelectList(_context.CategorieVehicul, "ID", "CategoriaVehicul");
        ViewData["ClientID"] = new SelectList(detaliiClient, "ID", "DetaliiClient");
        ViewData["TipCombustibilID"] = new SelectList(_context.TipCombustibil, "ID", "TipulCombustibil");
        ViewData["TipSocietateID"] = new SelectList(_context.TipSocietate, "ID", "TipulSocietate");
            return Page();
        }

        [BindProperty]
        public OfertaPJ OfertaPJ { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.OfertaPJ == null || OfertaPJ == null)
            {
                return Page();
            }
            if (/*OfertaPJ.CategorieVehicul.ToString() == "autoturism" &&*/ OfertaPJ.NrLocuri <= 9 && OfertaPJ.MasaMaxima <= 3500)
            {
                if (OfertaPJ.CapacitateCilindrica <= 1200)
                {
                    OfertaPJ.Pret = 377;
                }
                else if (OfertaPJ.CapacitateCilindrica > 1200 && OfertaPJ.CapacitateCilindrica <= 1400)
                {
                    OfertaPJ.Pret = 374;
                }
                else if (OfertaPJ.CapacitateCilindrica > 1400 && OfertaPJ.CapacitateCilindrica <= 1600)
                {
                    OfertaPJ.Pret = 438;
                }
                else if (OfertaPJ.CapacitateCilindrica > 1600 && OfertaPJ.CapacitateCilindrica <= 1800)
                {
                    OfertaPJ.Pret = 483;
                }
                else if (OfertaPJ.CapacitateCilindrica > 1800 && OfertaPJ.CapacitateCilindrica <= 2000)
                {
                    OfertaPJ.Pret = 541;
                }
                else if (OfertaPJ.CapacitateCilindrica > 2000 && OfertaPJ.CapacitateCilindrica <= 2500)
                {
                    OfertaPJ.Pret = 762;
                }
                else if (OfertaPJ.CapacitateCilindrica > 2500)
                {
                    OfertaPJ.Pret = 1021;
                }
            }
            else if (OfertaPJ.NrLocuri > 9 && OfertaPJ.NrLocuri <= 40)

            {
                OfertaPJ.Pret = 502;
            }
            else if (OfertaPJ.NrLocuri > 40)

            {
                OfertaPJ.Pret = 1269;
            }
            else if (OfertaPJ.MasaMaxima <= 3500)

            {
                OfertaPJ.Pret = 343;
            }
            else if (OfertaPJ.MasaMaxima > 3500 && OfertaPJ.MasaMaxima <= 15999)

            {
                OfertaPJ.Pret = 502;
            }
            else if (OfertaPJ.MasaMaxima > 16000)

            {
                OfertaPJ.Pret = 1250;
            }
            _context.OfertaPJ.Add(OfertaPJ);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
