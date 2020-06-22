using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eRestoran.Model.Requests
{
    public class KlijentUpsertRequest
    {
        public string Ime { get; set; }

        public string Prezime { get; set; }
        [Required(ErrorMessage = "Adresa je obavezno polje !")]
        [MinLength(4, ErrorMessage = "Adresa mora sadržavati više od 4 karaktera !")]
        public string Adresa { get; set; }
        [Required(ErrorMessage = "Korisnicko ime je obavezno polje !")]
        [MinLength(4, ErrorMessage = "Korisnicko ime mora sadržavati više od 4 karaktera !")]
        public string KorisnickoIme { get; set; }
        [Required(ErrorMessage = "Lozinka je obavezno polje !")]
        [MinLength(4, ErrorMessage = "Lozinka mora sadržavati više od 4 karaktera !")]
        public string Lozinka { get; set; }
        [Required]
        //[RegularExpression("/(?/d{3}/)?[-/.]? */d{3}[-/.]? *[-/.]?/d{3}")]
        public string Telefon { get; set; }
        public int GradID { get; set; }
        public DateTime DatumRegistracije { get; set; }
        public int BrojNarudzbi { get; set; }
    }
}
