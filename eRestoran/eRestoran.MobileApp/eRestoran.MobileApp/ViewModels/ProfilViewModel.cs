using eRestoran.MobileApp.Models;
using eRestoran.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eRestoran.MobileApp.ViewModels
{
    public class ProfilViewModel
    {
        private readonly ApiService _narudzbe = new ApiService("Narudzba");
        public ObservableCollection<Narudzba> Narudzbe { get; set; } = new ObservableCollection<Narudzba>();


        public ProfilViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public string Ime { get; } = Global.prijavljeniKorisnik.Ime;
        public string Prezime { get; } = Global.prijavljeniKorisnik.Prezime;
        public string Korisnicko { get; } = Global.prijavljeniKorisnik.KorisnickoIme;
        public string Adresa { get; } = Global.prijavljeniKorisnik.Adresa;
        public string Telefon { get; } = Global.prijavljeniKorisnik.Telefon;
        public string Grad { get; } = Global.prijavljeniKorisnik.Grad;
        public string Lozinka { get; } = string.Empty;
        public string LozinkaNova { get; } = string.Empty;
        public string LozinkaPotvrda { get; } = string.Empty;

        public ICommand InitCommand { get; set; }
        public async Task Init()
        {
            NarudzbeSearchRequest req = new NarudzbeSearchRequest()
            {
                KlijentId = Global.prijavljeniKorisnik.KorisnikId
            };
            var list = await _narudzbe.Get<List<Model.Narudzbe>>(req);

            foreach (var x in list)
            {
                Narudzba nova = new Narudzba()
                {
                    NarudzbaId = x.NarudzbaId,
                    DatumNarudžbe = x.DatumNarudžbe,
                    Zavrsena = x.Zavrsena,
                    KlijentId = x.KlijentId
                };
                Narudzbe.Add(nova);
            }
        }

    }
}
