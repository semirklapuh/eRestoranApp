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
    public class NarudzbaService : BaseCRUDService<Model.Narudzbe, Model.Requests.NarudzbeSearchRequest, Database.Narudzba, Model.Requests.NarudzbaUpsertRequest, Model.Requests.NarudzbaUpsertRequest>
    {
        public NarudzbaService(eRestoranContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public override List<Model.Narudzbe> Get(NarudzbeSearchRequest search)
        {
            List<Model.Narudzbe> lista = new List<Model.Narudzbe>();

            var narudzba = _db.Narudzba.AsQueryable();
            if (search.KlijentId != 0)
            {
                narudzba = narudzba.Where(w => w.KlijentId == search.KlijentId);
            }
            //if (search.Zavrsena)
            //{
            //    narudzba = narudzba.Where(w => w.Zavrsena);
            //}
            //else
            //{
            //    narudzba = narudzba.Where(w => !w.Zavrsena);

            //}

           // narudzba = narudzba.Where(w => w.DatumNarudžbe.Day.Equals(search.DatumNarudzbe.Day) && w.DatumNarudžbe.Month.Equals(search.DatumNarudzbe.Month));



            foreach (var item in narudzba)
            {
                lista.Add(new Model.Narudzbe
                {
                    NarudzbaId = item.NarudzbaId,
                    DatumNarudžbe = item.DatumNarudžbe,
                    Zavrsena = item.Zavrsena,
                    KlijentId = item.KlijentId,
                    Klijent = _db.Korisnik.Where(w => w.KorisnikId == item.KlijentId).Select(w => w.Ime + " " + w.Prezime).FirstOrDefault()
            });
            }

            return lista;
        }

        public override Model.Narudzbe GetById(int id)
        {
            var item = _db.Narudzba.Where(w => w.NarudzbaId == id)
                .Include(x => x.Klijent)
                .SingleOrDefault();

            var klijentime = _db.Korisnik.Where(w => w.KorisnikId == item.KlijentId).Select(w=> w.Ime + " " +  w.Prezime).FirstOrDefault();
            Model.Narudzbe model = new Model.Narudzbe
            {
                NarudzbaId = item.NarudzbaId,
                DatumNarudžbe = item.DatumNarudžbe,
                Zavrsena = item.Zavrsena,
                KlijentId = item.KlijentId,
                Klijent = klijentime
            };

            return model;
        }

     
        public override Model.Narudzbe Update(int id, NarudzbaUpsertRequest request)
        {
  
            var obj = _db.Narudzba.Find(id);

            obj.Zavrsena = true;
            _db.Narudzba.Update(obj);
            _db.SaveChanges();
            var novi = _mapper.Map<Model.Narudzbe>(obj);
            return novi;
       
        }

        public override void Delete(int id)
        {
            var entity = _db.Narudzba.Find(id);
            _db.SaveChanges();
        }

        public override Model.Narudzbe Insert(NarudzbaUpsertRequest request)
        {
            
            Database.Narudzba narudzba = new Database.Narudzba();

            var datum = DateTime.Now;
            narudzba.DatumNarudžbe = request.DatumNarudžbe;
            narudzba.KlijentId = request.KlijentId;
            narudzba.Zavrsena = true;
            _db.Add(narudzba);
            _db.SaveChanges();
            
           

            return _mapper.Map<Model.Narudzbe>(narudzba);

        }

    }

}

