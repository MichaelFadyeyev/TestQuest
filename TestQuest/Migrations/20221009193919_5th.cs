using Microsoft.EntityFrameworkCore.Migrations;

namespace TestQuest.Migrations
{
    public partial class _5th : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RightIndex",
                table: "Questions",
                newName: "RightAnserIndex");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RightAnserIndex",
                table: "Questions",
                newName: "RightIndex");
        }
    }
}
