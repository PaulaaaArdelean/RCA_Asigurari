﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RCA_Asigurari.Migrations
{
    /// <inheritdoc />
    public partial class claseLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_Judet_JudetID",
                table: "Client");

            migrationBuilder.DropForeignKey(
                name: "FK_Client_Localitate_LocalitateID",
                table: "Client");

            migrationBuilder.DropTable(
                name: "Localitate");

            migrationBuilder.DropTable(
                name: "Judet");

            migrationBuilder.DropIndex(
                name: "IX_Client_JudetID",
                table: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Client_LocalitateID",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "JudetID",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "LocalitateID",
                table: "Client");

            migrationBuilder.AddColumn<string>(
                name: "Judet",
                table: "Client",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Localitate",
                table: "Client",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Judet",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "Localitate",
                table: "Client");

            migrationBuilder.AddColumn<int>(
                name: "JudetID",
                table: "Client",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LocalitateID",
                table: "Client",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Judet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Judetul = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Judet", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Localitate",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JudetID = table.Column<int>(type: "int", nullable: true),
                    Localitatea = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localitate", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Localitate_Judet_JudetID",
                        column: x => x.JudetID,
                        principalTable: "Judet",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_JudetID",
                table: "Client",
                column: "JudetID");

            migrationBuilder.CreateIndex(
                name: "IX_Client_LocalitateID",
                table: "Client",
                column: "LocalitateID");

            migrationBuilder.CreateIndex(
                name: "IX_Localitate_JudetID",
                table: "Localitate",
                column: "JudetID");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Judet_JudetID",
                table: "Client",
                column: "JudetID",
                principalTable: "Judet",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Localitate_LocalitateID",
                table: "Client",
                column: "LocalitateID",
                principalTable: "Localitate",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
