using System;
using System.Collections.Generic;
using System.Text;

namespace eRestoran.Model.Requests
{
    public class NarudzbeSearchRequest
    {
        public DateTime DatumNarudzbe { get; set; }
        public bool Zavrsena { get; set; }
        public int KlijentId { get; set; }
    }
}
