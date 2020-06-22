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
    public class StavkeNarudzbeViewModel:BaseViewModel
    {
        private readonly ApiService _stavkeNarudzbeService = new ApiService("NarudzbaStavka");
        public StavkeNarudzbeViewModel()
        {

        }
        public StavkeNarudzbeViewModel(int _id)
        {
            InitCommand = new Command(async () => await Init(_id));
        }
        public ObservableCollection<NarudzbaStavke> NarudzbaStavkeList { get; set; } = new ObservableCollection<NarudzbaStavke>();


        public ICommand InitCommand { get; set; }

        public async Task Init(int _id)
        {
            var list = await _stavkeNarudzbeService.Get<IEnumerable<NarudzbaStavke>>(null);

            NarudzbaStavkeList.Clear();
            foreach (var stavke in list)
            {
                if (stavke.NarudzbaId == _id)
                {
                    NarudzbaStavkeList.Add(stavke);
                }
                
            }
        }
    }
}
