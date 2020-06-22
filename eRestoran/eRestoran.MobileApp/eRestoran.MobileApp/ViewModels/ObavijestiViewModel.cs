using eRestoran.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eRestoran.MobileApp.ViewModels
{
    public class ObavijestiViewModel
    {
        private readonly ApiService _obavijestiService = new ApiService("Obavijest");
        public ObavijestiViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<Obavijesti> ObavijestiList { get; set; } = new ObservableCollection<Obavijesti>();


        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            var list = await _obavijestiService.Get<IEnumerable<Obavijesti>>(null);

            ObavijestiList.Clear();
            foreach(var obavijest in list)
            {
                ObavijestiList.Add(obavijest);
            }
        }
    }
}
