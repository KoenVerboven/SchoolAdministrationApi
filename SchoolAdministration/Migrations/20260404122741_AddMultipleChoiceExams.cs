using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolAdministration.Migrations
{
    /// <inheritdoc />
    public partial class AddMultipleChoiceExams : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MCExamId",
                table: "ExamResults",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassRoomId",
                table: "CourseSchedulings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "CourseSchedulings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "CourseSchedulings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DayOfWeek",
                table: "CourseSchedulings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "CourseSchedulings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SchoolClassId",
                table: "CourseSchedulings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "CourseSchedulings",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "CourseSchedulings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "CourseSchedulings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "CourseSchedulings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WeekNumber",
                table: "CourseSchedulings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MCExams",
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
                    table.PrimaryKey("PK_MCExams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MCExamQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionNumber = table.Column<int>(type: "int", nullable: false),
                    QuestionText = table.Column<int>(type: "int", nullable: false),
                    MCExamId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MCExamQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MCExamQuestions_MCExams_MCExamId",
                        column: x => x.MCExamId,
                        principalTable: "MCExams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MCExamOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MCExamQuestionId = table.Column<int>(type: "int", nullable: false),
                    Option = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCorrectAnswer = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MCExamOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MCExamOptions_MCExamQuestions_MCExamQuestionId",
                        column: x => x.MCExamQuestionId,
                        principalTable: "MCExamQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExamResults_MCExamId",
                table: "ExamResults",
                column: "MCExamId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSchedulings_CourseId",
                table: "CourseSchedulings",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_MCExamOptions_MCExamQuestionId",
                table: "MCExamOptions",
                column: "MCExamQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_MCExamQuestions_MCExamId",
                table: "MCExamQuestions",
                column: "MCExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSchedulings_Courses_CourseId",
                table: "CourseSchedulings",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamResults_MCExams_MCExamId",
                table: "ExamResults",
                column: "MCExamId",
                principalTable: "MCExams",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseSchedulings_Courses_CourseId",
                table: "CourseSchedulings");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamResults_MCExams_MCExamId",
                table: "ExamResults");

            migrationBuilder.DropTable(
                name: "MCExamOptions");

            migrationBuilder.DropTable(
                name: "MCExamQuestions");

            migrationBuilder.DropTable(
                name: "MCExams");

            migrationBuilder.DropIndex(
                name: "IX_ExamResults_MCExamId",
                table: "ExamResults");

            migrationBuilder.DropIndex(
                name: "IX_CourseSchedulings_CourseId",
                table: "CourseSchedulings");

            migrationBuilder.DropColumn(
                name: "MCExamId",
                table: "ExamResults");

            migrationBuilder.DropColumn(
                name: "ClassRoomId",
                table: "CourseSchedulings");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "CourseSchedulings");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CourseSchedulings");

            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "CourseSchedulings");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "CourseSchedulings");

            migrationBuilder.DropColumn(
                name: "SchoolClassId",
                table: "CourseSchedulings");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "CourseSchedulings");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "CourseSchedulings");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "CourseSchedulings");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "CourseSchedulings");

            migrationBuilder.DropColumn(
                name: "WeekNumber",
                table: "CourseSchedulings");
        }
    }
}
