using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Data.Migrations
{
    public partial class update2orderhasproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderHasProduct_OrderHasProductOrderId_OrderHasProductProductId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_OrderHasProduct_OrderHasProductOrderId_OrderHasProductProductId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_OrderHasProductOrderId_OrderHasProductProductId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderHasProductOrderId_OrderHasProductProductId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderHasProductOrderId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "OrderHasProductProductId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "OrderHasProductOrderId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderHasProductProductId",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "Autor",
                table: "OrderHasProduct",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReleaseYear",
                table: "OrderHasProduct",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "OrderHasProduct",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Autor",
                table: "OrderHasProduct");

            migrationBuilder.DropColumn(
                name: "ReleaseYear",
                table: "OrderHasProduct");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "OrderHasProduct");

            migrationBuilder.AddColumn<int>(
                name: "OrderHasProductOrderId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderHasProductProductId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderHasProductOrderId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderHasProductProductId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_OrderHasProductOrderId_OrderHasProductProductId",
                table: "Product",
                columns: new[] { "OrderHasProductOrderId", "OrderHasProductProductId" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderHasProductOrderId_OrderHasProductProductId",
                table: "Orders",
                columns: new[] { "OrderHasProductOrderId", "OrderHasProductProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderHasProduct_OrderHasProductOrderId_OrderHasProductProductId",
                table: "Orders",
                columns: new[] { "OrderHasProductOrderId", "OrderHasProductProductId" },
                principalTable: "OrderHasProduct",
                principalColumns: new[] { "OrderId", "ProductId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_OrderHasProduct_OrderHasProductOrderId_OrderHasProductProductId",
                table: "Product",
                columns: new[] { "OrderHasProductOrderId", "OrderHasProductProductId" },
                principalTable: "OrderHasProduct",
                principalColumns: new[] { "OrderId", "ProductId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
