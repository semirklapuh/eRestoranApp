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
    public class LoginPageViewModel : BaseViewModel
    {
        string _username = string.Empty;
        string _password = string.Empty;
        string _userError = string.Empty;
        string _passError = string.Empty;
        bool _visible = false;
        bool _visiblePass = false;
     

        private readonly ApiService _klijent = new ApiService("Klijent");
        public LoginPageViewModel()
        {
            Title = "Login";

            LoginKomanda = new Command(async () => await Login());

        }

       
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public string UserError
        {
            get { return _userError; }
            set { SetProperty(ref _userError, value); }
        }
        public string PassError
        {
            get { return _passError; }
            set { SetProperty(ref _passError, value); }
        }

        public bool VisibleKors
        {
            get { return _visible; }
            set { SetProperty(ref _visible, value); }
        }
        public bool VisiblePass
        {
            get { return _visiblePass; }
            set { SetProperty(ref _visiblePass, value); }
        }
        public ICommand LoginKomanda { get; set; }


        private async Task Login()
        {
            if (Validacija())
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Unesite tražena polja!", "OK");

            }
            else
            {
                IsBusy = true;
                ApiService.username = Username;
                ApiService.pass = Password;
                KlijentiSearchRequest req = new KlijentiSearchRequest()
                {
                    Korisnicko = Username,
                    Password = ApiService.pass

                };


                try
                {
                    var klijent = await _klijent.Get<List<Klijenti>>(req);
                    if(klijent != null)
                    {
                        Global.prijavljeniKorisnik = new Klijenti()
                        {
                            KorisnikId = klijent[0].KorisnikId,
                            Ime = klijent[0].Ime,
                            Prezime = klijent[0].Prezime,
                            Adresa = klijent[0].Adresa,
                            KorisnickoIme = klijent[0].KorisnickoIme,
                            Telefon = klijent[0].Telefon,
                            GradId = klijent[0].GradId,
                            Grad = klijent[0].Grad
                        };

                        Application.Current.MainPage = new MainPage();
                        
                    }
                }
                catch (Exception e)
                {
                    await Application.Current.MainPage.DisplayAlert("Greska", "Pogresno Korisnicko ime ili lozinka", "Ok");
                    //Application.Current.MainPage = new MainPage();
                }
            }
        }

        private bool Validacija()
        {
            if (Username == string.Empty)
            {
                UserError = "Korisničko ime je obavezno!";
                VisibleKors = true;
                VisiblePass = false;
                return true;
            }

            else if (Password == string.Empty)
            {
                PassError = "Password je obavezan!";
                VisiblePass = true;
                VisibleKors = false;
                return true;
            }
            else
            {
                VisiblePass = false;
                return false;
            }


        }
    }
}
