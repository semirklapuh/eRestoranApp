using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using eRestoran.MobileApp.Models;
using eRestoran.MobileApp.ViewModels;

namespace eRestoran.MobileApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ObavijestiPage : ContentPage
    {
        private ObavijestiViewModel model = null;
        public ObavijestiPage()
        {
            InitializeComponent();
            BindingContext = model = new ObavijestiViewModel();
        }



        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
    }
}