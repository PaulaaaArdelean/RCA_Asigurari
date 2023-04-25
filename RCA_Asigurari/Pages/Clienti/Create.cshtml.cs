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

        [BindProperty]
        public Client Client { get; set; } = default!;


        public IList<SelectListItem> Judete { get; set; }
        public IList<SelectListItem> Localitati { get; set; }


        [BindProperty]
        public string? RadioButtonClient { get; set; }
        public string[]? RadioButtonClienti = new[] { "Persoana fizica", "Persoana juridica" };

        public IActionResult OnGet()
        {
            Judete = _context.Location_1
            .Select(l => new SelectListItem
            {
                Value = l.Judet,
                Text = l.Judet
            })
            .Distinct()
            .OrderBy(j => j.Text)
            .ToList();

            Localitati = _context.Location_1
                .Select(l => new SelectListItem
                {
                    Group = new SelectListGroup { Name = l.Judet },
                    Value = l.Localitate,
                    Text = l.Localitate
                })
                .OrderBy(l => l.Group.Name)
                .ThenBy(l => l.Text)
                .ToList();
           
            ViewData["TipSocietateID"] = new SelectList(_context.TipSocietate, "ID", "TipulSocietate");

            return Page();
        }

     

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