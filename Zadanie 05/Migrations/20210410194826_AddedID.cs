using Microsoft.EntityFrameworkCore.Migrations;

namespace Zadanie_5.Migrations
{
    public partial class AddedID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdJson",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdJson",
                table: "Products");
        }
    }
}
