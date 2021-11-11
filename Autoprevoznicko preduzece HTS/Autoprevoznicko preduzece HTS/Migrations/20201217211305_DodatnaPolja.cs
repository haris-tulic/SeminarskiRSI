using Microsoft.EntityFrameworkCore.Migrations;

namespace Autoprevoznicko_preduzece_HTS.Migrations
{
    public partial class DodatnaPolja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "uprava",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "kupac",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "telefon",
                table: "kupac",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "uprava");

            migrationBuilder.DropColumn(
                name: "email",
                table: "kupac");

            migrationBuilder.DropColumn(
                name: "telefon",
                table: "kupac");
        }
    }
}
