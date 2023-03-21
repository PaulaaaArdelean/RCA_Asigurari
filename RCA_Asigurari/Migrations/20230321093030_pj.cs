using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RCA_Asigurari.Migrations
{
    /// <inheritdoc />
    public partial class pj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersoanaJuridica",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(type: "int", nullable: true),
                    TipSocietateID = table.Column<int>(type: "int", nullable: true),
                    JudetID = table.Column<int>(type: "int", nullable: true),
                    LocalitateID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersoanaJuridica", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PersoanaJuridica_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PersoanaJuridica_Judet_JudetID",
                        column: x => x.JudetID,
                        principalTable: "Judet",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PersoanaJuridica_Localitate_LocalitateID",
                        column: x => x.LocalitateID,
                        principalTable: "Localitate",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PersoanaJuridica_TipSocietate_TipSocietateID",
                        column: x => x.TipSocietateID,
                        principalTable: "TipSocietate",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersoanaJuridica_ClientID",
                table: "PersoanaJuridica",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_PersoanaJuridica_JudetID",
                table: "PersoanaJuridica",
                column: "JudetID");

            migrationBuilder.CreateIndex(
                name: "IX_PersoanaJuridica_LocalitateID",
                table: "PersoanaJuridica",
                column: "LocalitateID");

            migrationBuilder.CreateIndex(
                name: "IX_PersoanaJuridica_TipSocietateID",
                table: "PersoanaJuridica",
                column: "TipSocietateID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersoanaJuridica");
        }
    }
}
