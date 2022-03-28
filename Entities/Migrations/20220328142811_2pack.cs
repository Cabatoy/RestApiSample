using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class _2pack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Customers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
