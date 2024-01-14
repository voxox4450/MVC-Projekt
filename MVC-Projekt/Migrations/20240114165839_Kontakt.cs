using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Projekt.Migrations
{
    /// <inheritdoc />
    public partial class Kontakt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresy_Kontakty_KontaktId",
                table: "Adresy");

            migrationBuilder.DropIndex(
                name: "IX_Adresy_KontaktId",
                table: "Adresy");

            migrationBuilder.AddColumn<int>(
                name: "AdresId",
                table: "Kontakty",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kontakty_AdresId",
                table: "Kontakty",
                column: "AdresId",
                unique: true,
                filter: "[AdresId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Kontakty_Adresy_AdresId",
                table: "Kontakty",
                column: "AdresId",
                principalTable: "Adresy",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kontakty_Adresy_AdresId",
                table: "Kontakty");

            migrationBuilder.DropIndex(
                name: "IX_Kontakty_AdresId",
                table: "Kontakty");

            migrationBuilder.DropColumn(
                name: "AdresId",
                table: "Kontakty");

            migrationBuilder.CreateIndex(
                name: "IX_Adresy_KontaktId",
                table: "Adresy",
                column: "KontaktId",
                unique: true,
                filter: "[KontaktId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Adresy_Kontakty_KontaktId",
                table: "Adresy",
                column: "KontaktId",
                principalTable: "Kontakty",
                principalColumn: "Id");
        }
    }
}
