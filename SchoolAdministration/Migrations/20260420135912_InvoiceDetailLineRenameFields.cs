using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolAdministration.Migrations
{
    /// <inheritdoc />
    public partial class InvoiceDetailLineRenameFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArticleId",
                table: "InvoiceDetailLines");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "InvoiceDetailLines");

            migrationBuilder.RenameColumn(
                name: "NumberOfCourses",
                table: "InvoiceDetailLines",
                newName: "UnitId");

            migrationBuilder.RenameColumn(
                name: "NumberOfArticles",
                table: "InvoiceDetailLines",
                newName: "UnitCount");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "InvoiceDetailLines",
                newName: "UnitPrice");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "InvoiceDetailLines",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "UnitId",
                table: "InvoiceDetailLines",
                newName: "NumberOfCourses");

            migrationBuilder.RenameColumn(
                name: "UnitCount",
                table: "InvoiceDetailLines",
                newName: "NumberOfArticles");

            migrationBuilder.AddColumn<int>(
                name: "ArticleId",
                table: "InvoiceDetailLines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "InvoiceDetailLines",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
