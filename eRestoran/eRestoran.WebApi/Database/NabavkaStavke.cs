using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.WebApi.Database
{
    public partial class NabavkaStavke
    {
        [Key]
        public int DetaljiNarudzbeId { get; set; }
        public int Kolicina { get; set; }
        public double Cijena { get; set; }
        public int NabavkaId { get; set; }
        public virtual Nabavka Nabavka { get; set; }

        public int RobaId { get; set; }

        public virtual Roba Roba { get; set; }

    }
}
