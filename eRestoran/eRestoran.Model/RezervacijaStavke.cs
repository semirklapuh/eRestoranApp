using System;
using System.Collections.Generic;
using System.Text;

namespace eRestoran.Model
{
    public class RezervacijaStavke
    {
        public int RezervacijaStavkeId { get; set; }
        public int RezervacijaId { get; set; }
        public string Naziv { get; set; }
        public int StolId { get; set; }
        public int KlijentId { get; set; }
        public string Klijent { get; set; }

    }
}
