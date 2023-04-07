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
    public class DeleteModel : PageModel
    {
        private readonly RCA_Asigurari.Data.RCA_AsigurariContext _context;

        public DeleteModel(RCA_Asigurari.Data.RCA_AsigurariContext context)
        {
            _context = context;
        }

        [BindProperty]
      public OfertaPJ OfertaPJ { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.OfertaPJ == null)
            {
                return NotFound();
            }

            var ofertapj = await _context.OfertaPJ.FirstOrDefaultAsync(m => m.ID == id);

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.OfertaPJ == null)
            {
                return NotFound();
            }
            var ofertapj = await _context.OfertaPJ.FindAsync(id);

            if (ofertapj != null)
            {
                OfertaPJ = ofertapj;
                _context.OfertaPJ.Remove(OfertaPJ);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
