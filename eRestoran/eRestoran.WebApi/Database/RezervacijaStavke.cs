using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.WebApi.Database
{
    public partial class RezervacijaStavke
    {
        public int RezervacijaStavkeId { get; set; }
        public int RezervacijaId { get; set; }
        public virtual Rezervacija Rezervacija { get; set; }

        public int StolId { get; set; }
        public virtual Stol Stol { get; set; }


    }
}
