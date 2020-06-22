using System;
using System.Collections.Generic;
using System.Text;

namespace eRestoran.Model
{
    public class Obavijesti
    {
        public int ObavijestId { get; set; }
        public string Naziv { get; set; }
        public string Sadrzaj { get; set; }
        public string Datum { get; set; }
        public int UposlenikId { get; set; }

        public string Uposlenik { get; set; }
    }
}
