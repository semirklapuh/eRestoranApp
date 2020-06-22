using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eRestoran.WebApi.Database;

namespace eRestoran.WebApi.Services
{
    public class JedinicaMjereService : BaseService<Model.JedinicaMjere, Model.Requests.JedinicaMjereSearchRequest, Database.JedinicaMjere>
    {
        public JedinicaMjereService(eRestoranContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public override List<Model.JedinicaMjere> Get(Model.Requests.JedinicaMjereSearchRequest search)
        {
            return base.Get(search);
        }
    }
}
