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
    public class RezervacijaController : BaseCRUDController<Model.Rezervacije, Model.Requests.RezervacijaSearchRequest, Model.Requests.RezervacijeUpsertRequest, Model.Requests.RezervacijeUpsertRequest>
    {
        public RezervacijaController(ICRUDService<Rezervacije, RezervacijaSearchRequest, RezervacijeUpsertRequest, RezervacijeUpsertRequest> service) : base(service)
        {
        }
    }
}