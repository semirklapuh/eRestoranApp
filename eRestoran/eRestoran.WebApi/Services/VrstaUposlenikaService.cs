using AutoMapper;
using eRestoran.Model;
using eRestoran.Model.Requests;
using eRestoran.WebApi.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.WebApi.Services
{
    public class VrstaUposlenikaService : BaseService<Model.VrstaUposlenika, VrstaUposlenikaSearchRequest, Database.VrstaUposlenika>
    {
        public VrstaUposlenikaService(eRestoranContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public override List<Model.VrstaUposlenika> Get(VrstaUposlenikaSearchRequest search)
        {
            return base.Get(search);
        }
    }
}
