using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolAdministration.Migrations
{
    /// <inheritdoc />
    public partial class SeedAspNetRoleClaims : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "Permission", "Users.Create", "7cc42937-7905-486c-bfcc-7c9319994565" },
                    { 2, "Permission", "Users.Update", "7cc42937-7905-486c-bfcc-7c9319994565" },
                    { 3, "Permission", "Users.Delete", "7cc42937-7905-486c-bfcc-7c9319994565" },
                    { 4, "Permission", "Users.Create", "d1c8e5b6-9a3f-4c8e-9f0a-2b5e6c7d8f90" },
                    { 5, "Permission", "Users.Update", "d1c8e5b6-9a3f-4c8e-9f0a-2b5e6c7d8f90" },
                    { 6, "Permission", "Students.Create", "d1c8e5b6-9a3f-4c8e-9f0a-2b5e6c7d8f90" },
                    { 7, "Permission", "Students.Update", "d1c8e5b6-9a3f-4c8e-9f0a-2b5e6c7d8f90" },
                    { 8, "Permission", "Teachers.Create", "d1c8e5b6-9a3f-4c8e-9f0a-2b5e6c7d8f90" },
                    { 9, "Permission", "Teachers.Update", "d1c8e5b6-9a3f-4c8e-9f0a-2b5e6c7d8f90" },
                    { 10, "Permission", "HomeWorks.Create", "906572c2-a601-4286-8e0f-8c03e0395e85" },
                    { 11, "Permission", "HomeWorks.Update", "906572c2-a601-4286-8e0f-8c03e0395e85" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 11);
        }
    }
}
