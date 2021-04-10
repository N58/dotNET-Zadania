using Microsoft.EntityFrameworkCore.Migrations;

namespace Zadanie_5.Migrations
{
    public partial class AddedIdJsonIgnore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdJson",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdJson",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
