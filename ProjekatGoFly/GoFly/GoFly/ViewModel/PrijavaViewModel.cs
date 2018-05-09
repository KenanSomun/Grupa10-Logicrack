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

namespace GoFly.ViewModel
{
    public class PrijavaViewModel : INotifyPropertyChanged
    {
        public ICommand Back { get; set; }
        public ICommand Login { get; set; }
        public ICommand Registracija { get; set; }
        INavigationService NavigationService { get; set; }

        private String username;
        private String password;
        private String errorMessage;

        public String Username { get { return username; } set { Set(ref username, value); } }
        public String Password { get { return password; } set { Set(ref password, value); } }
        public String ErrorMessage { get { return errorMessage; } set { Set(ref errorMessage, value); } }

        public PrijavaViewModel()
        {
            NavigationService = new NavigationService();
            Back = new RelayCommand<object>(goBack);
            Login = new RelayCommand<object>(loginButton_Click);
            Registracija = new RelayCommand<object>(registracija);
        }

        public void registracija(object parameter)
        {
            NavigationService.Navigate(typeof(View.Registracija), new Gost());
        }

        public void goBack(object parameter)
        {
            NavigationService.Navigate(typeof(View.Prijava), new Gost());
        }

        public void loginButton_Click(object parameter)
        {
            
            using (var db = new GoFlyDbContext())
            {
                ErrorMessage = "";
                if (Username == null || Password == null)
                {
                    ErrorMessage = "Unesite podatke";
                    return;
                }
                foreach (Korisnik k in db.Korisnici)
                {
                    if (k.Email == Username)
                    {
                        if (k.Sifra == (Validation.CreateMD5(Password)))
                        {
                            NavigationService.Navigate(typeof(View.Prijava), k);
                        }
                        break;
                    }
                }
                ErrorMessage = "Pogresna sifra ili mail";
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
