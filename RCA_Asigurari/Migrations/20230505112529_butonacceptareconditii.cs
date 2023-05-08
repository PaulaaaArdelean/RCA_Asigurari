using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RCA_Asigurari.Migrations
{
    /// <inheritdoc />
    public partial class butonacceptareconditii : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AcceptareConditii",
                table: "OfertaPF",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcceptareConditii",
                table: "OfertaPF");
        }
    }
}
