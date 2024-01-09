using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcEgitimPortalı.Migrations
{
    /// <inheritdoc />
    public partial class mig9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LessonName",
                table: "Notes");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Notes",
                newName: "LessonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LessonId",
                table: "Notes",
                newName: "Date");

            migrationBuilder.AddColumn<string>(
                name: "LessonName",
                table: "Notes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
