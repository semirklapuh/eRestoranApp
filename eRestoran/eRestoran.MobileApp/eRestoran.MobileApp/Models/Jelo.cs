using System;
using System.Collections.Generic;
using System.Text;

namespace eRestoran.MobileApp.Models
{
    public class Jelo
    {
        public int JeloId { get; set; }
        public string Naziv { get; set; }

        public double Cijena { get; set; }
        public string Opis { get; set; }
        public int VrstaJelaId { get; set; }
        public string VrstaJela { get; set; }
    }
}
