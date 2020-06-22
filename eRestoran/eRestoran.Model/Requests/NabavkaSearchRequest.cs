using System;
using System.Collections.Generic;
using System.Text;

namespace eRestoran.Model.Requests
{
    public class NabavkaSearchRequest
    {
        public DateTime DatumNabavke { get; set; }
        public bool Zavrsena { get; set; }
    }
}
