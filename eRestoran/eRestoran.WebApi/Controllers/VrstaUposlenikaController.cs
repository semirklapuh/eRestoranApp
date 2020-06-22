using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eRestoran.Model;
using eRestoran.Model.Requests;
using eRestoran.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace eRestoran.WebApi.Controllers
{
    public class VrstaUposlenikaController : BaseController<Model.VrstaUposlenika,VrstaUposlenikaSearchRequest>
    {
        public VrstaUposlenikaController(IService<VrstaUposlenika, VrstaUposlenikaSearchRequest> service) : base(service)
        {
        }

       
    }
}