using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Autoprevoznicko_preduzece_HTS.Migrations
{
    public partial class Nova : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "autobus",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RedniBrojAutobusa = table.Column<int>(nullable: false),
                    BrojSjedila = table.Column<int>(nullable: false),
                    GodisteAutobusa = table.Column<int>(nullable: false),
                    informacije = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_autobus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "grad",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nazivGrada = table.Column<string>(nullable: true),
                    PostanskiBroj = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grad", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "login",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnickoIme = table.Column<string>(nullable: true),
                    Sifra = table.Column<string>(nullable: true),
                    ZapamtiSifru = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_login", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "stanica",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nazivLokacijeStanice = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stanica", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tipKarte",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naziv = table.Column<string>(nullable: true),
                    Informacije = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipKarte", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "vrstaKarte",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naziv = table.Column<string>(nullable: true),
                    Informacije = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vrstaKarte", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "zona",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojZone = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zona", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "kupac",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ime = table.Column<string>(nullable: true),
                    prezime = table.Column<string>(nullable: true),
                    gradID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kupac", x => x.ID);
                    table.ForeignKey(
                        name: "FK_kupac_grad_gradID",
                        column: x => x.gradID,
                        principalTable: "grad",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "opstina",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivOpstine = table.Column<string>(nullable: true),
                    gradID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_opstina", x => x.ID);
                    table.ForeignKey(
                        name: "FK_opstina_grad_gradID",
                        column: x => x.gradID,
                        principalTable: "grad",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "uprava",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    DatumRodjenja = table.Column<DateTime>(nullable: false),
                    loginID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uprava", x => x.ID);
                    table.ForeignKey(
                        name: "FK_uprava_login_loginID",
                        column: x => x.loginID,
                        principalTable: "login",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vozac",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    DatumRodjenja = table.Column<DateTime>(nullable: false),
                    email = table.Column<string>(nullable: true),
                    VozackaKategorija = table.Column<string>(nullable: true),
                    loginID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vozac", x => x.ID);
                    table.ForeignKey(
                        name: "FK_vozac_login_loginID",
                        column: x => x.loginID,
                        principalTable: "login",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cjenovnik",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    zonaID = table.Column<int>(nullable: false),
                    vrstaKarteID = table.Column<int>(nullable: false),
                    tipkarteID = table.Column<int>(nullable: false),
                    cijena = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cjenovnik", x => x.ID);
                    table.ForeignKey(
                        name: "FK_cjenovnik_tipKarte_tipkarteID",
                        column: x => x.tipkarteID,
                        principalTable: "tipKarte",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cjenovnik_vrstaKarte_vrstaKarteID",
                        column: x => x.vrstaKarteID,
                        principalTable: "vrstaKarte",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cjenovnik_zona_zonaID",
                        column: x => x.zonaID,
                        principalTable: "zona",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "gradskeLinije",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojAutobusaID = table.Column<int>(nullable: false),
                    zonaID = table.Column<int>(nullable: false),
                    StanicaPolaskaID = table.Column<int>(nullable: false),
                    StanicaDolaskaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gradskeLinije", x => x.ID);
                    table.ForeignKey(
                        name: "FK_gradskeLinije_autobus_BrojAutobusaID",
                        column: x => x.BrojAutobusaID,
                        principalTable: "autobus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_gradskeLinije_stanica_StanicaDolaskaID",
                        column: x => x.StanicaDolaskaID,
                        principalTable: "stanica",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_gradskeLinije_stanica_StanicaPolaskaID",
                        column: x => x.StanicaPolaskaID,
                        principalTable: "stanica",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_gradskeLinije_zona_zonaID",
                        column: x => x.zonaID,
                        principalTable: "zona",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "obavijesti",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naslov = table.Column<string>(nullable: true),
                    sadrzaj = table.Column<string>(nullable: true),
                    datumObjave = table.Column<DateTime>(nullable: false),
                    upravaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_obavijesti", x => x.ID);
                    table.ForeignKey(
                        name: "FK_obavijesti_uprava_upravaID",
                        column: x => x.upravaID,
                        principalTable: "uprava",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "registracioniPodaci",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    autobusID = table.Column<int>(nullable: false),
                    registracijskibroj = table.Column<int>(nullable: false),
                    PolisaOsiguranja = table.Column<string>(nullable: true),
                    tehnickipregled = table.Column<string>(nullable: true),
                    upravaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registracioniPodaci", x => x.ID);
                    table.ForeignKey(
                        name: "FK_registracioniPodaci_autobus_autobusID",
                        column: x => x.autobusID,
                        principalTable: "autobus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_registracioniPodaci_uprava_upravaID",
                        column: x => x.upravaID,
                        principalTable: "uprava",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "autobusVozac",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pocetak = table.Column<DateTime>(nullable: false),
                    kraj = table.Column<DateTime>(nullable: false),
                    smjena = table.Column<int>(nullable: false),
                    autobusID = table.Column<int>(nullable: false),
                    vozacID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_autobusVozac", x => x.ID);
                    table.ForeignKey(
                        name: "FK_autobusVozac_autobus_autobusID",
                        column: x => x.autobusID,
                        principalTable: "autobus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_autobusVozac_vozac_vozacID",
                        column: x => x.vozacID,
                        principalTable: "vozac",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "karta",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kupacID = table.Column<int>(nullable: false),
                    tipKarteID = table.Column<int>(nullable: false),
                    vrstaKarteID = table.Column<int>(nullable: false),
                    DatumVadjenjaKarte = table.Column<DateTime>(nullable: false),
                    DatumVazenjaKarte = table.Column<DateTime>(nullable: false),
                    gradskaLinijaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_karta", x => x.ID);
                    table.ForeignKey(
                        name: "FK_karta_gradskeLinije_gradskaLinijaID",
                        column: x => x.gradskaLinijaID,
                        principalTable: "gradskeLinije",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_karta_kupac_kupacID",
                        column: x => x.kupacID,
                        principalTable: "kupac",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_karta_tipKarte_tipKarteID",
                        column: x => x.tipKarteID,
                        principalTable: "tipKarte",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_karta_vrstaKarte_vrstaKarteID",
                        column: x => x.vrstaKarteID,
                        principalTable: "vrstaKarte",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "redVoznje",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gradskaLinijaID = table.Column<int>(nullable: false),
                    VrijemePolaska = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_redVoznje", x => x.ID);
                    table.ForeignKey(
                        name: "FK_redVoznje_gradskeLinije_gradskaLinijaID",
                        column: x => x.gradskaLinijaID,
                        principalTable: "gradskeLinije",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_autobusVozac_autobusID",
                table: "autobusVozac",
                column: "autobusID");

            migrationBuilder.CreateIndex(
                name: "IX_autobusVozac_vozacID",
                table: "autobusVozac",
                column: "vozacID");

            migrationBuilder.CreateIndex(
                name: "IX_cjenovnik_tipkarteID",
                table: "cjenovnik",
                column: "tipkarteID");

            migrationBuilder.CreateIndex(
                name: "IX_cjenovnik_vrstaKarteID",
                table: "cjenovnik",
                column: "vrstaKarteID");

            migrationBuilder.CreateIndex(
                name: "IX_cjenovnik_zonaID",
                table: "cjenovnik",
                column: "zonaID");

            migrationBuilder.CreateIndex(
                name: "IX_gradskeLinije_BrojAutobusaID",
                table: "gradskeLinije",
                column: "BrojAutobusaID");

            migrationBuilder.CreateIndex(
                name: "IX_gradskeLinije_StanicaDolaskaID",
                table: "gradskeLinije",
                column: "StanicaDolaskaID");

            migrationBuilder.CreateIndex(
                name: "IX_gradskeLinije_StanicaPolaskaID",
                table: "gradskeLinije",
                column: "StanicaPolaskaID");

            migrationBuilder.CreateIndex(
                name: "IX_gradskeLinije_zonaID",
                table: "gradskeLinije",
                column: "zonaID");

            migrationBuilder.CreateIndex(
                name: "IX_karta_gradskaLinijaID",
                table: "karta",
                column: "gradskaLinijaID");

            migrationBuilder.CreateIndex(
                name: "IX_karta_kupacID",
                table: "karta",
                column: "kupacID");

            migrationBuilder.CreateIndex(
                name: "IX_karta_tipKarteID",
                table: "karta",
                column: "tipKarteID");

            migrationBuilder.CreateIndex(
                name: "IX_karta_vrstaKarteID",
                table: "karta",
                column: "vrstaKarteID");

            migrationBuilder.CreateIndex(
                name: "IX_kupac_gradID",
                table: "kupac",
                column: "gradID");

            migrationBuilder.CreateIndex(
                name: "IX_obavijesti_upravaID",
                table: "obavijesti",
                column: "upravaID");

            migrationBuilder.CreateIndex(
                name: "IX_opstina_gradID",
                table: "opstina",
                column: "gradID");

            migrationBuilder.CreateIndex(
                name: "IX_redVoznje_gradskaLinijaID",
                table: "redVoznje",
                column: "gradskaLinijaID");

            migrationBuilder.CreateIndex(
                name: "IX_registracioniPodaci_autobusID",
                table: "registracioniPodaci",
                column: "autobusID");

            migrationBuilder.CreateIndex(
                name: "IX_registracioniPodaci_upravaID",
                table: "registracioniPodaci",
                column: "upravaID");

            migrationBuilder.CreateIndex(
                name: "IX_uprava_loginID",
                table: "uprava",
                column: "loginID");

            migrationBuilder.CreateIndex(
                name: "IX_vozac_loginID",
                table: "vozac",
                column: "loginID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "autobusVozac");

            migrationBuilder.DropTable(
                name: "cjenovnik");

            migrationBuilder.DropTable(
                name: "karta");

            migrationBuilder.DropTable(
                name: "obavijesti");

            migrationBuilder.DropTable(
                name: "opstina");

            migrationBuilder.DropTable(
                name: "redVoznje");

            migrationBuilder.DropTable(
                name: "registracioniPodaci");

            migrationBuilder.DropTable(
                name: "vozac");

            migrationBuilder.DropTable(
                name: "kupac");

            migrationBuilder.DropTable(
                name: "tipKarte");

            migrationBuilder.DropTable(
                name: "vrstaKarte");

            migrationBuilder.DropTable(
                name: "gradskeLinije");

            migrationBuilder.DropTable(
                name: "uprava");

            migrationBuilder.DropTable(
                name: "grad");

            migrationBuilder.DropTable(
                name: "autobus");

            migrationBuilder.DropTable(
                name: "stanica");

            migrationBuilder.DropTable(
                name: "zona");

            migrationBuilder.DropTable(
                name: "login");
        }
    }
}
