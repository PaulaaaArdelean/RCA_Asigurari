using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RCA_Asigurari.Data;
using RCA_Asigurari.Models;

namespace RCA_Asigurari.Pages.PersoaneFizice
{
    public class DeleteModel : PageModel
    {
        private readonly RCA_Asigurari.Data.RCA_AsigurariContext _context;

        public DeleteModel(RCA_Asigurari.Data.RCA_AsigurariContext context)
        {
            _context = context;
        }

        [BindProperty]
      public PersoanaFizica PersoanaFizica { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PersoanaFizica == null)
            {
                return NotFound();
            }

            var persoanafizica = await _context.PersoanaFizica
                .Include(p=>p.Client)
                .Include(p => p.Judet)
                .Include(p => p.Localitate)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (persoanafizica == null)
            {
                return NotFound();
            }
            else 
            {
                PersoanaFizica = persoanafizica;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.PersoanaFizica == null)
            {
                return NotFound();
            }
            var persoanafizica = await _context.PersoanaFizica.FindAsync(id);

            if (persoanafizica != null)
            {
                PersoanaFizica = persoanafizica;
                _context.PersoanaFizica.Remove(PersoanaFizica);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
