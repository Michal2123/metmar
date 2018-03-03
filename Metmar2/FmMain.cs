using Metmar2.BookmarkReplace;
using Metmar2.Connection;
using Metmar2.Models;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Metmar2
{
    public partial class FmMain : Form
    {
        private BindingList<ItemModel> _list = new BindingList<ItemModel>();
        private BindingList<KlientModel> _klientList = new BindingList<KlientModel>();
        private ItemModel _itemModel = new ItemModel();
        private KlientModel _klientModel = new KlientModel();
        private DAL _dataConnection = new DAL();

        private void fillComboKat()
        {
            comboBoxKat.DataSource = _dataConnection.FillComboKat();
            comboBoxKat.DisplayMember = "NazwaKategori";
            comboBoxKat.ValueMember = "Id";
        }

        private void fillComboNazwa(int idKat)
        {
            comboboxItem.DataSource = _dataConnection.FillComboNazw(idKat);
            comboboxItem.DisplayMember = "NazwaPrzedmiotu";
            comboboxItem.ValueMember = "Id";
        }

        public void refreshClientBindings()
        {
            lbImie.DataBindings.Clear();
            lbNazwisko.DataBindings.Clear();
            textBoxPesel.DataBindings.Clear();
            lbTelefon.DataBindings.Clear();

            lbImie.DataBindings.Add("Text", _klientModel, "Imie");
            lbNazwisko.DataBindings.Add("Text", _klientModel, "Nazwisko");
            textBoxPesel.DataBindings.Add("Text", _klientModel, "Pesel");
            lbTelefon.DataBindings.Add("Text", _klientModel, "Telefon");
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

            textBoxKaucja.DataBindings.Add("Text", _itemModel, "Kaucja", false, DataSourceUpdateMode.OnPropertyChanged);
            comboboxItem.DataBindings.Add("SelectedItem", _itemModel, "NazwaPrzedmiotu", false, DataSourceUpdateMode.OnPropertyChanged);
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
            SumaService sumaService = new SumaService();
            decimal SumaPrzedmiotu = 0;
            var selectedKat = comboBoxKat.SelectedItem as ItemModel;

            if (_itemModel.IsPrice == true)
            {
                SumaPrzedmiotu = sumaService.Sumuj(Convert.ToDecimal(lbCenaStawka.Text), Convert.ToDecimal(textBoxIlosc.Text), Convert.ToDecimal(tbiloscCzas.Text));
                _itemModel.TypStawki = TypStawki.Cena;

                //TODO IF namioty
                Console.WriteLine("TEST");
            }

            else
            {
                if (radioButtonStawkaDobowa.Checked == true)
                {
                    SumaPrzedmiotu = sumaService.Sumuj(Convert.ToDecimal(labelStawkaDzien.Text), Convert.ToDecimal(textBoxIlosc.Text), Convert.ToDecimal(tbiloscCzas.Text));
                    _itemModel.TypStawki = TypStawki.Dobowa;
                }
                else if (radioButtonStawkaGodzinowa.Checked == true)
                {
                    SumaPrzedmiotu = sumaService.Sumuj(Convert.ToDecimal(labelStawkaGdzinowa.Text), Convert.ToDecimal(textBoxIlosc.Text), Convert.ToDecimal(tbiloscCzas.Text));
                    _itemModel.TypStawki = TypStawki.Godzinowa;
                }
                else
                {
                    SumaPrzedmiotu = sumaService.Sumuj(Convert.ToDecimal(lbCenaStawka.Text), Convert.ToDecimal(textBoxIlosc.Text), Convert.ToDecimal(tbiloscCzas.Text));
                    _itemModel.TypStawki = TypStawki.Cena;
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
        }

        private void buttonGeneruj_Click(object sender, EventArgs e)
        {
            if(_list.Count ==0 || _klientModel == null)
            {
                MessageBox.Show("Musisz najpierw wskazać klienta i dodać przedmioty do listy");
                return;
            }
            BookmarkService bookmark = new BookmarkService();
            var nrFaktury = _dataConnection.FakturaDodaj(_list, _klientModel.Id);                      
            bookmark.GenerateDoc(_klientModel, _list, nrFaktury);
            
        }

        private void textBoxPesel_Leave(object sender, EventArgs e)
        {
            _klientModel = _dataConnection.FillKlientByPesel(textBoxPesel.Text);
            if (_klientModel == null)
            {
                MessageBox.Show("Nie znaleziono klienta o podanym peselu");
                return;
            }
            refreshClientBindings();

        }

        private void oProgramieToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void edycjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmKlient fmKlient = new FmKlient();
            fmKlient.ShowDialog();
        }
    }
}
