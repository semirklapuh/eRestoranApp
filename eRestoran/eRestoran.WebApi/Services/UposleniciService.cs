using AutoMapper;
using eRestoran.Model;
using eRestoran.Model.Requests;
using eRestoran.WebApi.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.WebApi.Services
{
    public class UposleniciService : BaseCRUDService<Uposlenici, UposleniciSearchRequest, Database.Uposlenik, UposleniciUpsertRequest, UposleniciUpsertRequest>
    {
        public UposleniciService(eRestoranContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public override List<Uposlenici> Get(UposleniciSearchRequest search)
        {
            List<Uposlenici> lista = new List<Uposlenici>();

            var uposlenik = _db.Uposlenik.Include(x => x.Vrsta).Include(x => x.UposlenikNavigation.Grad).AsQueryable();

            if (!string.IsNullOrWhiteSpace(search.Ime))
            {
                uposlenik = uposlenik.Where(x => x.UposlenikNavigation.Ime.StartsWith(search.Ime));
            }

            if(search.VrstaId != 0)
            {
                uposlenik = uposlenik.Where(w => w.VrstaId == search.VrstaId);
            }

            foreach (var item in uposlenik)
            {
                lista.Add(new Uposlenici
                {
                    KorisnikId = item.UposlenikId,
                    Ime = item.UposlenikNavigation.Ime,
                    Prezime = item.UposlenikNavigation.Prezime,
                    KorisnickoIme = item.UposlenikNavigation.KorisnickoIme,
                    Telefon = item.UposlenikNavigation.Telefon,
                    Grad = item.UposlenikNavigation.Grad.Naziv,
                    VrstaUposlenika = item.Vrsta.Naziv,
                    VrstaUposlenikaId = item.VrstaId,
                    Status = item.Status
                });
            }

            foreach (var item in lista)
            {
                if (item.Status == true)
                    item.StatusS = "Radi";
                else { item.StatusS = "Ne radi"; }
            }
            return lista;
        }

        public override Uposlenici GetById(int id)
        {

            var uposlenik = _db.Uposlenik.Where(x => x.UposlenikId == id).Include(x => x.UposlenikNavigation).Include(x => x.UposlenikNavigation.Grad).Include(x => x.Vrsta).SingleOrDefault();

            Uposlenici model = new Uposlenici
            {
                KorisnikId = uposlenik.UposlenikId,
                Ime = uposlenik.UposlenikNavigation.Ime,
                Prezime = uposlenik.UposlenikNavigation.Prezime,
                KorisnickoIme = uposlenik.UposlenikNavigation.KorisnickoIme,
                Telefon = uposlenik.UposlenikNavigation.Telefon,
                Grad = uposlenik.UposlenikNavigation.Grad.Naziv,
                GradId = uposlenik.UposlenikNavigation.GradId,
                VrstaUposlenika = uposlenik.Vrsta.Naziv,
                VrstaUposlenikaId = uposlenik.VrstaId,
                Adresa = uposlenik.UposlenikNavigation.Adresa,
                JMBG = uposlenik.JMBG,
                DatumZaposljavanja = uposlenik.DatumZaposljavanja,
                DatumRodjenja = uposlenik.DatumRodjenja,
                Status = uposlenik.Status
            };

            return model;
        }

        public override Uposlenici Insert(UposleniciUpsertRequest request)
        {
            Korisnik korisnik = new Korisnik();
            Uposlenik uposlenik = new Uposlenik();



            korisnik.Ime = request.Ime;
            korisnik.Prezime = request.Prezime;
            korisnik.Adresa = request.Adresa;
            korisnik.KorisnickoIme = request.KorisnickoIme;
            korisnik.LozinkaSalt = GenerateSalt();
            korisnik.LozinkaHash = GenerateHash(korisnik.LozinkaSalt, request.Lozinka);
            korisnik.Telefon = request.Telefon;
            korisnik.GradId = request.GradId;
            _db.Korisnik.Add(korisnik);

            uposlenik.DatumRodjenja = request.DatumRodjenja;
            uposlenik.DatumZaposljavanja = request.DatumZaposljavanja;
            uposlenik.JMBG = request.JMBG;
            uposlenik.VrstaId = request.VrstaUposlenikaId;
            uposlenik.Status = request.Status;
            uposlenik.UposlenikId = korisnik.KorisnikId;

            _db.Uposlenik.Add(uposlenik);

            _db.SaveChanges();

            return _mapper.Map<Uposlenici>(uposlenik);




        }
        public override Uposlenici Update(int id, UposleniciUpsertRequest request)
        {
            var _korisnik = _db.Korisnik.Find(id);
            var _uposlenik = _db.Uposlenik.Find(id);

            _korisnik.Ime = request.Ime;
            _korisnik.Prezime = request.Prezime;
            _korisnik.Adresa = request.Adresa;
            _korisnik.KorisnickoIme = request.KorisnickoIme;
            if(request.Lozinka != "")
            {
                _korisnik.LozinkaSalt = GenerateSalt();
                _korisnik.LozinkaHash = GenerateHash(_korisnik.LozinkaSalt, request.Lozinka);
            }

            _korisnik.Telefon = request.Telefon;
            _korisnik.GradId = request.GradId;
            _db.Korisnik.Attach(_korisnik);
            _db.Korisnik.Update(_korisnik);

            _uposlenik.DatumRodjenja = request.DatumRodjenja;
            _uposlenik.DatumZaposljavanja = request.DatumZaposljavanja;
            _uposlenik.JMBG = request.JMBG;
            _uposlenik.VrstaId = request.VrstaUposlenikaId;
            _uposlenik.Status = request.Status;
            _uposlenik.UposlenikId = _korisnik.KorisnikId;

            _db.Uposlenik.Attach(_uposlenik);
            _db.Uposlenik.Update(_uposlenik);

            _db.SaveChanges();
            return _mapper.Map<Uposlenici>(_uposlenik);
        }

        public override void Delete(int id)
        {
            var entity = _db.Uposlenik.Find(id);
            entity.Status = true;
            _db.SaveChanges();
        }
    }
}
