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

    public class NabavkaStavkeController : BaseCRUDController<Model.NabavkaStavke, Model.Requests.NabavkaStavkeSearchRequest, Model.Requests.NabavkaStavkeUpsertRequest, Model.Requests.NabavkaStavkeUpsertRequest>
    {
        public NabavkaStavkeController(ICRUDService<NabavkaStavke, NabavkaStavkeSearchRequest, NabavkaStavkeUpsertRequest, NabavkaStavkeUpsertRequest> service) : base(service)
        {
        }
    }
}