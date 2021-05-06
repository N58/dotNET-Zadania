using Microsoft.EntityFrameworkCore.Migrations;

namespace Zadanie_7.Migrations
{
    public partial class UpdatedFizz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "FizzNumbers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FizzNumbers");
        }
    }
}
