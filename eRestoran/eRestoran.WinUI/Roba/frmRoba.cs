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

namespace eRestoran.WinUI.Roba
{
    public partial class frmRoba : Form
    {

        private readonly APIService _roba = new APIService("Roba");
        private readonly APIService _kategorije = new APIService("Kategorija");


        public frmRoba()
        {
            InitializeComponent();
        }

        private async void FrmRoba_Load(object sender, EventArgs e)
        {
            await GetRoba();
            await LoadKategorije();

        }


        private async Task LoadKategorije()
        {
            var kategorije = await _kategorije.Get<List<Model.Kategorije>>(null);


            kategorije.Insert(0, new Model.Kategorije
            {
                KategorijaId = 0,
                Opis = "Kategorija"
            });
            cmbKategorije.DataSource = kategorije;
            cmbKategorije.DisplayMember = "Opis";
            cmbKategorije.ValueMember = "KategorijaId";


            //RobaSearchRequest model = new RobaSearchRequest
            //{
            //    KategorijaId = id
            //};

            //var result = await _kategorije.Get<List<Model.Roba>>(model);
            //dgvRoba.DataSource = result;


        }

        public async Task GetRoba()
        {
            var result = await _roba.Get<List<Model.Roba>>(null);
            dgvRoba.AutoGenerateColumns = false;
            dgvRoba.DataSource = result;
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void BunifuFlatButton2_Click(object sender, EventArgs e)
        {
            var search = new RobaSearchRequest
            {
                Naziv = txtNazivRobe.Text
            };

            var result = await _roba.Get<List<Model.Roba>>(search);

            dgvRoba.DataSource = result;
        }

        private async void CmbKategorije_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idObj = cmbKategorije.SelectedValue;
            if(int.TryParse(idObj.ToString(),out int id))
            {
                await LoadIzabranuKategoriju(id);
            }

        }

        private async Task LoadIzabranuKategoriju(int id)
        {
            RobaSearchRequest model = new RobaSearchRequest
            {
                KategorijaId = id
            };
            var result = await _roba.Get<List<Model.Roba>>(model);
            dgvRoba.DataSource = result;
            
        }

        private void DgvRoba_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvRoba.Columns[e.ColumnIndex].Name == "Detalji")
            {
                var id = dgvRoba.Rows[e.RowIndex].Cells[0].Value;
                frmRobaDetalji frm = new frmRobaDetalji(int.Parse(id.ToString()), this);
                frm.Show();
            }
            if (dgvRoba.Columns[e.ColumnIndex].Name == "Stanje")
            {
                var id = dgvRoba.Rows[e.RowIndex].Cells[0].Value;
                frmIzmjenaStanja frm = new frmIzmjenaStanja(int.Parse(id.ToString()), this);
                frm.Show();
            }
        }
    }
}
