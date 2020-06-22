using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.WebApi.Database
{
    public partial class Korisnik
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

        public virtual Grad Grad { get; set; }
        public virtual Uposlenik Uposlenik { get; set; }
        public virtual Klijent Klijent { get; set; }

    }
}
