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
    public partial class RezervacijaPage : ContentPage
    {
        private readonly ApiService _rezervacijaService = new ApiService("Rezervacija");

        RezervacijaViewModel model = null;
        public RezervacijaPage()
        {

            InitializeComponent();

            BindingContext = model = new RezervacijaViewModel(Navigation);
        }

        private void spremi_Clicked(object sender, EventArgs e)
        {

        }
    }
}