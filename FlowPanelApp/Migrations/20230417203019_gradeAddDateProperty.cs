using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowPanelApp.Migrations
{
    public partial class gradeAddDateProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AddDate",
                table: "Grade",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddDate",
                table: "Grade");
        }
    }
}
