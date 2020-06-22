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
    public class ObavijestiService : BaseCRUDService<Model.Obavijesti, Model.Requests.ObavijestiSearchRequest, Database.Obavijest, Model.Requests.ObavijestiUpsertRequest, Model.Requests.ObavijestiUpsertRequest>
    {
        public ObavijestiService(eRestoranContext db, IMapper mapper) : base(db, mapper)
        {
        }


        public override List<Model.Obavijesti> Get(ObavijestiSearchRequest search)
        {
            List<Model.Obavijesti> lista = new List<Model.Obavijesti>();

            var obavijesti = _db.Obavijest.Include(x => x.Uposlenik).AsQueryable();

            if (!string.IsNullOrWhiteSpace(search.Naziv))
            {
                obavijesti = obavijesti.Where(w => w.Naziv == search.Naziv);
            }

            foreach (var item in obavijesti)
            {
                var uposlenik = _db.Korisnik.Where(w => w.KorisnikId == item.UposlenikId).Select(w => w.Ime + " " + w.Prezime).FirstOrDefault();
                lista.Add(new Model.Obavijesti
                {
                    Naziv = item.Naziv,
                    Sadrzaj = item.Sadrzaj,
                    ObavijestId = item.ObavijestId,
                    Datum = item.Datum.ToString("dd.MM.yyyy hh:mm"),
                    Uposlenik = uposlenik,
                    UposlenikId = item.UposlenikId
                });
            }
            if (search.Naziv != null)
            {
                lista = lista.Where(x => x.Naziv.ToLower().Contains(search.Naziv.ToLower())).ToList();
            }
            return lista;
        }


        public override Model.Obavijesti GetById(int id)
        {

            var item = _db.Obavijest.Where(w=> w.ObavijestId == id)
                .Include(x => x.Uposlenik)
                .SingleOrDefault();

            var uposlenik = _db.Korisnik.Where(w => w.KorisnikId == item.UposlenikId)
                                        .Select(w=> w.Ime + " " + w.Prezime)
                                        .FirstOrDefault();

            Model.Obavijesti model = new Model.Obavijesti
            {
                Naziv = item.Naziv,
                Sadrzaj = item.Sadrzaj,
                ObavijestId = item.ObavijestId,
                Datum = item.Datum.ToString("dd.MM.yyyy hh:mm"),
                Uposlenik = uposlenik,
                UposlenikId = item.UposlenikId
            };

            return model;

        }


        public override Model.Obavijesti Update(int id, ObavijestiUpsertRequest request)
        {
            var obavijest = _db.Obavijest.Find(id);

            obavijest.Naziv = request.Naziv;
            obavijest.Sadrzaj = request.Sadrzaj;
            obavijest.UposlenikId = request.UposlenikId;
            obavijest.Datum = request.Datum;


            _db.Obavijest.Attach(obavijest);
            _db.Obavijest.Update(obavijest);

            _db.SaveChanges();

            return _mapper.Map<Model.Obavijesti>(obavijest);
        }

        public override Model.Obavijesti Insert(ObavijestiUpsertRequest request)
        {
            Database.Obavijest obavijest = new Database.Obavijest();

            obavijest.Naziv = request.Naziv;
            obavijest.Sadrzaj = request.Sadrzaj;
            obavijest.UposlenikId = request.UposlenikId;
            obavijest.Datum = request.Datum;
            _db.Add(obavijest);

            _db.SaveChanges();

            return _mapper.Map<Model.Obavijesti>(obavijest);

        }
    }
}
