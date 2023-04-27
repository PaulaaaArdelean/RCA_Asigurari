using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        public String CurrentFilter { get; set; }

        public async Task OnGetAsync(string searchString, bool? vizualizareDorite)
        {
            CurrentFilter = searchString;
            var userEmail = User.Identity.Name;
            var ofertePJ = _context.OfertaPJ
                .Include(o => o.CategorieVehicul)
                .Include(o => o.Client)
                .Include(o => o.TipCombustibil)
                .Include(o => o.TipSocietate)
                .AsNoTracking();
            
            var logedinClientId = _context.Client.Where(c => c.Email == userEmail).Select(c => c.ID).FirstOrDefault();

            if (_context.OfertaPJ != null)
            {
                if (vizualizareDorite != null && vizualizareDorite == true)
                {
                    ofertePJ = ofertePJ.Join(
                        _context.OfertaPJDorita.Where(x => x.ClientID == logedinClientId),
                        e => e.ID,
                       f => f.OfertaPJID, (firstentity, secondentity) => new
                       {
                           OfertaPJ = firstentity,
                           OfertaPJDorita = secondentity
                       }).Select(entity => entity.OfertaPJ);

                }
                if (userEmail != ADMIN_EMAIL)
                {
                    ofertePJ = ofertePJ.Where(ofertapersjuridica => ofertapersjuridica.Client.Email == userEmail);
                }


                if (!String.IsNullOrEmpty(searchString))
                {

                    ofertePJ = ofertePJ.Where(s => s.Client.NumeProprietar.Contains(searchString)
                     || s.CUI.Contains(searchString)
                   || s.NumeIntregReprezentant.Contains(searchString)
                   || s.TipSocietate.TipulSocietate.Contains(searchString)
                   || s.ActivitateSocietate.Contains(searchString)
                   || s.NumarIdentificare.Contains(searchString)
                   || s.Marca.Contains(searchString)
                   || s.CategorieVehicul.CategoriaVehicul.Contains(searchString)
                   || s.TipCombustibil.TipulCombustibil.Contains(searchString)
                   || s.SerieCIV.Contains(searchString)
                   || s.AnFabricatie.ToString().Contains(searchString)
                   || s.Model.Contains(searchString)
                   || s.NumarIdentificare.Contains(searchString));

                }
                OfertaPJ = await ofertePJ.ToListAsync();
                var oferteDorite = _context.OfertaPJDorita.Where(x => x.ClientID == logedinClientId).ToList();

                for (int i = 0; i < OfertaPJ.Count(); i++)
                {
                    var currentOferta = OfertaPJ.ElementAt(i);

                    //Aici verifica...Pt event urile din Db se seteaza valoarea pt Addedtofav ca sa seteze Add/Remove to fav
                    currentOferta.AdaugatOfertaDorita = oferteDorite.Where(x => x.ClientID == logedinClientId && x.OfertaPJID == currentOferta.ID
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