using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolAdministration.Migrations
{
    /// <inheritdoc />
    public partial class InsertIdentityRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4de15cdf-c009-4a7c-9134-245106e8ed02", null, "Parent", "PARENT" },
                    { "7cc42937-7905-486c-bfcc-7c9319994565", null, "Admin", "ADMIN" },
                    { "906572c2-a601-4286-8e0f-8c03e0395e85", null, "Teacher", "TEACHER" },
                    { "a1b2c3d4-e5f6-7890-abcd-ef1234567890", null, "Tester", "TESTER" },
                    { "c09ca4e9-4fb1-4599-8213-4385b5ba9e68", null, "Student", "STUDENT" },
                    { "d1c8e5b6-9a3f-4c8e-9f0a-2b5e6c7d8f90", null, "SchoolEmployee", "SCHOOLEMPLOYEE" },
                    { "f570f646-3f00-477f-a9cf-5053f03f0eaf", null, "SuperAdmin", "SUPERADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4de15cdf-c009-4a7c-9134-245106e8ed02");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cc42937-7905-486c-bfcc-7c9319994565");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "906572c2-a601-4286-8e0f-8c03e0395e85");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1b2c3d4-e5f6-7890-abcd-ef1234567890");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c09ca4e9-4fb1-4599-8213-4385b5ba9e68");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1c8e5b6-9a3f-4c8e-9f0a-2b5e6c7d8f90");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f570f646-3f00-477f-a9cf-5053f03f0eaf");
        }
    }
}
