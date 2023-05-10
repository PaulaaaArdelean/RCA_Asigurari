using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RCA_Asigurari.Data;
using RCA_Asigurari.Migrations;
using RCA_Asigurari.Models;
using RCA_Asigurari.Models.OferteDorite;

namespace RCA_Asigurari.Pages.OfertePF
{
    public class IndexModel : PageModel
    {
        private readonly RCA_Asigurari.Data.RCA_AsigurariContext _context;
        private readonly string ADMIN_EMAIL = "admin@gmail.com";

        public IndexModel(RCA_Asigurari.Data.RCA_AsigurariContext context)
        {
            _context = context;
        }


        public IList<OfertaPF> OfertaPF { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Cautare { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? CautareOfertaPF { get; set; }
 
        public async Task OnGetAsync( bool? vizualizareDorite)
        {
     
            var userEmail = User.Identity.Name;
            var ofertePF = _context.OfertaPF
                    .Include(o => o.CategorieVehicul)
                    .Include(o => o.Client)
                    .Include(o => o.TipCombustibil).AsNoTracking();
            var logedinClientId = _context.Client
                .Where(c => c.Email == userEmail)
                .Select(c => c.ID)
                .FirstOrDefault();

            if (_context.OfertaPF != null)
            {

                if (vizualizareDorite != null && vizualizareDorite == true)
                {
                    if (vizualizareDorite != null && vizualizareDorite == true)
                    {
                        if (userEmail == ADMIN_EMAIL)
                        {
                            ofertePF = ofertePF.Join(
                                _context.OfertaPFDorita,
                                e => e.ID,
                                f => f.OfertaPFID,
                                (firstentity, secondentity) => new
                                {
                                    OfertaPF = firstentity,
                                    OfertaPFDorita = secondentity
                                }).Select(entity => entity.OfertaPF);
                        }
                        else
                        {
                            ofertePF = ofertePF.Join(
                                _context.OfertaPFDorita.Where(x => x.ClientID == logedinClientId),
                                e => e.ID,
                                f => f.OfertaPFID,
                                (firstentity, secondentity) => new
                                {
                                    OfertaPF = firstentity,
                                    OfertaPFDorita = secondentity
                                }).Select(entity => entity.OfertaPF);
                        }
                    }

                    //ofertePF = ofertePF.Join(
                    //    _context.OfertaPFDorita.Where(x => x.ClientID == logedinClientId),
                    //    e => e.ID,
                    //   f => f.OfertaPFID, (firstentity, secondentity) => new
                    //   {
                    //       OfertaPF = firstentity,
                    //       OfertaPFDorita = secondentity
                    //   }).Select(entity => entity.OfertaPF);

                }

                if (userEmail != ADMIN_EMAIL)
                {
                    ofertePF = ofertePF.Where(ofertapersfizica => ofertapersfizica.Client.Email == userEmail);
                }

                if (!String.IsNullOrEmpty(SearchString))
                {
                    ofertePF = ofertePF.Where(s => s.Client.NumeProprietar.Contains(SearchString)
                   || s.CNP.Contains(SearchString)
                       || s.SerieCI.Contains(SearchString)
                       || s.NumarCI.Contains(SearchString)
                       || s.NrInmatriculare.Contains(SearchString)
                       || s.NumarIdentificare.Contains(SearchString)
                       || s.Marca.Contains(SearchString)
                       || s.Model.Contains(SearchString)
                       || s.CategorieVehicul.CategoriaVehicul.Contains(SearchString)
                       || s.TipCombustibil.TipulCombustibil.Contains(SearchString)
                       || s.SerieCIV.Contains(SearchString)
                       || s.AnFabricatie.ToString().Contains(SearchString)
                       || s.NumarIdentificare.Contains(SearchString)
                    );
                }
              
                OfertaPF = await ofertePF.ToListAsync();


                var oferteDorite = _context.OfertaPFDorita.Where(x => x.ClientID == logedinClientId).ToList();

                for (int i = 0; i < OfertaPF.Count(); i++)
                {
                    var currentOferta = OfertaPF.ElementAt(i);

                    currentOferta.AdaugatOfertaDorita = oferteDorite.Where(x => x.ClientID == logedinClientId &&
                      x.OfertaPFID == currentOferta.ID
                    ).FirstOrDefault() != null;
                }
            }
        }
      
        public IActionResult OnPost()
        {
            var userEmail = User.Identity.Name;
            var logedinClientId = _context.Client.Where(c => c.Email == userEmail).Select(c => c.ID).FirstOrDefault();

            var OfertaPFID = Request.Form["OfertaPFID"];
            var EsteAdaugatLaDorite = Request.Form["EsteAdaugatLaDorite"];
            var OfertaDorita = new OfertaPFDorita();

            OfertaDorita.OfertaPFID = Int32.Parse(OfertaPFID);
            OfertaDorita.ClientID = logedinClientId;

            if (!bool.Parse(EsteAdaugatLaDorite))
            {
                _context.OfertaPFDorita.Add(OfertaDorita);
            }
            else
            {
                _context.OfertaPFDorita.Remove(OfertaDorita);

            }

            _context.SaveChanges();


            return RedirectToPage("./Index");
        }


    }
}

