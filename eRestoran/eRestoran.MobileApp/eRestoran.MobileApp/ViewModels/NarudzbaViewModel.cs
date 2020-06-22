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
    public class NarudzbaViewModel
    {
        private readonly ApiService _stavke = new ApiService("NarudzbaStavka");
        private readonly int _id;

        public ObservableCollection<NarudzbaStavke> stavkeNarudzbe { get; set; } = new ObservableCollection<NarudzbaStavke>();
        public NarudzbaViewModel(int id)
        {
            _id = id;
            InitCommand = new Command(async () => await Init(_id));
        }

        double _ukupno = 0;
        public double Ukupno
        {
            get { return _ukupno; }
            set { _ukupno = value; }
        }

        public async Task Init(int id)
        {
            stavkeNarudzbe.Clear();
            NarudzbaStavkeSearchRequest req = new NarudzbaStavkeSearchRequest()
            {
                NarudzbaId = id
            };
            var result = await _stavke.Get<List<NarudzbaStavke>>(req);
            foreach (var x in result)
            {
                Ukupno += x.Cijena * x.Kolicina;
                stavkeNarudzbe.Add(x);
            }
        }

        public ICommand InitCommand { get; set; }

    }
}
