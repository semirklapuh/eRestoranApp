using System;
using System.Collections.Generic;
using System.Text;

namespace eRestoran.Model.Requests
{
    public class JelaSearchRequest
    {
        public int VrstaJelaId { get; set; }
        public string Naziv { get; set; }
    }
}
