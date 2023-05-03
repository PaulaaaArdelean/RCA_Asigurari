using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RCA_Asigurari.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfertaPF_Varste_VarstaID",
                table: "OfertaPF");

            migrationBuilder.DropColumn(
                name: "Varsta",
                table: "OfertaPF");

            migrationBuilder.AlterColumn<int>(
                name: "Varstaa",
                table: "Varste",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "VarstaID",
                table: "OfertaPF",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OfertaPF_Varste_VarstaID",
                table: "OfertaPF",
                column: "VarstaID",
                principalTable: "Varste",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfertaPF_Varste_VarstaID",
                table: "OfertaPF");

            migrationBuilder.AlterColumn<string>(
                name: "Varstaa",
                table: "Varste",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "VarstaID",
                table: "OfertaPF",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Varsta",
                table: "OfertaPF",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_OfertaPF_Varste_VarstaID",
                table: "OfertaPF",
                column: "VarstaID",
                principalTable: "Varste",
                principalColumn: "ID");
        }
    }
}
