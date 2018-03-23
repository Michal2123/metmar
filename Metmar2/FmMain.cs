using Metmar2.BookmarkReplace;
using Metmar2.Connection;
using Metmar2.Models;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Metmar2
{
    public partial class FmMain : Form
    {
        private BindingList<ItemModel> _list = new BindingList<ItemModel>();
        private ItemModel _itemModel = new ItemModel();
        private KlientModel _klientModel = new KlientModel();
        private DAL _dal = new DAL();
        private Klienci _klienci = new Klienci();

        private void fillComboKat()
        {
            comboBoxKat.DataSource = _dal.FillComboKat();
            comboBoxKat.DisplayMember = "NazwaKategori";
            comboBoxKat.ValueMember = "Id";
        }

        private void fillComboNazwa(int idKat)
        {
            comboboxItem.DataSource = _dal.FillComboNazw(idKat);
            comboboxItem.DisplayMember = "NazwaPrzedmiotu";
            comboboxItem.ValueMember = "Id";
        }

        public void refreshClientBindings()
        {
            lbImie.DataBindings.Clear();
            lbNazwisko.DataBindings.Clear();
            textBoxPesel.DataBindings.Clear();
            lbTelefon.DataBindings.Clear();

            lbImie.DataBindings.Add("Text", _klienci, "Imie");
            lbNazwisko.DataBindings.Add("Text", _klienci, "Nazwisko");
            textBoxPesel.DataBindings.Add("Text", _klienci, "Pesel");
            lbTelefon.DataBindings.Add("Text", _klienci, "Telefon");
        }

        public void refreshBindings()
        {
            comboboxItem.DataBindings.Clear();
            labelStawkaDzien.DataBindings.Clear();
            labelStawkaGdzinowa.DataBindings.Clear();

            textBoxIlosc.DataBindings.Clear();
            textBoxKaucja.DataBindings.Clear();
            tbiloscCzas.DataBindings.Clear();

            radioButtonStawkaDobowa.DataBindings.Clear();
            radioButtonStawkaGodzinowa.DataBindings.Clear();

            lbCenaWidok.DataBindings.Clear();
            lbCenaStawka.DataBindings.Clear();
            lbStawkaDbWidok.DataBindings.Clear();
            lbStawkaGdWidok.DataBindings.Clear();

            radioButtonStawkaDobowa.DataBindings.Add("Enabled", _itemModel, "IsNotPrice");
            radioButtonStawkaGodzinowa.DataBindings.Add("Enabled", _itemModel, "IsNotPrice");

            lbCenaWidok.DataBindings.Add("Visible", _itemModel, "IsPrice");
            lbCenaStawka.DataBindings.Add("Visible", _itemModel, "IsPrice");

            lbStawkaDbWidok.DataBindings.Add("Visible", _itemModel, "IsNotPrice");
            labelStawkaDzien.DataBindings.Add("Visible", _itemModel, "IsNotPrice");
            lbStawkaGdWidok.DataBindings.Add("Visible", _itemModel, "IsNotPrice");
            labelStawkaGdzinowa.DataBindings.Add("Visible", _itemModel, "IsNotPrice");

            textBoxKaucja.DataBindings.Add("Text", _itemModel, "Kaucja");
            comboboxItem.DataBindings.Add("SelectedItem", _itemModel, "NazwaPrzedmiotu");
            labelStawkaGdzinowa.DataBindings.Add("Text", _itemModel, "StawkaGodzina");
            labelStawkaDzien.DataBindings.Add("Text", _itemModel, "StawkaDzien");
            lbCenaStawka.DataBindings.Add("Text", _itemModel, "Cena");
            textBoxIlosc.DataBindings.Add("Text", _itemModel, "Ilosc");
            tbiloscCzas.DataBindings.Add("Text", _itemModel, "IloscCzas");
            listBox1.DisplayMember = "DisplayProperty";
        }

        public FmMain()
        {
            InitializeComponent();
            fillComboKat();
            refreshBindings();
        }

        private void comboBoxKat_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedObject = comboBoxKat.SelectedItem as ItemModel;
            fillComboNazwa(selectedObject.Id);
            refreshBindings();
        }

        private void comboboxItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = sender as ComboBox;
            _itemModel = combo.SelectedItem as ItemModel;
            _itemModel.DisplayedNazwa = _itemModel.NazwaPrzedmiotu;
            refreshBindings();
        }

        private void buttonDodaj_Click(object sender, EventArgs e)
        {
            var selectedObject = comboBoxKat.SelectedItem as ItemModel;

            if (_list.Contains(_itemModel))
            {
                MessageBox.Show("Przedmiot już istnieje");
                return;
            }

            SumaService sumaService = new SumaService();
            decimal SumaPrzedmiotu = 0;

            if (_itemModel.IsPrice == true)
            {
                if (selectedObject.Id == 21)
                {
                    lbCenaStawka.Text = new Promocje.Promocje().promNamioty(lbCenaStawka, tbiloscCzas, _itemModel);
                    SumaPrzedmiotu = sumaService.Sumuj(Convert.ToDecimal(lbCenaStawka.Text), Convert.ToDecimal(textBoxIlosc.Text), Convert.ToDecimal(tbiloscCzas.Text));
                    _itemModel.TypStawki = TypStawki.Cena;
                    _itemModel.StawkaUmowa = lbCenaStawka.Text;
                }
                else if (selectedObject.Id == 18)
                {
                    lbCenaStawka.Text = new Promocje.Promocje().promNarty(lbCenaStawka, tbiloscCzas, _itemModel);
                    SumaPrzedmiotu = sumaService.Sumuj(Convert.ToDecimal(lbCenaStawka.Text), Convert.ToDecimal(textBoxIlosc.Text), Convert.ToDecimal(tbiloscCzas.Text));
                    SumaPrzedmiotu = new Promocje.Promocje().promWyjPrzyj(tbiloscCzas, SumaPrzedmiotu, lbCenaStawka);
                    _itemModel.TypStawki = TypStawki.Cena;
                    _itemModel.StawkaUmowa = lbCenaStawka.Text;
                }
                else
                {
                    SumaPrzedmiotu = sumaService.Sumuj(Convert.ToDecimal(lbCenaStawka.Text), Convert.ToDecimal(textBoxIlosc.Text), Convert.ToDecimal(tbiloscCzas.Text));
                    _itemModel.TypStawki = TypStawki.Cena;
                    _itemModel.StawkaUmowa = lbCenaStawka.Text;
                }
                
            }
            else
            {
                if (radioButtonStawkaDobowa.Checked == true)
                {
                    SumaPrzedmiotu = sumaService.Sumuj(Convert.ToDecimal(labelStawkaDzien.Text), Convert.ToDecimal(textBoxIlosc.Text), Convert.ToDecimal(tbiloscCzas.Text));
                    SumaPrzedmiotu = new Promocje.Promocje().promWeekend(labelStawkaDzien, SumaPrzedmiotu, tbiloscCzas);
                    _itemModel.TypStawki = TypStawki.Dobowa;
                    _itemModel.StawkaUmowa = labelStawkaDzien.Text;
                }
                else if (radioButtonStawkaGodzinowa.Checked == true)
                {
                    SumaPrzedmiotu = sumaService.Sumuj(Convert.ToDecimal(labelStawkaGdzinowa.Text), Convert.ToDecimal(textBoxIlosc.Text), Convert.ToDecimal(tbiloscCzas.Text));
                    _itemModel.TypStawki = TypStawki.Godzinowa;
                    _itemModel.StawkaUmowa = labelStawkaGdzinowa.Text;
                }


            }
         
            _itemModel.SumaZaPrzedmiot = SumaPrzedmiotu;

            listBox1.Items.Add(_itemModel);
            _list.Add(_itemModel);

            buttonUsun.Enabled = true;
            txtBoxSuma.Text = Convert.ToString(_list.Sum(x => x.SumaZaPrzedmiot) + "PLN");
        }

        private void buttonUsun_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                var toRemove = listBox1.SelectedItem as ItemModel;
                _list.Remove(toRemove);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                txtBoxSuma.Text = Convert.ToString(_list.Sum(x => x.SumaZaPrzedmiot) + " PLN");
            }
            var selectedObject = comboBoxKat.SelectedItem as ItemModel;
            fillComboNazwa(selectedObject.Id);
            refreshBindings();
        }

        private void buttonGeneruj_Click(object sender, EventArgs e)
        {
            if (_list.Count == 0 || _klientModel == null)
            {
                MessageBox.Show("Musisz najpierw wskazać klienta i dodać przedmioty do listy");
                return;
            }
            BookmarkService bookmark = new BookmarkService();
            var nrFaktury = _dal.FakturaDodaj(_list, _klientModel.Id);
            bookmark.GenerateDoc(_klientModel, _list);

        }

        private void textBoxPesel_Leave(object sender, EventArgs e)
        {
            _klienci = _dal.FillKlientByPesel(textBoxPesel.Text);
            if (_klienci == null)
            {
                MessageBox.Show("Nie znaleziono klienta o podanym peselu");
                return;
            }
            refreshClientBindings();
        }

        private void edycjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmKlient fmKlient = new FmKlient();
            fmKlient.ShowDialog();
        }
    }
}
