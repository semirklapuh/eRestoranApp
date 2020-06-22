using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eRestoran.Model.Requests
{
    public class ObavijestiUpsertRequest
    {

        public int ObavijestId { get; set; }
        public string Naziv { get; set; }

        [Required(ErrorMessage = "Sadrzaj je obavezno polje ! ")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Sadrzaj mora imati najmanje 10 slova !")]
        public string Sadrzaj { get; set; }
        public DateTime Datum { get; set; }

        public int UposlenikId { get; set; }
    }
}
