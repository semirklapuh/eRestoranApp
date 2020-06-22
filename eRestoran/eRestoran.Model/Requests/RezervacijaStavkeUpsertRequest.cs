using System;
using System.Collections.Generic;
using System.Text;

namespace eRestoran.Model.Requests
{
    public class RezervacijaStavkeUpsertRequest
    {
       public int RezervacijaId { get; set; }
        public int StolId { get; set; }
        public string Klijent { get; set; }
        public int KlijentId { get; set; }
    }
}
