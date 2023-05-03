using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RCA_Asigurari.Migrations
{
    /// <inheritdoc />
    public partial class tot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategorieVehicul",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaVehicul = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieVehicul", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Judet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Judetul = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Judet", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TipClient",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipulClientului = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipClient", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TipCombustibil",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipulCombustibil = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipCombustibil", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TipSocietate",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipulSocietate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipSocietate", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Varste",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Varstaa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Varste", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeProprietar = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    JudetID = table.Column<int>(type: "int", nullable: false),
                    Localitate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Strada = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Numar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodPostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RadioButtonClient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipClientID = table.Column<int>(type: "int", nullable: true),
                    TipSocietateID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Client_Judet_JudetID",
                        column: x => x.JudetID,
                        principalTable: "Judet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Client_TipClient_TipClientID",
                        column: x => x.TipClientID,
                        principalTable: "TipClient",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Client_TipSocietate_TipSocietateID",
                        column: x => x.TipSocietateID,
                        principalTable: "TipSocietate",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "OfertaPF",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(type: "int", nullable: true),
                    CNP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerieCI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumarCI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Varsta = table.Column<int>(type: "int", nullable: false),
                    NumarIdentificare = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NrInmatriculare = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnFabricatie = table.Column<int>(type: "int", nullable: false),
                    CapacitateCilindrica = table.Column<int>(type: "int", nullable: false),
                    SerieCIV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NrLocuri = table.Column<int>(type: "int", nullable: false),
                    MasaMaxima = table.Column<int>(type: "int", nullable: false),
                    Putere = table.Column<int>(type: "int", nullable: false),
                    CategorieVehiculID = table.Column<int>(type: "int", nullable: true),
                    TipCombustibilID = table.Column<int>(type: "int", nullable: true),
                    Pret = table.Column<int>(type: "int", nullable: true),
                    PFCreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VarstaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfertaPF", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OfertaPF_CategorieVehicul_CategorieVehiculID",
                        column: x => x.CategorieVehiculID,
                        principalTable: "CategorieVehicul",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_OfertaPF_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_OfertaPF_TipCombustibil_TipCombustibilID",
                        column: x => x.TipCombustibilID,
                        principalTable: "TipCombustibil",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_OfertaPF_Varste_VarstaID",
                        column: x => x.VarstaID,
                        principalTable: "Varste",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "OfertaPJ",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(type: "int", nullable: true),
                    CUI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipSocietateID = table.Column<int>(type: "int", nullable: true),
                    ActivitateSocietate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeReprezentantFirma = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PrenumeReprezentantFirma = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NumarIdentificare = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NrInmatriculare = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnFabricatie = table.Column<int>(type: "int", nullable: false),
                    CapacitateCilindrica = table.Column<int>(type: "int", nullable: false),
                    SerieCIV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NrLocuri = table.Column<int>(type: "int", nullable: false),
                    MasaMaxima = table.Column<int>(type: "int", nullable: false),
                    Putere = table.Column<int>(type: "int", nullable: false),
                    CategorieVehiculID = table.Column<int>(type: "int", nullable: true),
                    TipCombustibilID = table.Column<int>(type: "int", nullable: true),
                    Pret = table.Column<int>(type: "int", nullable: true),
                    PJCreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfertaPJ", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OfertaPJ_CategorieVehicul_CategorieVehiculID",
                        column: x => x.CategorieVehiculID,
                        principalTable: "CategorieVehicul",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_OfertaPJ_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_OfertaPJ_TipCombustibil_TipCombustibilID",
                        column: x => x.TipCombustibilID,
                        principalTable: "TipCombustibil",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_OfertaPJ_TipSocietate_TipSocietateID",
                        column: x => x.TipSocietateID,
                        principalTable: "TipSocietate",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "OfertaPFDorita",
                columns: table => new
                {
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    OfertaPFID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfertaPFDorita", x => new { x.ClientID, x.OfertaPFID });
                    table.ForeignKey(
                        name: "FK_OfertaPFDorita_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfertaPFDorita_OfertaPF_OfertaPFID",
                        column: x => x.OfertaPFID,
                        principalTable: "OfertaPF",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfertaPJDorita",
                columns: table => new
                {
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    OfertaPJID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfertaPJDorita", x => new { x.ClientID, x.OfertaPJID });
                    table.ForeignKey(
                        name: "FK_OfertaPJDorita_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfertaPJDorita_OfertaPJ_OfertaPJID",
                        column: x => x.OfertaPJID,
                        principalTable: "OfertaPJ",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_JudetID",
                table: "Client",
                column: "JudetID");

            migrationBuilder.CreateIndex(
                name: "IX_Client_TipClientID",
                table: "Client",
                column: "TipClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Client_TipSocietateID",
                table: "Client",
                column: "TipSocietateID");

            migrationBuilder.CreateIndex(
                name: "IX_OfertaPF_CategorieVehiculID",
                table: "OfertaPF",
                column: "CategorieVehiculID");

            migrationBuilder.CreateIndex(
                name: "IX_OfertaPF_ClientID",
                table: "OfertaPF",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_OfertaPF_TipCombustibilID",
                table: "OfertaPF",
                column: "TipCombustibilID");

            migrationBuilder.CreateIndex(
                name: "IX_OfertaPF_VarstaID",
                table: "OfertaPF",
                column: "VarstaID");

            migrationBuilder.CreateIndex(
                name: "IX_OfertaPFDorita_OfertaPFID",
                table: "OfertaPFDorita",
                column: "OfertaPFID");

            migrationBuilder.CreateIndex(
                name: "IX_OfertaPJ_CategorieVehiculID",
                table: "OfertaPJ",
                column: "CategorieVehiculID");

            migrationBuilder.CreateIndex(
                name: "IX_OfertaPJ_ClientID",
                table: "OfertaPJ",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_OfertaPJ_TipCombustibilID",
                table: "OfertaPJ",
                column: "TipCombustibilID");

            migrationBuilder.CreateIndex(
                name: "IX_OfertaPJ_TipSocietateID",
                table: "OfertaPJ",
                column: "TipSocietateID");

            migrationBuilder.CreateIndex(
                name: "IX_OfertaPJDorita_OfertaPJID",
                table: "OfertaPJDorita",
                column: "OfertaPJID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfertaPFDorita");

            migrationBuilder.DropTable(
                name: "OfertaPJDorita");

            migrationBuilder.DropTable(
                name: "OfertaPF");

            migrationBuilder.DropTable(
                name: "OfertaPJ");

            migrationBuilder.DropTable(
                name: "Varste");

            migrationBuilder.DropTable(
                name: "CategorieVehicul");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "TipCombustibil");

            migrationBuilder.DropTable(
                name: "Judet");

            migrationBuilder.DropTable(
                name: "TipClient");

            migrationBuilder.DropTable(
                name: "TipSocietate");
        }
    }
}
