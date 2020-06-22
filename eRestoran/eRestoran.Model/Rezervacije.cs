using System;
using System.Collections.Generic;
using System.Text;

namespace eRestoran.Model
{
    public class Rezervacije
    {
        public int RezervacijaId { get; set; }
        public string Naziv { get; set; }
        public DateTime DatumEvidencije { get; set; }
        public DateTime DatumRezervacije { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int StolId { get; set; }
        public int KlijentId { get; set; }
    }
}
