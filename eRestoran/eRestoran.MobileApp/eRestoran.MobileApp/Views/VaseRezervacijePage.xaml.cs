using eRestoran.MobileApp.ViewModels;
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
    public partial class VaseRezervacijePage : ContentPage
    {
        private VaseRezervacijeViewModel model = null;
        public VaseRezervacijePage()
        {
            InitializeComponent();
            BindingContext = model = new VaseRezervacijeViewModel();
        }


        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private void rezervisi_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage.DisplayAlert("Rezervisi", "Popunite podatke vase rezervacije", "Ok");
            this.Navigation.PushAsync(new RezervacijaPage());
        }
    }
}