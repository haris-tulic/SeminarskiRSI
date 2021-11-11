using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autoprevoznicko_preduzece_HTS.Model
{
   public class MyContext:DbContext
    {
        public MyContext(DbContextOptions<MyContext> x) : base(x)
        {
            // puca bez defaultnog konstruktora
        }
        public MyContext() { }
        public DbSet<Kupac> kupac { get; set; }
        public DbSet<Grad> grad { get; set; }
        public DbSet<GradskeLinije> gradskeLinije { get; set; }
        public DbSet<Karta> karta { get; set; }
        public DbSet<Stanica> stanica { get; set; }
        public DbSet<Opstina> opstina { get; set; }
        public DbSet<Autobus> autobus { get; set; }
        public DbSet<RedVoznje> redVoznje { get; set; }
        public DbSet<TipKarte> tipKarte { get; set; }
        public DbSet<VrstaKarte> vrstaKarte { get; set; }
        public DbSet<Zona> zona { get; set; }
        public DbSet<Cjenovnik> cjenovnik { get; set; }
        public DbSet<Login> login { get; set; }
        public DbSet<Uprava> uprava { get; set; }
        public DbSet<Vozac> vozac { get; set; }
        public DbSet<Obavijesti> obavijesti { get; set; }
        public DbSet<RegistracioniPodaci> registracioniPodaci { get; set; }
        public DbSet<AutobusVozac> autobusVozac { get; set; }
        public DbSet<AutorizacijskiToken> AutorizacijskiToken { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=.;
                  Database=AutoprevoznickoPreduzeceHTS;
                  Trusted_Connection=true;
                  MultipleActiveResultSets=true;
                  User ID=sa;
                  Password=test");
        }
    }
}
