using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RCA_Asigurari.Data;
using RCA_Asigurari.Models;

namespace RCA_Asigurari.Pages.Localitati
{
    public class DeleteModel : PageModel
    {
        private readonly RCA_Asigurari.Data.RCA_AsigurariContext _context;

        public DeleteModel(RCA_Asigurari.Data.RCA_AsigurariContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Localitate Localitate { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Localitate == null)
            {
                return NotFound();
            }

            var localitate = await _context.Localitate.FirstOrDefaultAsync(m => m.ID == id);

            if (localitate == null)
            {
                return NotFound();
            }
            else 
            {
                Localitate = localitate;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Localitate == null)
            {
                return NotFound();
            }
            var localitate = await _context.Localitate.FindAsync(id);

            if (localitate != null)
            {
                Localitate = localitate;
                _context.Localitate.Remove(Localitate);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
