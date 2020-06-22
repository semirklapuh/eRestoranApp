using eRestoran.MobileApp.Models;
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
    public class VaseRezervacijeViewModel :BaseViewModel
    {
        private readonly ApiService _RezervacijaService = new ApiService("Rezervacija");
        public ObservableCollection<Rezervacije> Narudzbe { get; set; } = new ObservableCollection<Rezervacije>();


        public VaseRezervacijeViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        int _klijentId = 0;
        public int KlijentId
        {
            get { return _klijentId; }
            set { SetProperty(ref _klijentId, value); }
        }

        public ICommand InitCommand { get; set; }

        public ObservableCollection<Rezervacije> RezervacijeList { get; set; } = new ObservableCollection<Rezervacije>();
        public async Task Init()
        {
            KlijentId = Global.prijavljeniKorisnik.KorisnikId;
            var list = await _RezervacijaService.Get<IEnumerable<Rezervacije>>(null);

            RezervacijeList.Clear();
            foreach (var item in list)
            {
                if (item.KlijentId == KlijentId)
                {
                    RezervacijeList.Add(item);
                }
                   
                              
            }
        }
    }
}
