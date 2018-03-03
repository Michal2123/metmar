using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Metmar2
{
    public enum TypStawki
    {
        Dobowa =0,
        Godzinowa = 1,
        Cena = 2
    }

    public class ItemModel : INotifyPropertyChanged
    {
        private int ilosc = 1;
        private decimal _kaucja;
        private string _nazwa;

        public int Id { get; set; }
        public string DisplayedNazwa { get; set; }
        public int Ilosc { get { return ilosc; } set { ilosc = value; } }
        public decimal StawkaCzas { get; set; }
        public int IloscCzas { get; set; }
        public int IdKlienta { get; set; }
        public decimal StawkaDzien { get; set; }
        public decimal StawkaGodzina { get; set; }
        public decimal Cena { get; set; }
        public decimal SumaZaPrzedmiot { get; set; }
        public string NazwaPrzedmiotu { get; set; }

        public TypStawki TypStawki { get; set; }

        public string NazwaKategori
        {
            get
            {
                return _nazwa;
            }
            set
            {
                _nazwa = value;
                OnPropertyChanged("NazwaKategori");
            }
        }

        public decimal Kaucja
        {
            get
            {
                return _kaucja;
            }
            set
            {
                _kaucja = value;
                OnPropertyChanged("Kaucja");
            }
        } 
        
        public string DisplayProperty
        {
            get
            {
                return $"{DisplayedNazwa}, Ilość: {Ilosc}, Kaucja: {Kaucja}";
            }
        }

        public bool IsPrice { get; set; }

        public bool IsNotPrice
        {
            get { return !IsPrice; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }

}
