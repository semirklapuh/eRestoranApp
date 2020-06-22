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
    public partial class frmNabavke : Form
    {

            
        private readonly APIService _nabavke = new APIService("Nabavka");
        private readonly APIService _uposlenik = new APIService("Uposlenik");
        public frmNabavke()
        {
            InitializeComponent();
        }

  

        private async void FrmNabavke_Load(object sender, EventArgs e)
        {
            NabavkaSearchRequest search = new NabavkaSearchRequest
            {
                Zavrsena = false,
                DatumNabavke = DateTime.Now

            };

            List<StatusNabavke> lista = new List<StatusNabavke>();

            lista.Add(new StatusNabavke
            {
                Status = "Na cekanju",
                Value = 0
            });
            lista.Add(new StatusNabavke
            {
                Status = "Zavrsene",
                Value = 1
            });
            cmbStatus.DataSource = lista;
            cmbStatus.DisplayMember = "Status";
            cmbStatus.ValueMember = "Value";
            await LoadNabavke(search);

        }

        public  async Task LoadNabavke(NabavkaSearchRequest search)
        {
            dgvNabavke.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNabavke.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNabavke.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNabavke.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            var result = await _nabavke.Get<List<Model.Nabavke>>(search);

            dgvNabavke.AutoGenerateColumns = false;
            dgvNabavke.DataSource = result;

            
        }







        private void DgvNabavke_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var objId = dgvNabavke.Rows[e.RowIndex].Cells[0].Value;
            if (dgvNabavke.Columns[e.ColumnIndex].Name == "Detalji")
            {
                if (int.TryParse(objId.ToString(), out int id))
                {
                    frmNabavkaDetalji form = new frmNabavkaDetalji(id, this);
                    form.Show();
                }
            }
        }

        private async void CmbStatus_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int? _id = null;
            var idObj = cmbStatus.SelectedValue;
            if (int.TryParse(idObj.ToString(), out int id))
            {
                _id = id;
            }
            NabavkaSearchRequest search = new NabavkaSearchRequest
            {
                Zavrsena = Convert.ToBoolean(_id)
            };
            await LoadNabavke(search);
        }

        private async void BtnNaruci_Click(object sender, EventArgs e)
        {
            UposleniciSearchRequest search = new UposleniciSearchRequest
            {
                VrstaId = 1
            };
            var menadzeri = await _uposlenik.Get<List<Model.Uposlenici>>(search);

            var id = 0;
            foreach (var item in menadzeri)
            {
                id = item.KorisnikId;
            }
            
            NabavkeUpsertRequest model = new NabavkeUpsertRequest
            {
                UposlenikId = id,
                Zavrsena = false
            };
            var nesto = await _nabavke.Insert<Model.Nabavke>(model);

            frmNabavkaNova form = new frmNabavkaNova(nesto.NabavkaId, this);
            form.Show();
        }

        private async void TxtDatum_ValueChanged(object sender, EventArgs e)
        {
            NabavkaSearchRequest search = new NabavkaSearchRequest
            {
                DatumNabavke = txtDatum.Value
            };
            await LoadNabavke(search);
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
