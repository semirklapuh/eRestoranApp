using System;
using System.Collections.Generic;
using System.Text;

namespace eRestoran.Model
{
    public class NarudzbaStavke
    {
        public int NarudzbaStavkeId { get; set; }
        public int Kolicina { get; set; }
        public double Cijena { get; set; }
        public int NarudzbaId { get; set; }
        public int JeloId { get; set; }
        public string Jelo { get; set; }
    }
}
