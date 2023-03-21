using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RCA_Asigurari.Migrations
{
    /// <inheritdoc />
    public partial class atributeleoptionale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AtributOptional",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AtributulOptional = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtributOptional", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Oferta",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(type: "int", nullable: true),
                    NumarIdentificare = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NrInmatriculare = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnFabricatie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CapacitateCilindrica = table.Column<int>(type: "int", nullable: false),
                    SerieCIV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NrLocuri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MasaMaxima = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Putere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategorieVehiculID = table.Column<int>(type: "int", nullable: true),
                    TipCombustibilID = table.Column<int>(type: "int", nullable: true),
                    Pret = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oferta", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Oferta_CategorieVehicul_CategorieVehiculID",
                        column: x => x.CategorieVehiculID,
                        principalTable: "CategorieVehicul",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Oferta_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Oferta_TipCombustibil_TipCombustibilID",
                        column: x => x.TipCombustibilID,
                        principalTable: "TipCombustibil",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "AtributOptionalOferta",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfertaID = table.Column<int>(type: "int", nullable: false),
                    AtributOptionalID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtributOptionalOferta", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AtributOptionalOferta_AtributOptional_AtributOptionalID",
                        column: x => x.AtributOptionalID,
                        principalTable: "AtributOptional",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtributOptionalOferta_Oferta_OfertaID",
                        column: x => x.OfertaID,
                        principalTable: "Oferta",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtributOptionalOferta_AtributOptionalID",
                table: "AtributOptionalOferta",
                column: "AtributOptionalID");

            migrationBuilder.CreateIndex(
                name: "IX_AtributOptionalOferta_OfertaID",
                table: "AtributOptionalOferta",
                column: "OfertaID");

            migrationBuilder.CreateIndex(
                name: "IX_Oferta_CategorieVehiculID",
                table: "Oferta",
                column: "CategorieVehiculID");

            migrationBuilder.CreateIndex(
                name: "IX_Oferta_ClientID",
                table: "Oferta",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Oferta_TipCombustibilID",
                table: "Oferta",
                column: "TipCombustibilID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtributOptionalOferta");

            migrationBuilder.DropTable(
                name: "AtributOptional");

            migrationBuilder.DropTable(
                name: "Oferta");
        }
    }
}
