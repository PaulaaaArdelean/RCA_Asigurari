﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RCA_Asigurari.Data;
using RCA_Asigurari.Models;

namespace RCA_Asigurari.Pages.Oferte
{
    public class IndexModel : PageModel
    {
        private readonly RCA_Asigurari.Data.RCA_AsigurariContext _context;

        public IndexModel(RCA_Asigurari.Data.RCA_AsigurariContext context)
        {
            _context = context;
        }

        public IList<Oferta> Oferta { get; set; } = default!;
        public OfertaData OfertaD { get; set; }
        public int OfertaID { get; set; }
        public int OptionalID { get; set; }
        public string NumeSortCresc { get; set; }
        public string NumeSortDesc { get; set; }

        public String CurrentFilter { get; set; }

        public async Task OnGetAsync(int? id, int? optionalID, string numeSortCresc, string numeSortDesc, string searchString)
        {

            NumeSortDesc = String.IsNullOrEmpty(numeSortDesc) ? "nume_desc" : "";
            NumeSortCresc = String.IsNullOrEmpty(numeSortCresc) ? "nume_cresc" : "";
            CurrentFilter = searchString;

            OfertaD = new OfertaData();

            OfertaD.Oferte = await _context.Oferta
            .Include(b => b.Client)
            .ThenInclude(c => c.Judet)
             .Include(b => b.Client)
            .ThenInclude(c => c.Localitate)
            .Include(b => b.TipCombustibil)
            .Include(b => b.CategorieVehicul)

            .Include(b => b.AtributeOptionaleOferta)
            .ThenInclude(b => b.AtributOptional)
            .AsNoTracking()
            // .OrderBy(b => b.N)
            .ToListAsync();




            if (!String.IsNullOrEmpty(searchString))
            {
                OfertaD.Oferte = OfertaD.Oferte.Where(s => s.Client.NumeClientFirma.Contains(searchString)

               || s.NrInmatriculare.Contains(searchString)
               || s.NumarIdentificare.Contains(searchString)
               || s.Marca.Contains(searchString)
               || s.CategorieVehicul.CategoriaVehicul.Contains(searchString)
               || s.TipCombustibil.TipulCombustibil.Contains(searchString)
               || s.SerieCIV.Contains(searchString)
               || s.AnFabricatie.Contains(searchString)
               || s.Model.Contains(searchString)
               || s.NumarIdentificare.Contains(searchString));


            }


            if (id != null)
            {
                OfertaID = id.Value;
                Oferta oferta = OfertaD.Oferte
                .Where(i => i.ID == id.Value).Single();
                OfertaD.AtributeOptionale = oferta.AtributeOptionaleOferta.Select(s => s.AtributOptional);
            }


        }
    }

}
