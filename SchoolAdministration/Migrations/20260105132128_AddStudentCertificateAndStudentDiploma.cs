using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolAdministration.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentCertificateAndStudentDiploma : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentCertificates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CertificationId = table.Column<int>(type: "int", nullable: false),
                    CertificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CertificateScore = table.Column<double>(type: "float", nullable: true),
                    CertificateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCertificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentCertificates_Certificates_CertificateId",
                        column: x => x.CertificateId,
                        principalTable: "Certificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCertificates_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentDiplomas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    DiplomaId = table.Column<int>(type: "int", nullable: false),
                    DiplomaDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiplomaScore = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentDiplomas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentDiplomas_Diplomas_DiplomaId",
                        column: x => x.DiplomaId,
                        principalTable: "Diplomas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentDiplomas_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCertificates_CertificateId",
                table: "StudentCertificates",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCertificates_StudentId",
                table: "StudentCertificates",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentDiplomas_DiplomaId",
                table: "StudentDiplomas",
                column: "DiplomaId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentDiplomas_StudentId",
                table: "StudentDiplomas",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentCertificates");

            migrationBuilder.DropTable(
                name: "StudentDiplomas");
        }
    }
}
