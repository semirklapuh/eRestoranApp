using Microsoft.EntityFrameworkCore.Migrations;

namespace eRestoran.WebApi.Migrations
{
    public partial class RezNaziv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Naziv",
                table: "Rezervacija",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Naziv",
                table: "Rezervacija");
        }
    }
}
