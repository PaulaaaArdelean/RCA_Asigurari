using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RCA_Asigurari.Migrations
{
    /// <inheritdoc />
    public partial class figurinele : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Figurina",
                table: "Client",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Figurina",
                table: "Client");
        }
    }
}
