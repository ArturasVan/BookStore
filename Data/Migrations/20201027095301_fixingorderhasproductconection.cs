using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Data.Migrations
{
    public partial class fixingorderhasproductconection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderHasProduct_Orders_OrdersOrderId",
                table: "OrderHasProduct");

            migrationBuilder.DropIndex(
                name: "IX_OrderHasProduct_OrdersOrderId",
                table: "OrderHasProduct");

            migrationBuilder.DropColumn(
                name: "OrdersOrderId",
                table: "OrderHasProduct");

            migrationBuilder.AddColumn<int>(
                name: "OrderHasProductOrderId",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderHasProductProductId",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderHasProductOrderId_OrderHasProductProductId",
                table: "Orders",
                columns: new[] { "OrderHasProductOrderId", "OrderHasProductProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHasProduct_Orders_OrderId",
                table: "OrderHasProduct",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderHasProduct_OrderHasProductOrderId_OrderHasProductProductId",
                table: "Orders",
                columns: new[] { "OrderHasProductOrderId", "OrderHasProductProductId" },
                principalTable: "OrderHasProduct",
                principalColumns: new[] { "OrderId", "ProductId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderHasProduct_Orders_OrderId",
                table: "OrderHasProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderHasProduct_OrderHasProductOrderId_OrderHasProductProductId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderHasProductOrderId_OrderHasProductProductId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderHasProductOrderId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderHasProductProductId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "OrdersOrderId",
                table: "OrderHasProduct",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderHasProduct_OrdersOrderId",
                table: "OrderHasProduct",
                column: "OrdersOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHasProduct_Orders_OrdersOrderId",
                table: "OrderHasProduct",
                column: "OrdersOrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
