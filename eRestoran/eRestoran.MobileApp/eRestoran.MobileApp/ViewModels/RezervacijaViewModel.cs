using eRestoran.MobileApp.Models;
using eRestoran.MobileApp.Views;
using eRestoran.Model;
using eRestoran.Model.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eRestoran.MobileApp.ViewModels
{
    public class RezervacijaViewModel : BaseViewModel
    {
        private readonly ApiService _RezervacijaService = new ApiService("Rezervacija");

        string _naziv = string.Empty;
        int _stol = 0;
        DateTime _datumRezervacije = DateTime.Now;
        int _klijentId = 0;
        public string Naziv
        {
            get { return _naziv; }
            set { SetProperty(ref _naziv, value); }
        }
        public int Stol
        {
            get { return _stol; }
            set { SetProperty(ref _stol, value); }
        }
        public DateTime DatumRezervacije
        {
            get { return _datumRezervacije; }
            set { SetProperty(ref _datumRezervacije, value); }
        }
        public int KlijentId
        {
            get { return _klijentId; }
            set { SetProperty(ref _klijentId, value); }
        }

        public INavigation Navigation { get; set; }

        public RezervacijaViewModel(INavigation navigation)
        {
            Navigation = navigation;
            Title = "Registracija";
            InitCommand = new Command(async () => await Rezervisi());

        }
        public RezervacijaViewModel()
        {
            Title = "Rezervacija";
            InitCommand = new Command(async () => await Rezervisi());            
        }

        public ICommand InitCommand { get; set; }
        async Task Rezervisi()
        {
           
                RezervacijeUpsertRequest model = new RezervacijeUpsertRequest();
                KlijentId = Global.prijavljeniKorisnik.KorisnikId;
                model.Naziv=Naziv;
                model.KlijentId = KlijentId;
                model.DatumRezervacije = DatumRezervacije;
                model.StolId = Stol;

                
                await _RezervacijaService.Insert<Rezervacije>(model);
                await Application.Current.MainPage.DisplayAlert("Succeed", "Uspjesno ste izvrsili rezervaciju", "OK");
                await this.Navigation.PushAsync(new MainPage());
                
               
            }
        }
}

