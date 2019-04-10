using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity_Framework_Indication.Migrations
{
    public partial class TeacherAddedSpecification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Specification",
                table: "Teachers",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Specification",
                table: "Teachers");
        }
    }
}
