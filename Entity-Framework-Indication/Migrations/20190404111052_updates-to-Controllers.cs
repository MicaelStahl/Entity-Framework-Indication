using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity_Framework_Indication.Migrations
{
    public partial class updatestoControllers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentsCourses_Courses_CourseId",
                table: "StudentsCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsCourses_Students_StudentId",
                table: "StudentsCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentsCourses",
                table: "StudentsCourses");

            migrationBuilder.RenameTable(
                name: "StudentsCourses",
                newName: "Sc");

            migrationBuilder.RenameIndex(
                name: "IX_StudentsCourses_CourseId",
                table: "Sc",
                newName: "IX_Sc_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sc",
                table: "Sc",
                columns: new[] { "StudentId", "CourseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Sc_Courses_CourseId",
                table: "Sc",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sc_Students_StudentId",
                table: "Sc",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sc_Courses_CourseId",
                table: "Sc");

            migrationBuilder.DropForeignKey(
                name: "FK_Sc_Students_StudentId",
                table: "Sc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sc",
                table: "Sc");

            migrationBuilder.RenameTable(
                name: "Sc",
                newName: "StudentsCourses");

            migrationBuilder.RenameIndex(
                name: "IX_Sc_CourseId",
                table: "StudentsCourses",
                newName: "IX_StudentsCourses_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentsCourses",
                table: "StudentsCourses",
                columns: new[] { "StudentId", "CourseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsCourses_Courses_CourseId",
                table: "StudentsCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsCourses_Students_StudentId",
                table: "StudentsCourses",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
