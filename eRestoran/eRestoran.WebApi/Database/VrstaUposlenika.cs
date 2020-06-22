using System;
using System.Collections.Generic;


namespace eRestoran.WebApi.Database
{
    public partial class VrstaUposlenika
    {
        public VrstaUposlenika()
        {
            Uposlenik = new HashSet<Uposlenik>();
        }

        public int VrstaUposlenikaId { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Uposlenik> Uposlenik { get; set; }
    }
}
