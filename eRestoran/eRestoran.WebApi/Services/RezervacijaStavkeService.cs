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
    public class RezervacijaStavkeService : BaseCRUDService<Model.RezervacijaStavke, Model.Requests.RezervacijaStavkeSearchRequest, Database.RezervacijaStavke, Model.Requests.RezervacijaStavkeUpsertRequest, Model.Requests.RezervacijaStavkeUpsertRequest>
    {
        public RezervacijaStavkeService(eRestoranContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public override List<Model.RezervacijaStavke> Get(RezervacijaStavkeSearchRequest search)
        {
            List<Model.RezervacijaStavke> lista = new List<Model.RezervacijaStavke>();

            var rezervacijastavke = _db.RezervacijaStavke.Include(x => x.Rezervacija)
                                                         .Include(x=> x.Rezervacija.Klijent)
                                                         .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search.RezervacijaId.ToString()))
            {
                rezervacijastavke = rezervacijastavke.Where(w => w.RezervacijaId == search.RezervacijaId);
            }



            foreach (var item in rezervacijastavke)
            { 
                lista.Add(new Model.RezervacijaStavke
                {
                    RezervacijaStavkeId = item.RezervacijaStavkeId,
                    StolId = item.StolId
                });
            }

            return lista;
        }
        public override Model.RezervacijaStavke GetById(int id)
        {
            var item = _db.RezervacijaStavke.Where(w => w.RezervacijaStavkeId == id)
                .Include(x => x.Rezervacija)
                .Include(x=> x.Rezervacija.Klijent)
                .SingleOrDefault();


            Model.RezervacijaStavke model = new Model.RezervacijaStavke
            {
                RezervacijaStavkeId = item.RezervacijaStavkeId,
                StolId = item.StolId
            };

            return model;
        }

        public override Model.RezervacijaStavke Insert(RezervacijaStavkeUpsertRequest request)
        {
            Database.RezervacijaStavke rezervacijaStavke = new Database.RezervacijaStavke();

            rezervacijaStavke.StolId = request.StolId;
            rezervacijaStavke.RezervacijaId = request.RezervacijaId;
            _db.Add(rezervacijaStavke);

            _db.SaveChanges();

            return _mapper.Map<Model.RezervacijaStavke>(rezervacijaStavke);

        }
    }
}
