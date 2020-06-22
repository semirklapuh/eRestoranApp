using System;
using System.Collections.Generic;
using System.Text;

namespace eRestoran.Model.Requests
{
    public class NarudzbeStavkeUpsertRequest
    {
        public int Kolicina { get; set; }
        public double Cijena { get; set; }
        public int NarudzbaId { get; set; }
        public string Narudzba { get; set; }
        public string Jelo { get; set; }
        public int JeloId { get; set; }
        public DateTime datum { get; set; }
    }
}
