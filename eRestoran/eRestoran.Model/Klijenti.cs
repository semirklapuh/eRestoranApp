using System;
using System.Collections.Generic;
using System.Text;

namespace eRestoran.Model
{
    public class Klijenti
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

        public DateTime DatumRegistracije { get; set; }
        public int BrojNarudzbi { get; set; }
    }
}
