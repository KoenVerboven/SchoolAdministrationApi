using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolAdministration.Migrations
{
    /// <inheritdoc />
    public partial class AddQATables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamResults_Exams_ExamId",
                table: "ExamResults");

            migrationBuilder.DropTable(
                name: "ExamQuestions");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.RenameColumn(
                name: "ExamId",
                table: "ExamResults",
                newName: "QAExamDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_ExamResults_ExamId",
                table: "ExamResults",
                newName: "IX_ExamResults_QAExamDetailId");

            migrationBuilder.CreateTable(
                name: "QAExamDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    ExamTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExamType = table.Column<byte>(type: "tinyint", nullable: false),
                    IsReExam = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExamenDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExamEndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaxScore = table.Column<int>(type: "int", nullable: false),
                    MinScoreToPassExam = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QAExamDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QAExamQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QAExamDetailId = table.Column<int>(type: "int", nullable: false),
                    QuestionNumber = table.Column<int>(type: "int", nullable: false),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionGrade = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QAExamQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QAExamQuestions_QAExamDetails_QAExamDetailId",
                        column: x => x.QAExamDetailId,
                        principalTable: "QAExamDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QAExamAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QAExamQuestionId = table.Column<int>(type: "int", nullable: false),
                    CorrectAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QAExamAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QAExamAnswers_QAExamQuestions_QAExamQuestionId",
                        column: x => x.QAExamQuestionId,
                        principalTable: "QAExamQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QAExamAnswers_QAExamQuestionId",
                table: "QAExamAnswers",
                column: "QAExamQuestionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QAExamQuestions_QAExamDetailId",
                table: "QAExamQuestions",
                column: "QAExamDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamResults_QAExamDetails_QAExamDetailId",
                table: "ExamResults",
                column: "QAExamDetailId",
                principalTable: "QAExamDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamResults_QAExamDetails_QAExamDetailId",
                table: "ExamResults");

            migrationBuilder.DropTable(
                name: "QAExamAnswers");

            migrationBuilder.DropTable(
                name: "QAExamQuestions");

            migrationBuilder.DropTable(
                name: "QAExamDetails");

            migrationBuilder.RenameColumn(
                name: "QAExamDetailId",
                table: "ExamResults",
                newName: "ExamId");

            migrationBuilder.RenameIndex(
                name: "IX_ExamResults_QAExamDetailId",
                table: "ExamResults",
                newName: "IX_ExamResults_ExamId");

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExamEndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExamTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExamType = table.Column<byte>(type: "tinyint", nullable: false),
                    ExamenDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsReExam = table.Column<bool>(type: "bit", nullable: false),
                    MaxScore = table.Column<int>(type: "int", nullable: false),
                    MinScoreToPassExam = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExamQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamId = table.Column<int>(type: "int", nullable: false),
                    QuestionGrade = table.Column<double>(type: "float", nullable: false),
                    QuestionNumber = table.Column<int>(type: "int", nullable: false),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamQuestions_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestions_ExamId",
                table: "ExamQuestions",
                column: "ExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamResults_Exams_ExamId",
                table: "ExamResults",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
