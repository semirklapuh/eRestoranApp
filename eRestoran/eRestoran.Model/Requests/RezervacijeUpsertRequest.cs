using System;
using System.Collections.Generic;
using System.Text;

namespace eRestoran.Model.Requests
{
    public class RezervacijeUpsertRequest
    {
        public int RezervacijaId { get; set; }
        public string Naziv { get; set; }
        public int StolId { get; set; }
        public DateTime DatumRezervacije { get; set; }
        public int KlijentId { get; set; }
    }
}
