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

namespace RCA_Asigurari.Pages.Oferte
{
    public class EditModel : OferteOptionalPageModel
    {
        private readonly RCA_Asigurari.Data.RCA_AsigurariContext _context;
        //private readonly UserManager<IdentityUser> _userManager;

        public EditModel(RCA_Asigurari.Data.RCA_AsigurariContext context /*UserManager<IdentityUser> userManager*/)
        {
            _context = context;
            //_userManager = userManager;

        }

        [BindProperty]
        public Oferta Oferta { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Oferta == null)
            {
                return NotFound();
            }

            Oferta = await _context.Oferta
  .Include(b => b.Client)
  .Include(b => b.AtributeOptionaleOferta).ThenInclude(b => b.AtributOptional)
  .AsNoTracking()
  .FirstOrDefaultAsync(m => m.ID == id);

            if (Oferta == null)
            {
                return NotFound();
            }

            PopulateAssignedOptionalData(_context, Oferta);

            //var userName = _userManager.GetUserName(User);

            //var detaliiClient = _context.Client
            //    .Where(c => c.Email == userName)
            //    .Select(x => new
            //    {
            //        x.ID,
            //        DetaliiClient = x.NumeIntreg + " " + x.NumeFirma
            //    });
            ViewData["CategorieVehiculID"] = new SelectList(_context.CategorieVehicul, "ID", "CategoriaVehicul");
            ViewData["ClientID"] = new SelectList(_context.Client, "ID", "NumeIntreg");

            //ViewData["ClientID"] = new SelectList(detaliiClient, "ID", "DetaliiClient");
            ViewData["TipCombustibilID"] = new SelectList(_context.TipCombustibil, "ID", "TipulCombustibil");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedAttributes)
        {
            if (id == null)
            {
                return NotFound();
            }
            //se va include Author conform cu sarcina de la lab 2
            var ofertaToUpdate = await _context.Oferta
            .Include(i => i.Client)
            .Include(i => i.AtributeOptionaleOferta)
            .ThenInclude(i => i.AtributOptional)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (ofertaToUpdate == null)
            {
                return NotFound();
            }
            //se va modifica AuthorID conform cu sarcina de la lab 2
            if (await TryUpdateModelAsync<Oferta>(
            ofertaToUpdate,
            "Oferta",
            i => i.ClientID, i => i.NumarIdentificare,
            i => i.NrInmatriculare, i => i.Marca, i => i.Model, i => i.AnFabricatie,
            i => i.CapacitateCilindrica, i => i.SerieCIV,
             i => i.NrLocuri, i => i.MasaMaxima, i => i.Putere,
              i => i.CategorieVehiculID, i => i.TipCombustibilID))
            {
                UpdateAtributeOptionaleOferta(_context, selectedAttributes, ofertaToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care 
            //este editata 
            UpdateAtributeOptionaleOferta(_context, selectedAttributes, ofertaToUpdate);
            PopulateAssignedOptionalData(_context, ofertaToUpdate);
            return Page();
        }
    }

}
