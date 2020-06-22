using System;
using System.Collections.Generic;
using System.Text;

namespace eRestoran.Model
{
    public class Roba
    {
        public int RobaId { get; set; }
        public string Naziv { get; set; }
        public int Stanje { get; set; }
        public string Sifra { get; set; }
        public double Cijena { get; set; }

        public string Kategorija { get; set; }
        public int KategorijaId { get; set; }

        public string JedinicaMjere { get; set; }
        public int JedinicaMjereId { get; set; }


    }
}
