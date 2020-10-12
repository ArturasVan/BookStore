using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Data.Migrations
{
    public partial class deleteroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__OrderHasP__RoleI__32E0915F",
                table: "OrderHasProduct");

            migrationBuilder.DropTable(
                name: "UserHasRoles");

            migrationBuilder.DropTable(
                name: "AppUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_OrderHasProduct_RoleId",
                table: "OrderHasProduct");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserHasRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_OrderHasProduct_RoleId",
                table: "OrderHasProduct",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserHasRoles_RoleId",
                table: "UserHasRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserHasRoles_UserId",
                table: "UserHasRoles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK__OrderHasP__RoleI__32E0915F",
                table: "OrderHasProduct",
                column: "RoleId",
                principalTable: "AppUserRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
