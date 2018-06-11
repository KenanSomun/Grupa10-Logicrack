using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoFlyBACKEND.Models
{
    public enum KlasaLeta { Economy, Bussines };

    public class Let //: INotifyPropertyChanged
    {
        /*
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int LetId { get; set; } */

        private String polaziste;
        private String odrediste;
        private DateTime datumPolaska;
        private DateTime datumDolaska;
        private int maxBrojPutnika;
        private String klasaLeta;
        private double cijenaLeta;

        // get & set
        public String Polaziste { get => polaziste; set => polaziste = value; }
        public String Odrediste { get => odrediste; set => odrediste = value; }
        public DateTime DatumPolaska { get => datumPolaska; set => datumPolaska = value; }
        public DateTime DatumDolaska { get => datumDolaska; set => datumDolaska = value; }
        public int MaxBrojPutnika { get => maxBrojPutnika; set => maxBrojPutnika = value; }
        public String KlasaLeta { get => klasaLeta; set => klasaLeta = value; }
        public double CijenaLeta { get => cijenaLeta; set => cijenaLeta = value; }

        public Let() { }

        public Let(String polaziste, String odrediste, DateTime datPolaska, DateTime datDolaska, int maxBrPutnika, KlasaLeta klasa, double cijena)
        {
            this.polaziste = polaziste;
            this.odrediste = odrediste;
            this.datumPolaska = datPolaska;
            this.DatumDolaska = datDolaska;
            this.maxBrojPutnika = maxBrPutnika;
            this.KlasaLeta = klasa.ToString();
            this.cijenaLeta = cijena;
        }

        /*
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
        */
    }
}