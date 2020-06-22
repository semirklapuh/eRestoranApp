using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.WebApi.Database
{
    public class Obavijest
    {
        public int ObavijestId { get; set; }
        public string Naziv { get; set; }
        public string Sadrzaj { get; set; }
        public DateTime Datum { get; set; }

        public int UposlenikId { get; set; }
        public virtual Uposlenik Uposlenik { get; set; }


    }
}
