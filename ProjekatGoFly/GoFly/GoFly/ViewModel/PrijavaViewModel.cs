using GoFly.Helper;
using GoFly.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;

namespace GoFly.ViewModel
{
    public class PrijavaViewModel : INotifyPropertyChanged
    {
        public ICommand PrijaviSe { get; set; }
        public ICommand RegistrujSe { get; set; }
        public ICommand ZaboravljenaSifra { get; set; }
        public ICommand NastaviKaoGost { get; set; }
        INavigationService NavigationService { get; set; }

        private String username;
        private String password;

        public string Email
        {
            get
            {
                return username;
            }
            set
            {
                Set(ref username, value);
            }
        }

        public string Sifra
        {
            get
            {
                return password;
            }
            set
            {
                Set(ref password, value);
            }
        }

        public PrijavaViewModel()
        {
            NavigationService = new NavigationService();
            PrijaviSe = new RelayCommand<object>(prijava);
            RegistrujSe = new RelayCommand<object>(registracija);
            NastaviKaoGost = new RelayCommand<object>(nastaviKaoGost);
            ZaboravljenaSifra = new RelayCommand<object>(zaboravljenaSifra);
        }

        public async void zaboravljenaSifra(object parameter) {
            MessageDialog msg = new MessageDialog("Nije implementirano jos", "Greska");
            await msg.ShowAsync();
        }

        public void registracija(object parameter)
        {
            NavigationService.Navigate(typeof(View.Registracija), null);
        }

                            //Prijava korisnika
        public async void prijava(object parameter)
        {
            using (var db = new GoFlyDbContext())
            {
                bool nema = true;
                bool admin = false;

                if (Email == null || Sifra == null)
                {
                    MessageDialog msg = new MessageDialog("Unesite podatke", "Greska");
                    await msg.ShowAsync();
                    return;
                }

               
                if (db.Administratori.Count() == 0) {
                    Administrator temp = new Administrator();
                    temp.AdministratorId = 1;
                    temp.BrojTelefona = "";
                    temp.Email = "Admin";
                    temp.Ime = "Admin";
                    temp.KorisnikId = 1;
                    temp.MojeRezervacije = new List<Rezervacija>();
                    temp.Prezime = "Admin";
                    temp.Sifra = "admin1";

                    db.Administratori.Add(temp);
                    db.SaveChanges(); // OVO FALI NA GIT
                }
                
                foreach (Administrator Admin in db.Administratori) {
                    if (Admin.Email == Email && Admin.Sifra == Sifra) {
                        admin = true;
                        nema = false;
                        NavigationService.Navigate(typeof(View.StatistickiPodaci), null);
                    }
                }

                if (!admin)
                {
                    foreach (Korisnik user in db.Korisnici)
                    {
                        if (user.Email == Email && user.Sifra == Sifra)
                        {
                            nema = false;
                            NavigationService.Navigate(typeof(View.UredivanjeProfila), null);

                            break;
                        }
                    }
                }
                                // Ako u bazi nema osobe sa unesenim podacima
                if (nema) {
                    MessageDialog msg = new MessageDialog("Neispravan E-mail ili sifra.");
                    await msg.ShowAsync();
                }
            }
        }

        public async void nastaviKaoGost(object parameter)
        {
            MessageDialog msg = new MessageDialog("Nije implementirano za gost usera", "Greska");
            await msg.ShowAsync();
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
