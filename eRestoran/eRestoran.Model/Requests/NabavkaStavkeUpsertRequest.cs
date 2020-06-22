using System;
using System.Collections.Generic;
using System.Text;

namespace eRestoran.Model.Requests
{
    public class NabavkaStavkeUpsertRequest
    {
        public int NabavkaId { get; set; }
        public int Kolicina { get; set; }

        public int RobaId { get; set; }
        public double Cijena { get; set; }
    }
}
