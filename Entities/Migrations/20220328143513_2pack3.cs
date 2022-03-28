using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class _2pack3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerStatus",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CustomerStatusMeaning",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerStatus",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerStatusMeaning",
                table: "Customers");
        }
    }
}
