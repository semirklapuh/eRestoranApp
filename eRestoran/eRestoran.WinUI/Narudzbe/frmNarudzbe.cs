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
    public partial class frmNarudzbe : Form
    {
        private readonly APIService _narudzbe = new APIService("Narudzba");
        private readonly APIService _klijent = new APIService("Klijent");
        public frmNarudzbe()
        {
            InitializeComponent();
        }

        private async void FrmNarudzbe_Load(object sender, EventArgs e)
        {
            NarudzbeSearchRequest search = new NarudzbeSearchRequest
            {
                Zavrsena = false,
                DatumNarudzbe = DateTime.Now
            };

            List<StatusNarudzbe> lista = new List<StatusNarudzbe>();


            lista.Add(new StatusNarudzbe
            {
                Status = "Na cekanju",
                Value = 0
            });
            lista.Add(new StatusNarudzbe
            {
                Status = "Zavrsene",
                Value = 1
            });
            cmbStatus.DataSource = lista;
            cmbStatus.DisplayMember = "Status";
            cmbStatus.ValueMember = "Value";
            await LoadNarudzbe(search);



        }

        public async Task LoadNarudzbe(NarudzbeSearchRequest search)
        {
            dgvNarudzbe.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNarudzbe.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNarudzbe.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //for (int i = 0; i <= dgvNarudzbe.Columns.Count - 1; i++)
            //{
            //    int colw = dgvNarudzbe.Columns[i].Width;
            //    dgvNarudzbe.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            //    dgvNarudzbe.Columns[i].Width = colw;
            //}


            var result = await _narudzbe.Get<List<Model.Narudzbe>>(search);

            List<NarudzbeKlijenti> lista = new List<NarudzbeKlijenti>();
            foreach (var x in result)
            {
                var klijent = await _klijent.GetById<Model.Klijenti>(x.KlijentId);
                lista.Add(new NarudzbeKlijenti
                {

                    NarudzbaId = x.NarudzbaId,
                    DatumNarudžbe = x.DatumNarudžbe.ToString("dd.MM.yyyy - hh:mm"),
                    Zavrsena = x.Zavrsena,
                    Klijent = $"{klijent.Ime} {klijent.Prezime}"
                });
            }
            dgvNarudzbe.AutoGenerateColumns = false;
            dgvNarudzbe.DataSource = lista;

        }

        private async void CmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            int? _id = null;
            var idObj = cmbStatus.SelectedValue;
            if (int.TryParse(idObj.ToString(), out int id))
            {
                _id = id;
            }
            NarudzbeSearchRequest search = new NarudzbeSearchRequest
            {
                Zavrsena = Convert.ToBoolean(_id)
            };
            await LoadNarudzbe(search);
        }

        private void DgvNarudzbe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void DgvNarudzbe_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            var objId = dgvNarudzbe.Rows[e.RowIndex].Cells[0].Value;
            if (dgvNarudzbe.Columns[e.ColumnIndex].Name == "Detalji")
            {
                if (int.TryParse(objId.ToString(), out int id))
                {
                    frmNarudzbaDetalji form = new frmNarudzbaDetalji(id, this);
                    form.Show();
                }
            }
        }

        private async void TxtDatum_ValueChanged(object sender, EventArgs e)
        {
            NarudzbeSearchRequest search = new NarudzbeSearchRequest
            {
                DatumNarudzbe = txtDatum.Value
            };
            await LoadNarudzbe(search);
        }
    }
}
