using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RCA_Asigurari.Data;
using RCA_Asigurari.Models;

namespace RCA_Asigurari.Pages.Clienti
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
            ViewData["TipSocietateID"] = new SelectList(_context.TipSocietate, "ID", "TipulSocietate");
            ViewData["TipAsiguratID"] = new SelectList(_context.TipAsigurat, "ID", "TipulAsigurat");
            ViewData["JudetID"] = new SelectList(_context.Judet, "ID", "Judetul");
            ViewData["LocalitateID"] = new SelectList(_context.Localitate, "ID", "Localitatea");


            return Page();
        }

        [BindProperty]
        public Client Client { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Client.Add(Client);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
