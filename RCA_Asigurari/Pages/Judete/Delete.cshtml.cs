using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RCA_Asigurari.Data;
using RCA_Asigurari.Models;

namespace RCA_Asigurari.Pages.Judete
{
    public class DeleteModel : PageModel
    {
        private readonly RCA_Asigurari.Data.RCA_AsigurariContext _context;

        public DeleteModel(RCA_Asigurari.Data.RCA_AsigurariContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Judet Judet { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Judet == null)
            {
                return NotFound();
            }

            var judet = await _context.Judet.FirstOrDefaultAsync(m => m.ID == id);

            if (judet == null)
            {
                return NotFound();
            }
            else 
            {
                Judet = judet;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Judet == null)
            {
                return NotFound();
            }
            var judet = await _context.Judet.FindAsync(id);

            if (judet != null)
            {
                Judet = judet;
                _context.Judet.Remove(Judet);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
