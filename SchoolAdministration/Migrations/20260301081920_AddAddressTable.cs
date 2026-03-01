using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolAdministration.Migrations
{
    /// <inheritdoc />
    public partial class AddAddressTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HomeWorkDetailLineStudentAnswers_HomeWorkDetailLineId",
                table: "HomeWorkDetailLineStudentAnswers");

            migrationBuilder.DropColumn(
                name: "StreetAndNumber",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Zipcode",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "StreetAndNumber",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Zipcode",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "AddressSameAsStudent",
                table: "Parents");

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetAndNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BusNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zipcode = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomeWorkDetailLineCorrectAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomeWorkDetailLineId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeWorkDetailLineCorrectAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeWorkDetailLineCorrectAnswers_HomeWorkDetailLines_HomeWorkDetailLineId",
                        column: x => x.HomeWorkDetailLineId,
                        principalTable: "HomeWorkDetailLines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentAddresses",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    AddressOrder = table.Column<int>(type: "int", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegisteredByUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAddresses", x => new { x.StudentId, x.AddressId });
                    table.ForeignKey(
                        name: "FK_StudentAddresses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherAddresses",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    AddressOrder = table.Column<int>(type: "int", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegisteredByUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherAddresses", x => new { x.TeacherId, x.AddressId });
                    table.ForeignKey(
                        name: "FK_TeacherAddresses_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HomeWorkDetailLineStudentAnswers_HomeWorkDetailLineId",
                table: "HomeWorkDetailLineStudentAnswers",
                column: "HomeWorkDetailLineId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeWorkDetailLineCorrectAnswers_HomeWorkDetailLineId",
                table: "HomeWorkDetailLineCorrectAnswers",
                column: "HomeWorkDetailLineId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "HomeWorkDetailLineCorrectAnswers");

            migrationBuilder.DropTable(
                name: "StudentAddresses");

            migrationBuilder.DropTable(
                name: "TeacherAddresses");

            migrationBuilder.DropIndex(
                name: "IX_HomeWorkDetailLineStudentAnswers_HomeWorkDetailLineId",
                table: "HomeWorkDetailLineStudentAnswers");

            migrationBuilder.AddColumn<string>(
                name: "StreetAndNumber",
                table: "Teachers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Zipcode",
                table: "Teachers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreetAndNumber",
                table: "Students",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Zipcode",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AddressSameAsStudent",
                table: "Parents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_HomeWorkDetailLineStudentAnswers_HomeWorkDetailLineId",
                table: "HomeWorkDetailLineStudentAnswers",
                column: "HomeWorkDetailLineId",
                unique: true);
        }
    }
}
