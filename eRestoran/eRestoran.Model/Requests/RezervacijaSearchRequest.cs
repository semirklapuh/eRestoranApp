using System;
using System.Collections.Generic;
using System.Text;

namespace eRestoran.Model.Requests
{
    public class RezervacijaSearchRequest
    {
        public DateTime DatumRezervacije { get; set; }
        public int KlijentId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
    }
}
