using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowPanelApp.Migrations
{
    public partial class TeacherTableFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Class_School_SchoolId1",
                table: "Class");

            migrationBuilder.DropIndex(
                name: "IX_Class_SchoolId1",
                table: "Class");


            migrationBuilder.DropColumn(
                name: "SchoolId1",
                table: "Class");
        }
          

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Class_ClassId",
                table: "Teacher");
          

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Teacher");
                          

            migrationBuilder.CreateIndex(
                name: "IX_Class_TeacherId",
                table: "Class",
                column: "TeacherId",
                unique: true);        

            migrationBuilder.AddForeignKey(
                name: "FK_Class_Teacher_TeacherId",
                table: "Class",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
