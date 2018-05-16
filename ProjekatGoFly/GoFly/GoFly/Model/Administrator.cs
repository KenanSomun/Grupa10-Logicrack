using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFly.Model
{
    public class Administrator : Korisnik
    {
        public int AdministratorId { get; set; }

        public Administrator() { }
        public Administrator(string email, string brojTelefona, string sifra, List<Rezervacija> rezervacije) 
            : base(email, brojTelefona, sifra, rezervacije) { }
    }
}
