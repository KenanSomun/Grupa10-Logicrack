using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GoFly.Model
{
    public class Korisnik : INotifyPropertyChanged
    {
        private String ime;
        private String prezime;
        private String sifra;
        private String email;
        private String brojTelefona;
        private List<Rezervacija> mojeRezervacije;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KorisnikId { get; set; }

        public Korisnik() { }

        public event PropertyChangedEventHandler PropertyChanged;

        public Korisnik(String email, String brojTelefona, String sifra, List<Rezervacija> mojeRezervacije)
        {
            this.email = email;
            this.brojTelefona = brojTelefona;
            this.sifra = sifra;
            mojeRezervacije = MojeRezervacije;
        }
        public String Ime { get { return ime; } set { Set(ref ime, value); } }
        public String Prezime { get { return prezime; } set { Set(ref prezime, value); } }
        public String Email { get { return email; } set { Set(ref email, value); } }
        public String BrojTelefona { get { return brojTelefona; } set { Set(ref brojTelefona, value); } }
        public String Sifra { get { return sifra; } set { Set(ref sifra, value); } }
        public virtual List<Rezervacija> MojeRezervacije { get { return mojeRezervacije; } set { mojeRezervacije = value; } }
        public String ImePrezime { get { return ime + " " + prezime; } }

        protected virtual void OnPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public bool Set<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
        {
            if (Equals(storage, value)) return false;
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
