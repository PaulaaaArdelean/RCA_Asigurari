using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RCA_Asigurari.Migrations
{
    /// <inheritdoc />
    public partial class radiobuttons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Figurina",
                table: "Client",
                newName: "RadioButtonClient");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RadioButtonClient",
                table: "Client",
                newName: "Figurina");
        }
    }
}
