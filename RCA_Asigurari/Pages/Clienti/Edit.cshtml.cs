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

namespace RCA_Asigurari.Pages.Clienti
{
    public class EditModel : PageModel
    {
        private readonly RCA_Asigurari.Data.RCA_AsigurariContext _context;

        public EditModel(RCA_Asigurari.Data.RCA_AsigurariContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Client Client { get; set; } = default!;
        [BindProperty]
        public string? RadioButtonClient { get; set; }
        public string[]? RadioButtonClienti = new[] { "Persoana fizica", "Persoana juridica" };

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Client == null)
            {
                return NotFound();
            }

            var client = await _context.Client
                .FirstOrDefaultAsync(m => m.ID == id);
            if (client == null)
            {
                return NotFound();
            }
            Client = client;
            ViewData["TipSocietateID"] = new SelectList(_context.TipSocietate, "ID", "TipulSocietate");
            ViewData["TipAsiguratID"] = new SelectList(_context.TipAsigurat, "ID", "TipulAsigurat");
            ViewData["JudetID"] = new SelectList(_context.Judet, "ID", "Judetul");
            ViewData["LocalitateID"] = new SelectList(_context.Localitate, "ID", "Localitatea");

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

            _context.Attach(Client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(Client.ID))
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

        private bool ClientExists(int id)
        {
            return _context.Client.Any(e => e.ID == id);
        }
    }
}