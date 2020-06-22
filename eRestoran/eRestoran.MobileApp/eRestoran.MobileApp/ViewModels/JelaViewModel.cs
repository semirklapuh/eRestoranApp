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
    public class JelaViewModel : BaseViewModel
    {
        private readonly ApiService _jeloService = new ApiService("Jelo");
        private readonly ApiService _vrstaJelaService = new ApiService("VrstaJela");
        public JelaViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<Jela> JelaList { get; set; } = new ObservableCollection<Jela>();
        public ObservableCollection<VrsteJela> VrsteJelaList { get; set; } = new ObservableCollection<VrsteJela>();

        VrsteJela _SelectedVrstaJela = null;
        public VrsteJela SelectedVrstaJela
        {
            get { return _SelectedVrstaJela; }
            set { SetProperty(ref _SelectedVrstaJela, value);
                if (value != null)
                {
                    InitCommand.Execute(null);
                }
                
            }
        }
        public ICommand InitCommand { get; set; }

        public async Task Init()
        {

            if (VrsteJelaList.Count==0)
            {
                var vrsteJelaList = await _vrstaJelaService.Get<List<VrsteJela>>(null);
                foreach (var vrsta in vrsteJelaList)
                {
                    VrsteJelaList.Add(vrsta);
                }
            }

            if (SelectedVrstaJela != null)
            {
                JelaSearchRequest search = new JelaSearchRequest();
                search.VrstaJelaId = SelectedVrstaJela.VrstaJelaId;

                var list = await _jeloService.Get<IEnumerable<Jela>>(search);
                JelaList.Clear();
                foreach (var jelo in list)
                {
                    JelaList.Add(jelo);
                }

            }



        }
    }
}
