using Microsoft.Data.Entity;
using GoFly.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using System.IO;

namespace GoFly.Model
{
    public class GoFlyDbContext : DbContext
    {
        public DbSet<Let> Letovi { get; set; }
        public DbSet<Administrator> Administratori { get; set; }
        public DbSet<Korisnik> Korisnici { get; set; }
        //public DbSet<RezervacijaLeta> RezervisaniLetovi { get; set; }
        //public DbSet<Rezervacija> Rezervacije { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string databaseFilePath = "Parking.db";
            try
            {
                //za tačnu putanju gdje se nalazi baza uraditi ovdje debug i procitati Path
                databaseFilePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, databaseFilePath);
            }
            catch (InvalidOperationException) { }
            //Sqlite baza
            optionsBuilder.UseSqlite($"Data source={databaseFilePath}");
        }
    }
}
