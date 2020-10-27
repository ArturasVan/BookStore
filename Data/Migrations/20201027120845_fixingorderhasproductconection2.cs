using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Data.Migrations
{
    public partial class fixingorderhasproductconection2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderHasProductOrderId",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderHasProductProductId",
                table: "Product",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_OrderHasProductOrderId_OrderHasProductProductId",
                table: "Product",
                columns: new[] { "OrderHasProductOrderId", "OrderHasProductProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Product_OrderHasProduct_OrderHasProductOrderId_OrderHasProductProductId",
                table: "Product",
                columns: new[] { "OrderHasProductOrderId", "OrderHasProductProductId" },
                principalTable: "OrderHasProduct",
                principalColumns: new[] { "OrderId", "ProductId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_OrderHasProduct_OrderHasProductOrderId_OrderHasProductProductId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_OrderHasProductOrderId_OrderHasProductProductId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "OrderHasProductOrderId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "OrderHasProductProductId",
                table: "Product");
        }
    }
}
