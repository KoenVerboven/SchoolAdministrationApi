using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolAdministration.Migrations
{
    /// <inheritdoc />
    public partial class StudentPresenceAddToLateInMinutes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ToLateInMinutes",
                table: "StudentsPresence",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ArticleId",
                table: "Payments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentsPresence_CourseId",
                table: "StudentsPresence",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsPresence_StudentId",
                table: "StudentsPresence",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsPresence_Courses_CourseId",
                table: "StudentsPresence",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsPresence_Students_StudentId",
                table: "StudentsPresence",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentsPresence_Courses_CourseId",
                table: "StudentsPresence");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsPresence_Students_StudentId",
                table: "StudentsPresence");

            migrationBuilder.DropIndex(
                name: "IX_StudentsPresence_CourseId",
                table: "StudentsPresence");

            migrationBuilder.DropIndex(
                name: "IX_StudentsPresence_StudentId",
                table: "StudentsPresence");

            migrationBuilder.DropColumn(
                name: "ToLateInMinutes",
                table: "StudentsPresence");

            migrationBuilder.DropColumn(
                name: "ArticleId",
                table: "Payments");
        }
    }
}
