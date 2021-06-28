using Microsoft.EntityFrameworkCore.Migrations;

namespace Parts.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klienci",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nazwa = table.Column<string>(nullable: false),
                    adres = table.Column<string>(nullable: false),
                    email = table.Column<string>(maxLength: 50, nullable: false),
                    haslo = table.Column<string>(maxLength: 12, nullable: false),
                    nr_tel = table.Column<int>(maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klienci", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pozycja",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nazwa = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pozycja", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pracownicy",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imie = table.Column<string>(nullable: false),
                    nazwisko = table.Column<string>(nullable: true),
                    email = table.Column<string>(maxLength: 50, nullable: false),
                    haslo = table.Column<string>(nullable: false),
                    wypłata = table.Column<int>(nullable: false),
                    ID_pozycja = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pracownicy", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Produkty",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nazwa = table.Column<string>(nullable: true),
                    cena = table.Column<int>(nullable: false),
                    ilość_magazynowa = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkty", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Zamowienia",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_klienta = table.Column<int>(nullable: false),
                    ID_Produktu = table.Column<int>(nullable: false),
                    ilość = table.Column<int>(nullable: false),
                    suma_zamowienia = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienia", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Klienci");

            migrationBuilder.DropTable(
                name: "Pozycja");

            migrationBuilder.DropTable(
                name: "Pracownicy");

            migrationBuilder.DropTable(
                name: "Produkty");

            migrationBuilder.DropTable(
                name: "Zamowienia");
        }
    }
}
