using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Data.Migrations
{
    public partial class removeisrequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Product",
                unicode: false,
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(45)",
                oldUnicode: false,
                oldMaxLength: 45);

            migrationBuilder.AlterColumn<string>(
                name: "Info",
                table: "Product",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Autor",
                table: "Product",
                unicode: false,
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(45)",
                oldUnicode: false,
                oldMaxLength: 45);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Category",
                unicode: false,
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(45)",
                oldUnicode: false,
                oldMaxLength: 45);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AppUserRoles",
                unicode: false,
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(45)",
                oldUnicode: false,
                oldMaxLength: 45);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Product",
                type: "varchar(45)",
                unicode: false,
                maxLength: 45,
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 45,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Info",
                table: "Product",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Autor",
                table: "Product",
                type: "varchar(45)",
                unicode: false,
                maxLength: 45,
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 45,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Category",
                type: "varchar(45)",
                unicode: false,
                maxLength: 45,
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 45,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AppUserRoles",
                type: "varchar(45)",
                unicode: false,
                maxLength: 45,
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 45,
                oldNullable: true);
        }
    }
}
