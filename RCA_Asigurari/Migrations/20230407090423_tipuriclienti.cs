using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RCA_Asigurari.Migrations
{
    /// <inheritdoc />
    public partial class tipuriclienti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipClientID",
                table: "Client",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PF",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeProprietar = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PrenumeProprietar = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SerieCI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumarCI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Varsta = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PF", x => x.ID);
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

            migrationBuilder.CreateIndex(
                name: "IX_Client_TipClientID",
                table: "Client",
                column: "TipClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_TipClient_TipClientID",
                table: "Client",
                column: "TipClientID",
                principalTable: "TipClient",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_TipClient_TipClientID",
                table: "Client");

            migrationBuilder.DropTable(
                name: "PF");

            migrationBuilder.DropTable(
                name: "TipClient");

            migrationBuilder.DropIndex(
                name: "IX_Client_TipClientID",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "TipClientID",
                table: "Client");
        }
    }
}
