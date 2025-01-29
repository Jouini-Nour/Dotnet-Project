using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dotnet_Project.Migrations
{
    /// <inheritdoc />
    public partial class _3rd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Meetings",
                columns: new[] { "Id", "Date", "ModeratorId", "ParticipantId", "Subject", "Time" },
                values: new object[,]
                {
                    { 1, new DateOnly(2025, 2, 1), 2, 1, "Project Kickoff", new TimeOnly(10, 0, 0) },
                    { 2, new DateOnly(2025, 2, 3), 2, 3, "Quarterly Review", new TimeOnly(14, 30, 0) },
                    { 3, new DateOnly(2025, 2, 5), 1, 2, "Marketing Strategy", new TimeOnly(9, 15, 0) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
