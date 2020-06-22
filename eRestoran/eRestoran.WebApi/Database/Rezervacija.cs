using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.WebApi.Database
{
    public partial class Rezervacija
    {
        public int RezervacijaId { get; set; }
        public string Naziv { get; set; }

        public DateTime DatumEvidencije { get; set; }
        public DateTime DatumRezervacije { get; set; }
        public int KlijentId { get; set; }
        public virtual Klijent Klijent { get; set; }

    }
}
