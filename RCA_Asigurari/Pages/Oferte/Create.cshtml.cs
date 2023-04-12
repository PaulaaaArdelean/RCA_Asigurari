using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RCA_Asigurari.Data;
using RCA_Asigurari.Models;

namespace RCA_Asigurari.Pages.Oferte
{
    public class CreateModel : OferteOptionalPageModel
    {
        private readonly RCA_AsigurariContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CreateModel(RCA_AsigurariContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            var userEmail = User.Identity.Name;
            int CurrentClientID=_context.Client.First(client=>client.Email == userEmail).ID;



            var userName = _userManager.GetUserName(User);

            var detaliiClient = _context.Client
                .Where(c => c.Email == userName)
                .Select(x => new
                {
                    x.ID,
                    DetaliiClient = x.NumeProprietar /*+ " " + x.NumeFirma*/
                });

            ViewData["PretID"] = new SelectList(_context.Oferta, "ID", "Pret");
            ViewData["CategorieVehiculID"] = new SelectList(_context.CategorieVehicul, "ID", "CategoriaVehicul");
            ViewData["ClientID"] = new SelectList(detaliiClient, "ID", "DetaliiClient",CurrentClientID);
            ViewData["TipCombustibilID"] = new SelectList(_context.TipCombustibil, "ID", "TipulCombustibil");

            var oferta = new Oferta();
            oferta.AtributeOptionaleOferta = new List<AtributOptionalOferta>();
            PopulateAssignedOptionalData(_context, oferta);
            return Page();
        }

        [BindProperty]
        public Oferta Oferta { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedAttributes)
        {
            

            var newOferta = new Oferta();
            if (selectedAttributes != null)
            {
                newOferta.AtributeOptionaleOferta = new List<AtributOptionalOferta>();
                foreach (var cat in selectedAttributes)
                {
                    var catToAdd = new AtributOptionalOferta
                    {
                        AtributOptionalID = int.Parse(cat)
                    };
                    newOferta.AtributeOptionaleOferta.Add(catToAdd);
                }
            }

            Oferta.AtributeOptionaleOferta = newOferta.AtributeOptionaleOferta;

            // Update the price based on the value of CapacitateCilindrica


            if (/*Oferta.CategorieVehicul.ToString() == "autoturism" &&*/ Oferta.NrLocuri <= 9 && Oferta.MasaMaxima <= 3500)
            {
                if (Oferta.CapacitateCilindrica <= 1200)
                {
                    Oferta.Pret = 377;
                }
                else if (Oferta.CapacitateCilindrica > 1200 && Oferta.CapacitateCilindrica <= 1400)
                {
                    Oferta.Pret = 374;
                }
                else if (Oferta.CapacitateCilindrica > 1400 && Oferta.CapacitateCilindrica <= 1600)
                {
                    Oferta.Pret = 438;
                }
                else if (Oferta.CapacitateCilindrica > 1600 && Oferta.CapacitateCilindrica <= 1800)
                {
                    Oferta.Pret = 483;
                }
                else if (Oferta.CapacitateCilindrica > 1800 && Oferta.CapacitateCilindrica <= 2000)
                {
                    Oferta.Pret = 541;
                }
                else if (Oferta.CapacitateCilindrica > 2000 && Oferta.CapacitateCilindrica <= 2500)
                {
                    Oferta.Pret = 762;
                }
                else if (Oferta.CapacitateCilindrica >2500 )
                {
                    Oferta.Pret = 1021;
                }
            }
            else if (Oferta.NrLocuri > 9 && Oferta.NrLocuri<=40)
 
            {
                Oferta.Pret = 502;
            }
            else if (Oferta.NrLocuri > 40 )

            {
                Oferta.Pret = 1269;
            }
            else if (Oferta.MasaMaxima <=3500)

            {
                Oferta.Pret = 343;
            }
            else if (Oferta.MasaMaxima > 3500 && Oferta.MasaMaxima <= 15999)

            {
                Oferta.Pret = 502;
            }
            else if (Oferta.MasaMaxima > 16000 )

            {
                Oferta.Pret = 1250;
            }


            _context.Oferta.Add(Oferta);

            await _context.SaveChangesAsync();
            
            //var javascriptCode = "$(document).ready(function() { confirmDelete(); });";
            //return Content(HttpUtility.HtmlEncode(javascriptCode), "text/javascript"); 
           
            return RedirectToPage("./Index");
        }
    }
}