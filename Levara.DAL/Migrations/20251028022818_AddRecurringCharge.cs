using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Levara.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddRecurringCharge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaseCharges_Leases_LeaseId",
                table: "LeaseCharges");

            migrationBuilder.DropColumn(
                name: "MatchTags",
                table: "Leases");

            migrationBuilder.RenameColumn(
                name: "LeaseId",
                table: "LeaseCharges",
                newName: "TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_LeaseCharges_LeaseId",
                table: "LeaseCharges",
                newName: "IX_LeaseCharges_TypeId");

            migrationBuilder.AlterColumn<int>(
                name: "TransactionId",
                table: "PlaidReconciliation",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<decimal>(
                name: "ActualAmount",
                table: "PlaidReconciliation",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountDifference",
                table: "PlaidReconciliation",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountDifferencePercent",
                table: "PlaidReconciliation",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountMatchScore",
                table: "PlaidReconciliation",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountPenalty",
                table: "PlaidReconciliation",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountThreshold",
                table: "PlaidReconciliation",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "AmountWithinThreshold",
                table: "PlaidReconciliation",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "AppliedAt",
                table: "PlaidReconciliation",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppliedByUserId",
                table: "PlaidReconciliation",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConfiguredTags",
                table: "PlaidReconciliation",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DateMatchScore",
                table: "PlaidReconciliation",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ExpectedAmount",
                table: "PlaidReconciliation",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "HasExactAmountMatch",
                table: "PlaidReconciliation",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasExactTagMatch",
                table: "PlaidReconciliation",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "MatchPercentage",
                table: "PlaidReconciliation",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "MatchReason",
                table: "PlaidReconciliation",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MatchedAmount",
                table: "PlaidReconciliation",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "MatchedDate",
                table: "PlaidReconciliation",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MatchedDescription",
                table: "PlaidReconciliation",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MatchedTagsList",
                table: "PlaidReconciliation",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlaidDescription",
                table: "PlaidReconciliation",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PropertyName",
                table: "PlaidReconciliation",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecurringChargeId",
                table: "PlaidReconciliation",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecurringChargeName",
                table: "PlaidReconciliation",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "PlaidReconciliation",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TagMatchScore",
                table: "PlaidReconciliation",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "TagsMatched",
                table: "PlaidReconciliation",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TenantName",
                table: "PlaidReconciliation",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalTags",
                table: "PlaidReconciliation",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UnmatchedTagsList",
                table: "PlaidReconciliation",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LeaseChargeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastEditedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<int>(type: "integer", nullable: true),
                    LastEditorId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaseChargeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecurringCharges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    IsRecurrent = table.Column<bool>(type: "boolean", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: true),
                    Frequency = table.Column<int>(type: "integer", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    NextChargeDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LeaseId = table.Column<int>(type: "integer", nullable: true),
                    PropertyId = table.Column<int>(type: "integer", nullable: false),
                    ExpenseId = table.Column<int>(type: "integer", nullable: true),
                    MaintenanceTypeId = table.Column<int>(type: "integer", nullable: true),
                    LeaseChargeTypeId = table.Column<int>(type: "integer", nullable: true),
                    MatchTags = table.Column<List<string>>(type: "text[]", nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastEditedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<int>(type: "integer", nullable: true),
                    LastEditorId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecurringCharges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecurringCharges_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RecurringCharges_LeaseChargeTypes_LeaseChargeTypeId",
                        column: x => x.LeaseChargeTypeId,
                        principalTable: "LeaseChargeTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RecurringCharges_Leases_LeaseId",
                        column: x => x.LeaseId,
                        principalTable: "Leases",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RecurringCharges_MaintenanceTypes_MaintenanceTypeId",
                        column: x => x.MaintenanceTypeId,
                        principalTable: "MaintenanceTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RecurringCharges_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RecurringChargeInstances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RecurringChargeId = table.Column<int>(type: "integer", nullable: false),
                    TransactionId = table.Column<int>(type: "integer", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastEditedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<int>(type: "integer", nullable: true),
                    LastEditorId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecurringChargeInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecurringChargeInstances_RecurringCharges_RecurringChargeId",
                        column: x => x.RecurringChargeId,
                        principalTable: "RecurringCharges",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RecurringChargeInstances_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "CreatorId", "LastEditedDate", "LastEditorId" },
                values: new object[] { new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1 });

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "CreatorId", "LastEditedDate", "LastEditorId" },
                values: new object[] { new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1 });

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "CreatorId", "LastEditedDate", "LastEditorId" },
                values: new object[] { new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1 });

            migrationBuilder.InsertData(
                table: "LeaseChargeTypes",
                columns: new[] { "Id", "CreatedDate", "CreatorId", "Deleted", "Description", "LastEditedDate", "LastEditorId", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, "Refundable amount held to cover damages or unpaid rent", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Security Deposit" },
                    { 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, "Charge for occupying the property", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Rent" },
                    { 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, "Refundable deposit to cover potential damages caused by pets", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Pet Deposit" },
                    { 4, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, "Additional charge for keeping a pet in the property", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Pet Rent" }
                });

            migrationBuilder.UpdateData(
                table: "MaintenanceTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "CreatorId", "LastEditedDate", "LastEditorId" },
                values: new object[] { new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1 });

            migrationBuilder.UpdateData(
                table: "MaintenanceTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "CreatorId", "LastEditedDate", "LastEditorId" },
                values: new object[] { new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1 });

            migrationBuilder.UpdateData(
                table: "MaintenanceTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "CreatorId", "LastEditedDate", "LastEditorId" },
                values: new object[] { new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_PlaidReconciliation_RecurringChargeId",
                table: "PlaidReconciliation",
                column: "RecurringChargeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringChargeInstances_RecurringChargeId",
                table: "RecurringChargeInstances",
                column: "RecurringChargeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringChargeInstances_TransactionId",
                table: "RecurringChargeInstances",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringCharges_ExpenseId",
                table: "RecurringCharges",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringCharges_LeaseChargeTypeId",
                table: "RecurringCharges",
                column: "LeaseChargeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringCharges_LeaseId",
                table: "RecurringCharges",
                column: "LeaseId");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringCharges_MaintenanceTypeId",
                table: "RecurringCharges",
                column: "MaintenanceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringCharges_PropertyId",
                table: "RecurringCharges",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaseCharges_LeaseChargeTypes_TypeId",
                table: "LeaseCharges",
                column: "TypeId",
                principalTable: "LeaseChargeTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlaidReconciliation_RecurringCharges_RecurringChargeId",
                table: "PlaidReconciliation",
                column: "RecurringChargeId",
                principalTable: "RecurringCharges",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaseCharges_LeaseChargeTypes_TypeId",
                table: "LeaseCharges");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaidReconciliation_RecurringCharges_RecurringChargeId",
                table: "PlaidReconciliation");

            migrationBuilder.DropTable(
                name: "RecurringChargeInstances");

            migrationBuilder.DropTable(
                name: "RecurringCharges");

            migrationBuilder.DropTable(
                name: "LeaseChargeTypes");

            migrationBuilder.DropIndex(
                name: "IX_PlaidReconciliation_RecurringChargeId",
                table: "PlaidReconciliation");

            migrationBuilder.DropColumn(
                name: "ActualAmount",
                table: "PlaidReconciliation");

            migrationBuilder.DropColumn(
                name: "AmountDifference",
                table: "PlaidReconciliation");

            migrationBuilder.DropColumn(
                name: "AmountDifferencePercent",
                table: "PlaidReconciliation");

            migrationBuilder.DropColumn(
                name: "AmountMatchScore",
                table: "PlaidReconciliation");

            migrationBuilder.DropColumn(
                name: "AmountPenalty",
                table: "PlaidReconciliation");

            migrationBuilder.DropColumn(
                name: "AmountThreshold",
                table: "PlaidReconciliation");

            migrationBuilder.DropColumn(
                name: "AmountWithinThreshold",
                table: "PlaidReconciliation");

            migrationBuilder.DropColumn(
                name: "AppliedAt",
                table: "PlaidReconciliation");

            migrationBuilder.DropColumn(
                name: "AppliedByUserId",
                table: "PlaidReconciliation");

            migrationBuilder.DropColumn(
                name: "ConfiguredTags",
                table: "PlaidReconciliation");

            migrationBuilder.DropColumn(
                name: "DateMatchScore",
                table: "PlaidReconciliation");

            migrationBuilder.DropColumn(
                name: "ExpectedAmount",
                table: "PlaidReconciliation");

            migrationBuilder.DropColumn(
                name: "HasExactAmountMatch",
                table: "PlaidReconciliation");

            migrationBuilder.DropColumn(
                name: "HasExactTagMatch",
                table: "PlaidReconciliation");

            migrationBuilder.DropColumn(
                name: "MatchPercentage",
                table: "PlaidReconciliation");

            migrationBuilder.DropColumn(
                name: "MatchReason",
                table: "PlaidReconciliation");

            migrationBuilder.DropColumn(
                name: "MatchedAmount",
                table: "PlaidReconciliation");

            migrationBuilder.DropColumn(
                name: "MatchedDate",
                table: "PlaidReconciliation");

            migrationBuilder.DropColumn(
                name: "MatchedDescription",
                table: "PlaidReconciliation");

            migrationBuilder.DropColumn(
                name: "MatchedTagsList",
                table: "PlaidReconciliation");

            migrationBuilder.DropColumn(
                name: "PlaidDescription",
                table: "PlaidReconciliation");

            migrationBuilder.DropColumn(
                name: "PropertyName",
                table: "PlaidReconciliation");

            migrationBuilder.DropColumn(
                name: "RecurringChargeId",
                table: "PlaidReconciliation");

            migrationBuilder.DropColumn(
                name: "RecurringChargeName",
                table: "PlaidReconciliation");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "PlaidReconciliation");

            migrationBuilder.DropColumn(
                name: "TagMatchScore",
                table: "PlaidReconciliation");

            migrationBuilder.DropColumn(
                name: "TagsMatched",
                table: "PlaidReconciliation");

            migrationBuilder.DropColumn(
                name: "TenantName",
                table: "PlaidReconciliation");

            migrationBuilder.DropColumn(
                name: "TotalTags",
                table: "PlaidReconciliation");

            migrationBuilder.DropColumn(
                name: "UnmatchedTagsList",
                table: "PlaidReconciliation");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "LeaseCharges",
                newName: "LeaseId");

            migrationBuilder.RenameIndex(
                name: "IX_LeaseCharges_TypeId",
                table: "LeaseCharges",
                newName: "IX_LeaseCharges_LeaseId");

            migrationBuilder.AlterColumn<int>(
                name: "TransactionId",
                table: "PlaidReconciliation",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<List<string>>(
                name: "MatchTags",
                table: "Leases",
                type: "text[]",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "CreatorId", "LastEditedDate", "LastEditorId" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "CreatorId", "LastEditedDate", "LastEditorId" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "CreatorId", "LastEditedDate", "LastEditorId" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "MaintenanceTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "CreatorId", "LastEditedDate", "LastEditorId" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "MaintenanceTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "CreatorId", "LastEditedDate", "LastEditorId" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "MaintenanceTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "CreatorId", "LastEditedDate", "LastEditorId" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.AddForeignKey(
                name: "FK_LeaseCharges_Leases_LeaseId",
                table: "LeaseCharges",
                column: "LeaseId",
                principalTable: "Leases",
                principalColumn: "Id");
        }
    }
}
