using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RCA_Asigurari.Migrations
{
    /// <inheritdoc />
    public partial class ofertePFPJ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OfertaPF",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(type: "int", nullable: true),
                    CNP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeProprietar = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PrenumeProprietar = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SerieCI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumarCI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Varsta = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Pret = table.Column<int>(type: "int", nullable: true)
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
                    NumeFirma = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
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
                    Pret = table.Column<int>(type: "int", nullable: true)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfertaPF");

            migrationBuilder.DropTable(
                name: "OfertaPJ");
        }
    }
}
