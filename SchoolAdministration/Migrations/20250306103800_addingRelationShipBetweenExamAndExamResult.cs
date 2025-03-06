using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolAdministration.Migrations
{
    /// <inheritdoc />
    public partial class addingRelationShipBetweenExamAndExamResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExamId",
                table: "ExamResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ExamResults_ExamId",
                table: "ExamResults",
                column: "ExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamResults_Exams_ExamId",
                table: "ExamResults",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamResults_Exams_ExamId",
                table: "ExamResults");

            migrationBuilder.DropIndex(
                name: "IX_ExamResults_ExamId",
                table: "ExamResults");

            migrationBuilder.DropColumn(
                name: "ExamId",
                table: "ExamResults");
        }
    }
}
