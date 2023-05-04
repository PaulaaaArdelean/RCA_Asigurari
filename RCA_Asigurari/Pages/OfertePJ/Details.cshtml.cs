using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RCA_Asigurari.Data;
using RCA_Asigurari.Models;

namespace RCA_Asigurari.Pages.OfertePJ
{
    [Authorize(Roles = "Admin")]

    public class DetailsModel : PageModel
    {
        private readonly RCA_Asigurari.Data.RCA_AsigurariContext _context;

        public DetailsModel(RCA_Asigurari.Data.RCA_AsigurariContext context)
        {
            _context = context;
        }

      public OfertaPJ OfertaPJ { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.OfertaPJ == null)
            {
                return NotFound();
            }

            var ofertapj = await _context.OfertaPJ.Include(o=>o.Client).FirstOrDefaultAsync(m => m.ID == id);
            if (ofertapj == null)
            {
                return NotFound();
            }
            else 
            {
                OfertaPJ = ofertapj;
            }
            return Page();
        }
    }
}
