using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class novo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buys_Products_ProductId",
                table: "Buys");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Buys_BuyId",
                table: "Stocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Products_ProductId",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_BuyId",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_ProductId",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Buys_ProductId",
                table: "Buys");

            migrationBuilder.DropColumn(
                name: "BuyId",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Buys");

            migrationBuilder.AddColumn<int>(
                name: "StockId",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Buys",
                maxLength: 10,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StockId",
                table: "Buys",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Value",
                table: "Buys",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Products_StockId",
                table: "Products",
                column: "StockId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Buys_StockId",
                table: "Buys",
                column: "StockId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buys_Stocks_StockId",
                table: "Buys",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Stocks_StockId",
                table: "Products",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buys_Stocks_StockId",
                table: "Buys");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Stocks_StockId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_StockId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Buys_StockId",
                table: "Buys");

            migrationBuilder.DropColumn(
                name: "StockId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Buys");

            migrationBuilder.DropColumn(
                name: "StockId",
                table: "Buys");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Buys");

            migrationBuilder.AddColumn<int>(
                name: "BuyId",
                table: "Stocks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Stocks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Buys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_BuyId",
                table: "Stocks",
                column: "BuyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductId",
                table: "Stocks",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Buys_ProductId",
                table: "Buys",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buys_Products_ProductId",
                table: "Buys",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Buys_BuyId",
                table: "Stocks",
                column: "BuyId",
                principalTable: "Buys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Products_ProductId",
                table: "Stocks",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
