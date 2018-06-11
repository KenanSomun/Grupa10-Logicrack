using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using GoFly.Model;

namespace GoFlyMigrations
{
    [ContextType(typeof(GoFlyDbContext))]
    partial class GoFlyDbContextModelSnapshot : ModelSnapshot
    {
        public override void BuildModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

            builder.Entity("GoFly.Model.Administrator", b =>
                {
                    b.Property<int>("AdministratorId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BrojTelefona");

                    b.Property<string>("Email");

                    b.Property<string>("Ime");

                    b.Property<int>("KorisnikId");

                    b.Property<string>("Prezime");

                    b.Property<string>("Sifra");

                    b.Key("AdministratorId");
                });

            builder.Entity("GoFly.Model.Korisnik", b =>
                {
                    b.Property<int>("KorisnikId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BrojTelefona");

                    b.Property<string>("Email");

                    b.Property<string>("Ime");

                    b.Property<string>("Prezime");

                    b.Property<string>("Sifra");

                    b.Key("KorisnikId");
                });

            builder.Entity("GoFly.Model.Let", b =>
                {
                    b.Property<int>("LetId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("CijenaLeta");

                    b.Property<DateTime>("DatumDolaska");

                    b.Property<DateTime>("DatumPolaska");

                    b.Property<string>("KlasaLeta");

                    b.Property<int>("MaxBrojPutnika");

                    b.Property<string>("Odrediste");

                    b.Property<string>("Polaziste");

                    b.Key("LetId");
                });

            builder.Entity("GoFly.Model.Rezervacija", b =>
                {
                    b.Property<int>("RezervacijaId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AdministratorAdministratorId");

                    b.Property<DateTime>("DatumDolaska");

                    b.Property<DateTime>("DatumPolaska");

                    b.Property<int>("KorisnikId");

                    b.Property<string>("Odrediste");

                    b.Property<string>("Polaziste");

                    b.Key("RezervacijaId");
                });

            builder.Entity("GoFly.Model.Rezervacija", b =>
                {
                    b.Reference("GoFly.Model.Administrator")
                        .InverseCollection()
                        .ForeignKey("AdministratorAdministratorId");

                    b.Reference("GoFly.Model.Korisnik")
                        .InverseCollection()
                        .ForeignKey("KorisnikId");
                });
        }
    }
}
