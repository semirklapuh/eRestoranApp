using System;
using System.Collections.Generic;
using System.Text;

namespace eRestoran.Model
{
    public class NabavkaStavke
    {
        public int RobaId { get; set; }
        public int NabavkaId { get; set; }
        public string Roba { get; set; }
        public double Cijena { get; set; }

        public int Dostavljeno { get; set; }

        public int Stanje { get; set; }
        public string Sifra { get; set; }
    }
}
