using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.WebApi.Database
{
    public partial class Nabavka
    {
        public int NabavkaId { get; set; }
        public DateTime DatumNabavke { get; set; }
        public bool Zavrsena { get; set; }

        public int UposlenikId { get; set; }
        public virtual Uposlenik Uposlenik { get; set; }



    }
}
