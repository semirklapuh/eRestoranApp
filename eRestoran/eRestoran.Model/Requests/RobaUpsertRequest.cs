using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eRestoran.Model.Requests
{
    public class RobaUpsertRequest
    {
        [Required(ErrorMessage = "Naziv je obavezno polje !")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Naziv mora biti dugo barem 2 karaktera !")]
        public string Naziv { get; set; }

        [Required(ErrorMessage = "Stanje je obavezno polje !")]
        public int Stanje { get; set; }

        [Required(ErrorMessage ="Šifra je obavezno polje ! ")]
        [StringLength(10,MinimumLength =2,ErrorMessage ="Šifra mora imati barem 2 karaktera !")]
        public string Sifra { get; set; }

        [Required(ErrorMessage = "Cijena je obavezno polje ! ")]
        [RegularExpression("^(?(?=99)99(\\.0+)?|([1-9]\\d?(\\.\\d+)?))$", ErrorMessage = "Cijena mora biti veća od 0 i manja od 100")]
        public double Cijena { get; set; }

        public int KategorijaId { get; set; }
        public int JedinicaMjereId { get; set; }
    }
}
