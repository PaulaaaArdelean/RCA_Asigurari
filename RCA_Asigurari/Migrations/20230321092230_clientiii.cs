using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RCA_Asigurari.Migrations
{
    /// <inheritdoc />
    public partial class clientiii : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeProprietar = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PrenumeProprietar = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    SerieCI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumarCI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Varsta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipSocietateID = table.Column<int>(type: "int", nullable: true),
                    ActivitateSocietate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeFirma = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    NumeReprezentantFirma = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PrenumeReprezentantFirma = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    JudetID = table.Column<int>(type: "int", nullable: false),
                    LocalitateID = table.Column<int>(type: "int", nullable: false),
                    Strada = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Numar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodPostal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipAsiguratID = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_Client_Localitate_LocalitateID",
                        column: x => x.LocalitateID,
                        principalTable: "Localitate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Client_TipAsigurat_TipAsiguratID",
                        column: x => x.TipAsiguratID,
                        principalTable: "TipAsigurat",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Client_TipSocietate_TipSocietateID",
                        column: x => x.TipSocietateID,
                        principalTable: "TipSocietate",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_JudetID",
                table: "Client",
                column: "JudetID");

            migrationBuilder.CreateIndex(
                name: "IX_Client_LocalitateID",
                table: "Client",
                column: "LocalitateID");

            migrationBuilder.CreateIndex(
                name: "IX_Client_TipAsiguratID",
                table: "Client",
                column: "TipAsiguratID");

            migrationBuilder.CreateIndex(
                name: "IX_Client_TipSocietateID",
                table: "Client",
                column: "TipSocietateID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
