using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RCA_Asigurari.Data;
using RCA_Asigurari.Models;

namespace RCA_Asigurari.Pages.OfertePJ
{
    public class IndexModel : PageModel
    {
        private readonly RCA_Asigurari.Data.RCA_AsigurariContext _context;

        public IndexModel(RCA_Asigurari.Data.RCA_AsigurariContext context)
        {
            _context = context;
        }

        public IList<OfertaPJ> OfertaPJ { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.OfertaPJ != null)
            {
                OfertaPJ = await _context.OfertaPJ
                .Include(o => o.CategorieVehicul)
                .Include(o => o.Client)
                .Include(o => o.TipCombustibil)
                .Include(o => o.TipSocietate).ToListAsync();
            }
        }
    }
}
