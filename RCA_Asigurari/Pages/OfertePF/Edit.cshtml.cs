using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RCA_Asigurari.Data;
using RCA_Asigurari.Models;

namespace RCA_Asigurari.Pages.OfertePF
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
        public OfertaPF OfertaPF { get; set; } = default!;

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
                    DetaliiClient = x.NumeProprietar /*+ " " + x.NumeFirma*/
                });
            if (id == null || _context.OfertaPF == null)
            {
                return NotFound();
            }

            var ofertapf =  await _context.OfertaPF.FirstOrDefaultAsync(m => m.ID == id);
            if (ofertapf == null)
            {
                return NotFound();
            }
            OfertaPF = ofertapf;
           ViewData["CategorieVehiculID"] = new SelectList(_context.CategorieVehicul, "ID", "CategoriaVehicul");
            ViewData["ClientID"] = new SelectList(detaliiClient, "ID", "DetaliiClient", CurrentClientID);
            ViewData["TipCombustibilID"] = new SelectList(_context.TipCombustibil, "ID", "TipulCombustibil");
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

            _context.Attach(OfertaPF).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfertaPFExists(OfertaPF.ID))
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

        private bool OfertaPFExists(int id)
        {
          return (_context.OfertaPF?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
