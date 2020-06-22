using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.WebApi.Database
{
    public partial class Jelo
    {
        public int JeloId { get; set; }
        public string Naziv { get; set; }
        public double Cijena { get; set; }
        public string Opis { get; set; }
        public int VrstaJelaId { get; set; }
        public virtual VrstaJela VrstaJela { get; set; }
    }
}
