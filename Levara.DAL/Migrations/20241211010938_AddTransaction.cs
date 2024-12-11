using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Levara.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    SubType = table.Column<int>(type: "integer", nullable: false),
                    PropertyId = table.Column<int>(type: "integer", nullable: false),
                    EntityId = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    RunningBalance = table.Column<decimal>(type: "numeric", nullable: false),
                    EntityRunningBalance = table.Column<decimal>(type: "numeric", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastEditedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<int>(type: "integer", nullable: true),
                    LastEditorId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LeaseCharges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TransactionId = table.Column<int>(type: "integer", nullable: false),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LeaseId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastEditedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<int>(type: "integer", nullable: true),
                    LastEditorId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaseCharges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaseCharges_Leases_LeaseId",
                        column: x => x.LeaseId,
                        principalTable: "Leases",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LeaseCharges_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LeasePayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TransactionId = table.Column<int>(type: "integer", nullable: false),
                    LeaseId = table.Column<int>(type: "integer", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastEditedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<int>(type: "integer", nullable: true),
                    LastEditorId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeasePayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeasePayments_Leases_LeaseId",
                        column: x => x.LeaseId,
                        principalTable: "Leases",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LeasePayments_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TransactionApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChargeTransactionId = table.Column<int>(type: "integer", nullable: false),
                    PaymentTransactionId = table.Column<int>(type: "integer", nullable: false),
                    AppliedAmount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    BankTransactionId = table.Column<int>(type: "integer", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastEditedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<int>(type: "integer", nullable: true),
                    LastEditorId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionApplications_Transactions_ChargeTransactionId",
                        column: x => x.ChargeTransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TransactionApplications_Transactions_PaymentTransactionId",
                        column: x => x.PaymentTransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id");
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

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "CreatedDate", "CreatorId", "Date", "Deleted", "Description", "EntityId", "EntityRunningBalance", "LastEditedDate", "LastEditorId", "PropertyId", "RunningBalance", "SubType", "Type" },
                values: new object[,]
                {
                    { 1, 1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Charge of rent 1/1/2024", 1, -1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -1500m, 1, 1 },
                    { 2, 1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "Payment of rent 5/1/2024", 1, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0m, 2, 1 },
                    { 3, 1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Charge of rent 2/2/2024", 1, -1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -1500m, 1, 1 },
                    { 4, 1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "Payment of rent 5/2/2024", 1, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0m, 2, 1 },
                    { 5, 1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 3, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Charge of rent 3/3/2024", 1, -1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -1500m, 1, 1 },
                    { 6, 1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "Payment of rent 5/3/2024", 1, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0m, 2, 1 },
                    { 7, 1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 4, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Charge of rent 4/4/2024", 1, -1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -1500m, 1, 1 },
                    { 8, 1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "Payment of rent 5/4/2024", 1, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0m, 2, 1 },
                    { 9, 1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Charge of rent 5/5/2024", 1, -1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -1500m, 1, 1 },
                    { 10, 1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "Payment of rent 5/5/2024", 1, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0m, 2, 1 },
                    { 11, 1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 6, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Charge of rent 6/6/2024", 1, -1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -1500m, 1, 1 },
                    { 12, 1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "Payment of rent 5/6/2024", 1, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0m, 2, 1 },
                    { 13, 1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Charge of rent 7/7/2024", 1, -1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -1500m, 1, 1 },
                    { 14, 1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "Payment of rent 5/7/2024", 1, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0m, 2, 1 },
                    { 15, 1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 8, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Charge of rent 8/8/2024", 1, -1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -1500m, 1, 1 },
                    { 16, 1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "Payment of rent 5/8/2024", 1, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0m, 2, 1 },
                    { 17, 1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Charge of rent 9/9/2024", 1, -1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -1500m, 1, 1 },
                    { 18, 1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "Payment of rent 5/9/2024", 1, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0m, 2, 1 },
                    { 19, 1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 10, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Charge of rent 10/10/2024", 1, -1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -1500m, 1, 1 },
                    { 20, 1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "Payment of rent 5/10/2024", 1, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0m, 2, 1 },
                    { 21, 1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 11, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Charge of rent 11/11/2024", 1, -1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -1500m, 1, 1 },
                    { 22, 1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, "Payment of rent 5/11/2024", 1, 0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0m, 2, 1 },
                    { 23, 1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Charge of rent 12/12/2024", 1, -1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -1500m, 1, 1 },
                    { 24, 450m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 12, 9, 0, 0, 0, 0, DateTimeKind.Utc), false, "Charge of maintenance 9/12/2024", 1, -450m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -1950m, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "LeaseCharges",
                columns: new[] { "Id", "CreatedDate", "CreatorId", "Deleted", "DueDate", "LastEditedDate", "LastEditorId", "LeaseId", "Status", "TransactionId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 3, 1 },
                    { 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 3, 3 },
                    { 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 3, 5 },
                    { 4, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 3, 7 },
                    { 5, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 3, 9 },
                    { 6, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 3, 11 },
                    { 7, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 3, 13 },
                    { 8, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 3, 15 },
                    { 9, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 3, 17 },
                    { 10, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 3, 19 },
                    { 11, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 3, 21 },
                    { 12, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 12, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 3, 23 }
                });

            migrationBuilder.InsertData(
                table: "LeasePayments",
                columns: new[] { "Id", "CreatedDate", "CreatorId", "Deleted", "LastEditedDate", "LastEditorId", "LeaseId", "TransactionId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 2 },
                    { 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 4 },
                    { 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 6 },
                    { 4, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 8 },
                    { 5, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 10 },
                    { 6, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 12 },
                    { 7, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 14 },
                    { 8, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 16 },
                    { 9, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 18 },
                    { 10, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 20 },
                    { 11, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 22 }
                });

            migrationBuilder.InsertData(
                table: "TransactionApplications",
                columns: new[] { "Id", "AppliedAmount", "BankTransactionId", "ChargeTransactionId", "CreatedDate", "CreatorId", "Deleted", "LastEditedDate", "LastEditorId", "PaymentTransactionId" },
                values: new object[,]
                {
                    { 1, 1500m, 1, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 2 },
                    { 2, 1500m, 2, 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 4 },
                    { 3, 1500m, 3, 5, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 6 },
                    { 4, 1500m, 4, 7, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 8 },
                    { 5, 1500m, 5, 9, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 10 },
                    { 6, 1500m, 6, 11, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 12 },
                    { 7, 1500m, 7, 13, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 14 },
                    { 8, 1500m, 8, 15, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 16 },
                    { 9, 1500m, 9, 17, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 18 },
                    { 10, 1500m, 10, 19, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 20 },
                    { 11, 1500m, 11, 21, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 22 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeaseCharges_LeaseId",
                table: "LeaseCharges",
                column: "LeaseId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaseCharges_TransactionId",
                table: "LeaseCharges",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_LeasePayments_LeaseId",
                table: "LeasePayments",
                column: "LeaseId");

            migrationBuilder.CreateIndex(
                name: "IX_LeasePayments_TransactionId",
                table: "LeasePayments",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionApplications_ChargeTransactionId",
                table: "TransactionApplications",
                column: "ChargeTransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionApplications_PaymentTransactionId",
                table: "TransactionApplications",
                column: "PaymentTransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_PropertyId",
                table: "Transactions",
                column: "PropertyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaseCharges");

            migrationBuilder.DropTable(
                name: "LeasePayments");

            migrationBuilder.DropTable(
                name: "TransactionApplications");

            migrationBuilder.DropTable(
                name: "Transactions");

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
