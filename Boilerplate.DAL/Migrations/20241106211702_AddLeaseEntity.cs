using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Boilerplate.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddLeaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Frequency = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    LastEditorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leases_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Leases_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Leases_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 0, 480, DateTimeKind.Utc).AddTicks(9659), new DateTime(2024, 11, 6, 21, 17, 0, 480, DateTimeKind.Utc).AddTicks(9662) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 0, 567, DateTimeKind.Utc).AddTicks(6972), new DateTime(2024, 11, 6, 21, 17, 0, 567, DateTimeKind.Utc).AddTicks(6974) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 0, 631, DateTimeKind.Utc).AddTicks(3310), new DateTime(2024, 11, 6, 21, 17, 0, 631, DateTimeKind.Utc).AddTicks(3312) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 0, 696, DateTimeKind.Utc).AddTicks(6761), new DateTime(2024, 11, 6, 21, 17, 0, 696, DateTimeKind.Utc).AddTicks(6764) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 0, 761, DateTimeKind.Utc).AddTicks(7428), new DateTime(2024, 11, 6, 21, 17, 0, 761, DateTimeKind.Utc).AddTicks(7429) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 0, 828, DateTimeKind.Utc).AddTicks(9676), new DateTime(2024, 11, 6, 21, 17, 0, 828, DateTimeKind.Utc).AddTicks(9677) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 0, 901, DateTimeKind.Utc).AddTicks(6267), new DateTime(2024, 11, 6, 21, 17, 0, 901, DateTimeKind.Utc).AddTicks(6269) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 0, 968, DateTimeKind.Utc).AddTicks(1910), new DateTime(2024, 11, 6, 21, 17, 0, 968, DateTimeKind.Utc).AddTicks(1913) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 30, DateTimeKind.Utc).AddTicks(5714), new DateTime(2024, 11, 6, 21, 17, 1, 30, DateTimeKind.Utc).AddTicks(5715) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(8975), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(8978) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9405), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9405) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9448), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9448) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9449), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9450) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9451), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9451) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9452), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9452) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9457), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9457) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9458), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9458) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9460), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9461) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9462), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9462) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9464), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9464) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9515), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9516) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9517), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9518) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9519), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9519) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9520), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9520) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9522), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9522) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9523), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9523) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9524), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9524) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9526), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9527) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9528), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9528) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9529), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9529) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9530), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9530) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9533), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9533) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9534), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9535) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9536), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9537) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9538), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9538) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9539), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9539) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9540), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9540) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9541), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9542) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9543), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9543) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9579), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9579) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9580), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9580) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9582), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9582) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9583), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9584) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9585), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9585) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9586), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9587) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9588), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9588) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9589), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9589) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9590), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9590) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9591), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9592) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9593), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9593) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9594), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9594) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9596), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9596) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9597), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9598) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9599), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9599) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9600), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9600) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9601), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9601) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9602), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9603) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9604), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9604) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9605), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9605) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9606), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9606) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9607), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9608) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9609), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9610) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9611), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9611) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9612), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9612) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9613), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9613) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9615), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9615) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9616), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9617) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9618), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9618) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9619), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9619) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9620), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9620) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9646), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9646) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9648), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9648) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9649), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9650) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9651), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9651) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9652), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9652) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9654), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9654) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9655), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9656) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9657), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9657) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9658), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9658) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9659), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9659) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9660), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9661) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9662), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9663) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9664), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9664) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9665), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9665) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9666), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9666) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9667), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9668) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9669), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9669) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9670), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9670) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9671), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9672) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9672), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9673) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9674), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9674) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9675), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9675) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9676), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9677) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9678), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9678) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9679), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9679) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9680), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9680) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9681), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9682) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9683), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9683) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9684), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9684) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9685), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9685) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9687), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9687) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9688), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9688) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9689), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9689) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9710), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9710) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9711), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9711) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9712), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9713) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9714), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9714) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9715), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9715) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9716), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9717) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9718), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9718) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 501,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 158, DateTimeKind.Utc).AddTicks(3504), new DateTime(2024, 11, 6, 21, 17, 1, 158, DateTimeKind.Utc).AddTicks(3505) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 502,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 221, DateTimeKind.Utc).AddTicks(2228), new DateTime(2024, 11, 6, 21, 17, 1, 221, DateTimeKind.Utc).AddTicks(2231) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 503,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 282, DateTimeKind.Utc).AddTicks(6385), new DateTime(2024, 11, 6, 21, 17, 1, 282, DateTimeKind.Utc).AddTicks(6388) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 504,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 343, DateTimeKind.Utc).AddTicks(4784), new DateTime(2024, 11, 6, 21, 17, 1, 343, DateTimeKind.Utc).AddTicks(4785) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 505,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 404, DateTimeKind.Utc).AddTicks(636), new DateTime(2024, 11, 6, 21, 17, 1, 404, DateTimeKind.Utc).AddTicks(639) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 506,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 464, DateTimeKind.Utc).AddTicks(7995), new DateTime(2024, 11, 6, 21, 17, 1, 464, DateTimeKind.Utc).AddTicks(7997) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 507,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 526, DateTimeKind.Utc).AddTicks(5955), new DateTime(2024, 11, 6, 21, 17, 1, 526, DateTimeKind.Utc).AddTicks(5956) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 508,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 587, DateTimeKind.Utc).AddTicks(9447), new DateTime(2024, 11, 6, 21, 17, 1, 587, DateTimeKind.Utc).AddTicks(9449) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 509,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 648, DateTimeKind.Utc).AddTicks(6720), new DateTime(2024, 11, 6, 21, 17, 1, 648, DateTimeKind.Utc).AddTicks(6721) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 510,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 714, DateTimeKind.Utc).AddTicks(651), new DateTime(2024, 11, 6, 21, 17, 1, 714, DateTimeKind.Utc).AddTicks(654) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "7c3d8c27-3849-4b40-81eb-a4688789a6ca", "AQAAAAIAAYagAAAAEDuiEEHyHXyg+B7rEM98bQGEZyVGNWcX5ZJlvjn8kZOwrzhyo3fP4wNdIL7PSluKIA==", "cbc7d87a-7115-46a4-ab37-d658b4b616b5", "77a386a1-6716-4ed2-ae2e-f099ce8e9f29" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "13115632-ffa2-4914-ba84-db1a84e9368f", "AQAAAAIAAYagAAAAEJIKGopxzr2Y2CFE4D7ENLBUcAXm5wO0cmeDR+c3bhtGq0vyck4hpHNGXY/iB7NFeA==", "80e1aeba-2984-4389-a708-e9734dcc42e9", "9d75e99c-37a4-4e1a-ada8-e6bc19755a6c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "907f3c17-1bb9-4195-86ae-0d2ff1f6423e", "AQAAAAIAAYagAAAAEGmCZwKQeai4pZl1qT+oyXfMNgwZ5WlD2lMAHc7lzYj/KyIpDYkJ+hD1pYFkGh5FKQ==", "713a4cda-1368-4b95-9114-2bea6ed82230", "4288f9c5-62b6-43f5-93fd-4e85bc29825b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "2eb7b45d-fd3b-4c9a-8edc-25629bb514fc", "AQAAAAIAAYagAAAAEBZJ958AO6zHAQLuKCjxSNckWkOz44E6sqHZwONe6l7zuRn3SoYI9eleAw99I7IglA==", "101dce3a-f720-49d9-980d-aa0e24db1884", "835644e7-7b55-4073-ab3c-504e648a2f74" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "3299293d-529e-45e8-8e67-31dd1e7a0985", "AQAAAAIAAYagAAAAEJjoVkF71mEk/FdMC7QzkCZYIM/v9bE3o1sQxBMt096eNQgfVdzGS3+3qA0dM7jjlQ==", "0fc472fb-81bb-46fa-9c37-a50c824eb0db", "d8c0eabd-1101-4aa2-a30e-37765045302d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "8f4411e7-e5d4-4900-8bc6-1a3e0595c1c7", "AQAAAAIAAYagAAAAECsMh8N47SsZv9FK/0y+TjxJhMoNi/ezjFLvmyK6HZvknYubYcooKpdYBOUXNT+jXQ==", "a9ed4034-2822-4976-a827-5851fc67bedd", "acdfde21-c31b-4b1c-af97-d9ff11bb3bfd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "dac1e04f-fdca-444a-aaf9-89b9e78e4ab2", "AQAAAAIAAYagAAAAEF39mB+bKXtblu+B8GDOH5qM8UJGg6vZf8KqxzawYNJ41jMLW0TjskxQiC5dxTlvSw==", "91e6c112-fc7a-48c3-b2b4-8aee441cc301", "5fda4dce-bc40-48c0-b0e5-5f3456c9d278" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "632b4c3f-0b9d-45d3-ae24-3bf948a1e734", "AQAAAAIAAYagAAAAEP1o1WjhmL5zNZAkYIiJqn117eNNUH9Ew754CRcbtu/Lh1GmGXq7PlfBJVbpv+VyUA==", "f9429f39-a799-4b82-a083-ec500c7ee34c", "5f919069-c632-42fa-830a-771a86b149ff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "9015c25c-da26-4b1f-ac08-ca6a16b28636", "AQAAAAIAAYagAAAAELiHm7HLPp2/HMxylTHHfpYRhy4jntUletuCKNbB/vpkkpanxJfNjlyv6woDywtc7Q==", "d1259706-8cd9-4263-a07b-8af2f8c45c6a", "6492307a-88b5-418a-8a37-0a2334afa9a4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "085732ee-b217-4397-8620-bc4928a8cafc", "AQAAAAIAAYagAAAAEDAvmg3GTUvNernTtgx0jbd4n0YRLthjCp2TGoAho88phXCeY/JxxXZpxOQlutlFYg==", "6425844e-1c2c-4171-926a-7f4e0a144416", "996b48b0-5547-4ae6-9c99-f7b55e6a4a29" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "60976aa0-7315-4244-af0c-54bb65dfade2", "AQAAAAIAAYagAAAAEL7UC2HnTqCI5ky3JbSxaq+NiPbbJekhN2hJSU16LGyW5dPMbaBHz3TG0d5zDvhRWw==", "2b455f6c-538c-4ebe-b00a-a4ac0f650f5e", "0c24dedd-e012-4ccf-b9a5-227551bfc1ad" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "6e2f8be2-2110-4605-a793-231d49659a02", "AQAAAAIAAYagAAAAEGX89J2XDI/l+MBAqbplMQ0/OldTt6zRLrc/Q7uiHYtarwR9kBQ9DpSs+/wo9ZpfQw==", "c532912e-5e77-4f6c-89a7-7d7182859e10", "b3f124ac-97b5-4944-89bf-7119cb6c8b3c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "df99df2c-4227-4e80-abd0-81bf984ad1c8", "AQAAAAIAAYagAAAAEMnu2pN5pSKfqTJHaGWkzKAswdpX8TukVcx3rcZ0LAy3snPVv89ottNcPsntarx1/Q==", "619e211a-7053-4651-90e3-9a04031e6065", "74185ea9-8e5c-4507-9911-28fbe7f935d9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "902a00ca-d636-4ba1-9ced-d3392c8b453b", "AQAAAAIAAYagAAAAEGJv6MyxcmNXf7y67P1iA9exzbgPUPCDhI8kSvs0vKtRxPGUs2trx20OE+e/s2vstg==", "e098cb84-6a4c-4a04-93ac-1e80d2030904", "e0531dfc-1cff-4e0f-be80-a7a1d9ae0fb1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "71ec5d06-c939-4dbf-8b64-eb1898849624", "AQAAAAIAAYagAAAAEHffxWb8uo48+X0vO6UGexmGiujZeQ2W46OAj7geqjgJzvrbA2ZycSJcONK09T4VzQ==", "0b05ccd0-1cf1-428c-aff4-ec26deae7804", "f4dac748-314b-463b-a671-4228878c9c6f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "3a4d4907-e228-4476-bb4e-4c4d5759fc04", "AQAAAAIAAYagAAAAELPqKhR1nc5qvCGmF1AOva2hJKep9PI+zN9ekNNxjSB0wuCTUVCkNScJ4pQY+UJFPg==", "ca17a644-08db-4dae-b118-b32b6442ebb9", "ec4b64af-2539-48de-808f-5e653b3aa77a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "8ae65de4-c269-4f02-bd4b-6710535d561f", "AQAAAAIAAYagAAAAEJH9Xs1k7lx5hhy1QWVdQ+4bYwdg5dGLV6rTrInH3QaO1XaBQrBdp1Kce2/7BcYVpg==", "1b014d5a-c762-4ead-b051-562036cd3c35", "abd7a9ff-8c1b-404e-b319-98d03b8af7d2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "2e60af9b-d524-4fbe-932a-4b31f900a770", "AQAAAAIAAYagAAAAECabrpabtk5wvaQYrVV/sVEs5og4WLykNR1ZGr3iaTtboxxSBDBIoWMJMAzdklAhTg==", "3975dafe-663c-400e-a0c8-c938aa1db3a2", "fce7dd03-6aa3-4c68-b1c5-0b8dbd27db67" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "6192d93c-0148-4140-82ce-ec4ec6e98c3e", "AQAAAAIAAYagAAAAEFZLrkq61FLZmUrLw7gsA5Mm/jm5+MSFKmHzAQ10abwrIwrna4tNTmtMMvCnNjYaGQ==", "bdf10b3b-dedf-4fab-84c2-628d2939f6d3", "d5a1ab87-9967-47c9-98c8-1e9c00aeb138" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "0a029844-7694-4469-828b-3dad46de3ae6", "AQAAAAIAAYagAAAAEE7THVYpaTwNT7b8u7nzp3HThJioWN16koiJdReRawOTtn1tXXCvZe8plflikWurxw==", "47163807-2321-4bfb-9b65-36967661ef9d", "1899dac4-d736-4bee-a87c-01e17d793eee" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "833e76e0-081b-4392-a696-3e4208005a4c", "AQAAAAIAAYagAAAAELnOxLFWdGNr3wyXweK1dVEpqsvLB1LYqGR50gLWU/x+z/ZNKcfqg8AExAdyCsq4EA==", "af39d537-9e56-4643-9efa-b08e570d3f99", "21012b7b-6dbe-44e3-b739-29620e62d640" });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 0, 480, DateTimeKind.Utc).AddTicks(9942), new DateTime(2024, 11, 6, 21, 17, 0, 480, DateTimeKind.Utc).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 0, 567, DateTimeKind.Utc).AddTicks(7109), new DateTime(2024, 11, 6, 21, 17, 0, 567, DateTimeKind.Utc).AddTicks(7109) });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 0, 631, DateTimeKind.Utc).AddTicks(3337), new DateTime(2024, 11, 6, 21, 17, 0, 631, DateTimeKind.Utc).AddTicks(3337) });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 0, 696, DateTimeKind.Utc).AddTicks(6792), new DateTime(2024, 11, 6, 21, 17, 0, 696, DateTimeKind.Utc).AddTicks(6793) });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 0, 761, DateTimeKind.Utc).AddTicks(7454), new DateTime(2024, 11, 6, 21, 17, 0, 761, DateTimeKind.Utc).AddTicks(7454) });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 0, 828, DateTimeKind.Utc).AddTicks(9703), new DateTime(2024, 11, 6, 21, 17, 0, 828, DateTimeKind.Utc).AddTicks(9703) });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 0, 901, DateTimeKind.Utc).AddTicks(6293), new DateTime(2024, 11, 6, 21, 17, 0, 901, DateTimeKind.Utc).AddTicks(6293) });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 0, 968, DateTimeKind.Utc).AddTicks(1937), new DateTime(2024, 11, 6, 21, 17, 0, 968, DateTimeKind.Utc).AddTicks(1937) });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 30, DateTimeKind.Utc).AddTicks(5737), new DateTime(2024, 11, 6, 21, 17, 1, 30, DateTimeKind.Utc).AddTicks(5738) });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9093), new DateTime(2024, 11, 6, 21, 17, 1, 94, DateTimeKind.Utc).AddTicks(9093) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 158, DateTimeKind.Utc).AddTicks(3519), new DateTime(2024, 11, 6, 21, 17, 1, 158, DateTimeKind.Utc).AddTicks(3519) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 221, DateTimeKind.Utc).AddTicks(2242), new DateTime(2024, 11, 6, 21, 17, 1, 221, DateTimeKind.Utc).AddTicks(2242) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 282, DateTimeKind.Utc).AddTicks(6412), new DateTime(2024, 11, 6, 21, 17, 1, 282, DateTimeKind.Utc).AddTicks(6413) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 343, DateTimeKind.Utc).AddTicks(4799), new DateTime(2024, 11, 6, 21, 17, 1, 343, DateTimeKind.Utc).AddTicks(4800) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 404, DateTimeKind.Utc).AddTicks(653), new DateTime(2024, 11, 6, 21, 17, 1, 404, DateTimeKind.Utc).AddTicks(654) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 464, DateTimeKind.Utc).AddTicks(8020), new DateTime(2024, 11, 6, 21, 17, 1, 464, DateTimeKind.Utc).AddTicks(8020) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 526, DateTimeKind.Utc).AddTicks(5973), new DateTime(2024, 11, 6, 21, 17, 1, 526, DateTimeKind.Utc).AddTicks(5974) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 587, DateTimeKind.Utc).AddTicks(9468), new DateTime(2024, 11, 6, 21, 17, 1, 587, DateTimeKind.Utc).AddTicks(9468) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 648, DateTimeKind.Utc).AddTicks(6738), new DateTime(2024, 11, 6, 21, 17, 1, 648, DateTimeKind.Utc).AddTicks(6738) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 21, 17, 1, 714, DateTimeKind.Utc).AddTicks(674), new DateTime(2024, 11, 6, 21, 17, 1, 714, DateTimeKind.Utc).AddTicks(674) });

            migrationBuilder.CreateIndex(
                name: "IX_Leases_OwnerId",
                table: "Leases",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Leases_PropertyId",
                table: "Leases",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Leases_TenantId",
                table: "Leases",
                column: "TenantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leases");

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 270, DateTimeKind.Utc).AddTicks(6750), new DateTime(2024, 11, 5, 16, 1, 48, 270, DateTimeKind.Utc).AddTicks(6753) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 339, DateTimeKind.Utc).AddTicks(8336), new DateTime(2024, 11, 5, 16, 1, 48, 339, DateTimeKind.Utc).AddTicks(8339) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 409, DateTimeKind.Utc).AddTicks(5952), new DateTime(2024, 11, 5, 16, 1, 48, 409, DateTimeKind.Utc).AddTicks(5953) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 478, DateTimeKind.Utc).AddTicks(6980), new DateTime(2024, 11, 5, 16, 1, 48, 478, DateTimeKind.Utc).AddTicks(7170) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 551, DateTimeKind.Utc).AddTicks(9182), new DateTime(2024, 11, 5, 16, 1, 48, 551, DateTimeKind.Utc).AddTicks(9186) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 622, DateTimeKind.Utc).AddTicks(9163), new DateTime(2024, 11, 5, 16, 1, 48, 622, DateTimeKind.Utc).AddTicks(9165) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 701, DateTimeKind.Utc).AddTicks(197), new DateTime(2024, 11, 5, 16, 1, 48, 701, DateTimeKind.Utc).AddTicks(200) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 777, DateTimeKind.Utc).AddTicks(6320), new DateTime(2024, 11, 5, 16, 1, 48, 777, DateTimeKind.Utc).AddTicks(6323) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 869, DateTimeKind.Utc).AddTicks(2963), new DateTime(2024, 11, 5, 16, 1, 48, 869, DateTimeKind.Utc).AddTicks(2970) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9523), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9526) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9751), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9751) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9817), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9817) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9818), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9819) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9819), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9820) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9821), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9821) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9827), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9827) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9828), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9829) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9831), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9831) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9832), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9832) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9834), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9834) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9836), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9836) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9838), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9838) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9839), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9839) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9840), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9840) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9841), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9841) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9842), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9842) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9843), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9844) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9845), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9845) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9846), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9846) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9847), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9847) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9848), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9848) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9850), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9851), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9851) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9929), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9930) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9931), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9931) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9932), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9932) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9933), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9933) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9934), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9934) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9935), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9935) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9936), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9936) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9937), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9937) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9939), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9939) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9940), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9940) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9941), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9942) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9942), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9943), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9944) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9944), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9945) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9945), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9946) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9946), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9947) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9947), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9948) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9948), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9949) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9950), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9950) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9951), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9951) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9952), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9953) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9953), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9954) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9955), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9955) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9956), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9956) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9957), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9957) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9958), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9958) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9959), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9959) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9960), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9960) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9961), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9962) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9962), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9963) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9963), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9964) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(35), new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(36) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(38), new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(38) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(39), new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(39) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(40), new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(40) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(41), new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(41) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(42), new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(42) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(43), new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(43) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(45), new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(45) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(46), new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(46) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(47), new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(47) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(48), new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(48) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(50), new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(50) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(51), new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(52), new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(52) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(53), new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(53) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(54), new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(54) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(55), new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(55) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(57), new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(57) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(58), new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(58) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(59), new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(59) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(60), new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(60) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(61), new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(61) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(62), new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(62) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(63), new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(63) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(64), new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(64) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(65), new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(65) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(66), new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(66) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(67), new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(67) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(68), new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(68) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(96), new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(96) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(97), new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(97) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(98), new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(98) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(99), new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(99) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(100), new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(101) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(101), new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(102) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(102), new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(103) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(104), new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(104) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(105), new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(105) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(106), new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(106) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(107), new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(107) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(108), new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(108) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(109), new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(109) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(110), new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(110) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(111), new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(111) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(112), new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(112) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(113), new DateTime(2024, 11, 5, 16, 1, 48, 950, DateTimeKind.Utc).AddTicks(113) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 501,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 49, 19, DateTimeKind.Utc).AddTicks(6451), new DateTime(2024, 11, 5, 16, 1, 49, 19, DateTimeKind.Utc).AddTicks(6455) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 502,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 49, 83, DateTimeKind.Utc).AddTicks(4367), new DateTime(2024, 11, 5, 16, 1, 49, 83, DateTimeKind.Utc).AddTicks(4369) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 503,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 49, 149, DateTimeKind.Utc).AddTicks(2436), new DateTime(2024, 11, 5, 16, 1, 49, 149, DateTimeKind.Utc).AddTicks(2439) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 504,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 49, 219, DateTimeKind.Utc).AddTicks(883), new DateTime(2024, 11, 5, 16, 1, 49, 219, DateTimeKind.Utc).AddTicks(886) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 505,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 49, 292, DateTimeKind.Utc).AddTicks(3249), new DateTime(2024, 11, 5, 16, 1, 49, 292, DateTimeKind.Utc).AddTicks(3253) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 506,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 49, 367, DateTimeKind.Utc).AddTicks(7668), new DateTime(2024, 11, 5, 16, 1, 49, 367, DateTimeKind.Utc).AddTicks(7672) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 507,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 49, 454, DateTimeKind.Utc).AddTicks(688), new DateTime(2024, 11, 5, 16, 1, 49, 454, DateTimeKind.Utc).AddTicks(691) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 508,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 49, 535, DateTimeKind.Utc).AddTicks(316), new DateTime(2024, 11, 5, 16, 1, 49, 535, DateTimeKind.Utc).AddTicks(323) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 509,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 49, 609, DateTimeKind.Utc).AddTicks(4085), new DateTime(2024, 11, 5, 16, 1, 49, 609, DateTimeKind.Utc).AddTicks(4088) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 510,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 49, 693, DateTimeKind.Utc).AddTicks(1725), new DateTime(2024, 11, 5, 16, 1, 49, 693, DateTimeKind.Utc).AddTicks(1731) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "c01eeacb-8870-40d8-a6b2-3a7e84d547e3", "AQAAAAIAAYagAAAAENDKtB/+XPCA988p5c06y1RlhVoMKpFKvt4nZ5M2mNGB6fxvvB4HdxSPW3qyFe1UBg==", "0e23b54e-95f1-4476-946e-dd73ced09522", "5cafd901-1ce0-4b34-96a5-23333c04b65e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "fdbb7224-2263-4f1b-9b26-ee90d149d783", "AQAAAAIAAYagAAAAEI5dGNF1j7iSxWsy8XflHtVLyhgIEYxJ9+dMSEd1Hdw25BUp7KUjMKtbLXk34/dsUw==", "2a732706-9b90-4b1d-a0ac-65015726a9f8", "6a146178-f44b-4c25-abc8-f6627745eb8a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "ae77550c-1814-45a4-8f46-e2f37a577cdc", "AQAAAAIAAYagAAAAEOQONzzRip6QRmi0QxhUykcEjBIX+Kp3NsR0+e3279OFJSIZXzgDNBVyKiPUox1Ugw==", "a5960eae-92c4-4288-bb23-04cbd8950a0c", "95dacf79-b399-4c92-8dff-0af856fcc85a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "b4c71a85-6bd4-4419-bfc9-3fff64a4b8db", "AQAAAAIAAYagAAAAEMMmaDBi+Bu1CKoEahvZJG5gSdpa+sM7eP9DyUbw47xZKG2YYDJVXMT2MsAEkL24jA==", "6a941f71-15e6-46e7-9ac4-35bb90a0c24f", "3f6fec72-f4f6-419f-8437-78d53360cf47" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "659475c0-9242-4938-8c66-2e2dbd45ea43", "AQAAAAIAAYagAAAAEK1NYY/WlqNeBlk271Mu0oFgXj8EqEmbAUiS4CtXzwGYLxFJ8LiWHvF+B+JEDmrmMA==", "4820692d-dcbf-417f-a76e-198b84101135", "5a49e55d-a838-4c3f-9db4-31f6bce7257a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "04f5ffc0-b19e-467f-94f5-b2ef24c7a279", "AQAAAAIAAYagAAAAECPlWcc5DpiZ7QEX3xihj5jod4hiliWZsIunPcfilS8+2oofH5qJetYTI+fhDbhGfQ==", "650c59aa-d04b-4698-8603-1370da8877eb", "5837c0b0-bf30-4ba2-ac74-3ddddf0da97b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "1abeb6e0-114d-44b5-b6ec-dfb3294aab27", "AQAAAAIAAYagAAAAEOcoZSKRtV8IMRnIlzpZCY5ODb6eYxGkChzhFueX/qMDbEmT1aGcrBDlF4+DDkEE8g==", "4fa3f78d-b186-4005-906c-4f4fa5036b37", "16e02fbf-871b-48f1-8c0d-600854b99c9e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "c9aebb89-af50-4174-b118-6144011dc8ce", "AQAAAAIAAYagAAAAEJqDtr+Pj8rs1mgdirkgwfZ/GDzMrrp6EjJlno8Rllr1gaf2lkIjZdsmWv/e85De6g==", "731499bb-5667-4eb3-a0fc-a5ae382e27af", "a850fde7-8ae3-4aad-960b-a1bd1ea92c58" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "5b2b2a46-ff34-4d57-bdbb-1560e75cc0a7", "AQAAAAIAAYagAAAAEG0P945zOxyeJb6MxTk4QGlkeZMLG9B7NZBIyBp5RREyG4arcZlbGRzFaemlo9tSOQ==", "d265cb52-8436-45c0-9b56-e120cde96f0e", "c8d6b535-5690-4854-9253-a9ce8df58621" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "106e60ca-4ee6-4a59-b047-165f75e4c49f", "AQAAAAIAAYagAAAAEDkAN5PsS9g5CXJFoi1+ipUEgCRN/OcBtfRBdb5LLED3aVK6ZsE9XvEXh+zlecXLrg==", "cd4bb473-1b7a-4c9a-aad7-9742cbcda169", "601931fb-9e05-476d-9183-c4f73bd0f9d1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "46518671-b617-4e6f-a05c-61b777c96964", "AQAAAAIAAYagAAAAEG1F9qhDuAZTU5WEzXj6dsH6Au05kj3EKrFqcDbjuTqGEzb8HtmCt8VEJgDkGUWHLg==", "4dfafc49-9e33-45e6-98fa-48410ffadf5b", "4497cc05-61cc-4c66-a2e0-c3960a508bce" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "7dd0a1af-0ee2-4fca-ae27-4d3859d47341", "AQAAAAIAAYagAAAAEKZw5CJMSQmwBBmfu4dHhfxH1ScpqI8b4mEUKVD22L0jbXVCwm9xNXaTkskE0c6N1w==", "645ea93d-fe1d-4aa4-b02b-42735184ee3d", "2debb305-a4a2-4971-949e-37442414b1f0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "588f1634-687e-4f20-ae44-1abbebd5d53b", "AQAAAAIAAYagAAAAEAE9LH61Q6NwDalsQZB+mOsT6m8ApgFNQwiJUUTxP8FPu9GxacfevtIBKX4hPvlmig==", "a3e30ca7-8bc3-4940-b2a3-cf461dbf9943", "2dbf05b5-954a-4c46-a83c-7cac2c25a9d2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "6f2aea20-b4da-4930-be66-f0c8778d96c8", "AQAAAAIAAYagAAAAECvhmDd+4lintd6dKmq2tppX+4RyySNgXJY8y67dnrKNDElCb4YsEKJUu9n72La5uw==", "b049bc98-dd3a-456f-aa48-4bff8a95711f", "5b3d8117-243d-4f23-a375-609a60166cd6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "794ecba3-33e4-4734-923b-01baa3120854", "AQAAAAIAAYagAAAAEDUTgZiHKVe5HmnuF0WE3mDtKOHRUsQ1HSg4EJI4/udpFV134NTu2KnyIKJgfoTSPA==", "60555d75-0763-449d-a5df-8567fa172540", "3f862cdc-0aea-4b04-ad39-e039b9157dd3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "d509fa9d-589d-495a-bb13-93af3375d8f5", "AQAAAAIAAYagAAAAEJuvQeA138mzAToZ9zfpxABEd7BnB9v9DtR9jnczQjLB2rjZYieyYn1dZLT9c1sJeQ==", "88e1fcb5-601a-4c10-ae75-4700728f047f", "bbc5ceea-bc46-4b0d-87c6-864255f4e674" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "3937f77c-1f02-4e71-bba0-e617b7e451ae", "AQAAAAIAAYagAAAAENqlGesXKoy+EzZmsbUxt880PNWUJuVxyQYgcb7cCC4lDz6UxfqGEC/9LmZ0ilajqw==", "caef4e16-38e3-4a6e-b1a6-cdea092ddefc", "4779d56c-9559-4655-be1f-59a6de00f3b9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "a27da97b-4964-4443-839f-218ef209eb21", "AQAAAAIAAYagAAAAEBfDfYDZyozG51mTbeZbkjyMoZyFfK1jkMxW4Su+51knVB4R/TCP5zVEQcRbvemGUw==", "42ec18ed-c250-4090-86c5-dc8978355bf6", "e87fb0d6-de44-49f4-9552-987541751170" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "102b28c1-41af-48d4-8b8e-51266b204c12", "AQAAAAIAAYagAAAAEOYcLpIGo4qqOAkWEkT6hUnU5LK4wQxUKZ0VcxoTu/NEcn2KF+sP0Iu3e62MMrfr+w==", "b76fe5b6-b3d7-4ed8-919c-084de21750df", "33edc6fa-eeed-4dac-8bd8-799f467ba9a7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "229d2bfb-d6b3-4c85-96b8-ee3b7e4edcf8", "AQAAAAIAAYagAAAAEPDSowO7XH+ZeYvk2jzbsZ2DwEKMIS3YyxDqO3uiBC+PIggPwwXvNlTNsBsZ/sDJWw==", "f8204cec-666f-499c-82b2-06ac595fb62d", "35084aa0-18b0-490e-96c9-c63014809fee" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "ac85d1fd-1c7b-4c7a-b70d-5cdbd18948b5", "AQAAAAIAAYagAAAAEGMJViltGbDqINM9qjAQq6j9Ukigb/dm5gLxb9bOHzrQ2ye5YMEFk3vZZKVDR+U9mQ==", "7a68edc5-b4b5-4dda-97a1-d69568b4555d", "567d03ac-1403-480d-bec6-b6621e97cf21" });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 270, DateTimeKind.Utc).AddTicks(7023), new DateTime(2024, 11, 5, 16, 1, 48, 270, DateTimeKind.Utc).AddTicks(7023) });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 339, DateTimeKind.Utc).AddTicks(8363), new DateTime(2024, 11, 5, 16, 1, 48, 339, DateTimeKind.Utc).AddTicks(8363) });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 409, DateTimeKind.Utc).AddTicks(5978), new DateTime(2024, 11, 5, 16, 1, 48, 409, DateTimeKind.Utc).AddTicks(5978) });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 478, DateTimeKind.Utc).AddTicks(7200), new DateTime(2024, 11, 5, 16, 1, 48, 478, DateTimeKind.Utc).AddTicks(7200) });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 551, DateTimeKind.Utc).AddTicks(9210), new DateTime(2024, 11, 5, 16, 1, 48, 551, DateTimeKind.Utc).AddTicks(9210) });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 622, DateTimeKind.Utc).AddTicks(9186), new DateTime(2024, 11, 5, 16, 1, 48, 622, DateTimeKind.Utc).AddTicks(9187) });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 701, DateTimeKind.Utc).AddTicks(242), new DateTime(2024, 11, 5, 16, 1, 48, 701, DateTimeKind.Utc).AddTicks(243) });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 777, DateTimeKind.Utc).AddTicks(6351), new DateTime(2024, 11, 5, 16, 1, 48, 777, DateTimeKind.Utc).AddTicks(6352) });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 869, DateTimeKind.Utc).AddTicks(2995), new DateTime(2024, 11, 5, 16, 1, 48, 869, DateTimeKind.Utc).AddTicks(2995) });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9549), new DateTime(2024, 11, 5, 16, 1, 48, 949, DateTimeKind.Utc).AddTicks(9549) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 49, 19, DateTimeKind.Utc).AddTicks(6484), new DateTime(2024, 11, 5, 16, 1, 49, 19, DateTimeKind.Utc).AddTicks(6485) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 49, 83, DateTimeKind.Utc).AddTicks(4394), new DateTime(2024, 11, 5, 16, 1, 49, 83, DateTimeKind.Utc).AddTicks(4395) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 49, 149, DateTimeKind.Utc).AddTicks(2535), new DateTime(2024, 11, 5, 16, 1, 49, 149, DateTimeKind.Utc).AddTicks(2535) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 49, 219, DateTimeKind.Utc).AddTicks(908), new DateTime(2024, 11, 5, 16, 1, 49, 219, DateTimeKind.Utc).AddTicks(909) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 49, 292, DateTimeKind.Utc).AddTicks(3281), new DateTime(2024, 11, 5, 16, 1, 49, 292, DateTimeKind.Utc).AddTicks(3281) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 49, 367, DateTimeKind.Utc).AddTicks(7699), new DateTime(2024, 11, 5, 16, 1, 49, 367, DateTimeKind.Utc).AddTicks(7699) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 49, 454, DateTimeKind.Utc).AddTicks(711), new DateTime(2024, 11, 5, 16, 1, 49, 454, DateTimeKind.Utc).AddTicks(712) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 49, 535, DateTimeKind.Utc).AddTicks(346), new DateTime(2024, 11, 5, 16, 1, 49, 535, DateTimeKind.Utc).AddTicks(346) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 49, 609, DateTimeKind.Utc).AddTicks(4116), new DateTime(2024, 11, 5, 16, 1, 49, 609, DateTimeKind.Utc).AddTicks(4117) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 1, 49, 693, DateTimeKind.Utc).AddTicks(1754), new DateTime(2024, 11, 5, 16, 1, 49, 693, DateTimeKind.Utc).AddTicks(1754) });
        }
    }
}
