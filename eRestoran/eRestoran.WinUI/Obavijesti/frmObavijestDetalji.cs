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
    public partial class frmObavijestDetalji : Form
    {
        private readonly APIService _uposlenici = new APIService("Uposlenik");
        private readonly APIService _obavijest = new APIService("Obavijest");

        private int? _id { get; set; }
        private frmObavijesti _parent = null;
        public frmObavijestDetalji(int? id = null, frmObavijesti parent = null)
        {
            InitializeComponent();
            _id = id;
            _parent = parent;
        }

        private async void FrmObavijestDetalji_Load(object sender, EventArgs e)
        {
            if (!_id.HasValue)
            {
                lblUI.Text = "Nova obavijest";
            }
            await LoadForma();
        }

        private async Task LoadForma()
        {
            UposleniciSearchRequest search = new UposleniciSearchRequest
            {
                VrstaId = 1
            };
            var uposlenici = await _uposlenici.Get<List<Model.Uposlenici>>(search);
            if (_id.HasValue)
            {
                var obavijest = await _obavijest.GetById<Model.Obavijesti>(_id);

                txtNaziv.Text = obavijest.Naziv;
                txtDatum.Text = obavijest.Datum;
                txtSadrzaj.Text = obavijest.Sadrzaj;


                uposlenici.Insert(0, new Model.Uposlenici
                {
                    KorisnikId = obavijest.UposlenikId,
                    Ime = obavijest.Uposlenik
                });

                cmbUposlenik.DataSource = uposlenici;
                cmbUposlenik.DisplayMember = "Ime";
                cmbUposlenik.ValueMember = "KorisnikId";

            }
            else
            {
                uposlenici.Insert(0, new Model.Uposlenici());

                cmbUposlenik.DataSource = uposlenici;
                cmbUposlenik.DisplayMember = "Ime";
                cmbUposlenik.ValueMember = "KorisnikId";
            }
        }





        private async void BunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (Validacija())
            {
                MessageBox.Show("Unesite trazena polja");
            }
            else
            {
                ObavijestiUpsertRequest model = new ObavijestiUpsertRequest();

                model.Datum = txtDatum.Value;
                model.Sadrzaj = txtSadrzaj.Text;
                model.Naziv = txtNaziv.Text;

                var uposlenik = cmbUposlenik.SelectedValue;
                if(int.TryParse(uposlenik.ToString(),out int uid))
                {
                    model.UposlenikId = uid;
                }

                if (_id.HasValue)
                {
                    var nesto = await _obavijest.Update<Model.Obavijesti>(_id, model);
                    if (nesto != default(Model.Obavijesti))
                    {
                        await _parent.GetObavijesti();
                        MessageBox.Show("Uspješno promijenjen zapis!");

                    }
                    Close();
                }
                else if (!_id.HasValue)
                {
                    var nesto = await _obavijest.Insert<Model.Obavijesti>(model);
                    if (nesto != default(Model.Obavijesti))
                    {
                        await _parent.GetObavijesti();
                        MessageBox.Show("Uspješno ste dodali zapis!");
                    }
                    Close();
                }

            }
        }
        private bool Validacija()
        {
            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                errorProvider1.SetError(txtNaziv, "Obavezno polje !");
                errorProvider1.SetError(txtDatum, "");
                errorProvider1.SetError(cmbUposlenik, "");
                errorProvider1.SetError(txtSadrzaj, "");
                return true;
            }
            if (cmbUposlenik.SelectedIndex == 0 && _id == null)
            {
                errorProvider1.SetError(txtNaziv, "");
                errorProvider1.SetError(txtDatum, "");
                errorProvider1.SetError(cmbUposlenik, "Obavezno polje ! ");
                errorProvider1.SetError(txtSadrzaj, "");
                return true;
            }
            if (string.IsNullOrWhiteSpace(txtSadrzaj.Text))
            {
                errorProvider1.SetError(txtNaziv, "");
                errorProvider1.SetError(txtDatum, "");
                errorProvider1.SetError(cmbUposlenik, "");
                errorProvider1.SetError(txtSadrzaj, "Obavezno polje ! ");
                return true;
            }

            if (txtSadrzaj.Text.Length < 10 || txtSadrzaj.Text.Length > 100)
            {
                errorProvider1.SetError(txtNaziv, "");
                errorProvider1.SetError(txtDatum, "");
                errorProvider1.SetError(cmbUposlenik, "");
                errorProvider1.SetError(txtSadrzaj, "Najmanje 10 karaktera ! ");
                return true;
            }

            return false;
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
