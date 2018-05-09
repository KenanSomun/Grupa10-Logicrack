using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace GoFlyMigrations
{
    public partial class InitialMigration : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "Administrator",
                columns: table => new
                {
                    AdministratorId = table.Column(type: "INTEGER", nullable: false),
                        //.Annotation("Sqlite:Autoincrement", true),
                    BrojTelefona = table.Column(type: "TEXT", nullable: true),
                    Email = table.Column(type: "TEXT", nullable: true),
                    Ime = table.Column(type: "TEXT", nullable: true),
                    KorisnikId = table.Column(type: "INTEGER", nullable: false),
                    Prezime = table.Column(type: "TEXT", nullable: true),
                    Sifra = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrator", x => x.AdministratorId);
                });
            migration.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    KorisnikId = table.Column(type: "INTEGER", nullable: false),
                        //.Annotation("Sqlite:Autoincrement", true),
                    BrojTelefona = table.Column(type: "TEXT", nullable: true),
                    Email = table.Column(type: "TEXT", nullable: true),
                    Ime = table.Column(type: "TEXT", nullable: true),
                    Prezime = table.Column(type: "TEXT", nullable: true),
                    Sifra = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.KorisnikId);
                });
            migration.CreateTable(
                name: "Let",
                columns: table => new
                {
                    LetId = table.Column(type: "INTEGER", nullable: false),
                        //.Annotation("Sqlite:Autoincrement", true),
                    CijenaLeta = table.Column(type: "REAL", nullable: false),
                    DatumDolaska = table.Column(type: "TEXT", nullable: false),
                    DatumPolaska = table.Column(type: "TEXT", nullable: false),
                    KlasaLeta = table.Column(type: "TEXT", nullable: true),
                    MaxBrojPutnika = table.Column(type: "INTEGER", nullable: false),
                    Odrediste = table.Column(type: "TEXT", nullable: true),
                    Polaziste = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Let", x => x.LetId);
                });
            migration.CreateTable(
                name: "Rezervacija",
                columns: table => new
                {
                    RezervacijaId = table.Column(type: "INTEGER", nullable: false),
                        //.Annotation("Sqlite:Autoincrement", true),
                    AdministratorAdministratorId = table.Column(type: "INTEGER", nullable: true),
                    DatumDolaska = table.Column(type: "TEXT", nullable: false),
                    DatumPolaska = table.Column(type: "TEXT", nullable: false),
                    KorisnikId = table.Column(type: "INTEGER", nullable: false),
                    Odrediste = table.Column(type: "TEXT", nullable: true),
                    Polaziste = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacija", x => x.RezervacijaId);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Administrator_AdministratorAdministratorId",
                        columns: x => x.AdministratorAdministratorId,
                        referencedTable: "Administrator",
                        referencedColumn: "AdministratorId");
                    table.ForeignKey(
                        name: "FK_Rezervacija_Korisnik_KorisnikId",
                        columns: x => x.KorisnikId,
                        referencedTable: "Korisnik",
                        referencedColumn: "KorisnikId");
                });
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Let");
            migration.DropTable("Rezervacija");
            migration.DropTable("Administrator");
            migration.DropTable("Korisnik");
        }
    }
}
