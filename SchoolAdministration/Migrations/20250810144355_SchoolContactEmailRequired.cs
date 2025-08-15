using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolAdministration.Migrations
{
    /// <inheritdoc />
    public partial class SchoolContactEmailRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ContactEmail",
                table: "Schools",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EstablishedYear" },
                values: new object[] { new DateTime(2025, 8, 10, 16, 43, 55, 271, DateTimeKind.Local).AddTicks(1469), new DateTime(2025, 8, 10, 16, 43, 55, 271, DateTimeKind.Local).AddTicks(1586) });

            migrationBuilder.UpdateData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EstablishedYear" },
                values: new object[] { new DateTime(2025, 8, 10, 16, 43, 55, 271, DateTimeKind.Local).AddTicks(1844), new DateTime(2025, 8, 10, 16, 43, 55, 271, DateTimeKind.Local).AddTicks(1846) });

            migrationBuilder.UpdateData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EstablishedYear" },
                values: new object[] { new DateTime(2025, 8, 10, 16, 43, 55, 271, DateTimeKind.Local).AddTicks(1848), new DateTime(2025, 8, 10, 16, 43, 55, 271, DateTimeKind.Local).AddTicks(1849) });

            migrationBuilder.UpdateData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EstablishedYear" },
                values: new object[] { new DateTime(2025, 8, 10, 16, 43, 55, 271, DateTimeKind.Local).AddTicks(1851), new DateTime(2025, 8, 10, 16, 43, 55, 271, DateTimeKind.Local).AddTicks(1852) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ContactEmail",
                table: "Schools",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EstablishedYear" },
                values: new object[] { new DateTime(2025, 8, 10, 12, 37, 11, 51, DateTimeKind.Local).AddTicks(4204), new DateTime(2025, 8, 10, 12, 37, 11, 51, DateTimeKind.Local).AddTicks(4322) });

            migrationBuilder.UpdateData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EstablishedYear" },
                values: new object[] { new DateTime(2025, 8, 10, 12, 37, 11, 51, DateTimeKind.Local).AddTicks(4564), new DateTime(2025, 8, 10, 12, 37, 11, 51, DateTimeKind.Local).AddTicks(4566) });

            migrationBuilder.UpdateData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EstablishedYear" },
                values: new object[] { new DateTime(2025, 8, 10, 12, 37, 11, 51, DateTimeKind.Local).AddTicks(4569), new DateTime(2025, 8, 10, 12, 37, 11, 51, DateTimeKind.Local).AddTicks(4570) });

            migrationBuilder.UpdateData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EstablishedYear" },
                values: new object[] { new DateTime(2025, 8, 10, 12, 37, 11, 51, DateTimeKind.Local).AddTicks(4572), new DateTime(2025, 8, 10, 12, 37, 11, 51, DateTimeKind.Local).AddTicks(4573) });
        }
    }
}
