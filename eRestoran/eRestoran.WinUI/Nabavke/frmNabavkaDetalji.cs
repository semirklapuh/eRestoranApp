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

namespace eRestoran.WinUI.Nabavke
{
    public partial class frmNabavkaDetalji : Form
    {
        private readonly APIService _detalji = new APIService("NabavkaStavke");
        private readonly APIService _klijent = new APIService("Klijent");
        private readonly APIService _nabavka = new APIService("Nabavka");

        private int _id { get; set; }
        private frmNabavke _parent = null;
        public frmNabavkaDetalji(int id, frmNabavke parent = null)
        {
            InitializeComponent();
            _id = id;
            _parent = parent;
        }

        private async void FrmNabavkaDetalji_Load(object sender, EventArgs e)
        {
            PripremiDgv();
            NabavkaStavkeSearchRequest req = new NabavkaStavkeSearchRequest
            {
                NabavkaId = _id
            };

            var result = await _detalji.Get<List<Model.NabavkaStavke>>(req);
            dgvDetalji.AutoGenerateColumns = false;
            dgvDetalji.DataSource = result;
        }

        private void PripremiDgv()
        {
            dgvDetalji.BackgroundColor = Color.White;
            dgvDetalji.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDetalji.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDetalji.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDetalji.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;



        }

        private async void BtnZavrsi_Click(object sender, EventArgs e)
        {
            NabavkeUpsertRequest req = new NabavkeUpsertRequest
            {
                NabavkaId = _id,
                Zavrsena = true
              
            };
            await _nabavka.Update<NabavkeUpsertRequest>(_id, req);

            MessageBox.Show("Narudzba uspjesno zavrsena", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            NabavkaSearchRequest reload = new NabavkaSearchRequest { Zavrsena = false };
            await _parent.LoadNabavke(reload);
            Close();
        }

        private void DgvDetalji_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
