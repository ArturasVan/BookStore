using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Data.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BillingAddress",
                table: "AspNetUsers",
                unicode: false,
                maxLength: 45,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingCity",
                table: "AspNetUsers",
                unicode: false,
                maxLength: 45,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BillingZip",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryAddress",
                table: "AspNetUsers",
                unicode: false,
                maxLength: 45,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryCity",
                table: "AspNetUsers",
                unicode: false,
                maxLength: 45,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryZip",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "AspNetUsers",
                unicode: false,
                maxLength: 45,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Firstname",
                table: "AspNetUsers",
                unicode: false,
                maxLength: 45,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lastname",
                table: "AspNetUsers",
                unicode: false,
                maxLength: 45,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNo",
                table: "AspNetUsers",
                unicode: false,
                maxLength: 45,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AppUserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(unicode: false, maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(unicode: false, maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Orders__UserId__2C3393D0",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(unicode: false, maxLength: 45, nullable: false),
                    Autor = table.Column<string>(unicode: false, maxLength: 45, nullable: false),
                    ReleaseYear = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    Info = table.Column<string>(type: "text", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderHasProduct",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHasProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK__OrderHasP__RoleI__32E0915F",
                        column: x => x.RoleId,
                        principalTable: "AppUserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__OrderHasP__UserI__31EC6D26",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserHasRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserHasRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK__UserHasRo__RoleI__286302EC",
                        column: x => x.RoleId,
                        principalTable: "AppUserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__UserHasRo__UserI__276EDEB3",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductHasCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductHasCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK__ProductHa__Categ__45F365D3",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__ProductHa__Produ__44FF419A",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderHasProduct_RoleId",
                table: "OrderHasProduct",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHasProduct_UserId",
                table: "OrderHasProduct",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductHasCategory_CategoryId",
                table: "ProductHasCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductHasCategory_ProductId",
                table: "ProductHasCategory",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UserHasRoles_RoleId",
                table: "UserHasRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserHasRoles_UserId",
                table: "UserHasRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderHasProduct");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ProductHasCategory");

            migrationBuilder.DropTable(
                name: "UserHasRoles");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "AppUserRoles");

            migrationBuilder.DropColumn(
                name: "BillingAddress",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BillingCity",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BillingZip",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DeliveryAddress",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DeliveryCity",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DeliveryZip",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Firstname",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Lastname",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhoneNo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
