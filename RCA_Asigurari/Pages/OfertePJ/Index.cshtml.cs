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

namespace RCA_Asigurari.Pages.OfertePJ
{
    public class IndexModel : PageModel
    {
        private readonly RCA_Asigurari.Data.RCA_AsigurariContext _context;
        private readonly string ADMIN_EMAIL = "admin@gmail.com";

        public IndexModel(RCA_Asigurari.Data.RCA_AsigurariContext context)
        {
            _context = context;
        }






        public IList<OfertaPJ> OfertaPJ { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Cautare { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? CautareOfertaPJ { get; set; }
        //public String CurrentFilter { get; set; }
        public async Task OnGetAsync(/*string searchString,*/ bool? vizualizareDorite)
        {
            //CurrentFilter = searchString;
            var userEmail = User.Identity.Name;
            var ofertePJ = _context.OfertaPJ
                    .Include(o => o.CategorieVehicul)
                    .Include(o => o.Client)
                    .Include(o => o.TipCombustibil).AsNoTracking();
            var logedinClientId = _context.Client.Where(c => c.Email == userEmail).Select(c => c.ID).FirstOrDefault();

            if (_context.OfertaPJ != null)
            {

                if (vizualizareDorite != null && vizualizareDorite == true)
                {
                    if (userEmail == ADMIN_EMAIL)
                    {
                        ofertePJ = ofertePJ.Join(
                            _context.OfertaPJDorita,
                            e => e.ID,
                            f => f.OfertaPJID,
                            (firstentity, secondentity) => new
                            {
                                OfertaPJ = firstentity,
                                OfertaPJDorita = secondentity
                            }).Select(entity => entity.OfertaPJ);
                    }
                    else
                    {
                        ofertePJ = ofertePJ.Join(
                            _context.OfertaPJDorita.Where(x => x.ClientID == logedinClientId),
                            e => e.ID,
                            f => f.OfertaPJID,
                            (firstentity, secondentity) => new
                            {
                                OfertaPJ = firstentity,
                                OfertaPJDorita = secondentity
                            }).Select(entity => entity.OfertaPJ);
                    }
                    //ofertePJ = ofertePJ.Join(
                    //    _context.OfertaPJDorita.Where(x => x.ClientID == logedinClientId),
                    //    e => e.ID,
                    //   f => f.OfertaPJID, (firstentity, secondentity) => new
                    //   {
                    //       OfertaPJ = firstentity,
                    //       OfertaPJDorita = secondentity
                    //   }).Select(entity => entity.OfertaPJ);

                }

                if (userEmail != ADMIN_EMAIL)
                {
                    ofertePJ = ofertePJ.Where(ofertapersjuridica => ofertapersjuridica.Client.Email == userEmail);
                }

                if (!String.IsNullOrEmpty(SearchString))
                {
                    ofertePJ = ofertePJ.Where(s => s.Client.NumeProprietar.Contains(SearchString)
                   || s.CUI.Contains(SearchString)
                       //|| s.SerieCI.Contains(SearchString)
                       //|| s.NumarCI.Contains(SearchString)
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

                OfertaPJ = await ofertePJ.ToListAsync();


                var oferteDorite = _context.OfertaPJDorita.Where(x => x.ClientID == logedinClientId).ToList();

                for (int i = 0; i < OfertaPJ.Count(); i++)
                {
                    var currentOferta = OfertaPJ.ElementAt(i);

                    currentOferta.AdaugatOfertaDorita = oferteDorite.Where(x => x.ClientID == logedinClientId &&
                      x.OfertaPJID == currentOferta.ID
                    ).FirstOrDefault() != null;
                }

            }


        }

        public IActionResult OnPost()
        {
            var userEmail = User.Identity.Name;
            var logedinClientId = _context.Client.Where(c => c.Email == userEmail).Select(c => c.ID).FirstOrDefault();

            var OfertaPJID = Request.Form["OfertaPJID"];
            var EsteAdaugatLaDorite = Request.Form["EsteAdaugatLaDorite"];
            var OfertaDorita = new OfertaPJDorita();

            OfertaDorita.OfertaPJID = Int32.Parse(OfertaPJID);
            OfertaDorita.ClientID = logedinClientId;

            if (!bool.Parse(EsteAdaugatLaDorite))
            {
                _context.OfertaPJDorita.Add(OfertaDorita);
            }
            else
            {
                _context.OfertaPJDorita.Remove(OfertaDorita);

            }

            _context.SaveChanges();


            return RedirectToPage("./Index");
        }


    }
}

