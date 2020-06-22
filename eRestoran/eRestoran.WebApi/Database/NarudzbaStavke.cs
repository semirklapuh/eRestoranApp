using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.WebApi.Database
{
    public partial class NarudzbaStavke
    {
        public int NarudzbaStavkeId { get; set; }
        public int Kolicina { get; set; }
        public double Cijena { get; set; }
        public int NarudzbaId { get; set; }
        public int JeloId { get; set; }

        public virtual Jelo Jelo { get; set; }
        public virtual Narudzba Narudzba { get; set; }
    }
}
