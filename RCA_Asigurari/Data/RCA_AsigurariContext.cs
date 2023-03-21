using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RCA_Asigurari.Models;

namespace RCA_Asigurari.Data
{
    public class RCA_AsigurariContext : DbContext
    {
        public RCA_AsigurariContext (DbContextOptions<RCA_AsigurariContext> options)
            : base(options)
        {
        }

        public DbSet<RCA_Asigurari.Models.TipCombustibil> TipCombustibil { get; set; } = default!;

        public DbSet<RCA_Asigurari.Models.TipSocietate>? TipSocietate { get; set; }

        public DbSet<RCA_Asigurari.Models.TipAsigurat>? TipAsigurat { get; set; }

        public DbSet<RCA_Asigurari.Models.Judet>? Judet { get; set; }

        public DbSet<RCA_Asigurari.Models.Localitate>? Localitate { get; set; }

        public DbSet<RCA_Asigurari.Models.CategorieVehicul>? CategorieVehicul { get; set; }

        public DbSet<RCA_Asigurari.Models.Client>? Client { get; set; }

        public DbSet<RCA_Asigurari.Models.PersoanaFizica>? PersoanaFizica { get; set; }

        public DbSet<RCA_Asigurari.Models.PersoanaJuridica>? PersoanaJuridica { get; set; }

        public DbSet<RCA_Asigurari.Models.Oferta>? Oferta { get; set; }

        public DbSet<RCA_Asigurari.Models.AtributOptional>? AtributOptional { get; set; }

        public DbSet<RCA_Asigurari.Models.Vehicul>? Vehicul { get; set; }
    }
}
