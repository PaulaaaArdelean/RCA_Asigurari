﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RCA_Asigurari.Data;
using RCA_Asigurari.Models;

namespace RCA_Asigurari.Pages.PersoaneJuridice
{
    public class EditModel : PageModel
    {
        private readonly RCA_Asigurari.Data.RCA_AsigurariContext _context;

        public EditModel(RCA_Asigurari.Data.RCA_AsigurariContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PersoanaJuridica PersoanaJuridica { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PersoanaJuridica == null)
            {
                return NotFound();
            }

            var persoanajuridica =  await _context.PersoanaJuridica.FirstOrDefaultAsync(m => m.ID == id);
            if (persoanajuridica == null)
            {
                return NotFound();
            }
            PersoanaJuridica = persoanajuridica;
           ViewData["ClientID"] = new SelectList(_context.Client, "ID", "ID");
           ViewData["JudetID"] = new SelectList(_context.Judet, "ID", "ID");
           ViewData["LocalitateID"] = new SelectList(_context.Localitate, "ID", "ID");
           ViewData["TipSocietateID"] = new SelectList(_context.TipSocietate, "ID", "ID");
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

            _context.Attach(PersoanaJuridica).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersoanaJuridicaExists(PersoanaJuridica.ID))
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

        private bool PersoanaJuridicaExists(int id)
        {
          return (_context.PersoanaJuridica?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
