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
    public class RezervacijeService : BaseCRUDService<Model.Rezervacije, Model.Requests.RezervacijaSearchRequest, Database.Rezervacija, Model.Requests.RezervacijeUpsertRequest, Model.Requests.RezervacijeUpsertRequest>
    {
        public RezervacijeService(eRestoranContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public override List<Model.Rezervacije> Get(RezervacijaSearchRequest search)
        {
            List<Model.Rezervacije> lista = new List<Model.Rezervacije>();

            var rezervacija = _db.Rezervacija.AsQueryable();

            if (search.KlijentId != 0)
            {
                rezervacija = rezervacija.Where(w => w.KlijentId == search.KlijentId);

            }
            if (!string.IsNullOrWhiteSpace(search.Ime))
            {
                rezervacija = rezervacija.Where(w => w.Klijent.KlijentNavigation.Ime == search.Ime);

            }
            if (!string.IsNullOrWhiteSpace(search.Prezime))
            {
                rezervacija = rezervacija.Where(w => w.Klijent.KlijentNavigation.Prezime == search.Prezime);

            }


            //rezervacija = rezervacija.Where(w => w.DatumRezervacije.Day.Equals(search.DatumRezervacije.Day) && w.DatumRezervacije.Month.Equals(search.DatumRezervacije.Month));

            foreach (var item in rezervacija)
            {
                var Ime = _db.Korisnik.Where(w => w.KorisnikId == item.KlijentId)
                    .Select(w=> w.Ime)
                    .FirstOrDefault();
                var Prezime = _db.Korisnik.Where(w => w.KorisnikId == item.KlijentId)
                    .Select(w => w.Prezime)
                    .FirstOrDefault();
                
                var rezervacijaStavke = _db.RezervacijaStavke.Where(w => w.RezervacijaId == item.RezervacijaId)
                                                             .Include(x=> x.Stol)                    
                                                             .FirstOrDefault();
                lista.Add(new Model.Rezervacije
                {
                    RezervacijaId = item.RezervacijaId,
                    Naziv = item.Naziv,
                    StolId = rezervacijaStavke.StolId,
                    DatumEvidencije = item.DatumEvidencije,
                    DatumRezervacije = item.DatumRezervacije,
                    KlijentId = item.KlijentId,
                    Ime = Ime,
                    Prezime = Prezime
                });
            }
            return lista;
        }
        public override Model.Rezervacije GetById(int id)
        {
            var item = _db.Rezervacija.Where(w => w.RezervacijaId == id)
                                             .Include(w => w.Klijent)
                                             .SingleOrDefault();


      
            var Ime = _db.Korisnik.Where(w => w.KorisnikId == item.KlijentId)
               .Select(w => w.Ime)
               .FirstOrDefault();
            var Prezime = _db.Korisnik.Where(w => w.KorisnikId == item.KlijentId)
                                        .Select(w => w.Prezime)
                                        .FirstOrDefault();
            var rezervacijaStavke = _db.RezervacijaStavke.Where(w => w.RezervacijaId == item.RezervacijaId)
                                                         .Include(x => x.Stol)
                                                         .FirstOrDefault();
            Model.Rezervacije model = new Model.Rezervacije
            {
                RezervacijaId = item.RezervacijaId,
                Naziv = item.Naziv,
                StolId = rezervacijaStavke.StolId,
                DatumEvidencije = item.DatumEvidencije,
                DatumRezervacije = item.DatumRezervacije,
                KlijentId = item.KlijentId,
                Ime = Ime,
                Prezime = Prezime
            };


            return model;
        }
        public override Model.Rezervacije Update(int id, RezervacijeUpsertRequest request)
        {
            var _rezervacija = _db.Rezervacija.Find(id);
            var _rezervacijaStavke = _db.RezervacijaStavke.Find(_rezervacija.RezervacijaId);

            _rezervacija.Naziv = request.Naziv;
            _rezervacija.DatumRezervacije = request.DatumRezervacije;
            _rezervacija.KlijentId = request.KlijentId;

            _db.Rezervacija.Attach(_rezervacija);
            _db.Rezervacija.Update(_rezervacija);


            _rezervacijaStavke.StolId = request.StolId;
            _rezervacijaStavke.RezervacijaId = _rezervacija.RezervacijaId;
            _db.RezervacijaStavke.Attach(_rezervacijaStavke);
            _db.RezervacijaStavke.Update(_rezervacijaStavke);

            _db.SaveChanges();

            return _mapper.Map<Model.Rezervacije>(_rezervacija);
        }

        public override Model.Rezervacije Insert(RezervacijeUpsertRequest request)
        {
            Database.RezervacijaStavke rezervacijaStavke = new Database.RezervacijaStavke();
            Database.Rezervacija rezervacija = new Database.Rezervacija();

            var datum = DateTime.Now;
            rezervacija.DatumEvidencije = datum;
            rezervacija.DatumRezervacije = request.DatumRezervacije;
            rezervacija.KlijentId = request.KlijentId;
            rezervacija.Naziv = request.Naziv;
            _db.Add(rezervacija);


            rezervacijaStavke.StolId = request.StolId;
            rezervacijaStavke.RezervacijaId = rezervacija.RezervacijaId;

            _db.RezervacijaStavke.Add(rezervacijaStavke);
            _db.SaveChanges();

            return _mapper.Map<Model.Rezervacije>(rezervacija);

        }


    }
}
