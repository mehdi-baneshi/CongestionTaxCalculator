using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CongestionTax.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 1, 1001, "Gothenburg" });

            migrationBuilder.InsertData(
                table: "PublicHolidays",
                columns: new[] { "Id", "Date" },
                values: new object[,]
                {
                    { 1, new DateOnly(2013, 1, 1) },
                    { 2, new DateOnly(2013, 3, 29) },
                    { 3, new DateOnly(2013, 4, 1) },
                    { 4, new DateOnly(2013, 5, 1) },
                    { 5, new DateOnly(2013, 5, 9) },
                    { 6, new DateOnly(2013, 6, 6) },
                    { 7, new DateOnly(2013, 6, 21) },
                    { 8, new DateOnly(2013, 11, 1) },
                    { 9, new DateOnly(2013, 12, 25) },
                    { 10, new DateOnly(2013, 12, 26) }
                });

            migrationBuilder.InsertData(
                table: "TimelyTollFees",
                columns: new[] { "Id", "CityCode", "EndTime", "Fee", "StartTime" },
                values: new object[,]
                {
                    { 1, 1001, new TimeOnly(5, 59, 0), 0, new TimeOnly(0, 0, 0) },
                    { 2, 1001, new TimeOnly(6, 29, 0), 8, new TimeOnly(6, 0, 0) },
                    { 3, 1001, new TimeOnly(6, 59, 0), 13, new TimeOnly(6, 30, 0) },
                    { 4, 1001, new TimeOnly(7, 59, 0), 18, new TimeOnly(7, 0, 0) },
                    { 5, 1001, new TimeOnly(8, 29, 0), 13, new TimeOnly(8, 0, 0) },
                    { 6, 1001, new TimeOnly(14, 59, 0), 8, new TimeOnly(8, 30, 0) },
                    { 7, 1001, new TimeOnly(15, 29, 0), 13, new TimeOnly(15, 0, 0) },
                    { 8, 1001, new TimeOnly(16, 59, 0), 18, new TimeOnly(15, 30, 0) },
                    { 9, 1001, new TimeOnly(17, 59, 0), 13, new TimeOnly(17, 0, 0) },
                    { 10, 1001, new TimeOnly(18, 29, 0), 8, new TimeOnly(18, 0, 0) },
                    { 11, 1001, new TimeOnly(23, 59, 0), 0, new TimeOnly(18, 30, 0) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PublicHolidays",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PublicHolidays",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PublicHolidays",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PublicHolidays",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PublicHolidays",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PublicHolidays",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PublicHolidays",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PublicHolidays",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PublicHolidays",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "PublicHolidays",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TimelyTollFees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TimelyTollFees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TimelyTollFees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TimelyTollFees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TimelyTollFees",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TimelyTollFees",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TimelyTollFees",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TimelyTollFees",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TimelyTollFees",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TimelyTollFees",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TimelyTollFees",
                keyColumn: "Id",
                keyValue: 11);
        }
    }
}
