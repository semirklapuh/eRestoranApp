using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eRestoran.Model;
using eRestoran.Model.Requests;
using eRestoran.WebApi.Database;
using Microsoft.EntityFrameworkCore;

namespace eRestoran.WebApi.Services
{
    public class KlijentiService : BaseCRUDService<Model.Klijenti, Model.Requests.KlijentiSearchRequest, Database.Klijent, Model.Requests.KlijentUpsertRequest, Model.Requests.KlijentUpsertRequest>
    {
        public KlijentiService(eRestoranContext db, IMapper mapper) : base(db, mapper)
        {
        }


        public override List<Model.Klijenti> Get(KlijentiSearchRequest search)
        {
            List<Model.Klijenti> lista = new List<Model.Klijenti>();

            var klijent = _db.Klijent.Include(x => x.KlijentNavigation)
                                  .Include(x=> x.KlijentNavigation.Grad)
                                  .AsQueryable();

            if(!string.IsNullOrWhiteSpace(search.Korisnicko))
            {
                klijent = klijent.Where(x => x.KlijentNavigation.KorisnickoIme == search.Korisnicko);
                foreach (var item in klijent)
                {
                    lista.Add(new Model.Klijenti
                    {
                        KorisnikId = item.KlijentId,
                        Ime = item.KlijentNavigation.Ime,
                        Prezime = item.KlijentNavigation.Prezime,
                        KorisnickoIme = item.KlijentNavigation.KorisnickoIme,
                        Telefon = item.KlijentNavigation.Telefon,
                        Adresa = item.KlijentNavigation.Adresa,
                        Grad = item.KlijentNavigation.Grad.Naziv,
                        DatumRegistracije = item.DatumRegistracije,
                        BrojNarudzbi = item.BrojNarudzbi,
                    });
                }
                return lista;
            }

            
            foreach (var item in klijent)
            {
                lista.Add(new Model.Klijenti
                {
                    KorisnikId = item.KlijentId,
                    Ime = item.KlijentNavigation.Ime,
                    Prezime = item.KlijentNavigation.Prezime,
                    KorisnickoIme = item.KlijentNavigation.KorisnickoIme,
                    Telefon = item.KlijentNavigation.Telefon,
                    Adresa = item.KlijentNavigation.Adresa,
                    Grad = item.KlijentNavigation.Grad.Naziv,
                    DatumRegistracije = item.DatumRegistracije,
                    BrojNarudzbi = item.BrojNarudzbi,
                });
            }
            if (search.Test != null)
            {
                lista = lista.Where(x => x.Ime.ToLower().Contains(search.Test.ToLower()) ||
                  x.Prezime.ToLower().Contains(search.Test.ToLower()) ||
                  x.Grad.ToLower().Contains(search.Test.ToLower()) ||
                  x.KorisnickoIme.ToLower().Contains(search.Test.ToLower()) ||
                  x.Adresa.ToLower().Contains(search.Test.ToLower())).ToList();
            }
            return lista;
        }

        public override Klijenti GetById(int id)
        {
            var klijent = _db.Klijent.Where(x => x.KlijentId == id)
                                    .Include(x => x.KlijentNavigation)
                                    .Include(x => x.KlijentNavigation.Grad)
                                    .SingleOrDefault();

            Klijenti model = new Klijenti();
            model.KorisnikId = klijent.KlijentId;
            model.Ime = klijent.KlijentNavigation.Ime;
            model.Prezime = klijent.KlijentNavigation.Prezime;
            model.KorisnickoIme = klijent.KlijentNavigation.KorisnickoIme;
            model.Telefon = klijent.KlijentNavigation.Telefon;
            model.Grad = klijent.KlijentNavigation.Grad.Naziv;
            model.GradId = klijent.KlijentNavigation.GradId;
            model.Adresa = klijent.KlijentNavigation.Adresa;
            model.DatumRegistracije = klijent.DatumRegistracije;
            model.BrojNarudzbi = klijent.BrojNarudzbi;


            return model;
        }
        public override Klijenti Insert(KlijentUpsertRequest request)
        {
            Korisnik korisnik = new Korisnik();
            Klijent klijent = new Klijent();



            korisnik.Ime = request.Ime;
            korisnik.Prezime = request.Prezime;
            korisnik.Adresa = request.Adresa;
            korisnik.KorisnickoIme = request.KorisnickoIme;
            korisnik.LozinkaSalt = GenerateSalt();
            korisnik.LozinkaHash = GenerateHash(korisnik.LozinkaSalt, request.Lozinka);
            korisnik.Telefon = request.Telefon;
            korisnik.GradId = request.GradID;

            _db.Korisnik.Add(korisnik);

            klijent.DatumRegistracije = DateTime.Now;
            klijent.BrojNarudzbi = request.BrojNarudzbi;
            klijent.KlijentId = korisnik.KorisnikId;


            _db.Klijent.Add(klijent);

            _db.SaveChanges();
            return _mapper.Map<Klijenti>(klijent);


        }
        public override Klijenti Update(int id, Model.Requests.KlijentUpsertRequest request)
        {
            var _korisnik = _db.Korisnik.Find(id);
            var _klijent = _db.Klijent.Find(id);
            if (request.Ime == null && request.Prezime == null)
            { 
                _klijent.BrojNarudzbi += request.BrojNarudzbi;

                _db.Klijent.Update(_klijent);

                _db.SaveChanges();

                Model.Klijenti ret = null;
                return ret;
            }


            _korisnik.Ime = request.Ime;
            _korisnik.Prezime = request.Prezime;
            _korisnik.Adresa = request.Adresa;
            _korisnik.KorisnickoIme = request.KorisnickoIme;
            if (request.Lozinka != "")
            {
                _korisnik.LozinkaSalt = GenerateSalt();
                _korisnik.LozinkaHash = GenerateHash(_korisnik.LozinkaSalt, request.Lozinka);
            }

            _korisnik.Telefon = request.Telefon;
            _korisnik.GradId = request.GradID;
            _db.Korisnik.Attach(_korisnik);
            _db.Korisnik.Update(_korisnik);

            _klijent.DatumRegistracije = request.DatumRegistracije;
            _klijent.BrojNarudzbi = request.BrojNarudzbi    ;
            _klijent.KlijentId = _korisnik.KorisnikId;



            _db.Klijent.Attach(_klijent);
            _db.Klijent.Update(_klijent);

            _db.SaveChanges();
            return _mapper.Map<Klijenti>(_klijent);
        }
    }
}
