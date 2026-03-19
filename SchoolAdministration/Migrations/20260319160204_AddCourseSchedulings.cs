using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolAdministration.Migrations
{
    /// <inheritdoc />
    public partial class AddCourseSchedulings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "HomeWorkDetailLines");

            migrationBuilder.CreateTable(
                name: "CourseSchedulings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    SchoolYear = table.Column<DateOnly>(type: "date", nullable: false),
                    Trimester = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSchedulings", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QAExamAnswerByStudentIds_QAExamQuestionId",
                table: "QAExamAnswerByStudentIds",
                column: "QAExamQuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_QAExamAnswerByStudentIds_QAExamQuestions_QAExamQuestionId",
                table: "QAExamAnswerByStudentIds",
                column: "QAExamQuestionId",
                principalTable: "QAExamQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QAExamAnswerByStudentIds_QAExamQuestions_QAExamQuestionId",
                table: "QAExamAnswerByStudentIds");

            migrationBuilder.DropTable(
                name: "CourseSchedulings");

            migrationBuilder.DropIndex(
                name: "IX_QAExamAnswerByStudentIds_QAExamQuestionId",
                table: "QAExamAnswerByStudentIds");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "HomeWorkDetailLines",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
