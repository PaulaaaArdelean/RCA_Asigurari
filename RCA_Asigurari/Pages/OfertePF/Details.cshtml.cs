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

namespace RCA_Asigurari.Pages.OfertePF
{
    [Authorize(Roles = "Admin")]

    public class DetailsModel : PageModel
    {
        private readonly RCA_Asigurari.Data.RCA_AsigurariContext _context;

        public DetailsModel(RCA_Asigurari.Data.RCA_AsigurariContext context)
        {
            _context = context;
        }

        public OfertaPF OfertaPF { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.OfertaPF == null)
            {
                return NotFound();
            }
            //if (!_context.OfertaPF.Any(o => o.ID == id))
            //{
            //    return NotFound();
            //}
            var ofertapf = await _context.OfertaPF.Include(o => o.Client).FirstOrDefaultAsync(m => m.ID == id);
            if (ofertapf == null)
            {
                return NotFound();
            }
            else
            {
                OfertaPF = ofertapf;
            }
            return Page();
        }
    }
}

