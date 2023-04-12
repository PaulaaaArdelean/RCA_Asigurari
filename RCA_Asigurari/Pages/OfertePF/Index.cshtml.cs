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
        public String CurrentFilter { get; set; }
        public async Task OnGetAsync(string searchString)
        {
            CurrentFilter = searchString;
            var userEmail = User.Identity.Name;
            var ofertePF = _context.OfertaPF
                    .Include(o => o.CategorieVehicul)
                    .Include(o => o.Client)
                    .Include(o => o.TipCombustibil).AsNoTracking();

            if (_context.OfertaPF != null)
            {
                
                if (userEmail != ADMIN_EMAIL)
                {
                    ofertePF = ofertePF.Where(ofertapersfizica => ofertapersfizica.Client.Email == userEmail);
                }
              

                if (!String.IsNullOrEmpty(searchString))
                {

                    ofertePF = ofertePF.Where(s => s.Client.NumeProprietar.Contains(searchString)
                   || s.CNP.Contains(searchString)         
                   || s.SerieCI.Contains(searchString)
                   || s.NumarCI.Contains(searchString)
                   || s.NrInmatriculare.Contains(searchString)
                   || s.NumarIdentificare.Contains(searchString)
                   || s.Marca.Contains(searchString)
                   || s.Model.Contains(searchString)
                   || s.CategorieVehicul.CategoriaVehicul.Contains(searchString)
                   || s.TipCombustibil.TipulCombustibil.Contains(searchString)
                   || s.SerieCIV.Contains(searchString)
                   || s.AnFabricatie.ToString().Contains(searchString)
                   || s.NumarIdentificare.Contains(searchString));


                }
                OfertaPF = await ofertePF.ToListAsync();
            }
           

        }
      
    }
}

