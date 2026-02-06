using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolAdministration.Migrations
{
    /// <inheritdoc />
    public partial class FixNamingViolationHomeworkTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_homeWorkDetailLines_HomeWorks_HomeWorkId",
                table: "homeWorkDetailLines");

            migrationBuilder.DropTable(
                name: "homeWorkDetailLineAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_homeWorkDetailLines",
                table: "homeWorkDetailLines");

            migrationBuilder.RenameTable(
                name: "homeWorkDetailLines",
                newName: "HomeWorkDetailLines");

            migrationBuilder.RenameIndex(
                name: "IX_homeWorkDetailLines_HomeWorkId",
                table: "HomeWorkDetailLines",
                newName: "IX_HomeWorkDetailLines_HomeWorkId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HomeWorkDetailLines",
                table: "HomeWorkDetailLines",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "HomeWorkDetailLineStudentAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomeWorkDetailLineId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeWorkDetailLineStudentAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeWorkDetailLineStudentAnswers_HomeWorkDetailLines_HomeWorkDetailLineId",
                        column: x => x.HomeWorkDetailLineId,
                        principalTable: "HomeWorkDetailLines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HomeWorkDetailLineStudentAnswers_HomeWorkDetailLineId",
                table: "HomeWorkDetailLineStudentAnswers",
                column: "HomeWorkDetailLineId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeWorkDetailLines_HomeWorks_HomeWorkId",
                table: "HomeWorkDetailLines",
                column: "HomeWorkId",
                principalTable: "HomeWorks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeWorkDetailLines_HomeWorks_HomeWorkId",
                table: "HomeWorkDetailLines");

            migrationBuilder.DropTable(
                name: "HomeWorkDetailLineStudentAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HomeWorkDetailLines",
                table: "HomeWorkDetailLines");

            migrationBuilder.RenameTable(
                name: "HomeWorkDetailLines",
                newName: "homeWorkDetailLines");

            migrationBuilder.RenameIndex(
                name: "IX_HomeWorkDetailLines_HomeWorkId",
                table: "homeWorkDetailLines",
                newName: "IX_homeWorkDetailLines_HomeWorkId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_homeWorkDetailLines",
                table: "homeWorkDetailLines",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "homeWorkDetailLineAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomeWorkDetailLineId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_homeWorkDetailLineAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_homeWorkDetailLineAnswers_homeWorkDetailLines_HomeWorkDetailLineId",
                        column: x => x.HomeWorkDetailLineId,
                        principalTable: "homeWorkDetailLines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_homeWorkDetailLineAnswers_HomeWorkDetailLineId",
                table: "homeWorkDetailLineAnswers",
                column: "HomeWorkDetailLineId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_homeWorkDetailLines_HomeWorks_HomeWorkId",
                table: "homeWorkDetailLines",
                column: "HomeWorkId",
                principalTable: "HomeWorks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
