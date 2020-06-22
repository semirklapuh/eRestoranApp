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
    public class UposlenikController : BaseCRUDController<Uposlenici, UposleniciSearchRequest, UposleniciUpsertRequest, UposleniciUpsertRequest>
    {
        public UposlenikController(ICRUDService<Uposlenici, UposleniciSearchRequest, UposleniciUpsertRequest, UposleniciUpsertRequest> service) : base(service)
        {
        }

        
    }
}