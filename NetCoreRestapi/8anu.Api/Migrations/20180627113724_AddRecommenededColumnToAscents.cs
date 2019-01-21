using Microsoft.EntityFrameworkCore.Migrations;

namespace _8anu.Api.Migrations
{
    public partial class AddRecommenededColumnToAscents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<sbyte>(
                name: "recommended",
                table: "ascents",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: (sbyte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "recommended",
                table: "ascents");
        }
    }
}
