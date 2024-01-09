using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcEgitimPortalı.Migrations
{
    /// <inheritdoc />
    public partial class mig6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Instructors_LessonId",
                table: "Instructors",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Lessons_LessonId",
                table: "Instructors",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "LessonId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Lessons_LessonId",
                table: "Instructors");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_LessonId",
                table: "Instructors");
        }
    }
}
