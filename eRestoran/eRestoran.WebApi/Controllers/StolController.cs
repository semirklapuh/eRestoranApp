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

    public class StolController : BaseController<Model.Stol, Model.Requests.StolSearchRequest>
    {
        public StolController(IService<Stol, StolSearchRequest> service) : base(service)
        {
        }

    }
}