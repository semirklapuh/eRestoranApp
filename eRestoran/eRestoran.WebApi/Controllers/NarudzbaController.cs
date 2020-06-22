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

    public class NarudzbaController : BaseCRUDController<Model.Narudzbe, Model.Requests.NarudzbeSearchRequest, Model.Requests.NarudzbaUpsertRequest, Model.Requests.NarudzbaUpsertRequest>
    {
        public NarudzbaController(ICRUDService<Narudzbe, NarudzbeSearchRequest, NarudzbaUpsertRequest, NarudzbaUpsertRequest> service) : base(service)
        {
        }


    }
}