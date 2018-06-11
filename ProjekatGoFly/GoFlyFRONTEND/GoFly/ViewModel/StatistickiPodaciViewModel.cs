using System;
using GoFly.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GoFly.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GoFly.ViewModel
{
    class StatistickiPodaciViewModel : INotifyPropertyChanged
    {
        INavigationService NavigationService;
        public ICommand Back { get; set; }
        public ICommand KontrolaKorisnika { get; set; }
        public ICommand UnosLetova { get; set; }

        private int brojBrojKorisnika;
        private int brojUkupnoDostupnihKarti;
        private int brojAktivniLetovi;
        private int brojRezervisaniLetovi;

        public int BrojKorisnika {
            get {
                return brojBrojKorisnika;
            }
            set {
                Set(ref brojBrojKorisnika, value);
            }
        }

        public int UkupnoDostupnihKarti {
            get {
                return brojUkupnoDostupnihKarti;
            }
            set {
                Set(ref brojUkupnoDostupnihKarti, value);
            }
        }
        public int AktivniLetovi {
            get {
                return brojAktivniLetovi;
            }
            set {
                Set(ref brojAktivniLetovi, value);
            }
        }
        public int RezervisaniLetovi {
            get {
                return brojRezervisaniLetovi;
            }
            set {
                Set(ref brojRezervisaniLetovi, value);
            }
        }

        public StatistickiPodaciViewModel() {
            NavigationService = new NavigationService();
            Back = new RelayCommand<object>(back);
            KontrolaKorisnika = new RelayCommand<object>(kontrolaKorisnika);
            UnosLetova = new RelayCommand<object>(unosLetova);

            using (var db = new GoFlyDbContext()) {
                brojBrojKorisnika = db.Korisnici.Count();

                foreach (Let let in db.Letovi) {
                    brojUkupnoDostupnihKarti += let.MaxBrojPutnika;
                }

                brojAktivniLetovi = db.Letovi.Count();
                brojRezervisaniLetovi = 0;
            }
        }

        public void back(object parameter) {
            NavigationService.Navigate(typeof(View.Prijava), null);
        }

        public void kontrolaKorisnika(object parameter) {
            NavigationService.Navigate(typeof(View.KontrolaKorisnika), null);
        }

        public void unosLetova(object parameter) {
            NavigationService.Navigate(typeof(View.UnosLetova), null);
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
