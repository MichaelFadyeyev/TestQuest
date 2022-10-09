using Microsoft.EntityFrameworkCore.Migrations;

namespace TestQuest.Migrations
{
    public partial class _2nd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Subjects_SublectId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_SublectId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "SublectId",
                table: "Questions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SublectId",
                table: "Questions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_SublectId",
                table: "Questions",
                column: "SublectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Subjects_SublectId",
                table: "Questions",
                column: "SublectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
