using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RCA_Asigurari.Migrations
{
    /// <inheritdoc />
    public partial class pf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersoanaFizica",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(type: "int", nullable: true),
                    JudetID = table.Column<int>(type: "int", nullable: true),
                    LocalitateID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersoanaFizica", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PersoanaFizica_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PersoanaFizica_Judet_JudetID",
                        column: x => x.JudetID,
                        principalTable: "Judet",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PersoanaFizica_Localitate_LocalitateID",
                        column: x => x.LocalitateID,
                        principalTable: "Localitate",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersoanaFizica_ClientID",
                table: "PersoanaFizica",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_PersoanaFizica_JudetID",
                table: "PersoanaFizica",
                column: "JudetID");

            migrationBuilder.CreateIndex(
                name: "IX_PersoanaFizica_LocalitateID",
                table: "PersoanaFizica",
                column: "LocalitateID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersoanaFizica");
        }
    }
}
