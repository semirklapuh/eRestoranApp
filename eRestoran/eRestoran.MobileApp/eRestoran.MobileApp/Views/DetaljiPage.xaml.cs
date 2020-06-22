using eRestoran.MobileApp.Models;
using eRestoran.MobileApp.ViewModels;
using eRestoran.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace eRestoran.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetaljiPage : ContentPage
    {
        private readonly ApiService _jeloService = new ApiService("Jelo");
        private DetaljiViewModel model = null;
        private readonly int _id;
        private readonly Jela Jelo= null;
        private readonly int _JeloId;
        public DetaljiPage()
        {
            InitializeComponent();
        }
        public DetaljiPage(int JeloId)
        {
            InitializeComponent();
            _JeloId = JeloId;
            BindingContext = model = new DetaljiViewModel(JeloId);
            model.Init(JeloId);


        }

        private async void dodajButton_Clicked(object sender, EventArgs e)
        {
            if (Global.aktivnaNarudzba == null)
            {
                Global.aktivnaNarudzba = new Narudzba();
                Global.aktivnaNarudzba.DatumNarudžbe = DateTime.Now;
                Global.aktivnaNarudzba.KlijentId = Global.prijavljeniKorisnik.KorisnikId;
            }
            Jela _item = await _jeloService.GetById<Jela>(_JeloId);

            bool _jeloPostoji = false;

            foreach(var item in Global.aktivnaNarudzba.narudzbaStavke)
            {
                if (_item.JeloId == item.JeloId)
                {
                    item.Kolicina += Convert.ToInt32(kolicinaInput.Text);
                    _jeloPostoji = true;
                    await DisplayAlert("Succeed", "Uspjesno ste povecali kolicinu jela!", "OK");
                    break;
                }
                
            }

            if (!_jeloPostoji)
            {
                _narudzbaStavke stavka = new _narudzbaStavke();

                stavka.JeloId = _item.JeloId;
                stavka.Kolicina = Convert.ToInt32(kolicinaInput.Text);
                stavka.Cijena = _item.Cijena;
                stavka.Jelo = _item;
                Global.aktivnaNarudzba.narudzbaStavke.Add(stavka);
                await DisplayAlert("Succeed", "Uspjesno ste dodali jelo u korpu!", "OK");
            }

            infoLabel.Text = "Naruceno jela: " + Global.aktivnaNarudzba.narudzbaStavke.Count();
            zakljuciNarudzbuButton.IsVisible = true;

        }

        private void zakljuciNarudzbuButton_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new AktivnaNarudzbaPage());
        }



        //protected async override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    await model.Init(_id);
        //}
    }
}