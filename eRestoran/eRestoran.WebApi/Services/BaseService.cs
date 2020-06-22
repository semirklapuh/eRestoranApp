using AutoMapper;
using eRestoran.WebApi.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.WebApi.Services
{
    public class BaseService<TModel, TSearch, TDatabase> : IService<TModel, TSearch> where TDatabase : class
    {
        protected readonly eRestoranContext _db;
        protected readonly IMapper _mapper;
        public BaseService(eRestoranContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        public virtual List<TModel> Get(TSearch search)
        {
            var list = _db.Set<TDatabase>().ToList();
            return _mapper.Map<List<TModel>>(list);
        }

        public virtual TModel GetById(int id)
        {
            var entity = _db.Set<TDatabase>().Find(id);
            return _mapper.Map<TModel>(entity);
        }
    }
}
