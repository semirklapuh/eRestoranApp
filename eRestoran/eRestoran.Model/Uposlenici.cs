using System;
using System.Collections.Generic;
using System.Text;

namespace eRestoran.Model
{
    public class Uposlenici
    {
        public int KorisnikId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public string KorisnickoIme { get; set; }
        public string LozinkaHash { get; set; }
        public string LozinkaSalt { get; set; }
        public string Telefon { get; set; }
        public int GradId { get; set; }
        public string Grad { get; set; }

        public DateTime DatumZaposljavanja { get; set; }
        public string JMBG { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public bool Status { get; set; }
        public string StatusS { get; set; }

        public int VrstaUposlenikaId { get; set; }
        public string VrstaUposlenika { get; set; }
    }
    
}
