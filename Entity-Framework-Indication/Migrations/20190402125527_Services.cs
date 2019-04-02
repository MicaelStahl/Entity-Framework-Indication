using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity_Framework_Indication.Migrations
{
    public partial class Services : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Teachers",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecondName",
                table: "Teachers",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TeachingSubject",
                table: "Teachers",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Students",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SchoolYear",
                table: "Students",
                maxLength: 2,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SecondName",
                table: "Students",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Courses",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "Courses",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Grades",
                table: "Courses",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Assignments",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "Assignments",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Grades",
                table: "Assignments",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Assignments",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "SecondName",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "TeachingSubject",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SchoolYear",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SecondName",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Teachers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Students",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Courses",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "Courses",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Grades",
                table: "Courses",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Assignments",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "Assignments",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Grades",
                table: "Assignments",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Assignments",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 250,
                oldNullable: true);
        }
    }
}
