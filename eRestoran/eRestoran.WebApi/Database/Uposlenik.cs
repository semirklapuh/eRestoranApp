using System;
using System.Collections.Generic;


namespace eRestoran.WebApi.Database
{
    public partial class Uposlenik
    {
        public int UposlenikId { get; set; }
        public DateTime DatumZaposljavanja { get; set; }
        public string JMBG { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public bool Status { get; set; }
        public int VrstaId { get; set; }
        public virtual VrstaUposlenika Vrsta { get; set; }

        public virtual Korisnik UposlenikNavigation { get; set; }
    }
}
