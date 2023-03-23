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

namespace RCA_Asigurari.Pages.Oferte
{
    public class CreateModel : OferteOptionalPageModel
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
            // var anFabricatie = _context.Oferta.Select(x => new { x.ID, anulFabricatiei = x.AnFabricatie });

           // var capacitateCilindrica = _context.Oferta
           //     .Where(o => o.CapacitateCilindrica <= 1200).First();
           // capacitateCilindrica.Pret = 377;
           // _context.SaveChanges();




           // var capacitateCilindrica1 = _context.Oferta
           //    .Where(o => o.CapacitateCilindrica > 1200 && o.CapacitateCilindrica <= 1400).OrderBy(o => o.ID).First();
           // capacitateCilindrica.Pret = 374;
           // _context.SaveChanges();

           // var capacitateCilindrica2 = _context.Oferta
           // .Where(o => o.CapacitateCilindrica > 1400 && o.CapacitateCilindrica <= 1600).OrderBy(o => o.ID).First();
           // capacitateCilindrica.Pret = 438;
           // _context.SaveChanges();


           // var capacitateCilindrica3 = _context.Oferta
           //.Where(o => o.CapacitateCilindrica > 1600 && o.CapacitateCilindrica <= 1800).OrderBy(o => o.ID).First();
           // capacitateCilindrica.Pret = 483;
           // _context.SaveChanges();

           // var capacitateCilindrica4 = _context.Oferta
           //.Where(o => o.CapacitateCilindrica > 1800 && o.CapacitateCilindrica <= 2000).OrderBy(o => o.ID).First();
           // capacitateCilindrica.Pret = 541;
           // _context.SaveChanges();

           // var capacitateCilindrica5 = _context.Oferta
           //.Where(o => o.CapacitateCilindrica > 2000 && o.CapacitateCilindrica <= 2500).OrderBy(o => o.ID).First();
           // capacitateCilindrica.Pret = 762;
           // _context.SaveChanges();

           // var capacitateCilindrica6 = _context.Oferta
           //.Where(o => o.CapacitateCilindrica > 2000).OrderBy(o => o.ID).First();
           // capacitateCilindrica.Pret = 1021;
           // _context.SaveChanges();



            //.Select(x => new { x.ID, x.Pret = 300})


            //var pret = anFabricatie * 0.2 + capacitateCilindrica * 0.8 ;


            //  var capacitateCilindrica=_context.Oferta
            //    .Select(x=> new
            //  { x.ID,
            //    capacitateaCilindrica=x.CapacitateCilindrica });





            ViewData["PretID"] = new SelectList(_context.Oferta, "ID", "Pret");

            var userName = _userManager.GetUserName(User);

            var detaliiClient = _context.Client
                .Where(c => c.Email == userName)
                .Select(x => new
                {
                    x.ID,
                    DetaliiClient = x.NumeIntreg + " " + x.NumeFirma
                });

            ViewData["CategorieVehiculID"] = new SelectList(_context.CategorieVehicul, "ID", "CategoriaVehicul");
            //ViewData["ClientID"] = new SelectList(_context.Client, "ID", "NumeIntreg");

            ViewData["ClientID"] = new SelectList(detaliiClient, "ID", "DetaliiClient");
            ViewData["TipCombustibilID"] = new SelectList(_context.TipCombustibil, "ID", "TipulCombustibil");

            var oferta = new Oferta();
            oferta.AtributeOptionaleOferta = new List<AtributOptionalOferta>();
            PopulateAssignedOptionalData(_context, oferta);
            return Page();
        }

        [BindProperty]
        public Oferta Oferta { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
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
            _context.Oferta.Add(Oferta);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");

            PopulateAssignedOptionalData(_context, newOferta);
            return Page();
        }

    }
}