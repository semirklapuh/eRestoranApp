using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.WebApi.Database
{
    public partial class Roba
    {
      
        public int RobaId { get; set; }
        public string Naziv { get; set; }

        public int Stanje { get; set; }
        public string Sifra { get; set; }
        public double Cijena { get; set; }
        
        public int KategorijaId { get; set; }
        public virtual Kategorija Kategorija { get; set; }


        public int JedinicaMjereId { get; set; }
        public virtual JedinicaMjere JedinicaMjere { get; set; }


    }
}
