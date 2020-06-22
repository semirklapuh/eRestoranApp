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
    public class GradService : BaseCRUDService<Model.Grad, GradSearchRequest, Database.Grad, GradUpsertRequest, GradUpsertRequest>
    {
        public GradService(eRestoranContext db, IMapper mapper) : base(db, mapper)
        {
        }


        public override List<Model.Grad> Get(GradSearchRequest search)
        {
            var query = _db.Grad.AsQueryable();


            if (!string.IsNullOrWhiteSpace(search.Naziv))
            {
                query = query.Where(w => w.Naziv == search.Naziv);
            }
            return _mapper.Map<List<Model.Grad>>(query);
        }
    }
}
