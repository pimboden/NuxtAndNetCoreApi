using Microsoft.EntityFrameworkCore.Migrations;

namespace _8anu.Api.Migrations
{
    public partial class LegacyIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "legacy_id",
                table: "routes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "legacy_id",
                table: "forum_comments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "legacy_id",
                table: "crags",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "legacy_id",
                table: "boulders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "legacy_id",
                table: "ascents",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "legacy_id",
                table: "areas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "legacy_id",
                table: "routes");

            migrationBuilder.DropColumn(
                name: "legacy_id",
                table: "forum_comments");

            migrationBuilder.DropColumn(
                name: "legacy_id",
                table: "crags");

            migrationBuilder.DropColumn(
                name: "legacy_id",
                table: "boulders");

            migrationBuilder.DropColumn(
                name: "legacy_id",
                table: "ascents");

            migrationBuilder.DropColumn(
                name: "legacy_id",
                table: "areas");
        }
    }
}
