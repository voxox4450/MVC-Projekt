using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Projekt.Migrations
{
    /// <inheritdoc />
    public partial class Modele : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grupy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kontakty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumerTelefonu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdresEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InneInformacje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GrupaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kontakty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kontakty_Grupy_GrupaId",
                        column: x => x.GrupaId,
                        principalTable: "Grupy",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Adresy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ulica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Miasto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KodPocztowy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kraj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KontaktId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adresy_Kontakty_KontaktId",
                        column: x => x.KontaktId,
                        principalTable: "Kontakty",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adresy_KontaktId",
                table: "Adresy",
                column: "KontaktId",
                unique: true,
                filter: "[KontaktId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Kontakty_GrupaId",
                table: "Kontakty",
                column: "GrupaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adresy");

            migrationBuilder.DropTable(
                name: "Kontakty");

            migrationBuilder.DropTable(
                name: "Grupy");
        }
    }
}
