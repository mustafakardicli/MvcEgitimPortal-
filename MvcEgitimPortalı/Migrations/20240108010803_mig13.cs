using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcEgitimPortalı.Migrations
{
    /// <inheritdoc />
    public partial class mig13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Lessons_LessonId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_LessonId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "Notes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LessonId",
                table: "Notes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Notes_LessonId",
                table: "Notes",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Lessons_LessonId",
                table: "Notes",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "LessonId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
