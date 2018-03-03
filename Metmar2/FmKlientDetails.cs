﻿using Metmar2.Connection;
using Metmar2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Metmar2
{
    public partial class FmKlientDetails : Form
    {
        private KlientModel _klient = new KlientModel();
        private DAL _dal = new DAL();

        public FmKlientDetails(KlientModel klient) : this()
        {
            _klient = klient;
            Init();
        }

        public FmKlientDetails()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            tbImie.DataBindings.Clear();
            tbNazwisko.DataBindings.Clear();
            tbPesel.DataBindings.Clear();
            tbTelefon.DataBindings.Clear();
            rtbAdres.DataBindings.Clear();

            tbImie.DataBindings.Add("Text", _klient, "Imie");
            tbNazwisko.DataBindings.Add("Text", _klient, "Nazwisko");
            tbPesel.DataBindings.Add("Text", _klient, "Pesel");
            tbTelefon.DataBindings.Add("Text", _klient, "Pesel");
            rtbAdres.DataBindings.Add("Text", _klient, "Adres");

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_klient.Id == 0)
                _dal.DaneKlientaDodaj(_klient);
            else
                _dal.DaneKlientaUpdate(_klient);
        }
    }
}