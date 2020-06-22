using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eRestoran.Model.Requests;
using eRestoran.WebApi.Database;
using Microsoft.EntityFrameworkCore;

namespace eRestoran.WebApi.Services
{
    public class JelaService : BaseCRUDService<Model.Jela, Model.Requests.JelaSearchRequest, Database.Jelo, Model.Requests.JelaUpsertRequest, Model.Requests.JelaUpsertRequest>
    {
        public JelaService(eRestoranContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public override List<Model.Jela> Get(JelaSearchRequest search)
        {
            List<Model.Jela> lista = new List<Model.Jela>();

            var jela = _db.Jelo.Include(x => x.VrstaJela)
                               .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search.Naziv))
            {
                jela = jela.Where(w => w.Naziv == search.Naziv);
            }
            if (search.VrstaJelaId != 0)
            {
                jela = jela.Where(w => w.VrstaJelaId == search.VrstaJelaId);
            }


            foreach (var item in jela)
            {
                lista.Add(new Model.Jela
                {
                    JeloId = item.JeloId,
                    Naziv = item.Naziv,
                    Cijena = item.Cijena,
                    VrstaJela = item.VrstaJela.Naziv,
                    VrstaJelaId = item.VrstaJelaId,
                    Opis = item.Opis
                }); 
            }

            return lista;
        }

        public override Model.Jela GetById(int id)
        {
            var item = _db.Jelo.Where(w => w.JeloId == id)
                .Include(x => x.VrstaJela)
                .SingleOrDefault();


            Model.Jela model = new Model.Jela
            {
                JeloId = item.JeloId,
                Naziv = item.Naziv,
                Cijena = item.Cijena,
                VrstaJela = item.VrstaJela.Naziv,
                VrstaJelaId = item.VrstaJelaId,
                Opis = item.Opis
            };

            return model;
        }

        public override Model.Jela Insert(JelaUpsertRequest request)
        {
            Database.Jelo jelo = new Database.Jelo();

            jelo.Naziv = request.Naziv;
            jelo.Cijena = request.Cijena;
            jelo.Opis = request.Opis;
            jelo.VrstaJelaId = request.VrstaJelaId;
            _db.Add(jelo);

            _db.SaveChanges();

            return _mapper.Map<Model.Jela>(jelo);

        }


        public override Model.Jela Update(int id, JelaUpsertRequest request)
        {
            var jelo = _db.Jelo.Find(id);

            jelo.Naziv = request.Naziv;
            jelo.Cijena = request.Cijena;
            jelo.Opis = request.Opis;
            jelo.VrstaJelaId = request.VrstaJelaId;

            _db.Jelo.Attach(jelo);
            _db.Jelo.Update(jelo);

            _db.SaveChanges();

            return _mapper.Map<Model.Jela>(jelo);
        }

        public override void Delete(int id)
        {
            var entity = _db.Jelo.Find(id);
            _db.SaveChanges();
        }
    }
}
