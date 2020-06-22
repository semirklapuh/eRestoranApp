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
    public class KategorijaController : BaseController<Model.Kategorije, KategorijeSearchRequest>
    {
        public KategorijaController(IService<Model.Kategorije, KategorijeSearchRequest> service) : base(service)
        {
        }
    }
}