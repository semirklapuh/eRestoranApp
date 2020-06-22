using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eRestoran.WebApi.Migrations
{
    public partial class PrvaMigra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grad",
                columns: table => new
                {
                    GradID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grad", x => x.GradID);
                });

            migrationBuilder.CreateTable(
                name: "JedinicaMjere",
                columns: table => new
                {
                    JedinicaMjereId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JedinicaMjere", x => x.JedinicaMjereId);
                });

            migrationBuilder.CreateTable(
                name: "Kategorija",
                columns: table => new
                {
                    KategorijaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorija", x => x.KategorijaId);
                });

            migrationBuilder.CreateTable(
                name: "VrstaJela",
                columns: table => new
                {
                    VrstaJelaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrstaJela", x => x.VrstaJelaId);
                });

            migrationBuilder.CreateTable(
                name: "VrstaUposlenika",
                columns: table => new
                {
                    VrstaUposlenikaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrstaUposlenika", x => x.VrstaUposlenikaId);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    KorisnikID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(maxLength: 50, nullable: false),
                    Prezime = table.Column<string>(maxLength: 50, nullable: false),
                    Adresa = table.Column<string>(maxLength: 50, nullable: false),
                    KorisnickoIme = table.Column<string>(maxLength: 50, nullable: false),
                    LozinkaHash = table.Column<string>(maxLength: 255, nullable: false),
                    LozinkaSalt = table.Column<string>(maxLength: 255, nullable: false),
                    Telefon = table.Column<string>(maxLength: 50, nullable: false),
                    GradID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.KorisnikID);
                    table.ForeignKey(
                        name: "FK_Korisnik2_Grad",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Roba",
                columns: table => new
                {
                    RobaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    Stanje = table.Column<int>(nullable: false),
                    Sifra = table.Column<string>(nullable: true),
                    Cijena = table.Column<double>(nullable: false),
                    KategorijaId = table.Column<int>(nullable: false),
                    JedinicaMjereId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roba", x => x.RobaId);
                    table.ForeignKey(
                        name: "FK_Roba_JedinicaMjere_JedinicaMjereId",
                        column: x => x.JedinicaMjereId,
                        principalTable: "JedinicaMjere",
                        principalColumn: "JedinicaMjereId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Roba_Kategorija_KategorijaId",
                        column: x => x.KategorijaId,
                        principalTable: "Kategorija",
                        principalColumn: "KategorijaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jelo",
                columns: table => new
                {
                    JeloId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    Cijena = table.Column<double>(nullable: false),
                    Opis = table.Column<string>(nullable: true),
                    VrstaJelaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jelo", x => x.JeloId);
                    table.ForeignKey(
                        name: "FK_Jelo_VrstaJela_VrstaJelaId",
                        column: x => x.VrstaJelaId,
                        principalTable: "VrstaJela",
                        principalColumn: "VrstaJelaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Klijent",
                columns: table => new
                {
                    KlijentId = table.Column<int>(nullable: false),
                    DatumRegistracije = table.Column<DateTime>(nullable: false),
                    BrojNarudzbi = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klijent", x => x.KlijentId);
                    table.ForeignKey(
                        name: "FK_Klijent_Korisnik2",
                        column: x => x.KlijentId,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Uposlenik",
                columns: table => new
                {
                    UposlenikID = table.Column<int>(nullable: false),
                    DatumZaposljavanja = table.Column<DateTime>(type: "date", nullable: false),
                    JMBG = table.Column<string>(maxLength: 50, nullable: false),
                    DatumRodjenja = table.Column<DateTime>(type: "date", nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    VrstaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uposlenik", x => x.UposlenikID);
                    table.ForeignKey(
                        name: "FK_Uposlenik_Korisnik2",
                        column: x => x.UposlenikID,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Uposlenik_VrstaUposlenika",
                        column: x => x.VrstaID,
                        principalTable: "VrstaUposlenika",
                        principalColumn: "VrstaUposlenikaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Narudzba",
                columns: table => new
                {
                    NarudzbaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumNarudžbe = table.Column<DateTime>(nullable: false),
                    Zavrsena = table.Column<bool>(nullable: false),
                    KlijentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narudzba", x => x.NarudzbaId);
                    table.ForeignKey(
                        name: "FK_Narudzba_Klijent_KlijentId",
                        column: x => x.KlijentId,
                        principalTable: "Klijent",
                        principalColumn: "KlijentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nabavka",
                columns: table => new
                {
                    NabavkaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumNabavke = table.Column<DateTime>(nullable: false),
                    Zavrsena = table.Column<bool>(nullable: false),
                    UposlenikId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nabavka", x => x.NabavkaId);
                    table.ForeignKey(
                        name: "FK_Nabavka_Uposlenik_UposlenikId",
                        column: x => x.UposlenikId,
                        principalTable: "Uposlenik",
                        principalColumn: "UposlenikID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NarudzbaStavke",
                columns: table => new
                {
                    NarudzbaStavkeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Kolicina = table.Column<int>(nullable: false),
                    Cijena = table.Column<double>(nullable: false),
                    NarudzbaId = table.Column<int>(nullable: false),
                    JeloId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NarudzbaStavke", x => x.NarudzbaStavkeId);
                    table.ForeignKey(
                        name: "FK_NarudzbaStavke_Jelo_JeloId",
                        column: x => x.JeloId,
                        principalTable: "Jelo",
                        principalColumn: "JeloId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NarudzbaStavke_Narudzba_NarudzbaId",
                        column: x => x.NarudzbaId,
                        principalTable: "Narudzba",
                        principalColumn: "NarudzbaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NabavkaStavke",
                columns: table => new
                {
                    DetaljiNarudzbeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Kolicina = table.Column<int>(nullable: false),
                    Cijena = table.Column<double>(nullable: false),
                    NabavkaId = table.Column<int>(nullable: false),
                    RobaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NabavkaStavke", x => x.DetaljiNarudzbeId);
                    table.ForeignKey(
                        name: "FK_NabavkaStavke_Nabavka_NabavkaId",
                        column: x => x.NabavkaId,
                        principalTable: "Nabavka",
                        principalColumn: "NabavkaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NabavkaStavke_Roba_RobaId",
                        column: x => x.RobaId,
                        principalTable: "Roba",
                        principalColumn: "RobaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jelo_VrstaJelaId",
                table: "Jelo",
                column: "VrstaJelaId");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_GradID",
                table: "Korisnik",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_Nabavka_UposlenikId",
                table: "Nabavka",
                column: "UposlenikId");

            migrationBuilder.CreateIndex(
                name: "IX_NabavkaStavke_NabavkaId",
                table: "NabavkaStavke",
                column: "NabavkaId");

            migrationBuilder.CreateIndex(
                name: "IX_NabavkaStavke_RobaId",
                table: "NabavkaStavke",
                column: "RobaId");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_KlijentId",
                table: "Narudzba",
                column: "KlijentId");

            migrationBuilder.CreateIndex(
                name: "IX_NarudzbaStavke_JeloId",
                table: "NarudzbaStavke",
                column: "JeloId");

            migrationBuilder.CreateIndex(
                name: "IX_NarudzbaStavke_NarudzbaId",
                table: "NarudzbaStavke",
                column: "NarudzbaId");

            migrationBuilder.CreateIndex(
                name: "IX_Roba_JedinicaMjereId",
                table: "Roba",
                column: "JedinicaMjereId");

            migrationBuilder.CreateIndex(
                name: "IX_Roba_KategorijaId",
                table: "Roba",
                column: "KategorijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Uposlenik_VrstaID",
                table: "Uposlenik",
                column: "VrstaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NabavkaStavke");

            migrationBuilder.DropTable(
                name: "NarudzbaStavke");

            migrationBuilder.DropTable(
                name: "Nabavka");

            migrationBuilder.DropTable(
                name: "Roba");

            migrationBuilder.DropTable(
                name: "Jelo");

            migrationBuilder.DropTable(
                name: "Narudzba");

            migrationBuilder.DropTable(
                name: "Uposlenik");

            migrationBuilder.DropTable(
                name: "JedinicaMjere");

            migrationBuilder.DropTable(
                name: "Kategorija");

            migrationBuilder.DropTable(
                name: "VrstaJela");

            migrationBuilder.DropTable(
                name: "Klijent");

            migrationBuilder.DropTable(
                name: "VrstaUposlenika");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "Grad");
        }
    }
}
