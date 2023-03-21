using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RCA_Asigurari.Data;
using RCA_Asigurari.Models;

namespace RCA_Asigurari.Pages.TipuriSocietati
{
    public class DetailsModel : PageModel
    {
        private readonly RCA_Asigurari.Data.RCA_AsigurariContext _context;

        public DetailsModel(RCA_Asigurari.Data.RCA_AsigurariContext context)
        {
            _context = context;
        }

      public TipSocietate TipSocietate { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TipSocietate == null)
            {
                return NotFound();
            }

            var tipsocietate = await _context.TipSocietate.FirstOrDefaultAsync(m => m.ID == id);
            if (tipsocietate == null)
            {
                return NotFound();
            }
            else 
            {
                TipSocietate = tipsocietate;
            }
            return Page();
        }
    }
}
