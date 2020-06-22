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
    public partial class frmNabavkaNova : Form
    {
        private readonly APIService _detalji = new APIService("NabavkaStavke");
        private readonly APIService _proizvodi = new APIService("Roba");
        private readonly APIService _nabavka = new APIService("Nabavka");

        private int _id { get; set; }
        private frmNabavke _parent = null;
        public frmNabavkaNova(int id, frmNabavke parent = null)
        {
            InitializeComponent();
            _id = id;
            _parent = parent;
        }



        private async void FrmNabavkaNova_Load(object sender, EventArgs e)
        {
            await LoadForma();
            
        }

        private async Task LoadForma()
        {
            var proizvodi = await _proizvodi.Get<List<Model.Roba>>(null);

            cmbProizvod.DataSource = proizvodi;
            cmbProizvod.ValueMember = "RobaId";
            cmbProizvod.DisplayMember = "Naziv";
        }

        private async void BtnNaruci_Click(object sender, EventArgs e)
        {
            if (await Validacija())
            {
                MessageBox.Show("Unesite trazena polja");

            }
            else
            {
                NabavkaStavkeUpsertRequest model = new NabavkaStavkeUpsertRequest();

                model.NabavkaId = _id;

                if (int.TryParse(txtKolicina.Value.ToString(), out int kol))
                {
                    model.Kolicina = kol;
                }

                var proizvod = cmbProizvod.SelectedValue;
                if (int.TryParse(proizvod.ToString(), out int pid))
                {
                    model.RobaId = pid;
                }


                var nesto = await _detalji.Insert<Model.NabavkaStavke>(model);
                MessageBox.Show("Dodano na listu!");
                Close();
                NabavkaSearchRequest search = new NabavkaSearchRequest
                {
                    Zavrsena = false

                };
                await _parent.LoadNabavke(search);
                frmNabavkaNova form = new frmNabavkaNova(_id, _parent);
                form.Show();
            }
        }

        private async Task<bool> Validacija()
        {
            if(txtKolicina.Value < 1)
            {
                errorProvider1.SetError(cmbProizvod, "");
                errorProvider1.SetError(txtKolicina, "Količina mora biti veća od 0");
                return true;
            }
            return false;
        }
    }
}
