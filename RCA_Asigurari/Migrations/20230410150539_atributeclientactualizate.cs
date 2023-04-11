using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RCA_Asigurari.Migrations
{
    /// <inheritdoc />
    public partial class atributeclientactualizate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeFirma",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "NumeReprezentantFirma",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "PrenumeProprietar",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "PrenumeReprezentantFirma",
                table: "Client");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NumeFirma",
                table: "Client",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumeReprezentantFirma",
                table: "Client",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrenumeProprietar",
                table: "Client",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrenumeReprezentantFirma",
                table: "Client",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);
        }
    }
}
