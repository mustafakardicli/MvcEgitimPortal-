using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcEgitimPortalı.Migrations
{
    /// <inheritdoc />
    public partial class mig11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LessonName",
                table: "Notes");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "LessonName",
                table: "Notes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
