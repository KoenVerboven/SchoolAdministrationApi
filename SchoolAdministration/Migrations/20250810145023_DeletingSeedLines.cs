using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolAdministration.Migrations
{
    /// <inheritdoc />
    public partial class DeletingSeedLines : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 4);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "ContactEmail", "ContactPhone", "CountryId", "CreatedAt", "CreatedBy", "Description", "EstablishedYear", "Facilities", "LogoUrl", "Name", "NumberOfStudents", "NumberOfTeachers", "SchoolType", "SocialMedia", "StreetAndNumber", "UpdatedAt", "UpdatedBy", "Website", "ZipCode" },
                values: new object[,]
                {
                    { 1, "VTechnischool@gmail.com", null, 0, new DateTime(2025, 8, 10, 16, 43, 55, 271, DateTimeKind.Local).AddTicks(1469), "system", null, new DateTime(2025, 8, 10, 16, 43, 55, 271, DateTimeKind.Local).AddTicks(1586), null, null, "Vrije Technische School", null, null, null, null, "Hoofdweg 1", null, "", null, 2300 },
                    { 2, "BSchoolTurnhout@gmail.com", null, 0, new DateTime(2025, 8, 10, 16, 43, 55, 271, DateTimeKind.Local).AddTicks(1844), "system", null, new DateTime(2025, 8, 10, 16, 43, 55, 271, DateTimeKind.Local).AddTicks(1846), null, null, "Basisschool Turnhout", null, null, null, null, "Kerkstraat 23", null, "", null, 2300 },
                    { 3, "KSchoolTurnhout@gmail.com", null, 0, new DateTime(2025, 8, 10, 16, 43, 55, 271, DateTimeKind.Local).AddTicks(1848), "system", null, new DateTime(2025, 8, 10, 16, 43, 55, 271, DateTimeKind.Local).AddTicks(1849), null, null, "Kleuterschool Turnhout", null, null, null, null, "Hoofdbaan 213", null, "", null, 2300 },
                    { 4, "PSchoolTurnhout@gmail.com", null, 0, new DateTime(2025, 8, 10, 16, 43, 55, 271, DateTimeKind.Local).AddTicks(1851), "system", null, new DateTime(2025, 8, 10, 16, 43, 55, 271, DateTimeKind.Local).AddTicks(1852), null, null, "Privateschool Turnhout", null, null, null, null, "steenweg 88", null, "", null, 2300 }
                });
        }
    }
}
