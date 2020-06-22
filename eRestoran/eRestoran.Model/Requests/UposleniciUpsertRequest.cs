using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eRestoran.Model.Requests
{
    public class UposleniciUpsertRequest
    {
        [Required(ErrorMessage = "Ime je obavezno polje !")]
        [StringLength(15, MinimumLength = 4, ErrorMessage = "Ime mora biti dugo barem 4 karaktera !")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Prezime je obavezno polje !")]
        [StringLength(15, MinimumLength = 4, ErrorMessage = "Prezime mora biti dugo barem 4 karaktera !")]
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Adresa je obavezno polje !")]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "Adresa mora sadržavati barem 4 karaktera !")]
        public string Adresa { get; set; }
        [Required(ErrorMessage = "Korisnicko ime je obavezno polje !")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "Korisnicko ime mora biti dugo barem 4 karaktera !")]
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        [Required(ErrorMessage = "Telefon je obavezno polje !")]

        public string Telefon { get; set; }
        public int GradId { get; set; }

        public DateTime DatumZaposljavanja { get; set; }
        [Required(ErrorMessage = "JMBG je obavezno polje !")]
        public string JMBG { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public bool Status { get; set; }

        public int VrstaUposlenikaId { get; set; }

    }
}
