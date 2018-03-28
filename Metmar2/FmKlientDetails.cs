using Metmar2.Connection;
using Metmar2.Models;
using System;
using System.Windows.Forms;

namespace Metmar2
{
    public partial class FmKlientDetails : Form
    {
        private KlientModel _klientModel = new KlientModel();
        private Klienci _klienci = new Klienci();
        private DAL _dal = new DAL();

        public FmKlientDetails(Klienci klient) : this()
        {
            chbIsActive.Text = "Deactive";
            tbPesel.Enabled = false;
            _klienci = klient;
            Init();
        }

        public FmKlientDetails()
        {
            InitializeComponent();
            InitEmpty();
        }

        private void InitEmpty()
        {
            tbImie.DataBindings.Clear();
            tbNazwisko.DataBindings.Clear();
            tbPesel.DataBindings.Clear();
            tbTelefon.DataBindings.Clear();
            rtbAdres.DataBindings.Clear();
            chbIsActive.DataBindings.Clear();

            tbImie.DataBindings.Add("Text", _klientModel, "Imie");
            tbNazwisko.DataBindings.Add("Text", _klientModel, "Nazwisko");
            tbPesel.DataBindings.Add("Text", _klientModel, "Pesel");
            tbTelefon.DataBindings.Add("Text", _klientModel, "Telefon");
            rtbAdres.DataBindings.Add("Text", _klientModel, "Adres");
        }

        private void Init()
        {
            tbImie.DataBindings.Clear();
            tbNazwisko.DataBindings.Clear();
            tbPesel.DataBindings.Clear();
            tbTelefon.DataBindings.Clear();
            rtbAdres.DataBindings.Clear();
            chbIsActive.DataBindings.Clear();

            tbImie.DataBindings.Add("Text", _klienci, "Imie");
            tbNazwisko.DataBindings.Add("Text", _klienci, "Nazwisko");
            tbPesel.DataBindings.Add("Text", _klienci, "Pesel");
            tbTelefon.DataBindings.Add("Text", _klienci, "Telefon");
            rtbAdres.DataBindings.Add("Text", _klienci, "Adres");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_klienci.Id == 0)
                _dal.DodajKlienta(_klientModel);
            else
                _dal.KlientUpdate(_klienci);
            this.Close();
        }

        private void chbIsActive_CheckedChanged(object sender, EventArgs e)
        {
            if (_klienci.Id == 0)
            {
                _klientModel.IsActive = true;
            }
            else
            _klienci.IsActive = false;
        }
    }
}
