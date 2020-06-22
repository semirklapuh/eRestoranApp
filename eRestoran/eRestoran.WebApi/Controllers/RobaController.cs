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

    public class RobaController : BaseCRUDController<Model.Roba, Model.Requests.RobaSearchRequest, Model.Requests.RobaUpsertRequest, Model.Requests.RobaUpsertRequest>
    {
        public RobaController(ICRUDService<Roba, RobaSearchRequest, RobaUpsertRequest, RobaUpsertRequest> service) : base(service)
        {
        }
    }
}