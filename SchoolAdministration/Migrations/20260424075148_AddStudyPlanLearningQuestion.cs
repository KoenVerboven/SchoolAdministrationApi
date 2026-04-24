using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolAdministration.Migrations
{
    /// <inheritdoc />
    public partial class AddStudyPlanLearningQuestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudyPlanParts");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DueDate",
                table: "Invoices",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateTime>(
                name: "InvoiceDate",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "StudyPlanDetailLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartLearning = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndLearning = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GoalDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudyObjectiveArchievedInProcent = table.Column<int>(type: "int", nullable: true),
                    StudyPlanId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyPlanDetailLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudyPlanDetailLines_StudyPlans_StudyPlanId",
                        column: x => x.StudyPlanId,
                        principalTable: "StudyPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudyPlanLearningQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudyPlanId = table.Column<int>(type: "int", nullable: false),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnswerFilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyPlanLearningQuestions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudyPlanDetailLines_StudyPlanId",
                table: "StudyPlanDetailLines",
                column: "StudyPlanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudyPlanDetailLines");

            migrationBuilder.DropTable(
                name: "StudyPlanLearningQuestions");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "InvoiceDate",
                table: "Invoices");

            migrationBuilder.CreateTable(
                name: "StudyPlanParts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: true),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GoalDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudyObjectiveArchievedInProcent = table.Column<int>(type: "int", nullable: true),
                    StudyPlanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyPlanParts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudyPlanParts_StudyPlans_StudyPlanId",
                        column: x => x.StudyPlanId,
                        principalTable: "StudyPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudyPlanParts_StudyPlanId",
                table: "StudyPlanParts",
                column: "StudyPlanId");
        }
    }
}
