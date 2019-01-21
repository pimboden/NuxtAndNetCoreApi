using Microsoft.EntityFrameworkCore.Migrations;

namespace _8anu.Api.Migrations
{
    public partial class VlIdsForCragTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "vl_sector_id",
                table: "sectors",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "vl_route_id",
                table: "routes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "vl_location_id",
                table: "crags",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "vl_boulder_id",
                table: "boulders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "vl_sector_id",
                table: "sectors");

            migrationBuilder.DropColumn(
                name: "vl_route_id",
                table: "routes");

            migrationBuilder.DropColumn(
                name: "vl_location_id",
                table: "crags");

            migrationBuilder.DropColumn(
                name: "vl_boulder_id",
                table: "boulders");
        }
    }
}
