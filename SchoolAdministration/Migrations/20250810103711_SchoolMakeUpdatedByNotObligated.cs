using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolAdministration.Migrations
{
    /// <inheritdoc />
    public partial class SchoolMakeUpdatedByNotObligated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Schools",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EstablishedYear",
                table: "Schools",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Schools",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Schools",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EstablishedYear",
                table: "Schools",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Schools",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EstablishedYear" },
                values: new object[] { new DateTime(2025, 8, 10, 12, 29, 13, 366, DateTimeKind.Local).AddTicks(8471), new DateTime(2025, 8, 10, 12, 29, 13, 366, DateTimeKind.Local).AddTicks(8616) });

            migrationBuilder.UpdateData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EstablishedYear" },
                values: new object[] { new DateTime(2025, 8, 10, 12, 29, 13, 366, DateTimeKind.Local).AddTicks(8830), new DateTime(2025, 8, 10, 12, 29, 13, 366, DateTimeKind.Local).AddTicks(8832) });

            migrationBuilder.UpdateData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EstablishedYear" },
                values: new object[] { new DateTime(2025, 8, 10, 12, 29, 13, 366, DateTimeKind.Local).AddTicks(8834), new DateTime(2025, 8, 10, 12, 29, 13, 366, DateTimeKind.Local).AddTicks(8835) });

            migrationBuilder.UpdateData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EstablishedYear" },
                values: new object[] { new DateTime(2025, 8, 10, 12, 29, 13, 366, DateTimeKind.Local).AddTicks(8837), new DateTime(2025, 8, 10, 12, 29, 13, 366, DateTimeKind.Local).AddTicks(8838) });
        }
    }
}
