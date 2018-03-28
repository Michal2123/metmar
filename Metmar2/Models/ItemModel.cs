namespace Metmar2
{
    public enum TypStawki
    {
        Dobowa = 0,
        Godzinowa = 1,
        Cena = 2
    }

    public class ItemModel 
    {
        public int Id { get; set; }
        public string DisplayedNazwa { get; set; }
        public int Ilosc { get; set; } = 1;
        public decimal StawkaCzas { get; set; }
        public int IloscCzas { get; set; } = 1;
        public int IdKlienta { get; set; }
        public decimal StawkaDzien { get; set; }
        public decimal StawkaGodzina { get; set; }
        public decimal Cena { get; set; }
        public decimal SumaZaPrzedmiot { get; set; }
        public string NazwaPrzedmiotu { get; set; }
        public int Wartosc { get; set; }
        public string StawkaUmowa { get; set; }
        public TypStawki TypStawki { get; set; }
        public decimal Kaucja { get; set; }

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

        public int IsSki { get; set; }
    }

}
