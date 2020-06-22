using System;
using System.Collections.Generic;
using System.Text;

namespace eRestoran.Model
{
    public class Jela
    {
        public int JeloId { get; set; }
        public string Naziv { get; set; }

        public double Cijena { get; set; }
        public string Opis { get; set; }
        public int VrstaJelaId { get; set; }
        public string VrstaJela { get; set; }
    }
}
