using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolAdministration.Migrations
{
    /// <inheritdoc />
    public partial class AddDepartmentClassRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SchoolDepartmentId",
                table: "SchoolClasses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SchoolClasses_SchoolDepartmentId",
                table: "SchoolClasses",
                column: "SchoolDepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolClasses_SchoolDepartments_SchoolDepartmentId",
                table: "SchoolClasses",
                column: "SchoolDepartmentId",
                principalTable: "SchoolDepartments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolClasses_SchoolDepartments_SchoolDepartmentId",
                table: "SchoolClasses");

            migrationBuilder.DropIndex(
                name: "IX_SchoolClasses_SchoolDepartmentId",
                table: "SchoolClasses");

            migrationBuilder.DropColumn(
                name: "SchoolDepartmentId",
                table: "SchoolClasses");
        }
    }
}
