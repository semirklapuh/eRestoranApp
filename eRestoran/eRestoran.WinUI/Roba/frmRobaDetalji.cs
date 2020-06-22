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
    public partial class frmRobaDetalji : Form
    {
        private int? _id = null;
        private frmRoba _parent = null;
        private readonly APIService _roba = new APIService("Roba");
        private readonly APIService _kategorije = new APIService("Kategorija");
        private readonly APIService _jedinicaMjere = new APIService("JedinicaMjere");
       

        public frmRobaDetalji(int? id=null,frmRoba frm = null )
        {
            InitializeComponent();
            _id = id;
            _parent = frm;
        }

        private async void FrmRobaDetalji_Load(object sender, EventArgs e)
        {
            if (!_id.HasValue)
            {
                lblUI.Text = "Novi proizvod";
            }
            await LoadForma();
        }

        private async Task LoadForma()
        {
            var kategorije = await _kategorije.Get<List<Model.Kategorije>>(null);
            var jedinicaMjere = await _jedinicaMjere.Get<List<Model.JedinicaMjere>>(null);
            if (_id.HasValue)
            {

                var proizvod = await _roba.GetById<Model.Roba>(_id);

                txtNaziv.Text = proizvod.Naziv;
                txtCijena.Text = proizvod.Cijena.ToString("0.0");
                txtStanje.Text = proizvod.Stanje.ToString();
                txtSifra.Text = proizvod.Sifra;

                kategorije.Insert(0, new Model.Kategorije
                {
                    KategorijaId = proizvod.KategorijaId,
                    Opis = proizvod.Kategorija
                });


                cmbKategorija.DataSource = kategorije;
                cmbKategorija.DisplayMember = "Opis";
                cmbKategorija.ValueMember = "KategorijaId";


                jedinicaMjere.Insert(0, new Model.JedinicaMjere
                {
                    JedinicaMjereId = proizvod.JedinicaMjereId,
                    Naziv = proizvod.JedinicaMjere
                });

                cmbJedinicaMjere.DataSource = jedinicaMjere;
                cmbJedinicaMjere.DisplayMember = "Naziv";
                cmbJedinicaMjere.ValueMember = "JedinicaMjereId";

            }
            else
            {
                kategorije.Insert(0, new Model.Kategorije());

                cmbKategorija.DataSource = kategorije;
                cmbKategorija.DisplayMember = "Opis";
                cmbKategorija.ValueMember = "KategorijaId";

                jedinicaMjere.Insert(0, new Model.JedinicaMjere());

                cmbJedinicaMjere.DataSource = jedinicaMjere;
                cmbJedinicaMjere.DisplayMember = "Naziv";
                cmbJedinicaMjere.ValueMember = "JedinicaMjereId";
            }

        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {

            if(await Validacija())
            {
                MessageBox.Show("Unesite trazena polja");
            }
            else
            {
                RobaUpsertRequest model = new RobaUpsertRequest();

                model.Naziv = txtNaziv.Text;
                model.Sifra = txtSifra.Text;
                model.Cijena = double.Parse(txtCijena.Text);
                model.Stanje = int.Parse(txtStanje.Text);

                var kategorijaId = cmbKategorija.SelectedValue;
                if(int.TryParse(kategorijaId.ToString(),out int kid))
                {
                    model.KategorijaId = kid;
                }

                var jedinicaMjereId = cmbJedinicaMjere.SelectedValue;
                if(int.TryParse(jedinicaMjereId.ToString(),out int jmid))
                {
                    model.JedinicaMjereId = jmid;
                }

                if (_id.HasValue)
                {
                    var nesto = await _roba.Update<Model.Roba>(_id, model);
                    if(nesto != default(Model.Roba))
                    {
                        await _parent.GetRoba();
                        MessageBox.Show("Uspješno promijenjen zapis!");

                    }
                    Close();
                }
                else if (!_id.HasValue)
                {
                    var nesto = await _roba.Insert<Model.Roba>(model);
                    if (nesto != default(Model.Roba))
                    {
                        await _parent.GetRoba();
                        
                        MessageBox.Show("Uspješno ste dodali zapis!");
                    }
                    Close();
                    
                }
               
                  
            }


        }

        private async Task<bool> Validacija()
        {
            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                errorProvider1.SetError(txtNaziv, "Obavezno polje !");
                errorProvider1.SetError(txtCijena, "");
                errorProvider1.SetError(txtStanje, "");
                errorProvider1.SetError(txtSifra, "");
                errorProvider1.SetError(cmbJedinicaMjere, "");
                errorProvider1.SetError(cmbKategorija, "");

                return true;
            }
            if (txtNaziv.Text.Length < 4 || txtNaziv.Text.Length > 15)
            {
                var lista = await _roba.Get<List<Model.Roba>>(null);
                foreach (var item in lista)
                {
                    if (_id == null)
                        if (txtNaziv.Text == item.Naziv)
                        {
                            errorProvider1.SetError(txtNaziv, "Proizvod ime zauzeto, odaberite drugo !");
                            errorProvider1.SetError(txtStanje, "");
                            errorProvider1.SetError(txtSifra, "");
                            errorProvider1.SetError(txtCijena, "");
                            errorProvider1.SetError(cmbJedinicaMjere, "");
                            errorProvider1.SetError(cmbKategorija, "");
                            return true;
                        }
                }

            }
            if (txtNaziv.Text.Length < 4 || txtNaziv.Text.Length > 15)
            {
                errorProvider1.SetError(txtNaziv, "Naziv mora sadrzavati bar 2 karaktera, ne više od 10 !");
                errorProvider1.SetError(txtStanje, "");
                errorProvider1.SetError(txtSifra, "");
                errorProvider1.SetError(txtCijena, "");
                errorProvider1.SetError(cmbJedinicaMjere, "");
                errorProvider1.SetError(cmbKategorija, "");

                return true;
            }
            if (string.IsNullOrWhiteSpace(txtStanje.Text))
            {
                errorProvider1.SetError(txtSifra, "");
                errorProvider1.SetError(txtNaziv, "");
                errorProvider1.SetError(txtCijena, "");
                errorProvider1.SetError(cmbJedinicaMjere, "");
                errorProvider1.SetError(cmbKategorija, "");
                errorProvider1.SetError(txtStanje, "Obavezno polje !");


                return true;
            }
            if (string.IsNullOrWhiteSpace(txtSifra.Text))
            {
                errorProvider1.SetError(txtNaziv, "");
                errorProvider1.SetError(txtStanje, "");
                errorProvider1.SetError(txtSifra, "Obavezno polje !");
                errorProvider1.SetError(txtCijena, "");
                errorProvider1.SetError(cmbJedinicaMjere, "");
                errorProvider1.SetError(cmbKategorija, "");

                return true;
            }
            if (!string.IsNullOrWhiteSpace(txtSifra.Text))
            {
                var lista = await _roba.Get<List<Model.Roba>>(null);
                foreach (var item in lista)
                {
                    if (_id == null)
                        if (txtSifra.Text == item.Sifra)
                        {
                            errorProvider1.SetError(txtNaziv, "");
                            errorProvider1.SetError(txtStanje, "");
                            errorProvider1.SetError(txtSifra, "Ova šifra već postoji");
                            errorProvider1.SetError(txtCijena, "");

                            errorProvider1.SetError(cmbJedinicaMjere, "");
                            errorProvider1.SetError(cmbKategorija, "");
                            return true;
                        }
                }

            }
          
            if (string.IsNullOrWhiteSpace(txtCijena.Text))
            {
                errorProvider1.SetError(txtNaziv, "");
                errorProvider1.SetError(txtStanje, "");
                errorProvider1.SetError(txtSifra, "");
                errorProvider1.SetError(txtCijena, "Obavezno polje !");
                errorProvider1.SetError(cmbJedinicaMjere, "");
                errorProvider1.SetError(cmbKategorija, "");

                return true;
            }
            if (double.Parse(txtCijena.Text) < 1 || double.Parse(txtCijena.Text) > 200)
            {
                errorProvider1.SetError(txtNaziv, "");
                errorProvider1.SetError(txtStanje, "");
                errorProvider1.SetError(txtSifra, "");
                errorProvider1.SetError(txtCijena, "Cijena ne smija biti manja od 1 i veća od 200 !");

                errorProvider1.SetError(cmbJedinicaMjere, "");
                errorProvider1.SetError(cmbKategorija, "");

                return true;
            }
            if (cmbKategorija.SelectedIndex == 0 && _id == null)
            {
                errorProvider1.SetError(txtNaziv, "");
                errorProvider1.SetError(txtStanje, "");
                errorProvider1.SetError(txtSifra, "");
                errorProvider1.SetError(txtCijena, "");
                errorProvider1.SetError(cmbJedinicaMjere, "");
                errorProvider1.SetError(cmbKategorija, "Obavezno polje !");
                return true;
            }
            if (cmbJedinicaMjere.SelectedIndex == 0 && _id == null)
            {
                errorProvider1.SetError(txtNaziv, "");
                errorProvider1.SetError(txtStanje, "");
                errorProvider1.SetError(txtSifra, "");
                errorProvider1.SetError(txtCijena, "");

                errorProvider1.SetError(cmbJedinicaMjere, "Obavezno polje !");
                errorProvider1.SetError(cmbKategorija, "");
                return true;
            }
           
            return false;

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
