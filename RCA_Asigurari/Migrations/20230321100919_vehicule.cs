using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RCA_Asigurari.Migrations
{
    /// <inheritdoc />
    public partial class vehicule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "IX_Vehicul_OfertaID",
                table: "Vehicul",
                column: "OfertaID");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicul_TipCombustibilID",
                table: "Vehicul",
                column: "TipCombustibilID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicul");
        }
    }
}
