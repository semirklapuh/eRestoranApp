
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eRestoran.WebApi.Database;
using eRestoran.Model.Requests;
using Microsoft.EntityFrameworkCore;
using eRestoran.Model;

namespace eRestoran.WebApi.Services
{
    public class RobaService : BaseCRUDService<Model.Roba, Model.Requests.RobaSearchRequest, Database.Roba, Model.Requests.RobaUpsertRequest, Model.Requests.RobaUpsertRequest>
    {
        public RobaService(eRestoranContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public override List<Model.Roba> Get(RobaSearchRequest search)
        {
            List<Model.Roba> lista = new List<Model.Roba>();

            var roba = _db.Roba.Include(x => x.Kategorija)
                               .Include(x => x.JedinicaMjere)
                               .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search.Naziv))
            {
                roba = roba.Where(w => w.Naziv == search.Naziv);
            }
            if(search.KategorijaId != 0)
            {
                roba = roba.Where(w => w.KategorijaId == search.KategorijaId);
            }


            foreach (var item in roba)
            {
                lista.Add(new Model.Roba
                {
                    RobaId = item.RobaId,
                    Naziv = item.Naziv,
                    Sifra = item.Sifra,
                    Cijena = item.Cijena,
                    JedinicaMjere = item.JedinicaMjere.Naziv,
                    JedinicaMjereId = item.JedinicaMjereId,
                    Kategorija = item.Kategorija.Opis,
                    KategorijaId = item.KategorijaId,
                    Stanje = item.Stanje
                });
            }

            return lista;
        }

        public override Model.Roba GetById(int id)
        {
            var item = _db.Roba.Where(w => w.RobaId == id)
                .Include(x => x.Kategorija)
                .Include(x => x.JedinicaMjere)
                .SingleOrDefault();


            Model.Roba model = new Model.Roba
            {
                RobaId = item.RobaId,
                Naziv = item.Naziv,
                Sifra = item.Sifra,
                Cijena = item.Cijena,
                JedinicaMjere = item.JedinicaMjere.Naziv,
                JedinicaMjereId = item.JedinicaMjereId,
                Kategorija = item.Kategorija.Opis,
                KategorijaId = item.KategorijaId,
                Stanje = item.Stanje
            };

            return model;
        }

        public override Model.Roba Insert(RobaUpsertRequest request)
        {
            Database.Roba roba = new Database.Roba();

            roba.Naziv = request.Naziv;
            roba.Sifra = request.Sifra;
            roba.Cijena = request.Cijena;
            roba.JedinicaMjereId = request.JedinicaMjereId;
            roba.KategorijaId = request.KategorijaId;
            roba.Stanje = request.Stanje;
            _db.Add(roba);

            _db.SaveChanges();

            return _mapper.Map<Model.Roba>(roba);

        }

        public override Model.Roba Update(int id, RobaUpsertRequest request)
        {
            var roba = _db.Roba.Find(id);

            roba.Naziv = request.Naziv;
            roba.Sifra = request.Sifra;
            roba.Cijena = request.Cijena;
            roba.JedinicaMjereId = request.JedinicaMjereId;
            roba.KategorijaId = request.KategorijaId;
            roba.Stanje = request.Stanje;

            _db.Roba.Attach(roba);
            _db.Roba.Update(roba);

            _db.SaveChanges();

            return _mapper.Map<Model.Roba>(roba);
        }

        public override void Delete(int id)
        {
            var entity = _db.Roba.Find(id);
            _db.SaveChanges();
        }
    }
}
