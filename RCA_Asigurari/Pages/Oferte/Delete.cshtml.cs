using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RCA_Asigurari.Data;
using RCA_Asigurari.Models;

namespace RCA_Asigurari.Pages.Oferte
{
    public class DeleteModel : PageModel
    {
        private readonly RCA_Asigurari.Data.RCA_AsigurariContext _context;

        public DeleteModel(RCA_Asigurari.Data.RCA_AsigurariContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Oferta Oferta { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Oferta == null)
            {
                return NotFound();
            }

            var oferta = await _context.Oferta.FirstOrDefaultAsync(m => m.ID == id);

            if (oferta == null)
            {
                return NotFound();
            }
            else 
            {
                Oferta = oferta;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Oferta == null)
            {
                return NotFound();
            }
            var oferta = await _context.Oferta.FindAsync(id);

            if (oferta != null)
            {
                Oferta = oferta;
                _context.Oferta.Remove(Oferta);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
