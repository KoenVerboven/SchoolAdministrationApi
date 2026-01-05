using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolAdministration.Migrations
{
    /// <inheritdoc />
    public partial class RemoveLinkStudentAndQualifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Certificates_CertificateId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Diplomas_DiplomaId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_CertificateId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_DiplomaId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CertificateId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DiplomaId",
                table: "Students");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CertificateId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DiplomaId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_CertificateId",
                table: "Students",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_DiplomaId",
                table: "Students",
                column: "DiplomaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Certificates_CertificateId",
                table: "Students",
                column: "CertificateId",
                principalTable: "Certificates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Diplomas_DiplomaId",
                table: "Students",
                column: "DiplomaId",
                principalTable: "Diplomas",
                principalColumn: "Id");
        }
    }
}
