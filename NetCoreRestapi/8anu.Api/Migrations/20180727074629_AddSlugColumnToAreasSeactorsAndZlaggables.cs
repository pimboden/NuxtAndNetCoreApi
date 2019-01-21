using Microsoft.EntityFrameworkCore.Migrations;

namespace _8anu.Api.Migrations
{
    public partial class AddSlugColumnToAreasSeactorsAndZlaggables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "slug",
                table: "sectors",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "slug",
                table: "routes",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "slug",
                table: "boulders",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "slug",
                table: "areas",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ascents_zlaggable_id_zlaggable_type_type",
                table: "ascents",
                columns: new[] { "zlaggable_id", "zlaggable_type", "type" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ascents_zlaggable_id_zlaggable_type_type",
                table: "ascents");

            migrationBuilder.DropColumn(
                name: "slug",
                table: "sectors");

            migrationBuilder.DropColumn(
                name: "slug",
                table: "routes");

            migrationBuilder.DropColumn(
                name: "slug",
                table: "boulders");

            migrationBuilder.DropColumn(
                name: "slug",
                table: "areas");
        }
    }
}
