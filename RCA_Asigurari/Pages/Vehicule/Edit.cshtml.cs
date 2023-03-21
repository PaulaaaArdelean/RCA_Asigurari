using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RCA_Asigurari.Data;
using RCA_Asigurari.Models;

namespace RCA_Asigurari.Pages.Vehicule
{
    public class EditModel : PageModel
    {
        private readonly RCA_Asigurari.Data.RCA_AsigurariContext _context;

        public EditModel(RCA_Asigurari.Data.RCA_AsigurariContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Vehicul Vehicul { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Vehicul == null)
            {
                return NotFound();
            }

            var vehicul =  await _context.Vehicul.FirstOrDefaultAsync(m => m.ID == id);
            if (vehicul == null)
            {
                return NotFound();
            }
            Vehicul = vehicul;
           ViewData["OfertaID"] = new SelectList(_context.Oferta, "ID", "NrInmatriculare");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Vehicul).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehiculExists(Vehicul.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool VehiculExists(int id)
        {
          return (_context.Vehicul?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
