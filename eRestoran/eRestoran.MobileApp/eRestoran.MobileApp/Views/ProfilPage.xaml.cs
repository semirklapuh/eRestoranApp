using eRestoran.MobileApp.Models;
using eRestoran.MobileApp.ViewModels;
using eRestoran.Model;
using eRestoran.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eRestoran.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilPage : ContentPage
    {
        private readonly ApiService _grad = new ApiService("Grad");
        private readonly ApiService _Klijenti = new ApiService("Klijent");

        private ProfilViewModel model = null;
        public ProfilPage()
        {
            Title = "Vas profil";
            InitializeComponent();
            BindingContext = model = new ProfilViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DopustiIzmjene();
        }

        private async void Spremi_Clicked(object sender, EventArgs e)
        {
            string lozinka = string.Empty;
            if (!string.IsNullOrEmpty(novaEntry.Text) && !string.IsNullOrEmpty(novaOpetEntry.Text))
            {
                if (novaEntry.Text == novaOpetEntry.Text)
                {
                    if (staraEntry.Text == ApiService.pass)
                    {
                        lozinka = novaEntry.Text;
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Greska", "Netacna stara lozinka.", "Ok");
                        return;
                    }
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Greska", "Nova lozinka i njega potvrda se ne slazu.", "Ok");
                    return;
                }

                return;
            }
            GradSearchRequest req = new GradSearchRequest()
            {
                Naziv = Global.prijavljeniKorisnik.Grad
            };

            var gradovi = await _grad.Get<List<Grad>>(req);
            KlijentUpsertRequest requ = new KlijentUpsertRequest()
            {
                Ime = ime.Text,
                Prezime = prezime.Text,
                Adresa = adresa.Text,
                KorisnickoIme = ApiService.username,
                Telefon = telefon.Text,
                GradID = gradovi[0].GradId,
                Lozinka = ApiService.pass
            };
            if (!string.IsNullOrEmpty(lozinka))
            {
                requ.Lozinka = lozinka;
            }
            await _Klijenti.Update<Klijenti>(Global.prijavljeniKorisnik.KorisnikId, requ);
            Global.prijavljeniKorisnik.Ime = ime.Text;
            Global.prijavljeniKorisnik.Prezime = prezime.Text;
            Global.prijavljeniKorisnik.Adresa = adresa.Text;
            Global.prijavljeniKorisnik.Telefon = telefon.Text;
            Global.prijavljeniKorisnik.Grad = grad.Text;
            await Application.Current.MainPage.DisplayAlert("Uspjesno", "Podaci uspjesno izmjenjeni.", "Ok");
            ZabraniIzmjene();

        }
        private void Ponisti_Clicked(object sender, EventArgs e)
        {
            ZabraniIzmjene();
        }

        private void ZabraniIzmjene()
        {
            ime.IsReadOnly = true;
            prezime.IsReadOnly = true;
            adresa.IsReadOnly = true;
            telefon.IsReadOnly = true;
            grad.IsReadOnly = true;
            izmjena.IsVisible = true;
            spremi.IsVisible = false;
            ponisti.IsVisible = false;

            stara.IsVisible = false;
            nova.IsVisible = false;
            novaOpet.IsVisible = false;
            stara.HeightRequest = 0;
            nova.HeightRequest = 0;
            novaOpet.HeightRequest = 0;

            staraEntry.IsVisible = false;
            novaEntry.IsVisible = false;
            novaOpetEntry.IsVisible = false;
            staraEntry.HeightRequest = 0;
            novaEntry.HeightRequest = 0;
            novaOpetEntry.HeightRequest = 0;
            staraEntry.Text = "";
            novaEntry.Text = "";
            novaOpetEntry.Text = "";
        }

        private void DopustiIzmjene()
        {
            ime.IsReadOnly = false;
            prezime.IsReadOnly = false;
            adresa.IsReadOnly = false;
            telefon.IsReadOnly = false;
            grad.IsReadOnly = false;
            izmjena.IsVisible = false;
            spremi.IsVisible = true;
            ponisti.IsVisible = true;

            stara.IsVisible = true;
            nova.IsVisible = true;
            novaOpet.IsVisible = true;
            stara.HeightRequest = 20;
            nova.HeightRequest = 20;
            novaOpet.HeightRequest = 20;

            staraEntry.IsVisible = true;
            novaEntry.IsVisible = true;
            novaOpetEntry.IsVisible = true;
            staraEntry.HeightRequest = 35;
            novaEntry.HeightRequest = 35;
            novaOpetEntry.HeightRequest = 35;
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var narudzba = e.Item as Models.Narudzba;
            this.Navigation.PushAsync(new NarudzbaPage(narudzba.NarudzbaId));

        }
    }
}