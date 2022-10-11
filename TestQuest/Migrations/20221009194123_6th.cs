using Microsoft.EntityFrameworkCore.Migrations;

namespace TestQuest.Migrations
{
    public partial class _6th : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RightAnserIndex",
                table: "Questions",
                newName: "RightAnserNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RightAnserNumber",
                table: "Questions",
                newName: "RightAnserIndex");
        }
    }
}
