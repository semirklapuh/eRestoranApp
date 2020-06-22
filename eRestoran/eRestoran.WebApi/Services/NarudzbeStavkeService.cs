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
    public class NarudzbeStavkeService : BaseCRUDService<Model.NarudzbaStavke, Model.Requests.NarudzbaStavkeSearchRequest, Database.NarudzbaStavke, Model.Requests.NarudzbeStavkeUpsertRequest, Model.Requests.NarudzbeStavkeUpsertRequest>
    {
        public NarudzbeStavkeService(eRestoranContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public override List<Model.NarudzbaStavke> Get(NarudzbaStavkeSearchRequest search)
        {
            List<Model.NarudzbaStavke> lista = new List<Model.NarudzbaStavke>();

            var narudzbastavke = _db.NarudzbaStavke.Include(x=> x.Jelo).AsQueryable();

            //if (!string.IsNullOrWhiteSpace(search.NarudzbaId.ToString()))
            //{
            //    narudzbastavke = narudzbastavke.Where(w => w.NarudzbaId == search.NarudzbaId);
            //}



            foreach (var item in narudzbastavke)
            {
                lista.Add(new Model.NarudzbaStavke
                {
                    NarudzbaStavkeId = item.NarudzbaStavkeId,
                    Cijena = item.Cijena,
                    Jelo = item.Jelo.Naziv,
                    JeloId = item.JeloId,
                    Kolicina = item.Kolicina,
                    NarudzbaId = item.NarudzbaId
                });
            }

            return lista;
        }

        public override Model.NarudzbaStavke GetById(int id)
        {
            var item = _db.NarudzbaStavke.Where(w => w.NarudzbaStavkeId == id)
                .Include(x => x.Jelo)
                .SingleOrDefault();


            Model.NarudzbaStavke model = new Model.NarudzbaStavke
            {
                NarudzbaStavkeId = item.NarudzbaStavkeId,
                Cijena = item.Cijena,
                Jelo = item.Jelo.Naziv,
                JeloId = item.JeloId,
                Kolicina = item.Kolicina,
                NarudzbaId = item.NarudzbaId
            };

            return model;
        }

        public override Model.NarudzbaStavke Insert(NarudzbeStavkeUpsertRequest request)
        {
            Database.NarudzbaStavke narudzbaStavke = new Database.NarudzbaStavke();

            request.NarudzbaId = _db.Narudzba.Where(x => x.DatumNarudžbe == request.datum).Select(x => x.NarudzbaId).FirstOrDefault();
            narudzbaStavke.Cijena = request.Cijena;
            narudzbaStavke.Kolicina = request.Kolicina;
            narudzbaStavke.NarudzbaId = request.NarudzbaId;
            narudzbaStavke.JeloId = request.JeloId;

            _db.Add(narudzbaStavke);

            _db.SaveChanges();

            return _mapper.Map<Model.NarudzbaStavke>(narudzbaStavke);

        }

        public override Model.NarudzbaStavke Update(int id, NarudzbeStavkeUpsertRequest request)
        {
            var narudzbaStavke = _db.NarudzbaStavke.Find(id);

            narudzbaStavke.Cijena = request.Cijena;
            narudzbaStavke.Kolicina = request.Kolicina;
            narudzbaStavke.NarudzbaId = request.NarudzbaId;

            _db.NarudzbaStavke.Attach(narudzbaStavke);
            _db.NarudzbaStavke.Update(narudzbaStavke);

            _db.SaveChanges();

            return _mapper.Map<Model.NarudzbaStavke>(narudzbaStavke);
        }

        public override void Delete(int id)
        {
            var entity = _db.NarudzbaStavke.Find(id);
            _db.SaveChanges();
        }
    }
}
