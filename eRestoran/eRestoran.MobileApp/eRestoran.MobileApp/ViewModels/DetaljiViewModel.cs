using eRestoran.Model;
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
    public class DetaljiViewModel :BaseViewModel
    {
        private readonly ApiService _jeloService = new ApiService("Jelo");
        private readonly ApiService _vrstaJelaService = new ApiService("VrstaJela");
        public DetaljiViewModel(int JeloId)
        {
            InitCommand = new Command(async () => await Init(JeloId));
        }
        string _naziv = string.Empty;
        public string Naziv
        {
            get { return _naziv; }
            set { SetProperty(ref _naziv, value); }
        }
        string _opis = string.Empty;
        public string Opis
        {
            get { return _opis; }
            set { SetProperty(ref _opis, value); }
        }
        double _cijena = 0;
        public double Cijena
        {
            get { return _cijena; }
            set { SetProperty(ref _cijena, value); }
        }
        public ObservableCollection<Jela> JelaList { get; set; } = new ObservableCollection<Jela>();
        public ObservableCollection<VrsteJela> VrsteJelaList { get; set; } = new ObservableCollection<VrsteJela>();

        public Jela Jelo = new Jela();
        VrsteJela _SelectedVrstaJela = null;

        public ICommand InitCommand { get; set; }

        public async Task Init(int JeloId)
        {


            Jelo = await _jeloService.GetById<Jela>(JeloId);
            int a = 0;
            Naziv = Jelo.Naziv;
            Cijena = Jelo.Cijena;
            Opis = Jelo.Opis;
            //if (VrsteJelaList.Count == 0)
            //{
            //    var vrsteJelaList = await _vrstaJelaService.Get<List<VrsteJela>>(null);
            //    foreach (var vrsta in vrsteJelaList)
            //    {
            //        VrsteJelaList.Add(vrsta);
            //    }
            //}

            //if (SelectedVrstaJela != null)
            //{
            //    JelaSearchRequest search = new JelaSearchRequest();
            //    search.VrstaJelaId = SelectedVrstaJela.VrstaJelaId;

            //    var list = await _jeloService.Get<IEnumerable<Jela>>(search);
            //    JelaList.Clear();
            //    foreach (var jelo in list)
            //    {
            //        JelaList.Add(jelo);
            //    }

            //}
            
        }
    }
}
