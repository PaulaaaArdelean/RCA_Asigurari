using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RCA_Asigurari.Data;
using RCA_Asigurari.Models;

namespace RCA_Asigurari.Pages.CategoriiVehicule
{
    public class DeleteModel : PageModel
    {
        private readonly RCA_Asigurari.Data.RCA_AsigurariContext _context;

        public DeleteModel(RCA_Asigurari.Data.RCA_AsigurariContext context)
        {
            _context = context;
        }

        [BindProperty]
      public CategorieVehicul CategorieVehicul { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CategorieVehicul == null)
            {
                return NotFound();
            }

            var categorievehicul = await _context.CategorieVehicul.FirstOrDefaultAsync(m => m.ID == id);

            if (categorievehicul == null)
            {
                return NotFound();
            }
            else 
            {
                CategorieVehicul = categorievehicul;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.CategorieVehicul == null)
            {
                return NotFound();
            }
            var categorievehicul = await _context.CategorieVehicul.FindAsync(id);

            if (categorievehicul != null)
            {
                CategorieVehicul = categorievehicul;
                _context.CategorieVehicul.Remove(CategorieVehicul);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
