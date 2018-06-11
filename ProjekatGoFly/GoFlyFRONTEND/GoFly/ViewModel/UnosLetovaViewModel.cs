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
    class UnosLetovaViewModel : INotifyPropertyChanged
    {
        INavigationService NavigationService;
        public ICommand Back { get; set; }
        public ICommand StatistickiPodaci { get; set; }
        public ICommand KontrolaKorisnika { get; set; }
        public ICommand UnesiLet { get; set; }

        private string polaziste;
        private string odrediste;
        private string klasa;
        private string max_broj_putnika;
        private string cijena_karte;
        private string datum_dolaska;
        private string datum_polaska;

        public string DatumPolaska
        {
            get
            {
                return datum_polaska;
            }
            set
            {
                Set(ref datum_polaska, value);
            }
        }

        public string DatumDolaska
        {
            get
            {
                return datum_dolaska;
            }
            set
            {
                Set(ref datum_dolaska, value);
            }
        }

        public string Polaziste {
            get {
                return polaziste;
            }
            set {
                Set(ref polaziste, value);
            }
        }

        public string Odrediste
        {
            get
            {
                return odrediste;
            }
            set
            {
                Set(ref odrediste, value);
            }
        }

        public string Klasa
        {
            get
            {
                return klasa;
            }
            set
            {
                Set(ref klasa, value);
            }
        }

        public string CijenaKarte
        {
            get
            {
                return cijena_karte;
            }
            set
            {
                Set(ref cijena_karte, value);
            }
        }

        public string MaxBrojPutnika {
            get {
                return max_broj_putnika;
            }
            set {
                Set(ref max_broj_putnika, value);
            }
        }

        public UnosLetovaViewModel() {
            NavigationService = new NavigationService();
            Back = new RelayCommand<object>(back);
            StatistickiPodaci = new RelayCommand<object>(statistickiPodaci);
            KontrolaKorisnika = new RelayCommand<object>(kontrolaKorisnika);
            UnesiLet = new RelayCommand<object>(unesiLet);
        }

        public void back(object paremeter){
            NavigationService.Navigate(typeof(View.Prijava), null);
        }

        public void statistickiPodaci(object parameter){
            NavigationService.Navigate(typeof(View.StatistickiPodaci), null);
        }

        public void kontrolaKorisnika(object parameter){
            NavigationService.Navigate(typeof(View.KontrolaKorisnika), null);
        }

        // Kod unosa letova, kad se omoguci brisanje letova iz baze 
        //podataka, imat cemo problema sa ID-em leta. ID mora bit unique a sad se odreduje prema velicini liste letova iz baze
        public async void unesiLet(object parameter)
        {
            if (DatumPolaska == null || DatumDolaska == null || Polaziste == null || Odrediste == null || CijenaKarte == null || MaxBrojPutnika == null )
            {
                MessageDialog msg = new MessageDialog("Unesite sve podatke", "Greska");
                await msg.ShowAsync();
                return;
            }

            for (int i = 0; i < CijenaKarte.Length; i++)
            {
                if (CijenaKarte[i] < '0' || CijenaKarte[i] > '9')
                {
                    MessageDialog msg = new MessageDialog("Cijena karte mora biti broj", "Greska");
                    await msg.ShowAsync();
                    return;
                }
            }

            for (int i = 0; i < MaxBrojPutnika.Length; i++)
            {
                if (MaxBrojPutnika[i] < '0' || MaxBrojPutnika[i] > '9')
                {
                    MessageDialog msg = new MessageDialog("Maksimalan broj putnika mora biti broj", "Greska");
                    await msg.ShowAsync();
                    return;
                }
            }

            int cijena = 0;
            int brojP = 0;

            if (!Int32.TryParse(CijenaKarte, out cijena) || !Int32.TryParse(MaxBrojPutnika, out brojP)) {
                MessageDialog msg = new MessageDialog("Unesite brojeve", "Greska");
                await msg.ShowAsync();
                return;
            }

            if (cijena <= 0 || brojP <= 0) {
                MessageDialog msg = new MessageDialog("Cijena ili broj putnika su manji ili jednaki nuli", "Greska");
                await msg.ShowAsync();
                return;
            }

            DateTime datump = DateTime.Now;
            DateTime datumd = DateTime.Now;

            if (!DateTime.TryParse(DatumPolaska, out datump) || !DateTime.TryParse(DatumDolaska, out datumd)) {
                MessageDialog msg = new MessageDialog("Neispravan datum", "Greska");
                await msg.ShowAsync();
                return;
            }

            using(var db = new GoFlyDbContext()) {
                Let NoviLet = new Let();

                NoviLet.LetId = db.Letovi.Count() + 1;
                NoviLet.DatumDolaska = datumd;
                NoviLet.DatumPolaska = datump;
                NoviLet.CijenaLeta = cijena;
                NoviLet.MaxBrojPutnika = brojP;
                NoviLet.Polaziste = Polaziste;
                NoviLet.Odrediste = Odrediste;
                NoviLet.KlasaLeta = Klasa;

                db.Letovi.Add(NoviLet);
                db.SaveChanges();

                MessageDialog msg = new MessageDialog("Uspjesno ste unijeli let", "Cestitamo");
                await msg.ShowAsync();
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
