using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcEgitimPortalı.Migrations
{
    /// <inheritdoc />
    public partial class mig10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
