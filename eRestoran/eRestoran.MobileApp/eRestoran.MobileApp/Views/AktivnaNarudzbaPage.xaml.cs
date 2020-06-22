
using eRestoran.MobileApp.Models;
using eRestoran.Model;
using eRestoran.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eRestoran.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AktivnaNarudzbaPage : ContentPage
    {
        
        private readonly ApiService _narudzbaService = new ApiService("Narudzba");
        private readonly ApiService _narudzbaStavkeService = new ApiService("NarudzbaStavka");
        private List<_narudzbaStavke> listaStavki = null;
        public AktivnaNarudzbaPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {

            BindNarudzba();
            base.OnAppearing();
        }

        private void BindNarudzba()
        {
            if (Global.aktivnaNarudzba!=null)
            {
                narudzbaList.ItemsSource = Global.aktivnaNarudzba.narudzbaStavke;
                listaStavki = Global.aktivnaNarudzba.narudzbaStavke;
                double iznos = 0;

                foreach (_narudzbaStavke item in Global.aktivnaNarudzba.narudzbaStavke)
                {
                    iznos += item.Jelo.Cijena * item.Kolicina;
                }

                iznosLabel.Text = "Ukupan iznos: " + Math.Round(iznos,2) + " KM";
            }
        }

        private async void zakljuciButton_Clicked(object sender, EventArgs e)
        {
            NarudzbaUpsertRequest model = new NarudzbaUpsertRequest();
            int id = 6;
            model.DatumNarudžbe = Global.aktivnaNarudzba.DatumNarudžbe;
            model.KlijentId = Global.aktivnaNarudzba.KlijentId;
            model.Zavrsena = true;

             await _narudzbaService.Insert<Narudzba>(model);
           
            
            NarudzbeStavkeUpsertRequest modelStavke = new NarudzbeStavkeUpsertRequest();

           foreach(var item in listaStavki)
            {
                
                modelStavke.NarudzbaId = item.NarudzbaId;
                modelStavke.Kolicina = item.Kolicina;
                modelStavke.Cijena = item.Cijena;
                modelStavke.JeloId = item.JeloId;
                modelStavke.Jelo = item.Jelo.Naziv;
                modelStavke.Narudzba = "narudzba";
                modelStavke.datum = model.DatumNarudžbe;
                await _narudzbaStavkeService.Insert<NarudzbaStavke>(modelStavke);
            }
            listaStavki.Clear();
            await DisplayAlert("Succeed", "Uspjesno ste izvrsili narudzbu!", "OK");
            await this.Navigation.PushAsync(new JelaPage());
        }
    }
}