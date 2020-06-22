using System;
using System.Collections.Generic;
using System.Text;

namespace eRestoran.Model
{
    public class Nabavke
    {
        public int NabavkaId { get; set; }
        public DateTime DatumNabavke { get; set; }
        public bool Zavrsena { get; set; }
        public int UposlenikId { get; set; }
        public string ImePrezime { get; set; }
        public double Cijena { get; set; }
    }
}
