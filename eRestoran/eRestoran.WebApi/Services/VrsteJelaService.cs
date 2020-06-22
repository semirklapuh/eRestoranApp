using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eRestoran.WebApi.Database;

namespace eRestoran.WebApi.Services
{
    public class VrsteJelaService : BaseService<Model.VrsteJela, Model.Requests.VrsteJelaSearchRequest, Database.VrstaJela>
    {
        public VrsteJelaService(eRestoranContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public override List<Model.VrsteJela> Get(Model.Requests.VrsteJelaSearchRequest search)
        {
            return base.Get(search);
        }
    }
}
