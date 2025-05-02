using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Levara.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddDomainEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DomainEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    EntityId = table.Column<int>(type: "integer", nullable: true),
                    OccurredOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Data = table.Column<Dictionary<string, object>>(type: "jsonb", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastEditedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<int>(type: "integer", nullable: true),
                    LastEditorId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainEvents", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 1", ["Date"] = new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 1", ["DueDate"] = new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 3,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 2", ["Date"] = new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 4,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 2", ["DueDate"] = new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 5,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 3", ["Date"] = new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 6,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 3", ["DueDate"] = new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 7,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 4", ["Date"] = new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 8,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 4", ["DueDate"] = new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 9,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 5", ["Date"] = new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 10,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 5", ["DueDate"] = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 11,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 6", ["Date"] = new DateTime(2023, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 12,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 6", ["DueDate"] = new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 13,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 7", ["Date"] = new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 14,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 7", ["DueDate"] = new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 15,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 8", ["Date"] = new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 16,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 8", ["DueDate"] = new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 17,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 9", ["Date"] = new DateTime(2023, 12, 23, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 18,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 9", ["DueDate"] = new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 19,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 10", ["Date"] = new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 20,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 10", ["DueDate"] = new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 21,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 1", ["Date"] = new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 22,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 1", ["DueDate"] = new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 23,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 2", ["Date"] = new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 24,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 2", ["DueDate"] = new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 25,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 3", ["Date"] = new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 26,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 3", ["DueDate"] = new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 27,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 4", ["Date"] = new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 28,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 4", ["DueDate"] = new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 29,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 5", ["Date"] = new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 30,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 5", ["DueDate"] = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 31,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 6", ["Date"] = new DateTime(2023, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 32,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 6", ["DueDate"] = new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 33,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 7", ["Date"] = new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 34,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 7", ["DueDate"] = new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 35,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 8", ["Date"] = new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 36,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 8", ["DueDate"] = new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 37,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 9", ["Date"] = new DateTime(2023, 12, 23, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 38,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 9", ["DueDate"] = new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 39,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 10", ["Date"] = new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 40,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 10", ["DueDate"] = new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 41,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 1", ["Date"] = new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 42,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 1", ["DueDate"] = new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 43,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 2", ["Date"] = new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 44,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 2", ["DueDate"] = new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 45,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 3", ["Date"] = new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 46,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 3", ["DueDate"] = new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 47,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 4", ["Date"] = new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 48,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 4", ["DueDate"] = new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 49,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 5", ["Date"] = new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 50,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 5", ["DueDate"] = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 51,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 6", ["Date"] = new DateTime(2023, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 52,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 6", ["DueDate"] = new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 53,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 7", ["Date"] = new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 54,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 7", ["DueDate"] = new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 55,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 8", ["Date"] = new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 56,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 8", ["DueDate"] = new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 57,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 9", ["Date"] = new DateTime(2023, 12, 23, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 58,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 9", ["DueDate"] = new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 59,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 10", ["Date"] = new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 60,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 10", ["DueDate"] = new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 61,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 1", ["Date"] = new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 62,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 1", ["DueDate"] = new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 63,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 2", ["Date"] = new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 64,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 2", ["DueDate"] = new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 65,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 3", ["Date"] = new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 66,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 3", ["DueDate"] = new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 67,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 4", ["Date"] = new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 68,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 4", ["DueDate"] = new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 69,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 5", ["Date"] = new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 70,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 5", ["DueDate"] = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 71,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 6", ["Date"] = new DateTime(2023, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 72,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 6", ["DueDate"] = new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 73,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 7", ["Date"] = new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 74,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 7", ["DueDate"] = new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 75,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 8", ["Date"] = new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 76,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 8", ["DueDate"] = new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 77,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 9", ["Date"] = new DateTime(2023, 12, 23, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 78,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 9", ["DueDate"] = new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 79,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 10", ["Date"] = new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 80,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 10", ["DueDate"] = new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 81,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 1", ["Date"] = new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 82,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 1", ["DueDate"] = new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 83,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 2", ["Date"] = new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 84,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 2", ["DueDate"] = new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 85,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 3", ["Date"] = new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 86,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 3", ["DueDate"] = new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 87,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 4", ["Date"] = new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 88,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 4", ["DueDate"] = new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 89,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 5", ["Date"] = new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 90,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 5", ["DueDate"] = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 91,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 6", ["Date"] = new DateTime(2023, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 92,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 6", ["DueDate"] = new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 93,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 7", ["Date"] = new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 94,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 7", ["DueDate"] = new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 95,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 8", ["Date"] = new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 96,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 8", ["DueDate"] = new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 97,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 9", ["Date"] = new DateTime(2023, 12, 23, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 98,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 9", ["DueDate"] = new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 99,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 10", ["Date"] = new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 100,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 10", ["DueDate"] = new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 101,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 1", ["Date"] = new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 102,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 1", ["DueDate"] = new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 103,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 2", ["Date"] = new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 104,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 2", ["DueDate"] = new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 105,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 3", ["Date"] = new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 106,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 3", ["DueDate"] = new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 107,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 4", ["Date"] = new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 108,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 4", ["DueDate"] = new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 109,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 5", ["Date"] = new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 110,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 5", ["DueDate"] = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 111,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 6", ["Date"] = new DateTime(2023, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 112,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 6", ["DueDate"] = new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 113,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 7", ["Date"] = new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 114,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 7", ["DueDate"] = new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 115,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 8", ["Date"] = new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 116,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 8", ["DueDate"] = new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 117,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 9", ["Date"] = new DateTime(2023, 12, 23, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 118,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 9", ["DueDate"] = new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 119,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 10", ["Date"] = new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 120,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 10", ["DueDate"] = new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 121,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 1", ["Date"] = new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 122,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 1", ["DueDate"] = new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 123,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 2", ["Date"] = new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 124,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 2", ["DueDate"] = new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 125,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 3", ["Date"] = new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 126,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 3", ["DueDate"] = new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 127,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 4", ["Date"] = new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 128,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 4", ["DueDate"] = new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 129,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 5", ["Date"] = new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 130,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 5", ["DueDate"] = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 131,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 6", ["Date"] = new DateTime(2023, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 132,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 6", ["DueDate"] = new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 133,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 7", ["Date"] = new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 134,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 7", ["DueDate"] = new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 135,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 8", ["Date"] = new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 136,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 8", ["DueDate"] = new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 137,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 9", ["Date"] = new DateTime(2023, 12, 23, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 138,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 9", ["DueDate"] = new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 139,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 10", ["Date"] = new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 140,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 10", ["DueDate"] = new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 141,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 1", ["Date"] = new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 142,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 1", ["DueDate"] = new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 143,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 2", ["Date"] = new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 144,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 2", ["DueDate"] = new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 145,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 3", ["Date"] = new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 146,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 3", ["DueDate"] = new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 147,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 4", ["Date"] = new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 148,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 4", ["DueDate"] = new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 149,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 5", ["Date"] = new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 150,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 5", ["DueDate"] = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 151,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 6", ["Date"] = new DateTime(2023, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 152,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 6", ["DueDate"] = new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 153,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 7", ["Date"] = new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 154,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 7", ["DueDate"] = new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 155,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 8", ["Date"] = new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 156,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 8", ["DueDate"] = new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 157,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 9", ["Date"] = new DateTime(2023, 12, 23, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 158,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 9", ["DueDate"] = new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 159,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 10", ["Date"] = new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 160,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 10", ["DueDate"] = new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 161,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 1", ["Date"] = new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 162,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 1", ["DueDate"] = new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 163,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 2", ["Date"] = new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 164,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 2", ["DueDate"] = new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 165,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 3", ["Date"] = new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 166,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 3", ["DueDate"] = new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 167,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 4", ["Date"] = new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 168,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 4", ["DueDate"] = new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 169,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 5", ["Date"] = new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 170,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 5", ["DueDate"] = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 171,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 6", ["Date"] = new DateTime(2023, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 172,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 6", ["DueDate"] = new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 173,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 7", ["Date"] = new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 174,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 7", ["DueDate"] = new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 175,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 8", ["Date"] = new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 176,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 8", ["DueDate"] = new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 177,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 9", ["Date"] = new DateTime(2023, 12, 23, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 178,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 9", ["DueDate"] = new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 179,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 10", ["Date"] = new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 180,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 10", ["DueDate"] = new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 181,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 1", ["Date"] = new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 182,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 1", ["DueDate"] = new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 183,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 2", ["Date"] = new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 184,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 2", ["DueDate"] = new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 185,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 3", ["Date"] = new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 186,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 3", ["DueDate"] = new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 187,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 4", ["Date"] = new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 188,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 4", ["DueDate"] = new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 189,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 5", ["Date"] = new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 190,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 5", ["DueDate"] = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 191,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 6", ["Date"] = new DateTime(2023, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 192,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 6", ["DueDate"] = new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 193,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 7", ["Date"] = new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 194,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 7", ["DueDate"] = new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 195,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 8", ["Date"] = new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 196,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 8", ["DueDate"] = new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 197,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 9", ["Date"] = new DateTime(2023, 12, 23, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 198,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 9", ["DueDate"] = new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 199,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 10", ["Date"] = new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 200,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 10", ["DueDate"] = new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.CreateIndex(
                name: "IX_DomainEvents_EventId",
                table: "DomainEvents",
                column: "EventId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DomainEvents");

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 1", ["Date"] = new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 1", ["DueDate"] = new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 3,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 2", ["Date"] = new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 4,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 2", ["DueDate"] = new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 5,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 3", ["Date"] = new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 6,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 3", ["DueDate"] = new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 7,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 4", ["Date"] = new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 8,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 4", ["DueDate"] = new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 9,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 5", ["Date"] = new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 10,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 5", ["DueDate"] = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 11,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 6", ["Date"] = new DateTime(2023, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 12,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 6", ["DueDate"] = new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 13,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 7", ["Date"] = new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 14,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 7", ["DueDate"] = new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 15,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 8", ["Date"] = new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 16,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 8", ["DueDate"] = new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 17,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 9", ["Date"] = new DateTime(2023, 12, 23, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 18,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 9", ["DueDate"] = new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 19,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 10", ["Date"] = new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 20,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 10", ["DueDate"] = new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 21,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 1", ["Date"] = new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 22,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 1", ["DueDate"] = new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 23,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 2", ["Date"] = new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 24,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 2", ["DueDate"] = new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 25,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 3", ["Date"] = new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 26,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 3", ["DueDate"] = new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 27,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 4", ["Date"] = new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 28,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 4", ["DueDate"] = new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 29,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 5", ["Date"] = new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 30,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 5", ["DueDate"] = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 31,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 6", ["Date"] = new DateTime(2023, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 32,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 6", ["DueDate"] = new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 33,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 7", ["Date"] = new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 34,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 7", ["DueDate"] = new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 35,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 8", ["Date"] = new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 36,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 8", ["DueDate"] = new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 37,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 9", ["Date"] = new DateTime(2023, 12, 23, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 38,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 9", ["DueDate"] = new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 39,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 10", ["Date"] = new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 40,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 10", ["DueDate"] = new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 41,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 1", ["Date"] = new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 42,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 1", ["DueDate"] = new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 43,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 2", ["Date"] = new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 44,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 2", ["DueDate"] = new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 45,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 3", ["Date"] = new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 46,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 3", ["DueDate"] = new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 47,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 4", ["Date"] = new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 48,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 4", ["DueDate"] = new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 49,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 5", ["Date"] = new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 50,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 5", ["DueDate"] = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 51,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 6", ["Date"] = new DateTime(2023, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 52,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 6", ["DueDate"] = new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 53,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 7", ["Date"] = new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 54,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 7", ["DueDate"] = new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 55,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 8", ["Date"] = new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 56,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 8", ["DueDate"] = new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 57,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 9", ["Date"] = new DateTime(2023, 12, 23, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 58,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 9", ["DueDate"] = new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 59,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 10", ["Date"] = new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 60,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 10", ["DueDate"] = new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 61,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 1", ["Date"] = new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 62,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 1", ["DueDate"] = new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 63,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 2", ["Date"] = new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 64,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 2", ["DueDate"] = new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 65,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 3", ["Date"] = new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 66,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 3", ["DueDate"] = new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 67,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 4", ["Date"] = new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 68,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 4", ["DueDate"] = new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 69,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 5", ["Date"] = new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 70,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 5", ["DueDate"] = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 71,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 6", ["Date"] = new DateTime(2023, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 72,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 6", ["DueDate"] = new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 73,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 7", ["Date"] = new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 74,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 7", ["DueDate"] = new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 75,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 8", ["Date"] = new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 76,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 8", ["DueDate"] = new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 77,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 9", ["Date"] = new DateTime(2023, 12, 23, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 78,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 9", ["DueDate"] = new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 79,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 10", ["Date"] = new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 80,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 10", ["DueDate"] = new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 81,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 1", ["Date"] = new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 82,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 1", ["DueDate"] = new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 83,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 2", ["Date"] = new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 84,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 2", ["DueDate"] = new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 85,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 3", ["Date"] = new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 86,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 3", ["DueDate"] = new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 87,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 4", ["Date"] = new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 88,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 4", ["DueDate"] = new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 89,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 5", ["Date"] = new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 90,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 5", ["DueDate"] = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 91,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 6", ["Date"] = new DateTime(2023, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 92,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 6", ["DueDate"] = new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 93,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 7", ["Date"] = new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 94,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 7", ["DueDate"] = new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 95,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 8", ["Date"] = new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 96,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 8", ["DueDate"] = new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 97,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 9", ["Date"] = new DateTime(2023, 12, 23, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 98,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 9", ["DueDate"] = new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 99,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 10", ["Date"] = new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 100,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 10", ["DueDate"] = new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 101,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 1", ["Date"] = new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 102,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 1", ["DueDate"] = new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 103,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 2", ["Date"] = new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 104,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 2", ["DueDate"] = new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 105,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 3", ["Date"] = new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 106,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 3", ["DueDate"] = new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 107,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 4", ["Date"] = new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 108,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 4", ["DueDate"] = new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 109,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 5", ["Date"] = new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 110,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 5", ["DueDate"] = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 111,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 6", ["Date"] = new DateTime(2023, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 112,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 6", ["DueDate"] = new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 113,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 7", ["Date"] = new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 114,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 7", ["DueDate"] = new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 115,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 8", ["Date"] = new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 116,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 8", ["DueDate"] = new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 117,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 9", ["Date"] = new DateTime(2023, 12, 23, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 118,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 9", ["DueDate"] = new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 119,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 10", ["Date"] = new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 120,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 10", ["DueDate"] = new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 121,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 1", ["Date"] = new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 122,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 1", ["DueDate"] = new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 123,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 2", ["Date"] = new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 124,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 2", ["DueDate"] = new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 125,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 3", ["Date"] = new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 126,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 3", ["DueDate"] = new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 127,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 4", ["Date"] = new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 128,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 4", ["DueDate"] = new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 129,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 5", ["Date"] = new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 130,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 5", ["DueDate"] = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 131,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 6", ["Date"] = new DateTime(2023, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 132,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 6", ["DueDate"] = new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 133,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 7", ["Date"] = new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 134,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 7", ["DueDate"] = new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 135,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 8", ["Date"] = new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 136,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 8", ["DueDate"] = new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 137,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 9", ["Date"] = new DateTime(2023, 12, 23, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 138,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 9", ["DueDate"] = new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 139,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 10", ["Date"] = new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 140,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 10", ["DueDate"] = new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 141,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 1", ["Date"] = new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 142,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 1", ["DueDate"] = new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 143,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 2", ["Date"] = new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 144,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 2", ["DueDate"] = new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 145,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 3", ["Date"] = new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 146,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 3", ["DueDate"] = new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 147,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 4", ["Date"] = new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 148,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 4", ["DueDate"] = new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 149,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 5", ["Date"] = new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 150,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 5", ["DueDate"] = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 151,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 6", ["Date"] = new DateTime(2023, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 152,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 6", ["DueDate"] = new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 153,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 7", ["Date"] = new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 154,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 7", ["DueDate"] = new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 155,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 8", ["Date"] = new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 156,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 8", ["DueDate"] = new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 157,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 9", ["Date"] = new DateTime(2023, 12, 23, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 158,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 9", ["DueDate"] = new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 159,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 10", ["Date"] = new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 160,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 10", ["DueDate"] = new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 161,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 1", ["Date"] = new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 162,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 1", ["DueDate"] = new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 163,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 2", ["Date"] = new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 164,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 2", ["DueDate"] = new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 165,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 3", ["Date"] = new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 166,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 3", ["DueDate"] = new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 167,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 4", ["Date"] = new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 168,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 4", ["DueDate"] = new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 169,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 5", ["Date"] = new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 170,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 5", ["DueDate"] = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 171,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 6", ["Date"] = new DateTime(2023, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 172,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 6", ["DueDate"] = new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 173,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 7", ["Date"] = new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 174,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 7", ["DueDate"] = new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 175,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 8", ["Date"] = new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 176,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 8", ["DueDate"] = new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 177,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 9", ["Date"] = new DateTime(2023, 12, 23, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 178,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 9", ["DueDate"] = new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 179,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 10", ["Date"] = new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 180,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 10", ["DueDate"] = new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 181,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 1", ["Date"] = new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 182,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 1", ["DueDate"] = new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 183,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 2", ["Date"] = new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 184,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 2", ["DueDate"] = new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 185,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 3", ["Date"] = new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 186,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 3", ["DueDate"] = new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 187,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 4", ["Date"] = new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 188,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 4", ["DueDate"] = new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 189,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 5", ["Date"] = new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 190,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 5", ["DueDate"] = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 191,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 6", ["Date"] = new DateTime(2023, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 192,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 6", ["DueDate"] = new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 193,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 7", ["Date"] = new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 194,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 7", ["DueDate"] = new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 195,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 8", ["Date"] = new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 196,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 8", ["DueDate"] = new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 197,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 9", ["Date"] = new DateTime(2023, 12, 23, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 198,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 9", ["DueDate"] = new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 199,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 10", ["Date"] = new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 200,
                column: "Data",
                value: new Dictionary<string, object> { ["Property"] = "Property 10", ["DueDate"] = new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" });
        }
    }
}
