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

    public class KlijentController : BaseCRUDController<Model.Klijenti, Model.Requests.KlijentiSearchRequest, Model.Requests.KlijentUpsertRequest, Model.Requests.KlijentUpsertRequest>
    {
        public KlijentController(ICRUDService<Klijenti, KlijentiSearchRequest, KlijentUpsertRequest, KlijentUpsertRequest> service) : base(service)
        {
        }
    }
}