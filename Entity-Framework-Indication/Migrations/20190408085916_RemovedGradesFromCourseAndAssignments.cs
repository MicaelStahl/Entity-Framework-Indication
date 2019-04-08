using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity_Framework_Indication.Migrations
{
    public partial class RemovedGradesFromCourseAndAssignments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grades",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Grades",
                table: "Assignments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Grades",
                table: "Courses",
                maxLength: 3,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Grades",
                table: "Assignments",
                maxLength: 3,
                nullable: true);
        }
    }
}
