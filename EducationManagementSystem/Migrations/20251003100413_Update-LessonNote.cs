using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLessonNote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "LessonNotes",
                newName: "StudentProgress");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "LessonNotes",
                newName: "HomeWork");

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "Lessons",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "AreasToWorkOn",
                table: "LessonNotes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContentCovered",
                table: "LessonNotes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Highlights",
                table: "LessonNotes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AreasToWorkOn",
                table: "LessonNotes");

            migrationBuilder.DropColumn(
                name: "ContentCovered",
                table: "LessonNotes");

            migrationBuilder.DropColumn(
                name: "Highlights",
                table: "LessonNotes");

            migrationBuilder.RenameColumn(
                name: "StudentProgress",
                table: "LessonNotes",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "HomeWork",
                table: "LessonNotes",
                newName: "Text");

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "Lessons",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
