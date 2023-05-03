using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RCA_Asigurari.Migrations
{
    /// <inheritdoc />
    public partial class deletevarsta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfertaPF_Varste_VarstaID",
                table: "OfertaPF");

            migrationBuilder.DropTable(
                name: "Varste");

            migrationBuilder.DropIndex(
                name: "IX_OfertaPF_VarstaID",
                table: "OfertaPF");

            migrationBuilder.RenameColumn(
                name: "VarstaID",
                table: "OfertaPF",
                newName: "Varsta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Varsta",
                table: "OfertaPF",
                newName: "VarstaID");

            migrationBuilder.CreateTable(
                name: "Varste",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Varstaa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Varste", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OfertaPF_VarstaID",
                table: "OfertaPF",
                column: "VarstaID");

            migrationBuilder.AddForeignKey(
                name: "FK_OfertaPF_Varste_VarstaID",
                table: "OfertaPF",
                column: "VarstaID",
                principalTable: "Varste",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
