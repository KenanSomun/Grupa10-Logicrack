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
    class KontrolaKorisnikaViewModel : INotifyPropertyChanged
    {
        INavigationService NavigationService;
        public ICommand Back{get; set;}
        public ICommand StatistickiPodaci { get; set; }
        public ICommand KontrolaKorisnika { get; set; }
        public ICommand UnosLetova { get; set; }
        public ICommand Pretraga { get; set; }
        public ICommand PridruziAdminPrava { get; set; }
        public ICommand ObrisiKorisnika { get; set; }

        private string status;
        private string korisnicki_mail;
        private string ime;
        private string prezime;
        private string sifra;
        private string e_mail;
        private string kontakt_telefon;

        public string Status {
            get {
                return status;
            }
            set {
                Set(ref status, value);
            }
        }

        public string Ime {
            get {
                return ime;
            }
            set {
                Set(ref ime, value);
            }
        }

        public string Prezime
        {
            get
            {
                return prezime;
            }
            set
            {
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

        public string Email
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

        public string KorisnickiEmail
        {
            get {
                return korisnicki_mail;
            }
            set {
                Set(ref korisnicki_mail, value);
            }
        }

        public KontrolaKorisnikaViewModel() {
            NavigationService = new NavigationService();
            Back = new RelayCommand<object>(back);
            StatistickiPodaci = new RelayCommand<object>(statistickiPodaci);
            KontrolaKorisnika = new RelayCommand<object>(kontrolaKorisnika);
            UnosLetova = new RelayCommand<object>(unosLetova);
            Pretraga = new RelayCommand<object>(pretraga);
            PridruziAdminPrava = new RelayCommand<object>(pridruziAdminPrava);
            ObrisiKorisnika = new RelayCommand<object>(obrisiKorisnika);
        }

        public void back(object paremeter) {
            NavigationService.Navigate(typeof(View.Prijava), null);
        }

        public void statistickiPodaci(object parameter) {
            NavigationService.Navigate(typeof(View.StatistickiPodaci), null);
        }

        public void kontrolaKorisnika(object parameter) {   // Na ovoj smo stranici, nista se ne desava
        }

        public void unosLetova(object parameter) {
            NavigationService.Navigate(typeof(View.UnosLetova), null);
        }

        public async void pretraga(object parameter) {
            if (KorisnickiEmail == null) {
                MessageDialog msg = new MessageDialog("Unesite e-mail", "Greska");
                await msg.ShowAsync();
                return;
            }

            if (!(new EmailAddressAttribute().IsValid(KorisnickiEmail))) {
                MessageDialog msg = new MessageDialog("Neispravan E-mail", "Greska");
                await msg.ShowAsync();
                return;
            }

            using (var db = new GoFlyDbContext()) {
                bool nema = true;

                foreach (Korisnik user in db.Korisnici) {
                    if (user.Email == KorisnickiEmail) {
                        nema = false;

                        Ime = user.Ime;
                        Prezime = user.Prezime;
                        Sifra = user.Sifra;
                        Email = user.Email;
                        KontaktTelefon = user.BrojTelefona;
                        Status = "Korisnik";

                    }
                }

                if (nema) {
                    MessageDialog msg = new MessageDialog("Korisnik nije pronaden", "Greska");
                    await msg.ShowAsync();
                    return;
                }
            }

        }

        public async void pridruziAdminPrava(object parameter) {
            if (KorisnickiEmail == null)
            {
                MessageDialog msg = new MessageDialog("Unesite e-mail", "Greska");
                await msg.ShowAsync();
                return;
            }

            if (!(new EmailAddressAttribute().IsValid(KorisnickiEmail)))
            {
                MessageDialog msg = new MessageDialog("Neispravan E-mail", "Greska");
                await msg.ShowAsync();
                return;
            }

            Administrator NoviAdmin = new Administrator();
                    
            using (var db = new GoFlyDbContext()) {

                foreach (Administrator tempAdmin in db.Administratori) {
                    if (tempAdmin.Email == KorisnickiEmail) {
                        MessageDialog msg = new MessageDialog("Ovaj korisnik vec ima admin prava", "Greska");
                        await msg.ShowAsync();
                        return;
                    }
                }

                bool nema = true;

                foreach (Korisnik user in db.Korisnici) {
                    if (user.Email == KorisnickiEmail) {
                        nema = false;

                        NoviAdmin.AdministratorId = db.Administratori.Count() + 1;
                        NoviAdmin.BrojTelefona = user.BrojTelefona;
                        NoviAdmin.Email = user.Email;
                        NoviAdmin.Ime = user.Ime;
                        NoviAdmin.Prezime = user.Prezime;
                        NoviAdmin.KorisnikId = user.KorisnikId + 2;
                        NoviAdmin.MojeRezervacije = user.MojeRezervacije;
                        NoviAdmin.Sifra = "admin" + user.Sifra;

                        
                        db.Administratori.Add(NoviAdmin);
                        db.SaveChanges();

                        string messege = "E-mail novog admina je: " + NoviAdmin.Email + " sifra novog admina je: " + NoviAdmin.Sifra;

                        MessageDialog msg = new MessageDialog(messege , "Dodali ste admin prava");
                        await msg.ShowAsync();
                        return;
                    }
                }

                if (nema)
                {
                    MessageDialog msg = new MessageDialog("Korisnik nije pronaden", "Greska");
                    await msg.ShowAsync();
                    return;
                }

            }
        }

        public async void obrisiKorisnika(object parameter) {
            if (KorisnickiEmail == null)
            {
                MessageDialog msg = new MessageDialog("Unesite e-mail", "Greska");
                await msg.ShowAsync();
                return;
            }

            if (!(new EmailAddressAttribute().IsValid(KorisnickiEmail)))
            {
                MessageDialog msg = new MessageDialog("Neispravan E-mail", "Greska");
                await msg.ShowAsync();
                return;
            }


            using (var db = new GoFlyDbContext()) {
                bool nema = true;

                foreach (Korisnik user in db.Korisnici) {

                    if (user.Email == KorisnickiEmail) {
                        nema = false;

                        db.Korisnici.Remove(user);
                        db.SaveChanges();


                        MessageDialog msg = new MessageDialog("Uspješno ste obrisali korisnika", "Čestitamo!");
                        await msg.ShowAsync();
                        return;
                    }

                 
                }

                if (nema)
                {
                    MessageDialog msg = new MessageDialog("Korisnik nije pronaden", "Greska");
                    await msg.ShowAsync();
                    return;
                }
            }

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
