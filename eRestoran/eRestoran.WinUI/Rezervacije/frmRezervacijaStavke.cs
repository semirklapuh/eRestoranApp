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

namespace eRestoran.WinUI.Rezervacije
{
    public partial class frmRezervacijaStavke : Form
    {

        private int? _id = null;
        private frmRezervacije _parent = null;
        private readonly APIService _rezervacije = new APIService("Rezervacija");
        private readonly APIService _rezervacijaStavke = new APIService("RezervacijaStavke");
        private readonly APIService _klijenti = new APIService("Klijent");

        public frmRezervacijaStavke(int? id = null, frmRezervacije frm = null)
        {
            InitializeComponent();
            _id = id;
            _parent = frm;
        }
        private async void FrmRezervacijaStavke_Load(object sender, EventArgs e)
        {
            if(!_id.HasValue)
            {
                lblUI.Text = "Nova rezervacija";
            }
            await LoadForma();

        }

        private async Task LoadForma()
        {
            var klijenti = await _klijenti.Get<List<Model.Klijenti>>(null);
            txtDatum.Format = DateTimePickerFormat.Custom;
            txtDatum.CustomFormat = "dddd-MMM hh:mmm";


            if (_id.HasValue)
            {
                var rezervacija = await _rezervacije.GetById<Model.Rezervacije>(_id);
                RezervacijaStavkeSearchRequest search = new RezervacijaStavkeSearchRequest
                {
                    RezervacijaId = rezervacija.RezervacijaId
                };

                var rezervacijaStavke = _rezervacijaStavke.Get<List<Model.RezervacijaStavke>>(search);

                
              
             

                txtDatum.Value = rezervacija.DatumRezervacije;
                txtNaziv.Text = rezervacija.Naziv;
                txtSlider.Value = 0;


                cmbKlijent.DataSource = klijenti;
                cmbKlijent.DisplayMember = "Prezime";
                cmbKlijent.ValueMember = "KorisnikId";
            }
            else
            {
                cmbKlijent.DataSource = klijenti;
                cmbKlijent.DisplayMember = "Prezime";
                cmbKlijent.ValueMember = "KorisnikId";
            }

        }

        private void BunifuSlider1_ValueChanged(object sender, EventArgs e)
        {
            int broj = txtSlider.Value;
            lblMr.Text = broj.ToString();
        }

        private async void BunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (await Validacija())
            {
                MessageBox.Show("Unesite trazena polja");
            }
            else
            {
                RezervacijeUpsertRequest model = new RezervacijeUpsertRequest();


                model.DatumRezervacije = txtDatum.Value;
                model.Naziv = txtNaziv.Text;
                model.StolId = txtSlider.Value;

                var klijentId = cmbKlijent.SelectedValue;
                if (int.TryParse(klijentId.ToString(), out int kid))
                {
                    model.KlijentId = kid;
                }



                if (_id.HasValue)
                {
                    var nesto = await _rezervacije.Update<Model.Rezervacije>(_id, model);
                    if (nesto != default(Model.Rezervacije))
                    {
                        await _parent.GetRezervacije();
                        MessageBox.Show("Uspješno promijenjen zapis!");

                    }
                    Close();
                }
                else if (!_id.HasValue)
                {
                    var nesto = await _rezervacije.Insert<Model.Rezervacije>(model);
                    if (nesto != default(Model.Rezervacije))
                    {
                        await _parent.GetRezervacije();

                        MessageBox.Show("Uspješno ste dodali zapis!");
                    }
                    Close();

                }
            }
        }

        private async Task<bool> Validacija()
        {
            if(string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                errorProvider1.SetError(txtNaziv, "Obavezno polje !");
                errorProvider1.SetError(txtSlider, "");
                errorProvider1.SetError(txtDatum, "");
                errorProvider1.SetError(cmbKlijent, "");
                return true;
            }

            if (txtNaziv.Text.Length < 4 || txtNaziv.Text.Length > 15)
            {
                errorProvider1.SetError(txtNaziv, "Naziv mora biti veći od 4 manji od 15");
                errorProvider1.SetError(txtSlider, "");
                errorProvider1.SetError(txtDatum, "");
                errorProvider1.SetError(cmbKlijent, "");
                return true;
            }
            //if (cmbKlijent.SelectedIndex == 0)
            //{
            //    errorProvider1.SetError(txtNaziv, "");
            //    errorProvider1.SetError(txtSlider, "");
            //    errorProvider1.SetError(txtDatum, "");
            //    errorProvider1.SetError(cmbKlijent, "Obavezno polje");
            //    return true;
            //}
            if (txtSlider.Value <2)
            {
                errorProvider1.SetError(txtNaziv, "");
                errorProvider1.SetError(txtSlider, "Mora biti više od 2 gosta");
                errorProvider1.SetError(txtDatum, "");
                errorProvider1.SetError(cmbKlijent, "");
                return true;
            }


                return false;
        }

        private  void CmbKlijent_Format(object sender, ListControlConvertEventArgs e)
        {
            string lastname = ((Model.Klijenti)e.ListItem).Ime;
            string firstname = ((Model.Klijenti)e.ListItem).Prezime;
            e.Value = lastname + " " + firstname;

        }

    }

   
}
