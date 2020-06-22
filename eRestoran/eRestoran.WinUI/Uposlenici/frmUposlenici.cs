using eRestoran.Model.Requests;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eRestoran.WinUI.Uposlenici
{
    public partial class frmUposlenici : Form
    {
        private readonly APIService _uposlenici = new APIService("Uposlenik");
        private readonly APIService _vrsta = new APIService("VrstaUposlenika");
        public frmUposlenici()
        {
            InitializeComponent();
        }
      
        public async Task GetUposlenici()
        {
            var result = await _uposlenici.Get<List<Model.Uposlenici>>(null);
            dgvUposlenici.AutoGenerateColumns = false;
            dgvUposlenici.DataSource = result;
        }
        private async Task LoadVrste()
        {
            var vrste = await _vrsta.Get<List<Model.VrstaUposlenika>>(null);

            vrste.Insert(0, new Model.VrstaUposlenika
            {
                VrstaUposlenikaId = 0,
                Naziv = "Vrsta uposlenika"
            });
            cmbVrsta.DataSource = vrste;
            cmbVrsta.DisplayMember = "Naziv";
            cmbVrsta.ValueMember = "VrstaUposlenikaId";
        }
        private async void BtnPretraga_Click(object sender, EventArgs e)
        {

            var search = new UposleniciSearchRequest
            {
                Ime = txtPret.Text
            };
            var result = await _uposlenici.Get<List<Model.Uposlenici>>(search);
            dgvUposlenici.AutoGenerateColumns = false;
            dgvUposlenici.DataSource = result;
        }

      

        private async void CmbVrsta_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idObj = cmbVrsta.SelectedValue;
            if(int.TryParse(idObj.ToString(),out int id))
            {
                await LoadVrstaUposlenici(id);
            }

        }

        private async Task LoadVrstaUposlenici(int id)
        {
            UposleniciSearchRequest model = new UposleniciSearchRequest
            {
                VrstaId = id
            };
            var result = await _uposlenici.Get<List<Model.Uposlenici>>(model);
            dgvUposlenici.DataSource = result;
        }

        private async void FrmUposlenici_Load(object sender, EventArgs e)
        {
            await GetUposlenici();
            await LoadVrste();
        }

        private void DgvUposlenici_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvUposlenici.Columns[e.ColumnIndex].Name == "Detalji")
            {
                var id = dgvUposlenici.Rows[e.RowIndex].Cells[0].Value;
                frmUposleniciDetalji forma = new frmUposleniciDetalji(int.Parse(id.ToString()), this);
                forma.Show();
            }
        }

        private void TxtPret_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnPretraga_Click_1(object sender, EventArgs e)
        {

        }
    }
}
