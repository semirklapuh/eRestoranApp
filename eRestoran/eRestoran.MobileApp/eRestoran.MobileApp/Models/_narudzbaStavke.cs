using eRestoran.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace eRestoran.MobileApp.Models
{
    public class _narudzbaStavke
    {
        public int _narudzbaStavkeId { get; set; }
        public int Kolicina { get; set; }
        public double Cijena { get; set; }
        public int NarudzbaId { get; set; }
        public int JeloId { get; set; }
        public Jela Jelo { get; set; }
        
    }
}
