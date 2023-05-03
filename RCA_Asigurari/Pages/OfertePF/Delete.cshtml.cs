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

    public class DeleteModel : PageModel
    {
        private readonly RCA_Asigurari.Data.RCA_AsigurariContext _context;

        public DeleteModel(RCA_Asigurari.Data.RCA_AsigurariContext context)
        {
            _context = context;
        }

        [BindProperty]
      public OfertaPF OfertaPF { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.OfertaPF == null)
            {
                return NotFound();
            }

            var ofertapf = await _context.OfertaPF.FirstOrDefaultAsync(m => m.ID == id);

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.OfertaPF == null)
            {
                return NotFound();
            }
            var ofertapf = await _context.OfertaPF.FindAsync(id);

            if (ofertapf != null)
            {
                OfertaPF = ofertapf;
                _context.OfertaPF.Remove(OfertaPF);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
