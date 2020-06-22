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

namespace eRestoran.WinUI.Obavijesti
{
    public partial class frmObavijesti : Form
    {
        private readonly APIService _obavijesti = new APIService("Obavijest");
        public frmObavijesti()
        {
            InitializeComponent();
        }

        private async void FrmObavijesti_Load(object sender, EventArgs e)
        {
            await GetObavijesti();
          

        }

     

        public async Task GetObavijesti()
        {
            var result = await _obavijesti.Get<List<Model.Obavijesti>>(null);

            dgvObavijesti.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvObavijesti.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvObavijesti.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvObavijesti.AutoGenerateColumns = false;
            dgvObavijesti.DataSource = result;

        }

        private async void BtnPretrazi_Click(object sender, EventArgs e)
        {
            var search = new ObavijestiSearchRequest
            {
                Naziv = txtNaziv.Text
            };

            var result = await _obavijesti.Get<List<Model.Obavijesti>>(search);

            dgvObavijesti.DataSource = result;
        }

        private void DgvObavijesti_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var objId = dgvObavijesti.Rows[e.RowIndex].Cells[0].Value;
            if (int.TryParse(objId.ToString(), out int id))
            {
                frmObavijestDetalji form = new frmObavijestDetalji(id, this);
                form.Show();
            }

        }

        private void BunifuFlatButton1_Click(object sender, EventArgs e)
        {
            frmObavijestDetalji form = new frmObavijestDetalji(null,this);
            form.Show();

        }
    }
}
