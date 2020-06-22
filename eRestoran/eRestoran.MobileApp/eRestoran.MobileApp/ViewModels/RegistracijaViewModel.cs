using eRestoran.MobileApp.Views;
using eRestoran.Model;
using eRestoran.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eRestoran.MobileApp.ViewModels
{
    public class RegistracijaViewModel :BaseViewModel
    {
        string _ime = string.Empty;
        string _prezime = string.Empty;
        string _adresa = string.Empty;
        string _korisnickoIme = string.Empty;
        string _lozinka = string.Empty;
        string _lozinka2 = string.Empty;
        Grad _grad = new Grad();
        string _telefon = string.Empty;

        string _imeError = string.Empty;
        string _prezimeError = string.Empty;
        string _adresaError = string.Empty;
        string _korsError = string.Empty;
        string _pass1Error = string.Empty;
        string _pass2Error = string.Empty;
        string _gradError = string.Empty;
        string _telefonError = string.Empty;


        bool _visibleIme = false;
        bool _visiblePrezime = false;
        bool _visibleAdresa = false;
        bool _visibleKorisnickoIme = false;
        bool _visibleLozinka1 = false;
        bool _visibleLozinka2 = false;
        bool _visibleGrad = false;
        bool _visibleTelefon = false;


        private readonly ApiService _klijent = new ApiService("Klijent");
        private readonly ApiService _gradovi = new ApiService("Grad");
        private readonly ApiService _uposlenik = new ApiService("Uposlenik");

        public INavigation Navigation { get; set; }

        public RegistracijaViewModel(INavigation navigation)
        {
            Navigation = navigation;
            Title = "Registracija";
            InitCommand = new Command(async() => await PopuniGradove());
            Registracija = new Command(async () => await RegistrujSE());
        }
        public RegistracijaViewModel()
        {
            Title = "Registracija";
            InitCommand = new Command(async () => await PopuniGradove());
            Registracija = new Command(async () => await RegistrujSE());
        }

        public string Ime
        {
            get { return _ime; }
            set { SetProperty(ref _ime, value); }
        }
        public string Prezime
        {
            get { return _prezime; }
            set { SetProperty(ref _prezime, value); }
        }
        public string Adresa
        {
            get { return _adresa; }
            set { SetProperty(ref _adresa, value); }
        }
        public string KorsIme
        {
            get { return _korisnickoIme; }
            set { SetProperty(ref _korisnickoIme, value); }
        }
        public string Lozinka1
        {
            get { return _lozinka; }
            set { SetProperty(ref _lozinka, value); }
        }
        public string Lozinka2
        {
            get { return _lozinka2; }
            set { SetProperty(ref _lozinka2, value); }
        }
        public Grad Grad
        {
            get { return _grad; }
            set { SetProperty(ref _grad, value); }
        }
        public string Telefon
        {
            get { return _telefon; }
            set { SetProperty(ref _telefon, value); }
        }


        public string ImeError
        {
            get { return _imeError; }
            set { SetProperty(ref _imeError, value); }
        }

        public string PrezimeError
        {
            get { return _prezimeError; }
            set { SetProperty(ref _prezimeError, value); }
        }

        public string AdresaError
        {
            get { return _adresaError; }
            set { SetProperty(ref _adresaError, value); }
        }

        public string GradError
        {
            get { return _gradError; }
            set { SetProperty(ref _gradError, value); }
        }

        public string KorsError
        {
            get { return _korsError; }
            set { SetProperty(ref _korsError, value); }
        }
        public string PassError
        {
            get { return _pass1Error; }
            set { SetProperty(ref _pass1Error, value); }
        }
        public string Pass1Error
        {
            get { return _pass2Error; }
            set { SetProperty(ref _pass2Error, value); }
        }

        public string TelError
        {
            get { return _telefonError; }
            set { SetProperty(ref _telefonError, value); }
        }

        public bool VisibleIme
        {
            get { return _visibleIme; }
            set { SetProperty(ref _visibleIme, value); }
        }
        public bool VisiblePrezime
        {
            get { return _visiblePrezime; }
            set { SetProperty(ref _visiblePrezime, value); }
        }
        public bool VisibleAdresa
        {
            get { return _visibleAdresa; }
            set { SetProperty(ref _visibleAdresa, value); }
        }
        public bool VisibleGrad
        {
            get { return _visibleGrad; }
            set { SetProperty(ref _visibleGrad, value); }
        }
        public bool VisibleKors
        {
            get { return _visibleKorisnickoIme; }
            set { SetProperty(ref _visibleKorisnickoIme, value); }
        }
        public bool VisiblePass
        {
            get { return _visibleLozinka1; }
            set { SetProperty(ref _visibleLozinka1, value); }
        }
        public bool Visible2Pass
        {
            get { return _visibleLozinka2; }
            set { SetProperty(ref _visibleLozinka2, value); }
        }
        public bool VisibleTel
        {
            get { return _visibleTelefon; }
            set { SetProperty(ref _visibleTelefon, value); }
        }


        public ObservableCollection<Grad> GradoviList { get; set; } = new ObservableCollection<Grad>();

        public ICommand InitCommand { get; set; }
        public ICommand Registracija { get; set; }

        public async Task PopuniGradove()
        {
            var list = await _gradovi.Get<IEnumerable<Grad>>(null);

            GradoviList.Clear();
            foreach (var item in list)
            {
                GradoviList.Add(item);
            }

        }

        async Task RegistrujSE()
        {
            if (await Validacija())
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Unesite tražena polja!", "OK");

            }
            else
            {


                IsBusy = true;
                KlijentUpsertRequest model = new KlijentUpsertRequest();
                
                model.Ime = Ime;
                model.Prezime = Prezime;
                model.Adresa = Adresa;
                model.GradID = Grad.GradId;
                model.KorisnickoIme = KorsIme;
                model.Lozinka = Lozinka1;
                model.Telefon = Telefon;

                if (Lozinka1 == Lozinka2)
                {
                    await _klijent.Insert<Klijenti>(model);
                    await Application.Current.MainPage.DisplayAlert("Uspjesna registracija", "Uspjesno ste se registrovali ! Sada se logirajte sa vasim korisnickim informacijama.", "OK");
                    //await this.Navigation.PushAsync(new LoginPage());
                    Application.Current.MainPage = new LoginPage();
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Lozinke nisu iste!", "OK");
                }
            }
        }

        private async Task<bool> Validacija()
        {

            if (Ime == string.Empty)
            {
                ImeError = "Ime je obavezno!";
                VisibleIme = true;
                VisiblePrezime = false;
                VisibleAdresa = false;
                VisibleGrad = false;
                VisibleKors = false;
                VisiblePass = false;
                Visible2Pass = false;
                VisibleTel = false;

                return true;
            }
            else if (Ime.Length < 4)
            {
                ImeError = "Ime mora sadržavati barem 4 karaktera!";
                VisibleIme = true;
                VisiblePrezime = false;
                VisibleAdresa = false;
                VisibleGrad = false;
                VisibleKors = false;
                VisiblePass = false;
                Visible2Pass = false;
                VisibleTel = false;

                return true;
            }
            else if (Ime.Any(char.IsDigit))
            {
                ImeError = "Ime ne smije sadržavati brojeve!";
                VisibleIme = true;
                VisiblePrezime = false;
                VisibleAdresa = false;
                VisibleGrad = false;
                VisibleKors = false;
                VisiblePass = false;
                Visible2Pass = false;
                VisibleTel = false;

                return true;
            }

            else if (Prezime == string.Empty)
            {
                PrezimeError = "Prezime je obavezno!";
                VisibleIme = false;
                VisiblePrezime = true;
                VisibleAdresa = false;
                VisibleGrad = false;
                VisibleKors = false;
                VisiblePass = false;
                Visible2Pass = false;
                VisibleTel = false;
                return true;
            }
            else if (Prezime.Length < 4)
            {
                PrezimeError = "Prezime mora sadržavati barem 4 karaktera!";
                VisibleIme = false;
                VisiblePrezime = true;
                VisibleAdresa = false;
                VisibleGrad = false;
                VisibleKors = false;
                VisiblePass = false;
                Visible2Pass = false;
                VisibleTel = false;
                return true;
            }
            else if (Prezime.Any(char.IsDigit))
            {
                PrezimeError = "Prezime ne smije sadržavati brojeve!";
                VisibleIme = false;
                VisiblePrezime = true;
                VisibleAdresa = false;
                VisibleGrad = false;
                VisibleKors = false;
                VisiblePass = false;
                Visible2Pass = false;
                VisibleTel = false;

                return true;
            }
            else if (Adresa == string.Empty)
            {
                AdresaError = "Adresa je obavezna!";
                VisibleIme = false;
                VisiblePrezime = false;
                VisibleAdresa = true;
                VisibleGrad = false;
                VisibleKors = false;
                VisiblePass = false;
                Visible2Pass = false;
                VisibleTel = false;
                return true;
            }
            else if (Adresa.Length < 10)
            {
                AdresaError = "Adresa mora sadržavati barem 10 karaktera!";
                VisibleIme = false;
                VisiblePrezime = false;
                VisibleAdresa = true;
                VisibleGrad = false;
                VisibleKors = false;
                VisiblePass = false;
                Visible2Pass = false;
                VisibleTel = false;
                return true;
            }
            else if (Grad == null)
            {
                GradError = "Grad je obavezan!";
                VisibleIme = false;
                VisiblePrezime = false;
                VisibleAdresa = false;
                VisibleGrad = true;
                VisibleKors = false;
                VisiblePass = false;
                Visible2Pass = false;
                VisibleTel = false;
                return true;
            }
            else if (KorsIme == string.Empty)
            {
                KorsError = "Korisničko ime je obavezno!";
                VisibleIme = false;
                VisiblePrezime = false;
                VisibleAdresa = false;
                VisibleGrad = false;
                VisibleKors = true;
                VisiblePass = false;
                Visible2Pass = false;
                VisibleTel = false;
                return true;
            }
            else if (KorsIme.Length < 4)
            {
                KorsError = "Korisničko ime mora sadržavati barem 4 karaktera!";
                VisibleIme = false;
                VisiblePrezime = false;
                VisibleAdresa = false;
                VisibleGrad = false;
                VisibleKors = true;
                VisiblePass = false;
                Visible2Pass = false;
                VisibleTel = false;
                return true;
            }
            if (KorsIme.Length >= 4)
            {
                var lista = await _klijent.Get<List<Model.Uposlenici>>(null);
                foreach (var item in lista)
                {
                    if (KorsIme == item.KorisnickoIme)
                    {
                        KorsError = "Korisničko ime zauzeto, odaberite drugo!";
                        VisibleIme = false;
                        VisiblePrezime = false;
                        VisibleAdresa = false;
                        VisibleGrad = false;
                        VisibleKors = true;
                        VisiblePass = false;
                        Visible2Pass = false;
                        VisibleTel = false;
                        return true;
                    }
                }
            }

            if (Lozinka1 == string.Empty)
            {
                PassError = "Lozinka je obavezna!";
                VisibleIme = false;
                VisiblePrezime = false;
                VisibleAdresa = false;
                VisibleGrad = false;
                VisibleKors = false;
                VisiblePass = true;
                Visible2Pass = false;
                VisibleTel = false;
                return true;
            }
            else if (Lozinka1.Length < 6)
            {
                PassError = "Lozinka mora sadržavati barem 6 karatera!";
                VisibleIme = false;
                VisiblePrezime = false;
                VisibleAdresa = false;
                VisibleGrad = false;
                VisibleKors = false;
                VisiblePass = true;
                Visible2Pass = false;
                VisibleTel = false;
                return true;
            }
            else if (Lozinka2 == string.Empty)
            {
                Pass1Error = "Potvrda lozinke je obavezna!";
                VisibleIme = false;
                VisiblePrezime = false;
                VisibleAdresa = false;
                VisibleGrad = false;
                VisibleKors = false;
                VisiblePass = false;
                Visible2Pass = true;
                VisibleTel = false;
                return true;
            }

            if (Telefon == string.Empty)
            {
                TelError = "Telefon je obavezan!";
                VisibleIme = false;
                VisiblePrezime = false;
                VisibleAdresa = false;
                VisibleGrad = false;
                VisibleKors = false;
                VisiblePass = false;
                Visible2Pass = false;
                VisibleTel = true;
                return true;
            }
            else if (Telefon.Any(char.IsLetter))
            {
                TelError = "Telefon ne može sadržavati slova!";
                VisibleIme = false;
                VisiblePrezime = false;
                VisibleAdresa = false;
                VisibleGrad = false;
                VisibleKors = false;
                VisiblePass = false;
                Visible2Pass = false;
                VisibleTel = true;
                return true;
            }
            else if (Telefon.Length < 9)
            {
                TelError = "Telefon mora sadržavati minimalno 9 brojeva!";
                VisibleIme = false;
                VisiblePrezime = false;
                VisibleAdresa = false;
                VisibleGrad = false;
                VisibleKors = false;
                VisiblePass = false;
                Visible2Pass = false;
                VisibleTel = true;
                return true;
            }
            if (Telefon == string.Empty)
            {
                TelError = "Telefon je obavezan!";
                VisibleIme = false;
                VisiblePrezime = false;
                VisibleAdresa = false;
                VisibleGrad = false;
                VisibleKors = false;
                VisiblePass = false;
                Visible2Pass = false;
                VisibleTel = true;
                return true;
            }
            else if (Telefon.Any(char.IsLetter))
            {
                TelError = "Telefon ne može sadržavati slova!";
                VisibleIme = false;
                VisiblePrezime = false;
                VisibleAdresa = false;
                VisibleGrad = false;
                VisibleKors = false;
                VisiblePass = false;
                Visible2Pass = false;
                VisibleTel = true;
                return true;
            }
            else if (Telefon.Length < 9)
            {
                TelError = "Telefon mora sadržavati minimalno 9 brojeva!";
                VisibleIme = false;
                VisiblePrezime = false;
                VisibleAdresa = false;
                VisibleGrad = false;
                VisibleKors = false;
                VisiblePass = false;
                Visible2Pass = false;
                VisibleTel = true;
                return true;
            }

            if (KorsIme.Length >= 4)
            {
                var lista = await _uposlenik.Get<List<Model.Uposlenici>>(null);
                foreach (var item in lista)
                {
                    if (KorsIme == item.KorisnickoIme)
                    {
                        KorsError = "Korisničko ime zauzeto, odaberite drugo!";
                        VisibleIme = false;
                        VisiblePrezime = false;
                        VisibleAdresa = false;
                        VisibleGrad = false;
                        VisibleKors = true;
                        VisiblePass = false;
                        Visible2Pass = false;
                        VisibleTel = false;
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
