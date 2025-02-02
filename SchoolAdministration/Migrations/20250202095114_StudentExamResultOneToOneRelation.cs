using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolAdministration.Migrations
{
    /// <inheritdoc />
    public partial class StudentExamResultOneToOneRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score",
                table: "ExamResults");

            migrationBuilder.RenameColumn(
                name: "ExamId",
                table: "ExamResults",
                newName: "CourseId");

            migrationBuilder.AddColumn<double>(
                name: "ExamenResultScore",
                table: "ExamResults",
                type: "float",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExamResults_StudentId",
                table: "ExamResults",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamResults_Students_StudentId",
                table: "ExamResults",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamResults_Students_StudentId",
                table: "ExamResults");

            migrationBuilder.DropIndex(
                name: "IX_ExamResults_StudentId",
                table: "ExamResults");

            migrationBuilder.DropColumn(
                name: "ExamenResultScore",
                table: "ExamResults");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "ExamResults",
                newName: "ExamId");

            migrationBuilder.AddColumn<decimal>(
                name: "Score",
                table: "ExamResults",
                type: "decimal(18,2)",
                nullable: true);
        }
    }
}
