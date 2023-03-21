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
    public class IndexModel : PageModel
    {
        private readonly RCA_Asigurari.Data.RCA_AsigurariContext _context;

        public IndexModel(RCA_Asigurari.Data.RCA_AsigurariContext context)
        {
            _context = context;
        }

        public IList<AtributOptional> AtributOptional { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.AtributOptional != null)
            {
                AtributOptional = await _context.AtributOptional.ToListAsync();
            }
        }
    }
}
