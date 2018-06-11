// Rezervacija.cs

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
    public class Rezervacija : INotifyPropertyChanged
    {
        private String polaziste;
        private String odrediste;
        private DateTime datumPolaska, datumDolaska;
        private Korisnik korisnik;
        //private RezervacijaLeta rezervisaniLet;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RezervacijaId { get; set; }

        public int KorisnikId { get; set; }
        [ForeignKey("KorisnikId")]

        public virtual Korisnik Korisnik
        {
            get
            {
                return korisnik;
            }
            set
            {
                korisnik = value;
            }
        }

        public string Polaziste { get => polaziste; set => polaziste = value; }
        public string Odrediste { get => odrediste; set => odrediste = value; }
        public DateTime DatumPolaska { get => datumPolaska; set => datumPolaska = value; }
        public DateTime DatumDolaska { get => datumDolaska; set => datumDolaska = value; }

        public Rezervacija()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool Set<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
        {
            if (Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
