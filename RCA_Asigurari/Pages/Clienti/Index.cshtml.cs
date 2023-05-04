using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RCA_Asigurari.Data;
using RCA_Asigurari.Models;

namespace RCA_Asigurari.Pages.Clienti
{
    [Authorize(Roles = "Admin")]

    public class IndexModel : PageModel
    {
        private readonly RCA_Asigurari.Data.RCA_AsigurariContext _context;

        public IndexModel(RCA_Asigurari.Data.RCA_AsigurariContext context)
        {
            _context = context;
        }

        public IList<Client> Client { get;set; } = default!;
        //public string CurrentFilter { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? CautareC { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? CautareClient { get; set; }
        //[BindProperty]
        //public string? RadioButtonClient { get; set; }
        //public string[]? RadioButtonClienti = new[] { "Persoana fizica", "Persoana juridica" };

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
               
                 .Include(c => c.TipClient)
                 .Include(c => c.Judet)
                 //.Include(c => c.OfertaPF)

                // .Include(c => c.TipSocietate)

                // .Where (CNP != null; 
                .ToListAsync();

                //if (!String.IsNullOrEmpty(SearchString))
                //{
                //    Client = Client.Where(s => s.NumeProprietar.Contains(SearchString)
                //      || s.Judet.Judetul.Contains(SearchString)

                //    );
                //}
            }
            
        }
    }
}
