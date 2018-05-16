using GoFly.Helper;
using GoFly.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;


namespace GoFly.ViewModel
{
    public class RegistracijaViewModel : INotifyPropertyChanged
    {
        public ICommand PrijaviSe { get; set; }
        public ICommand RegistrujSe { get; set; }
        INavigationService NavigationService { get; set; }

        private string ime;
        private string prezime;
        private string sifra;
        private string ponovi_sifru;
        private string e_mail;
        private string kontakt_telefon;


        public string Ime
        {
            get
            {
                return ime;
            }
            set
            {
                Set(ref ime, value);
            }
        }

        public string Prezime {
            get {
                return prezime;
            }
            set {
                Set(ref prezime, value);
            }
        }

        public string Sifra
        {
            get
            {
                return sifra;
            }
            set
            {
                Set(ref sifra, value);
            }
        }

        public string PonoviSifru
        {
            get
            {
                return ponovi_sifru;
            }
            set
            {
                Set(ref ponovi_sifru, value);
            }
        }

        public string E_mail
        {
            get
            {
                return e_mail;
            }
            set
            {
                Set(ref e_mail, value);
            }
        }

        public string KontaktTelefon
        {
            get
            {
                return kontakt_telefon;
            }
            set
            {
                Set(ref kontakt_telefon, value);
            }
        }


        public RegistracijaViewModel() {
            NavigationService = new NavigationService();
            PrijaviSe = new RelayCommand<object>(prijava);
            RegistrujSe = new RelayCommand<object>(registracija);
        }

        public void prijava(object parameter) {
            NavigationService.Navigate(typeof(View.Prijava), null);
        }

        public async void registracija(object parameter) {

            if (Ime == null || Prezime == null || Sifra == null || PonoviSifru == null || E_mail == null || KontaktTelefon == null) {
                MessageDialog msg = new MessageDialog("Unesite sve podatke", "Greska");
                await msg.ShowAsync();
                return;
            }

            if (Sifra.Length < 8) {
                MessageDialog msg = new MessageDialog("Sifra mora imati vise od 8 znakova", "Greska");
                await msg.ShowAsync();
                return;
            }

            if (Sifra != PonoviSifru) {
                MessageDialog msg = new MessageDialog("Sifre nisu iste", "Greska");
                await msg.ShowAsync();
                return;
            }

            if (!(new EmailAddressAttribute().IsValid(E_mail)))
            {
                MessageDialog msg = new MessageDialog("Pogresan E-mail", "Greska");
                await msg.ShowAsync();
                return;
            }

            using (var db = new GoFlyDbContext()) {
                foreach (Korisnik user in db.Korisnici) {
                    if (user.Email == E_mail) {
                        MessageDialog msg = new MessageDialog("Vec je prijavljen korisnik sa ovim E-mailom", "Greska");
                        await msg.ShowAsync();
                        return;
                    }
                }
            }

            for (int i = 0; i < KontaktTelefon.Length; i++) {
                if (KontaktTelefon[i] < '0' || KontaktTelefon[i] > '9' || KontaktTelefon.Length==0) {
                    MessageDialog msg = new MessageDialog("Unesite ispravan Kontakt telefon", "Greska");
                    await msg.ShowAsync();
                    return;
                }
            }

            //Spasavanje korisnika u lokalnu bazu podataka
            using (var db = new GoFlyDbContext()) {
                    Korisnik noviKorisnik = new Korisnik();
                    noviKorisnik.Ime = ime;
                    noviKorisnik.Prezime = prezime;
                    noviKorisnik.Sifra = sifra;
                    noviKorisnik.Email = e_mail;
                    noviKorisnik.BrojTelefona = kontakt_telefon;
                    noviKorisnik.MojeRezervacije = new List<Rezervacija>();

                    db.Korisnici.Add(noviKorisnik);

                    db.SaveChanges();
                }

            NavigationService.Navigate(typeof(View.Prijava), null); 


        }

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

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
