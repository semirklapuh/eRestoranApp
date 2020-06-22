using System;
using System.Collections.Generic;
using System.Text;

namespace eRestoran.Model.Requests
{
    public class NabavkeUpsertRequest
    {
        public int NabavkaId { get; set; }
        public bool Zavrsena { get; set; }

        public int UposlenikId { get; set; }
    }
}
