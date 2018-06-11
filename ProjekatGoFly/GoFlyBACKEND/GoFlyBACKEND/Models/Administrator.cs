using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoFlyBACKEND.Models
{
    public class Administrator : Korisnik
    {
        public int AdministratorId { get; set; }

        public Administrator() { }
        public Administrator(string email, string brojTelefona, string sifra, List<Rezervacija> rezervacije)
            : base(email, brojTelefona, sifra, rezervacije) { }
    }
}