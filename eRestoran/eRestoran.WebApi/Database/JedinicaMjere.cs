using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.WebApi.Database
{
    public partial class JedinicaMjere
    {
        [Key]
        public int JedinicaMjereId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
    }
}
