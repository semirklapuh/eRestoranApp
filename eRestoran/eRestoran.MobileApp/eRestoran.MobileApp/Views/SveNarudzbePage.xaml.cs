using eRestoran.MobileApp.Models;
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
    public partial class SveNarudzbePage : ContentPage
    {
        private NarudzbeViewModel model = null;
        public SveNarudzbePage()
        {
            InitializeComponent();
            BindingContext = model = new NarudzbeViewModel();
        }



        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                this.Navigation.PushAsync(new StavkaSaNarudzbePage((e.Item as Narudzba).NarudzbaId));
            }
        }
    }
}