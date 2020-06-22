using eRestoran.MobileApp.Models;
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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            Title = "Login";
            if (Global.prijavljeniKorisnik != null)
            {
                Navigation.PushAsync(new ProfilPage());
            }
            else
            {
                InitializeComponent();
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            // Navigation.PushAsync(new Registracija());
            
            Application.Current.MainPage = new Registracija();

        }
    }
}