using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RCA_Asigurari.Data;
using RCA_Asigurari.Models;

namespace RCA_Asigurari.Pages.PersoaneFizice
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
             ViewData["ClientID"] = new SelectList(_context.Client, "ID", "NumeClientFirma");
            ViewData["JudetID"] = new SelectList(_context.Judet, "ID", "Judetul");
            ViewData["LocalitateID"] = new SelectList(_context.Localitate, "ID", "Localitatea");

            return Page();
        }

        [BindProperty]
        public PersoanaFizica PersoanaFizica { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.PersoanaFizica == null || PersoanaFizica == null)
            {
                return Page();
            }

            _context.PersoanaFizica.Add(PersoanaFizica);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
