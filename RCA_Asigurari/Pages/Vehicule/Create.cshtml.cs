using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RCA_Asigurari.Data;
using RCA_Asigurari.Models;

namespace RCA_Asigurari.Pages.Vehicule
{
    public class CreateModel : PageModel
    {
        private readonly RCA_Asigurari.Data.RCA_AsigurariContext _context;

        public CreateModel(RCA_Asigurari.Data.RCA_AsigurariContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["OfertaID"] = new SelectList(_context.Oferta, "ID", "NrInmatriculare");
            return Page();
        }

        [BindProperty]
        public Vehicul Vehicul { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Vehicul == null || Vehicul == null)
            {
                return Page();
            }

            _context.Vehicul.Add(Vehicul);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
