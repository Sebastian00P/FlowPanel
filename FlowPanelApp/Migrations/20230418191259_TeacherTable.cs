using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowPanelApp.Migrations
{
    public partial class TeacherTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Class_SchoolId",
                table: "Class");

            migrationBuilder.AddColumn<long>(
                name: "SchoolId1",
                table: "Class",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TeacherId",
                table: "Class",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    TeacherId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pesel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Picture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ClassId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.TeacherId);
                    table.ForeignKey(
                        name: "FK_Teacher_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Class_SchoolId",
                table: "Class",
                column: "SchoolId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Class_SchoolId1",
                table: "Class",
                column: "SchoolId1");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_ClassId",
                table: "Teacher",
                column: "ClassId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Class_School_SchoolId1",
                table: "Class",
                column: "SchoolId1",
                principalTable: "School",
                principalColumn: "SchoolId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Class_School_SchoolId1",
                table: "Class");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Class_SchoolId",
                table: "Class");

            migrationBuilder.DropIndex(
                name: "IX_Class_SchoolId1",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "SchoolId1",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Class");

            migrationBuilder.CreateIndex(
                name: "IX_Class_SchoolId",
                table: "Class",
                column: "SchoolId");
        }
    }
}
