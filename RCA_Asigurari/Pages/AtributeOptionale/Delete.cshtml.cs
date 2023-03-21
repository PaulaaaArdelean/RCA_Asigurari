using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RCA_Asigurari.Data;
using RCA_Asigurari.Models;

namespace RCA_Asigurari.Pages.AtributeOptionale
{
    public class DeleteModel : PageModel
    {
        private readonly RCA_Asigurari.Data.RCA_AsigurariContext _context;

        public DeleteModel(RCA_Asigurari.Data.RCA_AsigurariContext context)
        {
            _context = context;
        }

        [BindProperty]
      public AtributOptional AtributOptional { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AtributOptional == null)
            {
                return NotFound();
            }

            var atributoptional = await _context.AtributOptional.FirstOrDefaultAsync(m => m.ID == id);

            if (atributoptional == null)
            {
                return NotFound();
            }
            else 
            {
                AtributOptional = atributoptional;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.AtributOptional == null)
            {
                return NotFound();
            }
            var atributoptional = await _context.AtributOptional.FindAsync(id);

            if (atributoptional != null)
            {
                AtributOptional = atributoptional;
                _context.AtributOptional.Remove(AtributOptional);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
