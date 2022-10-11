using Microsoft.EntityFrameworkCore.Migrations;

namespace TestQuest.Migrations
{
    public partial class _7th : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_AspNetUsers_AppUserId",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Tests_AppUserId",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Tests");

            migrationBuilder.CreateTable(
                name: "TestItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TestId = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestItem_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestItem_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestItem_TestId",
                table: "TestItem",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_TestItem_UserId",
                table: "TestItem",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestItem");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Tests",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tests_AppUserId",
                table: "Tests",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_AspNetUsers_AppUserId",
                table: "Tests",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
