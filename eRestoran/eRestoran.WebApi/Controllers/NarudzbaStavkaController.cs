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

    public class NarudzbaStavkaController : BaseCRUDController<Model.NarudzbaStavke, Model.Requests.NarudzbaStavkeSearchRequest, Model.Requests.NarudzbeStavkeUpsertRequest, Model.Requests.NarudzbeStavkeUpsertRequest>
    {
        public NarudzbaStavkaController(ICRUDService<Model.NarudzbaStavke, NarudzbaStavkeSearchRequest, NarudzbeStavkeUpsertRequest, NarudzbeStavkeUpsertRequest> service) : base(service)
        {
        }
    }
}