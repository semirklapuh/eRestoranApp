using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eRestoran.WebApi.Database;

namespace eRestoran.WebApi.Services
{
    public class StolService : BaseService<Model.Stol, Model.Requests.StolSearchRequest, Database.Stol>
    {
        public StolService(eRestoranContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public override List<Model.Stol> Get(Model.Requests.StolSearchRequest search)
        {
            return base.Get(search);
        }
    }
}
