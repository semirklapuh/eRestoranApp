using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eRestoran.Model;
using eRestoran.Model.Requests;
using eRestoran.WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eRestoran.WebApi.Controllers
{
    public class RezervacijaStavkeController : BaseCRUDController<Model.RezervacijaStavke, Model.Requests.RezervacijaStavkeSearchRequest, Model.Requests.RezervacijaStavkeUpsertRequest, Model.Requests.RezervacijaStavkeUpsertRequest>
    {
        public RezervacijaStavkeController(ICRUDService<RezervacijaStavke, RezervacijaStavkeSearchRequest, RezervacijaStavkeUpsertRequest, RezervacijaStavkeUpsertRequest> service) : base(service)
        {
        }
    }
}