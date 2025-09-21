using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class ChangeGuardian2BuildingToInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Guardian2SecondName",
                table: "AspNetUsers",
                newName: "Guardian2LastName");

            migrationBuilder.AlterColumn<int>(
                name: "Guardian2Building",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Guardian2LastName",
                table: "AspNetUsers",
                newName: "Guardian2SecondName");

            migrationBuilder.AlterColumn<string>(
                name: "Guardian2Building",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
