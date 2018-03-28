using Metmar2.Connection;
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
    public partial class FmKlient : Form
    {
        private DAL _dal = new DAL();
        public FmKlient()
        {
            InitializeComponent();
            dgvKlienci.AutoGenerateColumns = false;
            dgvKlienci.DataSource = _dal.GetList();
        }

        private void dgvKlienci_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var selected = ((DataGridView)sender).SelectedRows[0].DataBoundItem as Klienci;
            FmKlientDetails fmKlientDetails = new FmKlientDetails(selected);
            fmKlientDetails.ShowDialog();
            dgvKlienci.DataSource = _dal.GetList();
        }

        private void dodajKlientaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmKlientDetails fmKlientDetails = new FmKlientDetails();
            fmKlientDetails.ShowDialog();
            dgvKlienci.DataSource = _dal.GetList();
        }
    }
}
