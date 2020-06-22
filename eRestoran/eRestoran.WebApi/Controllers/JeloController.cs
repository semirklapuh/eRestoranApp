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
    public class JeloController : BaseCRUDController<Model.Jela, Model.Requests.JelaSearchRequest, Model.Requests.JelaUpsertRequest, Model.Requests.JelaUpsertRequest>
    {
        public JeloController(ICRUDService<Jela, JelaSearchRequest, JelaUpsertRequest, JelaUpsertRequest> service) : base(service)
        {
        }



    }
}