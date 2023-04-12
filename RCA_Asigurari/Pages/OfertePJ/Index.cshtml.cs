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

        public async Task OnGetAsync(string searchString)
        {
            CurrentFilter = searchString;
            var userEmail = User.Identity.Name;
            var ofertePJ = _context.OfertaPJ
                .Include(o => o.CategorieVehicul)
                .Include(o => o.Client)
                .Include(o => o.TipCombustibil)
                .Include(o => o.TipSocietate)
                .AsNoTracking();

            if (_context.OfertaPJ != null)
            {

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
            }


        }
    }
    }   