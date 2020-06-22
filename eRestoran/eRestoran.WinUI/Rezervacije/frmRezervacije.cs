using eRestoran.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eRestoran.WinUI.Rezervacije
{
    public partial class frmRezervacije : Form
    {
        private readonly APIService _rezervacija = new APIService("Rezervacija");
        private readonly APIService _korisnik = new APIService("Korisnik");
        public frmRezervacije()
        {
            InitializeComponent();
        }

        private async void FrmRezervacije_Load(object sender, EventArgs e)
        {
            await GetRezervacije();
        }

        public async Task GetRezervacije(RezervacijaSearchRequest search = null)
        {
            
            var result = await _rezervacija.Get<List<Model.Rezervacije>>(search);

            dgvRezervacije.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvRezervacije.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvRezervacije.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvRezervacije.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvRezervacije.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvRezervacije.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvRezervacije.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;




            dgvRezervacije.AutoGenerateColumns = false;
            dgvRezervacije.DataSource = result;
            
        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            var search = new RezervacijaSearchRequest {
                Ime = txtIme.Text,
                Prezime = txtPrezime.Text,
                DatumRezervacije = txtDatum.Value
               
            };

            var rezervacije = await _rezervacija.Get<List<Model.Rezervacije>>(search);

            dgvRezervacije.DataSource = rezervacije;
        }

        private void DgvRezervacije_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                var id = dgvRezervacije.Rows[e.RowIndex].Cells[0].Value;
                frmRezervacijaStavke frm = new frmRezervacijaStavke(int.Parse(id.ToString()), this);
                frm.Show();
            
        }

        private void BtnNovaRezervacija_Click(object sender, EventArgs e)
        {
            frmRezervacijaStavke form = new frmRezervacijaStavke(null, this);
            form.Show();
        }

     
    }
}
