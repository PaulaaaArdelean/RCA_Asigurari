using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RCA_Asigurari.Data;
using RCA_Asigurari.Models;

namespace RCA_Asigurari.Pages.TipuriAsigurati
{
    public class DeleteModel : PageModel
    {
        private readonly RCA_Asigurari.Data.RCA_AsigurariContext _context;

        public DeleteModel(RCA_Asigurari.Data.RCA_AsigurariContext context)
        {
            _context = context;
        }

        [BindProperty]
      public TipAsigurat TipAsigurat { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TipAsigurat == null)
            {
                return NotFound();
            }

            var tipasigurat = await _context.TipAsigurat.FirstOrDefaultAsync(m => m.ID == id);

            if (tipasigurat == null)
            {
                return NotFound();
            }
            else 
            {
                TipAsigurat = tipasigurat;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.TipAsigurat == null)
            {
                return NotFound();
            }
            var tipasigurat = await _context.TipAsigurat.FindAsync(id);

            if (tipasigurat != null)
            {
                TipAsigurat = tipasigurat;
                _context.TipAsigurat.Remove(TipAsigurat);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
