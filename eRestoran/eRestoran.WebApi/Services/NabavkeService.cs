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
    public class NabavkeService : BaseCRUDService<Model.Nabavke, Model.Requests.NabavkaSearchRequest, Database.Nabavka, Model.Requests.NabavkeUpsertRequest, Model.Requests.NabavkeUpsertRequest>
    {
        public NabavkeService(eRestoranContext db, IMapper mapper) : base(db, mapper)
        {
        }



        public override List<Model.Nabavke>Get(NabavkaSearchRequest search)
        {
            List<Model.Nabavke> lista = new List<Model.Nabavke>();
            var nabavka = _db.Nabavka.AsQueryable();

            if (search.Zavrsena)
            {
                nabavka = nabavka.Where(w => w.Zavrsena);
            }
            else
            {
                nabavka = nabavka.Where(w => !w.Zavrsena);
            }
            nabavka = nabavka.Where(w => w.DatumNabavke.Day.Equals(search.DatumNabavke.Day) && w.DatumNabavke.Month.Equals(search.DatumNabavke.Month));

            foreach (var item in nabavka)
            {
                var cijena = 0.0;
                var ns = _db.NabavkaStavke.Where(w => w.NabavkaId == item.NabavkaId).ToList();
                foreach (var stavka in ns)
                {
                    cijena += stavka.Cijena;
                }
                lista.Add(new Model.Nabavke
                {
                    NabavkaId = item.NabavkaId,
                    UposlenikId = item.UposlenikId,
                    ImePrezime = _db.Korisnik.Where(w => w.KorisnikId == item.UposlenikId).Select(w => w.Ime + " " + w.Prezime).FirstOrDefault(),
                    Zavrsena = item.Zavrsena,
                    DatumNabavke = item.DatumNabavke,
                    Cijena = cijena

                }); 
            }


            return lista;
        }

        public override Model.Nabavke GetById(int id)
        {
            var item = _db.Nabavka.Where(w => w.NabavkaId == id)
                .Include(w => w.Uposlenik)
                .SingleOrDefault();


            Model.Nabavke model = new Model.Nabavke
            {
                NabavkaId = item.NabavkaId,
                UposlenikId = item.UposlenikId,
                ImePrezime = _db.Korisnik.Where(w => w.KorisnikId == item.UposlenikId).Select(w => w.Ime + " " + w.Prezime).FirstOrDefault(),
                Zavrsena = item.Zavrsena,
                DatumNabavke = item.DatumNabavke
            };

            return model;
        }

        public override Model.Nabavke Update(int id, NabavkeUpsertRequest request)
        {

            var obj = _db.Nabavka.Find(id);

            obj.Zavrsena = true;

            var narudzbaStavke = _db.NabavkaStavke.Where(w => w.NabavkaId == id).ToList();

            foreach (var stavka in narudzbaStavke)
            {
                var roba = _db.Roba.Where(w => w.RobaId == stavka.RobaId).FirstOrDefault();
                roba.Stanje += stavka.Kolicina;
                _db.Roba.Update(roba);
            }

            _db.Nabavka.Update(obj);
            _db.SaveChanges();
            var novi = _mapper.Map<Model.Nabavke>(obj);
            return novi;

        }

        public override Model.Nabavke Insert(NabavkeUpsertRequest request)
        {

            Database.Nabavka nabavka = new Database.Nabavka();


            nabavka.Zavrsena = false;
            nabavka.DatumNabavke = DateTime.Now;
            nabavka.UposlenikId = request.UposlenikId;

            _db.Add(nabavka);

           _db.SaveChanges();
            return _mapper.Map<Model.Nabavke>(nabavka);



        }
    


    }
}
