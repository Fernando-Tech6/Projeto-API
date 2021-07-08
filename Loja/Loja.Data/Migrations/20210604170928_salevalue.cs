using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class salevalue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ChangeValue",
                table: "Stocks",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Value",
                table: "Sales",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChangeValue",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Sales");
        }
    }
}
