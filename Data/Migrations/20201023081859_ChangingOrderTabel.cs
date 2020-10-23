using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Data.Migrations
{
    public partial class ChangingOrderTabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNo",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryAddress",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryCity",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryZip",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Firstname",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lastname",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryAddress",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryCity",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryZip",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Firstname",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Lastname",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNo",
                table: "AspNetUsers",
                type: "varchar(45)",
                unicode: false,
                maxLength: 45,
                nullable: true);
        }
    }
}
