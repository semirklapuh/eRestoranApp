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
    public partial class StavkaSaNarudzbePage : ContentPage
    {
        private StavkeNarudzbeViewModel model = null;
        public StavkaSaNarudzbePage()
        {
            InitializeComponent();
            
        }

        public StavkaSaNarudzbePage(int _id)
        {
            InitializeComponent();
            BindingContext = model = new StavkeNarudzbeViewModel(_id);
            model.Init(_id);
        }

        //protected async override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    await model.Init(_id);
        //}

        //protected async override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    await model.Init();
        //}
    }
}