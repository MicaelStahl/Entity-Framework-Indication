using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity_Framework_Indication.Migrations
{
    public partial class RemovedAValueFromTeacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeachingSubject",
                table: "Teachers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TeachingSubject",
                table: "Teachers",
                maxLength: 20,
                nullable: true);
        }
    }
}
