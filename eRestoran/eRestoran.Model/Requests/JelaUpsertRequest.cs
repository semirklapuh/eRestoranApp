using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eRestoran.Model.Requests
{
    public class JelaUpsertRequest
    {
       
        [Required(ErrorMessage = "Naziv je obavezno polje !")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Naziv mora biti dugo barem 2 karaktera !")]
        public string Naziv { get; set; }

        [Required(ErrorMessage = "Cijena je obavezno polje ! ")]
        [RegularExpression("^(?(?=99)99(\\.0+)?|([1-9]\\d?(\\.\\d+)?))$", ErrorMessage = "Cijena mora biti veća od 0 i manja od 100")]
        public double Cijena { get; set; }

        [Required(ErrorMessage = "Opis je obavezno polje !")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Opis mora biti dugo barem 10 karaktera !")]
        public string Opis { get; set; }
        public int VrstaJelaId { get; set; }
    }
}
