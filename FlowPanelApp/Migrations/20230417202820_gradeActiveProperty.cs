using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowPanelApp.Migrations
{
    public partial class gradeActiveProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Grade",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Grade");
        }
    }
}
