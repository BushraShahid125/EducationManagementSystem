using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLessonStudentRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop old FK to StudentGroups
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_StudentGroups_StudentGroupId",
                table: "Lessons");

            // Drop old Duration (time) column
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Lessons");

            // Add new Duration (int) column
            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Lessons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            // Make StudentGroupId nullable
            migrationBuilder.AlterColumn<Guid>(
                name: "StudentGroupId",
                table: "Lessons",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            // Add StudentId FK
            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "Lessons",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_StudentId",
                table: "Lessons",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_AspNetUsers_StudentId",
                table: "Lessons",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_StudentGroups_StudentGroupId",
                table: "Lessons",
                column: "StudentGroupId",
                principalTable: "StudentGroups",
                principalColumn: "StudentGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_AspNetUsers_StudentId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_StudentGroups_StudentGroupId",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_StudentId",
                table: "Lessons");

            // Drop StudentId
            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Lessons");

            // Drop new int Duration
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Lessons");

            // Recreate old time Duration
            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "Lessons",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0));

            // Restore StudentGroupId as non-nullable
            migrationBuilder.AlterColumn<Guid>(
                name: "StudentGroupId",
                table: "Lessons",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_StudentGroups_StudentGroupId",
                table: "Lessons",
                column: "StudentGroupId",
                principalTable: "StudentGroups",
                principalColumn: "StudentGroupId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
