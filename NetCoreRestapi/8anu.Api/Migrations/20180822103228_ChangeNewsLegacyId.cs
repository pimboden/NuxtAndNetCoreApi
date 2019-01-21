using Microsoft.EntityFrameworkCore.Migrations;

namespace _8anu.Api.Migrations
{
    public partial class ChangeNewsLegacyId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "legacy_id",
                table: "news",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "legacy_id",
                table: "news",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
