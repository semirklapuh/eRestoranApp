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
    public class NabavkaStavkeService : BaseCRUDService<Model.NabavkaStavke, Model.Requests.NabavkaStavkeSearchRequest, Database.NabavkaStavke, Model.Requests.NabavkaStavkeUpsertRequest, Model.Requests.NabavkaStavkeUpsertRequest>
    {
        public NabavkaStavkeService(eRestoranContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public override List<Model.NabavkaStavke> Get(NabavkaStavkeSearchRequest search)
        {
            List<Model.NabavkaStavke> lista = new List<Model.NabavkaStavke>();
            var nabavkaStavke = _db.NabavkaStavke.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search.NabavkaId.ToString()))
            {
                nabavkaStavke = nabavkaStavke.Where(w => w.NabavkaId == search.NabavkaId);
            }
            foreach (var item in nabavkaStavke)
            {
                lista.Add(new Model.NabavkaStavke
                {
                    NabavkaId = item.NabavkaId,
                    RobaId = item.RobaId,
                    Cijena = item.Cijena,
                    Roba = _db.Roba.Where(w=> w.RobaId == item.RobaId).Select(w=> w.Naziv).FirstOrDefault(),
                    Sifra = _db.Roba.Where(w=> w.RobaId == item.RobaId).Select(w=> w.Sifra).FirstOrDefault(),
                    Dostavljeno = item.Kolicina,
                    Stanje = _db.Roba.Where(w=> w.RobaId == item.RobaId).Select(w=> w.Stanje).FirstOrDefault()
                });
            }


            return lista;
        }
        public override Model.NabavkaStavke GetById(int id)
        {
            var item = _db.NabavkaStavke.Where(w => w.DetaljiNarudzbeId == id)
                .Include(x => x.Nabavka)
                .Include(x=> x.Nabavka.Uposlenik)
                .Include(x=> x.Roba)
                .SingleOrDefault();


            Model.NabavkaStavke model = new Model.NabavkaStavke
            {
                NabavkaId = item.NabavkaId,
                RobaId = item.RobaId,
                Cijena = item.Cijena,
                Roba = _db.Roba.Where(w => w.RobaId == item.RobaId).Select(w => w.Naziv).FirstOrDefault(),
                Sifra = _db.Roba.Where(w => w.RobaId == item.RobaId).Select(w => w.Sifra).FirstOrDefault(),
                Stanje = _db.Roba.Where(w => w.RobaId == item.RobaId).Select(w => w.Stanje).FirstOrDefault()
            };

            return model;
        }


        public override Model.NabavkaStavke Insert(NabavkaStavkeUpsertRequest request)
        {
            Database.NabavkaStavke nabavkaStavke = new Database.NabavkaStavke();


            nabavkaStavke.NabavkaId = request.NabavkaId;
            nabavkaStavke.Kolicina = request.Kolicina;
            nabavkaStavke.RobaId = request.RobaId;
            nabavkaStavke.Cijena = _db.Roba.Where(w => w.RobaId == request.RobaId).Select(w => w.Cijena).FirstOrDefault() * request.Kolicina;

            _db.NabavkaStavke.Add(nabavkaStavke);
            _db.SaveChanges();

            return _mapper.Map<Model.NabavkaStavke>(nabavkaStavke);
        }

    }
}
