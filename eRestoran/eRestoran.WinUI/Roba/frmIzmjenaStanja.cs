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
    public partial class frmIzmjenaStanja : Form
    {
        private int _id;
        private frmRoba _parent = null;
        private readonly APIService _roba = new APIService("Roba");
        public frmIzmjenaStanja(int id, frmRoba frm = null)
        {
            InitializeComponent();
            _id = id;
            _parent = frm;
        }

        private async void FrmIzmjenaStanja_Load(object sender, EventArgs e)
        {
            await LoadForma();
        }

        private async Task LoadForma()
        {

            var proizvod = await _roba.GetById<Model.Roba>(_id);

            txtProizvod.Text = proizvod.Naziv;
            txtStanje.Text = proizvod.Stanje.ToString();


        }

        private async void TxtSave_Click(object sender, EventArgs e)
        {
            if (Validacija())
            {
                MessageBox.Show("Unesite trazena polja");
            }
            else
            {
                var proizvod = await _roba.GetById<Model.Roba>(_id);

                RobaUpsertRequest model = new RobaUpsertRequest();

                model.Naziv = proizvod.Naziv;
                model.Sifra = proizvod.Sifra;
                model.Cijena = proizvod.Cijena;
                model.Stanje = int.Parse(txtStanje.Text);
                model.KategorijaId = proizvod.KategorijaId;
                model.JedinicaMjereId = proizvod.JedinicaMjereId;

                var nesto = await _roba.Update<Model.Roba>(_id, model);
                if (nesto != default(Model.Roba))
                {
                    await _parent.GetRoba();
                    MessageBox.Show("Uspješno promijenjen zapis!");

                }
                Close();
            }
        }

        private bool Validacija()
        {
            if (int.Parse(txtStanje.Text) < 0 || int.Parse(txtStanje.Text) > 100)
            {
                errorProvider1.SetError(txtProizvod, "");
                errorProvider1.SetError(txtStanje, "Stanje ne smije biti manje od 1 i veće od 100");

                return true;
            }
            return false;
        }
    }
}
