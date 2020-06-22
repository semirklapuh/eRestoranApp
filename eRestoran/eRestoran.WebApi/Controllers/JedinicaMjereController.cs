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
    public class JedinicaMjereController : BaseController<Model.JedinicaMjere, Model.Requests.JedinicaMjereSearchRequest>
    {
        public JedinicaMjereController(IService<Model.JedinicaMjere, JedinicaMjereSearchRequest> service) : base(service)
        {
        }
    }
}