using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Projekt.Migrations
{
    /// <inheritdoc />
    public partial class Grupa1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kontakty_Adresy_AdresId",
                table: "Kontakty");

            migrationBuilder.DropForeignKey(
                name: "FK_Kontakty_Grupy_GrupaId",
                table: "Kontakty");

            migrationBuilder.AlterColumn<string>(
                name: "NumerTelefonu",
                table: "Kontakty",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "InneInformacje",
                table: "Kontakty",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "GrupaId",
                table: "Kontakty",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AdresId",
                table: "Kontakty",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdresEmail",
                table: "Kontakty",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Ulica",
                table: "Adresy",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Miasto",
                table: "Adresy",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Kraj",
                table: "Adresy",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "KodPocztowy",
                table: "Adresy",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Kontakty_Adresy_AdresId",
                table: "Kontakty",
                column: "AdresId",
                principalTable: "Adresy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Kontakty_Grupy_GrupaId",
                table: "Kontakty",
                column: "GrupaId",
                principalTable: "Grupy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kontakty_Adresy_AdresId",
                table: "Kontakty");

            migrationBuilder.DropForeignKey(
                name: "FK_Kontakty_Grupy_GrupaId",
                table: "Kontakty");

            migrationBuilder.AlterColumn<string>(
                name: "NumerTelefonu",
                table: "Kontakty",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InneInformacje",
                table: "Kontakty",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GrupaId",
                table: "Kontakty",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AdresId",
                table: "Kontakty",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "AdresEmail",
                table: "Kontakty",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ulica",
                table: "Adresy",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Miasto",
                table: "Adresy",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Kraj",
                table: "Adresy",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KodPocztowy",
                table: "Adresy",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Kontakty_Adresy_AdresId",
                table: "Kontakty",
                column: "AdresId",
                principalTable: "Adresy",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Kontakty_Grupy_GrupaId",
                table: "Kontakty",
                column: "GrupaId",
                principalTable: "Grupy",
                principalColumn: "Id");
        }
    }
}
