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

namespace eRestoran.WinUI.Uposlenici
{
    public partial class frmUposleniciDetalji : Form
    {
        private int? _id = null;
        private frmUposlenici _parent = null;
        private readonly APIService _uposlenik = new APIService("Uposlenik");
        private readonly APIService _gradovi = new APIService("Grad");
        private readonly APIService _vrsta = new APIService("VrstaUposlenika");


        public frmUposleniciDetalji(int? id=null, frmUposlenici frm=null)
        {
            InitializeComponent();
            _id = id;
            _parent = frm;
        }

        private async void FrmUposleniciDetalji_Load(object sender, EventArgs e)
        {
            if (!_id.HasValue)
            {
                lblU.Text = "Novi uposlenik";
            }
            await LoadForma();
        }

        private async Task LoadForma()
        {

            var gradovi = await _gradovi.Get<List<Model.Grad>>(null);
            var vrsta = await _vrsta.Get<List<Model.VrstaUposlenika>>(null);

            if (_id.HasValue)
            {
                var uposlenik = await _uposlenik.GetById<Model.Uposlenici>(_id);

                txtIme.Text = uposlenik.Ime;
                txtPrezime.Text = uposlenik.Prezime;
                txtAdresa.Text = uposlenik.Adresa;
                txtKorIme.Text = uposlenik.KorisnickoIme;
                txtLozinka.Text = uposlenik.LozinkaHash;
                txtLozinka.PasswordChar = '*';
                txtPotvrda.PasswordChar = '*';

                txtKorIme.ReadOnly = true;
                txtJMBG.Text = uposlenik.JMBG;
                txtTelefon.Text = uposlenik.Telefon;
                if (uposlenik.Status == true)
                {
                    Status.Checked = true;
                }
                else
                {
                    Status.Checked = false;
                }
                string format = "yyyy/MM/dd HH:mm:ss";
                txtDatumRodj.MinDate = new DateTime(1753, 6, 20);
                txtDatumRodj.MaxDate = new DateTime(2020, 1, 1);
                txtDatumRodj.Text = uposlenik.DatumRodjenja.ToString(format);

                txtDatZap.MinDate = new DateTime(1753, 6, 20);
                txtDatZap.MaxDate = new DateTime(2020, 1, 1);
                txtDatZap.Text = uposlenik.DatumZaposljavanja.ToString();

                gradovi.Insert(0, new Model.Grad
                {
                    GradId = uposlenik.GradId,
                    Naziv = uposlenik.Grad

                });
                cmbGrad.DataSource = gradovi;
                cmbGrad.DisplayMember = "Naziv";
                cmbGrad.ValueMember = "GradId";

                
                vrsta.Insert(0, new Model.VrstaUposlenika
                {
                    VrstaUposlenikaId = uposlenik.VrstaUposlenikaId,
                    Naziv = uposlenik.VrstaUposlenika

                });
                cmbVrstaUposlenika.DataSource = vrsta;
                cmbVrstaUposlenika.DisplayMember = "Naziv";
                cmbVrstaUposlenika.ValueMember = "VrstaUposlenikaId";
            }
            else
            {
                gradovi.Insert(0, new Model.Grad());
                cmbGrad.DataSource = gradovi;
                cmbGrad.DisplayMember = "Naziv";
                cmbGrad.ValueMember = "GradId";



                vrsta.Insert(0, new Model.VrstaUposlenika());
                cmbVrstaUposlenika.DataSource = vrsta;
                cmbVrstaUposlenika.DisplayMember = "Naziv";
                cmbVrstaUposlenika.ValueMember = "VrstaUposlenikaId";
            }
        }

        private async Task Button1_ClickAsync(object sender, EventArgs e)
        {
            if(await Validacija())
            {
                MessageBox.Show("Unesite trazena polja");
            }
            else
            {
                UposleniciUpsertRequest model = new UposleniciUpsertRequest();

                model.Ime = txtIme.Text;
                model.Prezime = txtPrezime.Text;
                model.JMBG = txtJMBG.Text;
                model.Adresa = txtAdresa.Text;
                model.Lozinka = txtLozinka.Text;
                model.DatumRodjenja = txtDatumRodj.Value;
                model.DatumZaposljavanja = txtDatZap.Value;
                model.Telefon = txtTelefon.Text;

                if (Status.Checked == true)
                {
                    model.Status = true;
                }
                else
                {
                    model.Status = false;
                }

                var gradID = cmbGrad.SelectedValue;
                if (int.TryParse(gradID.ToString(), out int gid))
                {
                    model.GradId = gid;
                }

                var vrsID = cmbVrstaUposlenika.SelectedValue;
                if (int.TryParse(vrsID.ToString(), out int vid))
                {
                    model.VrstaUposlenikaId = vid;
                }

                if (_id.HasValue && txtLozinka.Text == txtPotvrda.Text)
                {

                    var nesto = await _uposlenik.Update<Model.Uposlenici>(_id, model);
                    if (nesto != default(Model.Uposlenici))
                    {
                        await _parent.GetUposlenici();
                        MessageBox.Show("Uspješno promijenjen zapis!");
                    }

                    Close();
                }
                else if (txtLozinka.Text == txtPotvrda.Text)
                {


                    var nesto = await _uposlenik.Insert<Model.Uposlenici>(model);
                    if (nesto != default(Model.Uposlenici))
                    {
                        await _parent.GetUposlenici();
                        MessageBox.Show("Uspješno ste dodali zapis!");
                    }
                    Close();

                }
                else
                {
                    MessageBox.Show("Lozinke se ne slažu!");
                }
            

        }
        }

        private async Task<bool> Validacija()
        {
            if (string.IsNullOrWhiteSpace(txtIme.Text))
            {
                errorProvider1.SetError(txtIme, "Obavezno polje !");
                errorProvider1.SetError(txtPrezime, "");
                errorProvider1.SetError(txtAdresa, "");
                errorProvider1.SetError(txtKorIme, "");
                errorProvider1.SetError(txtLozinka, "");
                errorProvider1.SetError(txtPotvrda, "");
                errorProvider1.SetError(txtTelefon, "");
                errorProvider1.SetError(txtJMBG, "");
                errorProvider1.SetError(cmbGrad, "");
                errorProvider1.SetError(cmbVrstaUposlenika, "");
                return true;
            }
            if (txtIme.Text.Length < 4 || txtIme.Text.Length > 15)
            {
                errorProvider1.SetError(txtIme, "Ime mora sadržavati barem 4 karaktera, ne više od 15 !");
                errorProvider1.SetError(txtPrezime, "");
                errorProvider1.SetError(txtAdresa, "");
                errorProvider1.SetError(txtKorIme, "");
                errorProvider1.SetError(txtLozinka, "");
                errorProvider1.SetError(txtPotvrda, "");
                errorProvider1.SetError(txtTelefon, "");
                errorProvider1.SetError(txtJMBG, "");
                errorProvider1.SetError(cmbGrad, "");
                errorProvider1.SetError(cmbVrstaUposlenika, "");
                return true;
            }
            if (string.IsNullOrWhiteSpace(txtPrezime.Text))
            {
                errorProvider1.SetError(txtIme, "");
                errorProvider1.SetError(txtPrezime, "Obavezno polje !");
                errorProvider1.SetError(txtAdresa, "");
                errorProvider1.SetError(txtKorIme, "");
                errorProvider1.SetError(txtLozinka, "");
                errorProvider1.SetError(txtPotvrda, "");
                errorProvider1.SetError(txtTelefon, "");
                errorProvider1.SetError(txtJMBG, "");
                errorProvider1.SetError(cmbGrad, "");
                errorProvider1.SetError(cmbVrstaUposlenika, "");

                return true;
            }
            if (txtPrezime.Text.Length < 4 || txtPrezime.Text.Length > 15)
            {
                errorProvider1.SetError(txtIme, "");
                errorProvider1.SetError(txtPrezime, "Prezime mora sadržavati barem 4 karaktera, ne više od 15 !");
                errorProvider1.SetError(txtAdresa, "");
                errorProvider1.SetError(txtKorIme, "");
                errorProvider1.SetError(txtLozinka, "");
                errorProvider1.SetError(txtPotvrda, "");
                errorProvider1.SetError(txtTelefon, "");
                errorProvider1.SetError(txtJMBG, "");
                errorProvider1.SetError(cmbGrad, "");
                errorProvider1.SetError(cmbVrstaUposlenika, "");
                return true;

            }

            if (string.IsNullOrWhiteSpace(txtAdresa.Text))
            {
                errorProvider1.SetError(txtIme, "");
                errorProvider1.SetError(txtPrezime, "");
                errorProvider1.SetError(txtAdresa, "Obavezno polje !");
                errorProvider1.SetError(txtKorIme, "");
                errorProvider1.SetError(txtLozinka, "");
                errorProvider1.SetError(txtPotvrda, "");
                errorProvider1.SetError(txtTelefon, "");
                errorProvider1.SetError(txtJMBG, "");
                errorProvider1.SetError(cmbGrad, "");
                errorProvider1.SetError(cmbVrstaUposlenika, "");
                return true;
            }
            if (string.IsNullOrWhiteSpace(txtKorIme.Text))
            {
                errorProvider1.SetError(txtIme, "");
                errorProvider1.SetError(txtPrezime, "");
                errorProvider1.SetError(txtAdresa, "");
                errorProvider1.SetError(txtKorIme, "Obavezno polje !");
                errorProvider1.SetError(txtLozinka, "");
                errorProvider1.SetError(txtPotvrda, "");
                errorProvider1.SetError(txtTelefon, "");
                errorProvider1.SetError(txtJMBG, "");
                errorProvider1.SetError(cmbGrad, "");
                errorProvider1.SetError(cmbVrstaUposlenika, "");
                return true;
            }

            else if (txtKorIme.Text.Length < 4 || txtKorIme.Text.Length > 10)
            {
                errorProvider1.SetError(txtKorIme, "Korisnicko ime mora sadržavati barem 4 karaktera, ne više od 10 !");
                errorProvider1.SetError(txtIme, "");
                errorProvider1.SetError(txtPrezime, "");
                errorProvider1.SetError(txtAdresa, "");
                errorProvider1.SetError(txtLozinka, "");
                errorProvider1.SetError(txtPotvrda, "");
                errorProvider1.SetError(txtTelefon, "");
                errorProvider1.SetError(txtJMBG, "");
                errorProvider1.SetError(cmbGrad, "");
                errorProvider1.SetError(cmbVrstaUposlenika, "");
                return true;
            }
            if (txtKorIme.Text.Length >= 4 || txtKorIme.Text.Length <= 10)
            {
                var lista = await _uposlenik.Get<List<Model.Uposlenici>>(null);
                foreach (var item in lista)
                {
                    if (_id == null)
                        if (txtKorIme.Text == item.KorisnickoIme)
                        {
                            errorProvider1.SetError(txtKorIme, "Korisničko ime zauzeto, odaberite drugo !");
                            errorProvider1.SetError(txtIme, "");
                            errorProvider1.SetError(txtPrezime, "");
                            errorProvider1.SetError(txtAdresa, "");
                            errorProvider1.SetError(txtLozinka, "");
                            errorProvider1.SetError(txtPotvrda, "");
                            errorProvider1.SetError(txtTelefon, "");
                            errorProvider1.SetError(txtJMBG, "");
                            errorProvider1.SetError(cmbGrad, "");
                            errorProvider1.SetError(cmbVrstaUposlenika, "");
                            return true;
                        }
                }

            }
            if (string.IsNullOrWhiteSpace(txtLozinka.Text) && _id == null)
            {

                errorProvider1.SetError(txtIme, "");
                errorProvider1.SetError(txtPrezime, "");
                errorProvider1.SetError(txtAdresa, "");
                errorProvider1.SetError(txtKorIme, "");
                errorProvider1.SetError(txtLozinka, "Obavezno polje !");
                errorProvider1.SetError(txtPotvrda, "");
                errorProvider1.SetError(txtTelefon, "");
                errorProvider1.SetError(txtJMBG, "");
                errorProvider1.SetError(cmbGrad, "");
                errorProvider1.SetError(cmbVrstaUposlenika, "");

                return true;
            }
            if (txtLozinka.Text.Length < 5 && _id == null)
            {
                errorProvider1.SetError(txtLozinka, "Lozinka  mora sadržavati barem 5 karaktera!");
                errorProvider1.SetError(txtIme, "");
                errorProvider1.SetError(txtPrezime, "");
                errorProvider1.SetError(txtAdresa, "");
                errorProvider1.SetError(txtKorIme, "");
                errorProvider1.SetError(txtPotvrda, "");
                errorProvider1.SetError(txtTelefon, "");
                errorProvider1.SetError(txtJMBG, "");
                errorProvider1.SetError(cmbGrad, "");
                errorProvider1.SetError(cmbVrstaUposlenika, "");
               return true;
            }
            if (string.IsNullOrWhiteSpace(txtPotvrda.Text) && _id == null)
            {
                errorProvider1.SetError(txtIme, "");
                errorProvider1.SetError(txtPrezime, "");
                errorProvider1.SetError(txtAdresa, "");
                errorProvider1.SetError(txtKorIme, "");
                errorProvider1.SetError(txtLozinka, "");
                errorProvider1.SetError(txtPotvrda, "Obavezno polje !");
                errorProvider1.SetError(txtTelefon, "");
                errorProvider1.SetError(txtJMBG, "");
                errorProvider1.SetError(cmbGrad, "");
                errorProvider1.SetError(cmbVrstaUposlenika, "");
                return true;
            }
            if (txtPotvrda.Text.Length < 5 && _id == null)
            {
                errorProvider1.SetError(txtIme, "");
                errorProvider1.SetError(txtPrezime, "");
                errorProvider1.SetError(txtAdresa, "");
                errorProvider1.SetError(txtKorIme, "");
                errorProvider1.SetError(txtLozinka, "");
                errorProvider1.SetError(txtTelefon, "");
                errorProvider1.SetError(txtJMBG, "");
                errorProvider1.SetError(cmbGrad, "");
                errorProvider1.SetError(cmbVrstaUposlenika, "");
                errorProvider1.SetError(txtPotvrda, "Lozinka  mora sadržavati barem 5 karaktera!");
                return true;
            }


            if (string.IsNullOrWhiteSpace(txtTelefon.Text))
            {
                errorProvider1.SetError(txtIme, "");
                errorProvider1.SetError(txtPrezime, "");
                errorProvider1.SetError(txtAdresa, "");
                errorProvider1.SetError(txtKorIme, "");
                errorProvider1.SetError(txtLozinka, "");
                errorProvider1.SetError(txtPotvrda, "");
                errorProvider1.SetError(txtTelefon, "Obavezno polje !");
                errorProvider1.SetError(txtJMBG, "");
                errorProvider1.SetError(cmbGrad, "");
                errorProvider1.SetError(cmbVrstaUposlenika, "");
                return true;
            }
            if (txtTelefon.Text.Length < 9)
            {
                errorProvider1.SetError(txtIme, "");
                errorProvider1.SetError(txtPrezime, "");
                errorProvider1.SetError(txtAdresa, "");
                errorProvider1.SetError(txtKorIme, "");
                errorProvider1.SetError(txtLozinka, "");
                errorProvider1.SetError(txtPotvrda, "");
                errorProvider1.SetError(txtTelefon, "Telefon mora sadržavati minimalno 9 brojeva !");
                errorProvider1.SetError(txtJMBG, "");
                errorProvider1.SetError(cmbGrad, "");
                errorProvider1.SetError(cmbVrstaUposlenika, "");
                return true;
            }

            else if (string.IsNullOrWhiteSpace(txtJMBG.Text))
            {
                errorProvider1.SetError(txtIme, "");
                errorProvider1.SetError(txtPrezime, "");
                errorProvider1.SetError(txtAdresa, "");
                errorProvider1.SetError(txtKorIme, "");
                errorProvider1.SetError(txtLozinka, "");
                errorProvider1.SetError(txtPotvrda, "");
                errorProvider1.SetError(txtTelefon, "");
                errorProvider1.SetError(txtJMBG, "Obavezno polje !");
                errorProvider1.SetError(cmbGrad, "");
                errorProvider1.SetError(cmbVrstaUposlenika, "");
                return true;
            }

            if (txtJMBG.Text.Length != 13)
            {
                errorProvider1.SetError(txtJMBG, "JBMG  mora sadržavati 13 brojeva!");
                errorProvider1.SetError(txtIme, "");
                errorProvider1.SetError(txtPrezime, "");
                errorProvider1.SetError(txtAdresa, "");
                errorProvider1.SetError(txtKorIme, "");
                errorProvider1.SetError(txtLozinka, "");
                errorProvider1.SetError(txtPotvrda, "");
                errorProvider1.SetError(txtTelefon, "");
                errorProvider1.SetError(cmbGrad, "");
                errorProvider1.SetError(cmbVrstaUposlenika, "");
                return true;
            }

            if (cmbGrad.SelectedIndex == 0 && _id == null)
            {
                errorProvider1.SetError(txtIme, "");
                errorProvider1.SetError(txtPrezime, "");
                errorProvider1.SetError(txtAdresa, "");
                errorProvider1.SetError(txtKorIme, "");
                errorProvider1.SetError(txtLozinka, "");
                errorProvider1.SetError(txtPotvrda, "");
                errorProvider1.SetError(txtTelefon, "");
                errorProvider1.SetError(txtJMBG, "");
                errorProvider1.SetError(cmbGrad, "Obavezno polje !");
                errorProvider1.SetError(cmbVrstaUposlenika, "");
                return true;
            }
            if (cmbVrstaUposlenika.SelectedIndex == 0 && _id == null)
            {
                errorProvider1.SetError(txtIme, "");
                errorProvider1.SetError(txtPrezime, "");
                errorProvider1.SetError(txtAdresa, "");
                errorProvider1.SetError(txtKorIme, "");
                errorProvider1.SetError(txtLozinka, "");
                errorProvider1.SetError(txtPotvrda, "");
                errorProvider1.SetError(txtTelefon, "");
                errorProvider1.SetError(txtJMBG, "");
                errorProvider1.SetError(cmbGrad, "");
                errorProvider1.SetError(cmbVrstaUposlenika, "Obavezno polje !");
                return true;
            }

            return  false;
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (await Validacija())
            {
                MessageBox.Show("Unesite trazena polja");
            }
            else
            {
                UposleniciUpsertRequest model = new UposleniciUpsertRequest();

                model.Ime = txtIme.Text;
                model.Prezime = txtPrezime.Text;
                model.JMBG = txtJMBG.Text;
                model.Adresa = txtAdresa.Text;
                model.Lozinka = txtLozinka.Text;
                model.DatumRodjenja = txtDatumRodj.Value;
                model.DatumZaposljavanja = txtDatZap.Value;
                model.Telefon = txtTelefon.Text;
                model.KorisnickoIme = txtKorIme.Text;
                if (Status.Checked == true)
                {
                    model.Status = true;
                }
                else
                {
                    model.Status = false;
                }

                var gradID = cmbGrad.SelectedValue;
                if (int.TryParse(gradID.ToString(), out int gid))
                {
                    model.GradId = gid;
                }

                var vrsID = cmbVrstaUposlenika.SelectedValue;
                if (int.TryParse(vrsID.ToString(), out int vid))
                {
                    model.VrstaUposlenikaId = vid;
                }

                if (_id.HasValue && txtLozinka.Text == txtPotvrda.Text)
                {

                    var nesto = await _uposlenik.Update<Model.Uposlenici>(_id, model);
                    if (nesto != default(Model.Uposlenici))
                    {
                        await _parent.GetUposlenici();
                        MessageBox.Show("Uspješno promijenjen zapis!");
                    }

                    Close();
                }
                else if (txtLozinka.Text == txtPotvrda.Text)
                {


                    var nesto = await _uposlenik.Insert<Model.Uposlenici>(model);
                    if (nesto != default(Model.Uposlenici))
                    {
                        await _parent.GetUposlenici();
                        MessageBox.Show("Uspješno ste dodali zapis!");
                    }
                    Close();

                }
                else
                {
                    MessageBox.Show("Lozinke se ne slažu!");
                }


            }
        }
    }
}
