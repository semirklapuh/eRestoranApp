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

namespace eRestoran.WinUI.Narudzbe
{
    public partial class frmNarudzbaDetalji : Form
    {

        private readonly APIService _detalji = new APIService("NarudzbaStavka");
        private readonly APIService _klijent = new APIService("Klijent");
        private readonly APIService _narudzba = new APIService("Narudzba");
        private readonly APIService _korisnik = new APIService("Korisnik");

        private int _id { get; set; }
        private frmNarudzbe _parent = null;
        public frmNarudzbaDetalji(int id, frmNarudzbe parent = null)
        {
            InitializeComponent();
            _id = id;
            _parent = parent;
        }

        private async void FrmNarudzbaDetalji_Load(object sender, EventArgs e)
        {
            PripremiDgv();
            NarudzbaStavkeSearchRequest req = new NarudzbaStavkeSearchRequest
            {
                NarudzbaId = _id
            };
            var result = await _detalji.Get<List<Model.NarudzbaStavke>>(req);
            dgvDetalji.AutoGenerateColumns = false;
            dgvDetalji.DataSource = result;

            var narudzba = await _narudzba.GetById<Model.Narudzbe>(_id);


            var klijent = await _klijent.GetById<Model.Klijenti>(narudzba.KlijentId);
            txtIme.Text = $"{klijent.Ime} {klijent.Prezime}";
            txtAdresa.Text = klijent.Adresa;
            txtBrojTelefona.Text = klijent.Telefon;
            txtDatum.Text = narudzba.DatumNarudžbe.ToString("hh:mm");
            double ukupno = 0;
            foreach (var x in result)
            {
                ukupno += x.Cijena * x.Kolicina;
            }
            txtUkupno.Text = ukupno.ToString();

        }

        private void PripremiDgv()
        {
            dgvDetalji.BackgroundColor = Color.White;
            dgvDetalji.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDetalji.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDetalji.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i <= dgvDetalji.Columns.Count - 1; i++)
            {
                int colw = dgvDetalji.Columns[i].Width;
                dgvDetalji.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvDetalji.Columns[i].Width = colw;
            }
        }

        private async void BtnZavrsi_Click(object sender, EventArgs e)
        {
            NarudzbaUpsertRequest req = new NarudzbaUpsertRequest
            {
                NarudzbaId = _id,
                Zavrsena = true
            };
            await _narudzba.Update<NarudzbaUpsertRequest>(_id, req);
            //var narudzba = await _narudzba.GetById<Model.Narudzbe>(_id);
            //var klijent = await _klijent.GetById<Model.Klijenti>(narudzba.KlijentId);
            MessageBox.Show("Narudzba uspjesno zavrsena", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            NarudzbeSearchRequest reload = new NarudzbeSearchRequest { Zavrsena = false };
            await _parent.LoadNarudzbe(reload);
            Close();

        }

        private void dgvDetalji_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
