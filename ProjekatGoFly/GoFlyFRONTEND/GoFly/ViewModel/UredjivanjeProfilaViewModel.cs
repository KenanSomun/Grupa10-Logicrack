using GoFly.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GoFly.ViewModel
{
    public class UredjivanjeProfilaViewModel
    {
        INavigationService NavigationService { get; set; }
        public ICommand Back { get; set; }

        public UredjivanjeProfilaViewModel() {
            NavigationService = new NavigationService();
            Back = new RelayCommand<object>(back);
        }

        public void back(object parameter) {
            NavigationService.Navigate(typeof(View.Prijava), null);
        }

    }
}
