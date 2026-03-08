using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolAdministration.Migrations
{
    /// <inheritdoc />
    public partial class Add_QAExamAnswerByStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamResults_QAExamDetails_QAExamDetailId",
                table: "ExamResults");

            migrationBuilder.DropForeignKey(
                name: "FK_QAExamQuestions_QAExamDetails_QAExamDetailId",
                table: "QAExamQuestions");

            migrationBuilder.DropTable(
                name: "QAExamDetails");

            migrationBuilder.RenameColumn(
                name: "QAExamDetailId",
                table: "QAExamQuestions",
                newName: "QAExamId");

            migrationBuilder.RenameIndex(
                name: "IX_QAExamQuestions_QAExamDetailId",
                table: "QAExamQuestions",
                newName: "IX_QAExamQuestions_QAExamId");

            migrationBuilder.RenameColumn(
                name: "QAExamDetailId",
                table: "ExamResults",
                newName: "QAExamId");

            migrationBuilder.RenameIndex(
                name: "IX_ExamResults_QAExamDetailId",
                table: "ExamResults",
                newName: "IX_ExamResults_QAExamId");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "InvoiceDetailLines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfCourses",
                table: "InvoiceDetailLines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "QAExams",
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
                    table.PrimaryKey("PK_QAExams", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherAddresses_AddressId",
                table: "TeacherAddresses",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAddresses_AddressId",
                table: "StudentAddresses",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamResults_QAExams_QAExamId",
                table: "ExamResults",
                column: "QAExamId",
                principalTable: "QAExams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QAExamQuestions_QAExams_QAExamId",
                table: "QAExamQuestions",
                column: "QAExamId",
                principalTable: "QAExams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAddresses_Addresses_AddressId",
                table: "StudentAddresses",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherAddresses_Addresses_AddressId",
                table: "TeacherAddresses",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamResults_QAExams_QAExamId",
                table: "ExamResults");

            migrationBuilder.DropForeignKey(
                name: "FK_QAExamQuestions_QAExams_QAExamId",
                table: "QAExamQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAddresses_Addresses_AddressId",
                table: "StudentAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherAddresses_Addresses_AddressId",
                table: "TeacherAddresses");

            migrationBuilder.DropTable(
                name: "QAExams");

            migrationBuilder.DropIndex(
                name: "IX_TeacherAddresses_AddressId",
                table: "TeacherAddresses");

            migrationBuilder.DropIndex(
                name: "IX_StudentAddresses_AddressId",
                table: "StudentAddresses");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "InvoiceDetailLines");

            migrationBuilder.DropColumn(
                name: "NumberOfCourses",
                table: "InvoiceDetailLines");

            migrationBuilder.RenameColumn(
                name: "QAExamId",
                table: "QAExamQuestions",
                newName: "QAExamDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_QAExamQuestions_QAExamId",
                table: "QAExamQuestions",
                newName: "IX_QAExamQuestions_QAExamDetailId");

            migrationBuilder.RenameColumn(
                name: "QAExamId",
                table: "ExamResults",
                newName: "QAExamDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_ExamResults_QAExamId",
                table: "ExamResults",
                newName: "IX_ExamResults_QAExamDetailId");

            migrationBuilder.CreateTable(
                name: "QAExamDetails",
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
                    table.PrimaryKey("PK_QAExamDetails", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ExamResults_QAExamDetails_QAExamDetailId",
                table: "ExamResults",
                column: "QAExamDetailId",
                principalTable: "QAExamDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QAExamQuestions_QAExamDetails_QAExamDetailId",
                table: "QAExamQuestions",
                column: "QAExamDetailId",
                principalTable: "QAExamDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
