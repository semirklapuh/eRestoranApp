using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace eRestoran.WebApi.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Database.Grad, Model.Grad>();
            CreateMap<Database.VrstaUposlenika, Model.VrstaUposlenika>();
            CreateMap<Database.Uposlenik, Model.Uposlenici>();
            CreateMap<Database.Kategorija, Model.Kategorije>();
            CreateMap<Database.Roba, Model.Roba>();
            CreateMap<Database.JedinicaMjere, Model.JedinicaMjere>();
            CreateMap<Database.VrstaJela, Model.VrsteJela>();
            CreateMap<Database.Jelo, Model.Jela>();
            CreateMap<Database.Narudzba, Model.Narudzbe>();
            CreateMap<Database.NarudzbaStavke, Model.NarudzbaStavke>();
            CreateMap<Database.Klijent, Model.Klijenti>();
            CreateMap<Database.Obavijest, Model.Obavijesti>();
            CreateMap<Database.Stol, Model.Stol>();
            CreateMap<Database.Rezervacija, Model.Rezervacije>();
            CreateMap<Database.RezervacijaStavke, Model.RezervacijaStavke>();
            CreateMap<Database.Nabavka, Model.Nabavke>();
            CreateMap<Database.NabavkaStavke, Model.NabavkaStavke>();

            CreateMap<Model.Requests.NabavkaStavkeUpsertRequest, Database.NabavkaStavke>();
            CreateMap<Model.Requests.NabavkeUpsertRequest, Database.Nabavka>();
            CreateMap<Model.Requests.RezervacijeUpsertRequest, Database.RezervacijaStavke>();
            CreateMap<Model.Requests.RezervacijeUpsertRequest, Database.Rezervacija>();
            CreateMap<Model.Requests.ObavijestiUpsertRequest, Database.Obavijest>();
            CreateMap<Model.Requests.KlijentUpsertRequest, Database.Klijent>();
            CreateMap<Model.Requests.NarudzbaUpsertRequest, Database.Narudzba>();
            CreateMap<Model.Requests.NarudzbeStavkeUpsertRequest, Database.NarudzbaStavke>();
            CreateMap<Model.Requests.JelaUpsertRequest, Database.Jelo>();
            CreateMap<Model.Requests.RobaUpsertRequest, Database.Roba>();
            CreateMap<Model.Requests.GradUpsertRequest, Database.Grad>();
            CreateMap<Model.Requests.UposleniciUpsertRequest, Database.Uposlenik>();
        }
    }
}
