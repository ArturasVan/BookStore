using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Data.Migrations
{
    public partial class fixingOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__OrderHasP__UserI__31EC6D26",
                table: "OrderHasProduct");

            migrationBuilder.DropForeignKey(
                name: "FK__ProductHa__Produ__44FF419A",
                table: "ProductHasCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPictures_Product_ProductId",
                table: "ProductPictures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderHasProduct",
                table: "OrderHasProduct");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "OrderHasProduct");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "OrderHasProduct");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Product",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Orders",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "OrderHasProduct",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 2)");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "OrderHasProduct",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "OrderHasProduct",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrdersOrderId",
                table: "OrderHasProduct",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "OrderHasProduct",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderHasProduct",
                table: "OrderHasProduct",
                columns: new[] { "OrderId", "ProductId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderHasProduct_OrdersOrderId",
                table: "OrderHasProduct",
                column: "OrdersOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHasProduct_ProductId",
                table: "OrderHasProduct",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHasProduct_AspNetUsers_ApplicationUserId",
                table: "OrderHasProduct",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHasProduct_Orders_OrdersOrderId",
                table: "OrderHasProduct",
                column: "OrdersOrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHasProduct_Product_ProductId",
                table: "OrderHasProduct",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__ProductHa__Produ__44FF419A",
                table: "ProductHasCategory",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPictures_Product_ProductId",
                table: "ProductPictures",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderHasProduct_AspNetUsers_ApplicationUserId",
                table: "OrderHasProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderHasProduct_Orders_OrdersOrderId",
                table: "OrderHasProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderHasProduct_Product_ProductId",
                table: "OrderHasProduct");

            migrationBuilder.DropForeignKey(
                name: "FK__ProductHa__Produ__44FF419A",
                table: "ProductHasCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPictures_Product_ProductId",
                table: "ProductPictures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderHasProduct",
                table: "OrderHasProduct");

            migrationBuilder.DropIndex(
                name: "IX_OrderHasProduct_OrdersOrderId",
                table: "OrderHasProduct");

            migrationBuilder.DropIndex(
                name: "IX_OrderHasProduct_ProductId",
                table: "OrderHasProduct");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "OrderHasProduct");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "OrderHasProduct");

            migrationBuilder.DropColumn(
                name: "OrdersOrderId",
                table: "OrderHasProduct");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "OrderHasProduct");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "OrderHasProduct",
                type: "decimal(10, 2)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "OrderHasProduct",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "OrderHasProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderHasProduct",
                table: "OrderHasProduct",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__OrderHasP__UserI__31EC6D26",
                table: "OrderHasProduct",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__ProductHa__Produ__44FF419A",
                table: "ProductHasCategory",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPictures_Product_ProductId",
                table: "ProductPictures",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
