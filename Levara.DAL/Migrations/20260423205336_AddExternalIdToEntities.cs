using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Levara.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddExternalIdToEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExternalId",
                table: "Tenants",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExternalId",
                table: "Properties",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExternalId",
                table: "Owners",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExternalId",
                table: "Leases",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExternalId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExternalId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExternalId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 4,
                column: "ExternalId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 5,
                column: "ExternalId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 6,
                column: "ExternalId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 7,
                column: "ExternalId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 8,
                column: "ExternalId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 9,
                column: "ExternalId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 10,
                column: "ExternalId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_ExternalId",
                table: "Tenants",
                column: "ExternalId",
                unique: true,
                filter: "\"ExternalId\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_ExternalId",
                table: "Properties",
                column: "ExternalId",
                unique: true,
                filter: "\"ExternalId\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Owners_ExternalId",
                table: "Owners",
                column: "ExternalId",
                unique: true,
                filter: "\"ExternalId\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Leases_ExternalId",
                table: "Leases",
                column: "ExternalId",
                unique: true,
                filter: "\"ExternalId\" IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tenants_ExternalId",
                table: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_Properties_ExternalId",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Owners_ExternalId",
                table: "Owners");

            migrationBuilder.DropIndex(
                name: "IX_Leases_ExternalId",
                table: "Leases");

            migrationBuilder.DropColumn(
                name: "ExternalId",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "ExternalId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "ExternalId",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "ExternalId",
                table: "Leases");
        }
    }
}
