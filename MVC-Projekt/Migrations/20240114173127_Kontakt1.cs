using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Projekt.Migrations
{
    /// <inheritdoc />
    public partial class Kontakt1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Kontakty_AdresId",
                table: "Kontakty");

            migrationBuilder.DropColumn(
                name: "KontaktId",
                table: "Adresy");

            migrationBuilder.CreateIndex(
                name: "IX_Kontakty_AdresId",
                table: "Kontakty",
                column: "AdresId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Kontakty_AdresId",
                table: "Kontakty");

            migrationBuilder.AddColumn<int>(
                name: "KontaktId",
                table: "Adresy",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kontakty_AdresId",
                table: "Kontakty",
                column: "AdresId",
                unique: true,
                filter: "[AdresId] IS NOT NULL");
        }
    }
}
