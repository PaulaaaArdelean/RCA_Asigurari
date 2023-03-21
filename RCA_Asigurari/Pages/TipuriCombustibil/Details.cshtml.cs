using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RCA_Asigurari.Data;
using RCA_Asigurari.Models;

namespace RCA_Asigurari.Pages.TipuriCombustibil
{
    public class DetailsModel : PageModel
    {
        private readonly RCA_Asigurari.Data.RCA_AsigurariContext _context;

        public DetailsModel(RCA_Asigurari.Data.RCA_AsigurariContext context)
        {
            _context = context;
        }

      public TipCombustibil TipCombustibil { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TipCombustibil == null)
            {
                return NotFound();
            }

            var tipcombustibil = await _context.TipCombustibil.FirstOrDefaultAsync(m => m.ID == id);
            if (tipcombustibil == null)
            {
                return NotFound();
            }
            else 
            {
                TipCombustibil = tipcombustibil;
            }
            return Page();
        }
    }
}
