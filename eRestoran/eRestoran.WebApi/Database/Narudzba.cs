using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.WebApi.Database
{
    public partial  class Narudzba
    {
        public int NarudzbaId { get; set; }
        public DateTime DatumNarudžbe { get; set; }
        public bool Zavrsena { get; set; }
        public int KlijentId { get; set; }

        public virtual Klijent Klijent { get; set; }
    }
}
