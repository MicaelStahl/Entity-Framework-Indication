using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity_Framework_Indication.Migrations
{
    public partial class UpdatedFrontEnd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Teachers",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<string>(
                name: "SchoolYear",
                table: "Students",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Students",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 12);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumber",
                table: "Teachers",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<int>(
                name: "SchoolYear",
                table: "Students",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 6);

            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumber",
                table: "Students",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 12);
        }
    }
}
