using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eRestoran.WebApi.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using eRestoran.WebApi.Services;
using eRestoran.Model.Requests;
using Swashbuckle.AspNetCore.Swagger;
using AutoMapper;

namespace eRestoran.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAutoMapper(typeof(Startup));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });



            var connection = @"Server=.;Database=eRestoran2;Trusted_Connection=True;ConnectRetryCount=0";

            services.AddDbContext<eRestoranContext>(options => options.UseSqlServer(connection));


            services.AddScoped<ICRUDService<Model.Grad, GradSearchRequest, GradUpsertRequest, GradUpsertRequest>, GradService>();
            services.AddScoped<IService<Model.VrstaUposlenika, VrstaUposlenikaSearchRequest>, VrstaUposlenikaService>();
            services.AddScoped<ICRUDService<Model.Uposlenici, UposleniciSearchRequest, UposleniciUpsertRequest, UposleniciUpsertRequest>, UposleniciService>();
            services.AddScoped<ICRUDService<Model.Roba, RobaSearchRequest, RobaUpsertRequest,RobaUpsertRequest>, RobaService>();
            services.AddScoped<IService<Model.Kategorije, KategorijeSearchRequest>, KategorijeService>();
            services.AddScoped<IService<Model.JedinicaMjere, JedinicaMjereSearchRequest>, JedinicaMjereService>();
            services.AddScoped<IService<Model.VrsteJela, VrsteJelaSearchRequest>, VrsteJelaService>();
            services.AddScoped<ICRUDService<Model.Jela, JelaSearchRequest, JelaUpsertRequest, JelaUpsertRequest>, JelaService>();
            services.AddScoped<ICRUDService<Model.Narudzbe, NarudzbeSearchRequest, NarudzbaUpsertRequest, NarudzbaUpsertRequest>, NarudzbaService>();
            services.AddScoped<ICRUDService<Model.NarudzbaStavke, NarudzbaStavkeSearchRequest, NarudzbeStavkeUpsertRequest, NarudzbeStavkeUpsertRequest>, NarudzbeStavkeService>();
            services.AddScoped<ICRUDService<Model.Klijenti, KlijentiSearchRequest, KlijentUpsertRequest, KlijentUpsertRequest>, KlijentiService>();
            services.AddScoped<ICRUDService<Model.Obavijesti, ObavijestiSearchRequest, ObavijestiUpsertRequest, ObavijestiUpsertRequest>, ObavijestiService>();
            services.AddScoped<IService<Model.Stol, StolSearchRequest>, StolService>();
            services.AddScoped<ICRUDService<Model.Rezervacije, RezervacijaSearchRequest, RezervacijeUpsertRequest, RezervacijeUpsertRequest>, RezervacijeService>();
            services.AddScoped<ICRUDService<Model.RezervacijaStavke, RezervacijaStavkeSearchRequest, RezervacijaStavkeUpsertRequest, RezervacijaStavkeUpsertRequest>, RezervacijaStavkeService>();
            services.AddScoped<ICRUDService<Model.Nabavke, NabavkaSearchRequest, NabavkeUpsertRequest, NabavkeUpsertRequest>, NabavkeService>();
            services.AddScoped<ICRUDService<Model.NabavkaStavke, NabavkaStavkeSearchRequest, NabavkaStavkeUpsertRequest, NabavkaStavkeUpsertRequest>, NabavkaStavkeService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
