using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcEgitimPortalı.Migrations
{
    /// <inheritdoc />
    public partial class mig5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lesson",
                table: "Instructors");

            migrationBuilder.AddColumn<int>(
                name: "LessonId",
                table: "Instructors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "Instructors");

            migrationBuilder.AddColumn<string>(
                name: "Lesson",
                table: "Instructors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
