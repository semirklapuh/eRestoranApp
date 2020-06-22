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
    public class ObavijestController : BaseCRUDController<Model.Obavijesti, Model.Requests.ObavijestiSearchRequest, Model.Requests.ObavijestiUpsertRequest, Model.Requests.ObavijestiUpsertRequest>
    {
        public ObavijestController(ICRUDService<Obavijesti, ObavijestiSearchRequest, ObavijestiUpsertRequest, ObavijestiUpsertRequest> service) : base(service)
        {
        }
    }
}