using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RCA_Asigurari.Data;
using RCA_Asigurari.Models;

namespace RCA_Asigurari.Pages.OfertePJ
{
    public class EditModel : PageModel
    {
        private readonly RCA_Asigurari.Data.RCA_AsigurariContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public EditModel(RCA_Asigurari.Data.RCA_AsigurariContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public OfertaPJ OfertaPJ { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var userEmail = User.Identity.Name;
            int CurrentClientID = _context.Client.First(client => client.Email == userEmail).ID;



            var userName = _userManager.GetUserName(User);

            var detaliiClient = _context.Client
                 .Where(c => c.Email == userName)
                 .Select(x => new
                 {
                     x.ID,
                     DetaliiClient = x.NumeProprietar
                 });
            if (id == null || _context.OfertaPJ == null)
            {
                return NotFound();
            }

            var ofertapj =  await _context.OfertaPJ.FirstOrDefaultAsync(m => m.ID == id);
            if (ofertapj == null)
            {
                return NotFound();
            }
            OfertaPJ = ofertapj;
           ViewData["CategorieVehiculID"] = new SelectList(_context.CategorieVehicul, "ID", "CategoriaVehicul");
            ViewData["ClientID"] = new SelectList(detaliiClient, "ID", "DetaliiClient");
            ViewData["TipCombustibilID"] = new SelectList(_context.TipCombustibil, "ID", "TipulCombustibil");
           ViewData["TipSocietateID"] = new SelectList(_context.TipSocietate, "ID", "TipulSocietate");
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

            _context.Attach(OfertaPJ).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfertaPJExists(OfertaPJ.ID))
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

        private bool OfertaPJExists(int id)
        {
          return (_context.OfertaPJ?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
