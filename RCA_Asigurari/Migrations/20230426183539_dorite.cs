using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RCA_Asigurari.Migrations
{
    /// <inheritdoc />
    public partial class dorite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "IX_OfertaPFDorita_OfertaPFID",
                table: "OfertaPFDorita",
                column: "OfertaPFID");

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
        }
    }
}
