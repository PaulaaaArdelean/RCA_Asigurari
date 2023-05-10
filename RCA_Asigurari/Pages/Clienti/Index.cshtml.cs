using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
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

        public IList<Client> Client { get; set; } = default!;

     
        public async Task OnGetAsync()
        {

                    if (_context.Client != null)
            {
              

                Client = await _context.Client
                 .Include(c => c.TipClient)
                 .Include(c => c.Judet)
                .ToListAsync();

            }
        }
        public async Task OnPostAsync()
        {
            var searchString = Request.Form["searchString"];

            Client = await _context.Client
                .Include(b => b.Judet)
                .Include(c => c.TipClient)

                .Where(x => x.NumeProprietar.Contains(searchString) 
                || x.Judet.Judetul.Contains(searchString)
                || x.Localitate.Contains(searchString)
                || x.Numar.Contains(searchString)
                || x.Strada.Contains(searchString)
                || x.CodPostal.Contains(searchString)
                || x.Telefon.Contains(searchString)
                || x.Email.Contains(searchString)
                || x.TipClient.TipulClientului.Contains(searchString)
                ).ToListAsync();
        }
    }
}