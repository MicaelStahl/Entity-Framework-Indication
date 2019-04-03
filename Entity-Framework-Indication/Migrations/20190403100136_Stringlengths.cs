using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity_Framework_Indication.Migrations
{
    public partial class Stringlengths : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Grades",
                table: "Courses",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Grades",
                table: "Assignments",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 5,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Grades",
                table: "Courses",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Grades",
                table: "Assignments",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 3,
                oldNullable: true);
        }
    }
}
