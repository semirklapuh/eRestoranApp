using System;
using System.Collections.Generic;
using System.Text;

namespace eRestoran.Model.Requests
{
    public class RobaSearchRequest
    {
        public string Naziv { get; set; }
        public int KategorijaId { get; set; }
    }
}
