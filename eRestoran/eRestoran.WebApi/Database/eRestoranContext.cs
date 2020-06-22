using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.WebApi.Database
{
    public partial class eRestoranContext : DbContext
    {
        public eRestoranContext()
        {

        }

        public eRestoranContext(DbContextOptions<eRestoranContext> options)
           : base(options)
        {
        }

        public virtual DbSet<Korisnik> Korisnik { get; set; }
        public virtual DbSet<Uposlenik> Uposlenik { get; set; }
        public virtual DbSet<Grad> Grad { get; set; }
        public virtual DbSet<VrstaUposlenika> VrstaUposlenika { get; set; }
        public virtual DbSet<Roba> Roba { get; set; }

        public virtual DbSet<Nabavka> Nabavka { get; set; }
        public virtual DbSet<NabavkaStavke> NabavkaStavke { get; set; }

        public virtual DbSet<Kategorija> Kategorija { get; set; }
        public virtual DbSet<JedinicaMjere> JedinicaMjere { get; set; }

        public virtual DbSet<Narudzba> Narudzba { get; set; }


        public virtual DbSet<NarudzbaStavke> NarudzbaStavke { get; set; }
        public virtual DbSet<Klijent> Klijent { get; set; }


        public virtual DbSet<Jelo> Jelo { get; set; }
        public virtual DbSet<VrstaJela> VrstaJela { get; set; }

        public virtual DbSet<Obavijest> Obavijest { get; set; }

        public virtual DbSet<Rezervacija> Rezervacija { get; set; }

        public virtual DbSet<RezervacijaStavke> RezervacijaStavke { get; set; }


        public virtual DbSet<Stol> Stol { get; set; }













        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=eRestoran;Trusted_Connection=True;");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grad>(entity =>
            {
                entity.Property(e => e.GradId).HasColumnName("GradID");

                entity.Property(e => e.Naziv).HasMaxLength(50);
            });

            modelBuilder.Entity<Korisnik>(entity =>
            {
                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.Adresa)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GradId).HasColumnName("GradID");

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.KorisnickoIme)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LozinkaHash)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.LozinkaSalt)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Telefon)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.Korisnik)
                    .HasForeignKey(d => d.GradId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Korisnik2_Grad");
            });

            modelBuilder.Entity<Uposlenik>(entity =>
            {
                entity.Property(e => e.UposlenikId)
                    .HasColumnName("UposlenikID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DatumRodjenja).HasColumnType("date");

                entity.Property(e => e.DatumZaposljavanja).HasColumnType("date");

                entity.Property(e => e.JMBG)
                    .IsRequired()
                    .HasColumnName("JMBG")
                    .HasMaxLength(50);



                entity.Property(e => e.VrstaId).HasColumnName("VrstaID");

                entity.HasOne(d => d.UposlenikNavigation)
                    .WithOne(p => p.Uposlenik)
                    .HasForeignKey<Uposlenik>(d => d.UposlenikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Uposlenik_Korisnik2");

                entity.HasOne(d => d.Vrsta)
                    .WithMany(p => p.Uposlenik)
                    .HasForeignKey(d => d.VrstaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Uposlenik_VrstaUposlenika");
            });
            modelBuilder.Entity<Klijent>(entity =>
            {
                entity.Property(e => e.KlijentId)
                    .HasColumnName("KlijentId")
                    .ValueGeneratedOnAdd();


                entity.HasOne(d => d.KlijentNavigation)
                    .WithOne(p => p.Klijent)
                    .HasForeignKey<Klijent>(d => d.KlijentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Klijent_Korisnik2");


            });

        }
    }
}
