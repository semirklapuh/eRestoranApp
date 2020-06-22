using AutoMapper;
using eRestoran.Model;
using eRestoran.Model.Requests;
using eRestoran.WebApi.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.WebApi.Services
{
    public class KategorijeService : BaseService<Kategorije, KategorijeSearchRequest, Kategorija>
    {
        public KategorijeService(eRestoranContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public override List<Model.Kategorije> Get(KategorijeSearchRequest search)
        {
            return base.Get(search);
        }
        
    }
}
