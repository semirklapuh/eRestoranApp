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
    public partial class NarudzbaPage : ContentPage
    {
        private NarudzbaViewModel model = null;
        private readonly int _id;

        public NarudzbaPage(int id)
        {
            Title = "Stavke narudzbe";
            _id = id;
            BindingContext = model = new NarudzbaViewModel(_id);
            InitializeComponent();
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init(_id);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new ProfilPage());
            this.Navigation.RemovePage(this);
        }
    }
}