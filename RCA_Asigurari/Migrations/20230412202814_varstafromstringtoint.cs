using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RCA_Asigurari.Migrations
{
    /// <inheritdoc />
    public partial class varstafromstringtoint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdresaClient");

            migrationBuilder.DropTable(
                name: "Vehicul");

            migrationBuilder.AlterColumn<int>(
                name: "Varsta",
                table: "OfertaPF",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Varsta",
                table: "OfertaPF",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "AdresaClient",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JudetID = table.Column<int>(type: "int", nullable: false),
                    LocalitateID = table.Column<int>(type: "int", nullable: false),
                    CodPostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Strada = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdresaClient", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AdresaClient_Judet_JudetID",
                        column: x => x.JudetID,
                        principalTable: "Judet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdresaClient_Localitate_LocalitateID",
                        column: x => x.LocalitateID,
                        principalTable: "Localitate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicul",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfertaID = table.Column<int>(type: "int", nullable: true),
                    TipCombustibilID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicul", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Vehicul_Oferta_OfertaID",
                        column: x => x.OfertaID,
                        principalTable: "Oferta",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Vehicul_TipCombustibil_TipCombustibilID",
                        column: x => x.TipCombustibilID,
                        principalTable: "TipCombustibil",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdresaClient_JudetID",
                table: "AdresaClient",
                column: "JudetID");

            migrationBuilder.CreateIndex(
                name: "IX_AdresaClient_LocalitateID",
                table: "AdresaClient",
                column: "LocalitateID");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicul_OfertaID",
                table: "Vehicul",
                column: "OfertaID");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicul_TipCombustibilID",
                table: "Vehicul",
                column: "TipCombustibilID");
        }
    }
}
