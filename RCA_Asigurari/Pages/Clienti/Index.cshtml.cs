using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RCA_Asigurari.Data;
using RCA_Asigurari.Models;

namespace RCA_Asigurari.Pages.Clienti
{
    public class IndexModel : PageModel
    {
        private readonly RCA_Asigurari.Data.RCA_AsigurariContext _context;

        public IndexModel(RCA_Asigurari.Data.RCA_AsigurariContext context)
        {
            _context = context;
        }

        public IList<Client> Client { get;set; } = default!;
        //public string CurrentFilter { get; set; }

        public async Task OnGetAsync(string searchString1)
        {
            //CurrentFilter = searchString1;

            //if (!String.IsNullOrEmpty(searchString1))
            //{
            //    Client = Client.Where(s => s.NumeClientFirma.Contains(searchString1));
            //}

               //|| s.Author.LastName.Contains(searchString)
               //|| s.Title.Contains(searchString));

                if (_context.Client != null)
            {
                Client = await _context.Client
                .Include(c => c.Judet)
                .Include(c => c.Localitate)
                .Include(c => c.TipAsigurat)
                .Include(c => c.TipSocietate).ToListAsync();
            }
        }
    }
}
