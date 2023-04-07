using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RCA_Asigurari.Migrations
{
    /// <inheritdoc />
    public partial class newregister : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdresaClient",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JudetID = table.Column<int>(type: "int", nullable: false),
                    LocalitateID = table.Column<int>(type: "int", nullable: false),
                    Strada = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Numar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodPostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "PJ",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CUI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipSocietateID = table.Column<int>(type: "int", nullable: true),
                    ActivitateSocietate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeFirma = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NumeReprezentantFirma = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PrenumeReprezentantFirma = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PJ", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PJ_TipSocietate_TipSocietateID",
                        column: x => x.TipSocietateID,
                        principalTable: "TipSocietate",
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
                name: "IX_PJ_TipSocietateID",
                table: "PJ",
                column: "TipSocietateID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdresaClient");

            migrationBuilder.DropTable(
                name: "PJ");
        }
    }
}
