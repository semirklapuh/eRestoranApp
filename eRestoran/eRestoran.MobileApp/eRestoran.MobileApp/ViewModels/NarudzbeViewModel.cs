using eRestoran.MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eRestoran.MobileApp.ViewModels
{
    public class NarudzbeViewModel
    {
        private readonly ApiService _narudzbaService = new ApiService("Narudzba");
        public NarudzbeViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<Narudzba> NarudzbaList { get; set; } = new ObservableCollection<Narudzba>();


        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            var list = await _narudzbaService.Get<IEnumerable<Narudzba>>(null);

            NarudzbaList.Clear();
            foreach (var narudzba in list)
            {
                if (narudzba.KlijentId == Global.prijavljeniKorisnik.KorisnikId)
                {
                    NarudzbaList.Add(narudzba);
                }
                
            }
        }
    }
}
