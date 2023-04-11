using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RCA_Asigurari.Migrations
{
    /// <inheritdoc />
    public partial class actualizaretabelaclienti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_TipAsigurat_TipAsiguratID",
                table: "Client");

            migrationBuilder.DropTable(
                name: "PersoanaFizica");

            migrationBuilder.DropTable(
                name: "PersoanaJuridica");

            migrationBuilder.DropTable(
                name: "TipAsigurat");

            migrationBuilder.DropIndex(
                name: "IX_Client_TipAsiguratID",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "ActivitateSocietate",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "CNP",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "CUI",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "NumarCI",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "SerieCI",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "TipAsiguratID",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "Varsta",
                table: "Client");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ActivitateSocietate",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CNP",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CUI",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumarCI",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SerieCI",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipAsiguratID",
                table: "Client",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Varsta",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.CreateTable(
                name: "PersoanaJuridica",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(type: "int", nullable: true),
                    JudetID = table.Column<int>(type: "int", nullable: true),
                    LocalitateID = table.Column<int>(type: "int", nullable: true),
                    TipSocietateID = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "TipAsigurat",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipulAsigurat = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipAsigurat", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_TipAsiguratID",
                table: "Client",
                column: "TipAsiguratID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Client_TipAsigurat_TipAsiguratID",
                table: "Client",
                column: "TipAsiguratID",
                principalTable: "TipAsigurat",
                principalColumn: "ID");
        }
    }
}
