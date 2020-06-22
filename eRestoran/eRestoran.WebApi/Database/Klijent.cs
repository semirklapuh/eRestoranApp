using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.WebApi.Database
{
    public partial class Klijent
    {
        public int KlijentId { get; set; }
        
        public DateTime DatumRegistracije { get; set; }
        public int BrojNarudzbi { get; set; }

        public virtual Korisnik KlijentNavigation { get; set; }
    }
}
