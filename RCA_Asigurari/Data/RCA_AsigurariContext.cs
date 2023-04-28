﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RCA_Asigurari.Models;
using RCA_Asigurari.Models.OferteDorite;

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

        //public DbSet<RCA_Asigurari.Models.Judet>? Judet { get; set; }

        //public DbSet<RCA_Asigurari.Models.Localitate>? Localitate { get; set; }

        public DbSet<RCA_Asigurari.Models.CategorieVehicul>? CategorieVehicul { get; set; }

        public DbSet<RCA_Asigurari.Models.Client>? Client { get; set; }

        public DbSet<RCA_Asigurari.Models.Oferta>? Oferta { get; set; }

//public DbSet<RCA_Asigurari.Models.AtributOptional>? AtributOptional { get; set; }

        //public DbSet<RCA_Asigurari.Models.Vehicul>? Vehicul { get; set; }

        //public DbSet<RCA_Asigurari.Models.AdresaClient>? AdresaClient { get; set; }
        public DbSet<RCA_Asigurari.Models.PF>? PF { get; set; }
        public DbSet<RCA_Asigurari.Models.PJ>? PJ { get; set; }
        public DbSet<RCA_Asigurari.Models.TipClient>? TipClient { get; set; }
        public DbSet<RCA_Asigurari.Models.OfertaPF>? OfertaPF { get; set; }
        public DbSet<RCA_Asigurari.Models.OfertaPJ>? OfertaPJ { get; set; }
        //public IEnumerable<object> Location { get; internal set; }
        //public DbSet<RCA_Asigurari.Models.Location>? Location_1 { get; set; }
        public DbSet<RCA_Asigurari.Models.OferteDorite.OfertaPFDorita>? OfertaPFDorita { get; set; }
        public DbSet<RCA_Asigurari.Models.OferteDorite.OfertaPJDorita>? OfertaPJDorita { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OfertaPFDorita>()
                .HasKey(c => new { c.ClientID, c.OfertaPFID });
            
            modelBuilder.Entity<OfertaPJDorita>()
                .HasKey(c => new { c.ClientID, c.OfertaPJID });
        }
        public DbSet<RCA_Asigurari.Models.Judet>? Judet { get; set; }
        public DbSet<RCA_Asigurari.Models.Localitate>? Localitate { get; set; }

        }
}
