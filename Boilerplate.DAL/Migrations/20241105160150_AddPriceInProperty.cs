using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Boilerplate.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddPriceInProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Properties",
                type: "decimal(18,2)",
                nullable: true);

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
                table: "Properties",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 4,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 5,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 6,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 7,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 8,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 9,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 10,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 11,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 12,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 13,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 14,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 15,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 16,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 17,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 18,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 19,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 20,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 21,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 22,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 23,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 24,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 25,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 26,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 27,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 28,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 29,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 30,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 31,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 32,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 33,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 34,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 35,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 36,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 37,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 38,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 39,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 40,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 41,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 42,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 43,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 44,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 45,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 46,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 47,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 48,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 49,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 50,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 51,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 52,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 53,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 54,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 55,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 56,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 57,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 58,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 59,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 60,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 61,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 62,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 63,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 64,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 65,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 66,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 67,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 68,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 69,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 70,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 71,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 72,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 73,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 74,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 75,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 76,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 77,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 78,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 79,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 80,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 81,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 82,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 83,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 84,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 85,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 86,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 87,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 88,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 89,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 90,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 91,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 92,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 93,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 94,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 95,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 96,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 97,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 98,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 99,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 100,
                column: "Price",
                value: null);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Properties");

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 9, 931, DateTimeKind.Utc).AddTicks(5060), new DateTime(2024, 10, 31, 11, 21, 9, 931, DateTimeKind.Utc).AddTicks(5063) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 38, DateTimeKind.Utc).AddTicks(5522), new DateTime(2024, 10, 31, 11, 21, 10, 38, DateTimeKind.Utc).AddTicks(5526) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 122, DateTimeKind.Utc).AddTicks(8187), new DateTime(2024, 10, 31, 11, 21, 10, 122, DateTimeKind.Utc).AddTicks(8190) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 208, DateTimeKind.Utc).AddTicks(6326), new DateTime(2024, 10, 31, 11, 21, 10, 208, DateTimeKind.Utc).AddTicks(6329) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 300, DateTimeKind.Utc).AddTicks(5012), new DateTime(2024, 10, 31, 11, 21, 10, 300, DateTimeKind.Utc).AddTicks(5015) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 392, DateTimeKind.Utc).AddTicks(640), new DateTime(2024, 10, 31, 11, 21, 10, 392, DateTimeKind.Utc).AddTicks(642) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 467, DateTimeKind.Utc).AddTicks(6517), new DateTime(2024, 10, 31, 11, 21, 10, 467, DateTimeKind.Utc).AddTicks(6520) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 541, DateTimeKind.Utc).AddTicks(8712), new DateTime(2024, 10, 31, 11, 21, 10, 541, DateTimeKind.Utc).AddTicks(8715) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 617, DateTimeKind.Utc).AddTicks(9112), new DateTime(2024, 10, 31, 11, 21, 10, 617, DateTimeKind.Utc).AddTicks(9115) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(3929), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(3930) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4323), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4324) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4399), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4399) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4402), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4402) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4404), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4404) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4405), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4406) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4414), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4414) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4416), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4416) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4419), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4419) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4420), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4420) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4521), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4521) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4567), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4568) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4570), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4571) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4572), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4572) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4573), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4573) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4574), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4575) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4576), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4576) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4577), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4577) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4580), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4580) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4581), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4581) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4582), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4583) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4584), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4584) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4586), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4586) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4587), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4587) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4589), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4589) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4591), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4591) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4592), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4592) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4593), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4594) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4595), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4595) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4596), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4596) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4597), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4598) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4599), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4599) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4701), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4701) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4702), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4702) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4705), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4705) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4706), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4706) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4707), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4708) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4709), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4709) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4710), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4710) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4711), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4712) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4713), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4713) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4715), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4715) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4717), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4717) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4718), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4718) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4845), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4845) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4847), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4848) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4849), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4849) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4850), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4850) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4852), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4852) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4853), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4853) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4854), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4855) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4857), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4857) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4858), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4859) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4860), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4860) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4861), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4861) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4862), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4863) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4865), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4865) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4866), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4867) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4868), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4868) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4869), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4869) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4870), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4871) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4872), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4872) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4874), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4874) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4875), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4875) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4876), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4877) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4878), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4878) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4880), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4880) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4881), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4881) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4882), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4882) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4883), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4884) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4885), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4885) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4886), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4887) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4888), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4888) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4890), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4890) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4891), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4891) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4892), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4893) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4950), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4951) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4952), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4952) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4953), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4953) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4955), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4955) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4956), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4956) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4957), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4958) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4959), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4959) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4960), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4960) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4961), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4962) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4963), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4963) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4964), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4964) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4965), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4965) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4967), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4967) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4968), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4968) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4969), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4969) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4972), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4972) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4973), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4973) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4975), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4975) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4976), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4976) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4977), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4977) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4978), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4979) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4980) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4981), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4981) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4982), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4983) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4984), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4984) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 501,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 776, DateTimeKind.Utc).AddTicks(4389), new DateTime(2024, 10, 31, 11, 21, 10, 776, DateTimeKind.Utc).AddTicks(4392) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 502,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 851, DateTimeKind.Utc).AddTicks(6958), new DateTime(2024, 10, 31, 11, 21, 10, 851, DateTimeKind.Utc).AddTicks(6961) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 503,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 935, DateTimeKind.Utc).AddTicks(9223), new DateTime(2024, 10, 31, 11, 21, 10, 935, DateTimeKind.Utc).AddTicks(9226) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 504,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 11, 14, DateTimeKind.Utc).AddTicks(3362), new DateTime(2024, 10, 31, 11, 21, 11, 14, DateTimeKind.Utc).AddTicks(3366) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 505,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 11, 106, DateTimeKind.Utc).AddTicks(7871), new DateTime(2024, 10, 31, 11, 21, 11, 106, DateTimeKind.Utc).AddTicks(7874) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 506,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 11, 196, DateTimeKind.Utc).AddTicks(5525), new DateTime(2024, 10, 31, 11, 21, 11, 196, DateTimeKind.Utc).AddTicks(5528) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 507,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 11, 283, DateTimeKind.Utc).AddTicks(5122), new DateTime(2024, 10, 31, 11, 21, 11, 283, DateTimeKind.Utc).AddTicks(5126) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 508,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 11, 370, DateTimeKind.Utc).AddTicks(9714), new DateTime(2024, 10, 31, 11, 21, 11, 370, DateTimeKind.Utc).AddTicks(9722) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 509,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 11, 447, DateTimeKind.Utc).AddTicks(235), new DateTime(2024, 10, 31, 11, 21, 11, 447, DateTimeKind.Utc).AddTicks(238) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 510,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 11, 521, DateTimeKind.Utc).AddTicks(6769), new DateTime(2024, 10, 31, 11, 21, 11, 521, DateTimeKind.Utc).AddTicks(6772) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "710947cf-545b-4fa5-9a60-2fa3a964354b", "AQAAAAIAAYagAAAAEAYyKMgwu/onpZ0ww+glhN0Jwan+7NNj8wA8za7UsOCrJPYUu8DkcE4Z412/MGA+VQ==", "cd97d5d8-0513-4954-bdc9-b08987b666db", "942398b4-1eb2-4b07-a6c9-7ab899ac4c5e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "c6774f4b-b43d-4690-be37-ee205ebc23d3", "AQAAAAIAAYagAAAAEBJpw8O/QFiVKZ5YTadieyNaWnKXIALTOBEdC5LOC8O+g7LbTOzD2tUeyuw55G+lBQ==", "c80a1309-60b4-4588-8250-9d0f9f6b45ab", "7225284c-6ddf-4850-8b5d-1d37afb4aed3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "e904a25d-5e2a-4407-a942-40ece5db484b", "AQAAAAIAAYagAAAAEOS7x5SwXjiuxhhbfAf1N0mA3Tvm2AVRC84PAYSTIGRoMkpv3ZPBPOZQYVQfBrfT8w==", "04dbfb9f-d80d-4f24-88a4-3f2c4a912cf7", "7ecd0653-5d69-4ed8-b3e8-30c7c4033953" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "933b99eb-55ec-499d-8582-0a4c20dc841f", "AQAAAAIAAYagAAAAELWHEjL1XCbTICtCxLLrOJE+W+OsrZDHiTesrhc8yrio4cgMkO3GQboXPxY/Kz92sw==", "45d4fa33-46ed-4bf2-aa4d-39b48d598fa2", "617d12ae-7c5f-40a2-94f5-3abbfb53c1ba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "027ec3e4-c06e-4990-8407-c8459f82e5aa", "AQAAAAIAAYagAAAAEKfnFMz7C1qoY+zGiO22thLyPELqJ8VBTLRoJTmJrpflpvhLe5DnncN83/QfJb2Qxg==", "450ae751-6a81-4939-93aa-bbc8362e3cb7", "23f0357f-b41e-4f84-8982-9cc5f2fa83e0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "15b6b44b-3f26-4ce9-a1df-cb007e3f794a", "AQAAAAIAAYagAAAAEA8t9zHER+GDwsQc+4fhf7KyMVWNxkagxFIobpsuPpjsQwKa7tqek4YZMzMSby+SaQ==", "ced3673c-ee51-4a3e-9d77-9a30a9f2ced7", "928e2aa2-b843-4c73-95a5-8d15ab28aa8e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "9785e30e-f5b1-4d8a-9f0f-435bb8317b19", "AQAAAAIAAYagAAAAEEYg59bTgZ2yrsw3rHvbWk9SqKWCI1dHlwAeIwM44W9ewEW9D9eCT/0ev2H3/lfrXQ==", "436fc913-2baf-4f96-a3ef-d2588f02f196", "53a996c0-c18e-47b2-a029-07ba28fecda9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "3dd2ab06-13b3-4994-9b1a-f235afae1872", "AQAAAAIAAYagAAAAEEJl+nR+G7k4Pp3N8ms7Qvo4yTYIbjuWfPIWbz0kqrHVZDlLxb9isTo8H/aRvw438g==", "54789cbf-ff2c-41b7-a8cf-f0ac7532b5f7", "ff2e2c31-718e-4781-b2db-be82942b9f9e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "527c227f-5a73-4748-899b-f5f28d9ec749", "AQAAAAIAAYagAAAAEFPf7gHVf/B4cI+TNqhbvGyZoHQYlHXRWdCwSKPbFSzZJveylkJ6ldko8hzSsNv+bQ==", "53e00a10-6ce2-424c-9fe7-9705e15e29e6", "7a99ea27-3de2-495f-9d6d-316d24e4f57c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "2b9c4b05-902c-4fc9-8439-ea27357d241c", "AQAAAAIAAYagAAAAEAMBhaVtaljOlmEQebdUwmoE2V2PyJ2oCblJiUg8G9j0IaJ1bP1/r9Lunux+pSeAoA==", "28e94a04-5e76-4a6b-810e-ae12904b4818", "01daee87-b280-4911-9f45-e9fe53a3b263" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "f83f0804-1601-44c6-b3d5-dc25019fb6af", "AQAAAAIAAYagAAAAEHlzZH2+BnCMDXHA5SVo2+7JtOAA5/48cDC9eAhDmfsnhe+VSsqBlRxNAb794HZaTQ==", "a32a2abf-9f29-4094-b565-710d7d3df44f", "ff7752b7-0f62-4192-9acf-550dc7d6f96c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "bebc3056-57f0-4895-9635-7a6c3ce04bef", "AQAAAAIAAYagAAAAEMec7Gcxy98S2/KBmp+HyaFhqu0cLjRresofHgexv+j45F+D22cYI0ML3nWTx5aTgQ==", "be8548c1-ce90-4807-8809-b8e9c3571b77", "2a8cd81b-c1d5-420b-9ddf-9cf8e6542e9d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "c7c87dd9-f03c-47dd-ae44-149058a9fe8a", "AQAAAAIAAYagAAAAEE8cORjSRfESlOpUu2+v2Kb/00aRBhxtRztJpHcM0HvRX4qvnhb40BaOoIBitnyOzQ==", "208000f9-226d-4158-9c7a-cbb52b888a29", "c1df97ca-8495-4931-8312-95c977405529" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "ad9b8480-7d9e-468a-8491-4b9a7c301cc2", "AQAAAAIAAYagAAAAEDe9kNjIk9z2Htah01izWAS02m+4QARkW2OQIrywwtdPa6RYwNbbDUZIUSFcCQtB5g==", "874fb122-2d41-4abc-bf42-12ad73afce67", "48bd169f-371a-47a7-9f67-64701611a492" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "8b593bee-7397-48c4-8298-75b6b2d1703b", "AQAAAAIAAYagAAAAEFl+1P8LfR0yf1nKj88301XATU8e8mGoYMj3x7T3g75hOty4ac6gSlAOHUT/fXkFMw==", "cb075322-3742-4940-b66a-029e7360f5a9", "d31e2fc1-7800-4a86-a7d5-0a87385d1d3b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "0425aa04-e080-41ba-9673-ff9ae0fc44b3", "AQAAAAIAAYagAAAAEJ2bqVVYJGuxmWD6tBcQI5BsX78IOcVTRjWUURsw/0QzfHrDVa6lLBx1HhIBbfvUvw==", "734bb173-1fc9-4168-bb69-d81cb1056662", "9171f768-c84e-49e5-909e-5cf176c3fdf1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "7e3560f9-05d5-452f-aa13-4eacd0577b25", "AQAAAAIAAYagAAAAEE8mVbLv7URZv+8c8EkmZ0GBgQlZ5sFaVQYwgYHPBty0vdzM3abhrr0zIvxZWmFzQg==", "543a8bdf-3eb3-47db-8126-3ce1a1e7ff21", "9b344d9b-8410-476c-912b-993eac958aa2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "746aee05-9d6b-4c8c-b36b-540a16ca06d3", "AQAAAAIAAYagAAAAEOJ2ry+JSMN9IZZ7poEbXNQF4BSZ/9DrKcbkGuAoLWkeXjmZGYgiQCxD5K7H/XogEA==", "b9d729dd-6807-466c-9ab2-9725fbc1ece7", "1dcc38d0-19ba-463c-8976-a4df6713fe3e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "9d98408d-43a7-4999-9459-57a8cb1c7697", "AQAAAAIAAYagAAAAEDC1C5lbjTtKNcMvyD9EskOLdI0fjl4GoR7P/ZP1Uz3ivx2lTVdjPT6a7E7tw2uojw==", "27558da6-67bf-4db9-87cf-b3352d9976b5", "cbd12396-1909-4564-b8d5-e1055fc1e560" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "061ed649-3ab8-4ca1-9778-ce26be908d69", "AQAAAAIAAYagAAAAEFhE7ORUSUfHrc8f9su0irvfbEOqL2QLue7KCbUEGB00jHBIg1j6lp+xYo59lLAkQQ==", "20d0411d-6c6d-4293-861c-e20d151fc91a", "de78af48-116e-495d-8b15-bedd9f3fde11" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "SecurityStamp" },
                values: new object[] { "66c7da64-7767-437c-99eb-42642a56e646", "AQAAAAIAAYagAAAAEMVL92VhbCaRQTMvRVnE8u2ZqyiZMCwY7ZsMO8yhVrM518zAH3LWKvUYu52TcmNKIg==", "07985248-0152-49f0-b550-369516d942f4", "5fa82276-0db6-406e-a73f-903666ed6ca1" });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 9, 931, DateTimeKind.Utc).AddTicks(5348), new DateTime(2024, 10, 31, 11, 21, 9, 931, DateTimeKind.Utc).AddTicks(5348) });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 38, DateTimeKind.Utc).AddTicks(5586), new DateTime(2024, 10, 31, 11, 21, 10, 38, DateTimeKind.Utc).AddTicks(5587) });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 122, DateTimeKind.Utc).AddTicks(8212), new DateTime(2024, 10, 31, 11, 21, 10, 122, DateTimeKind.Utc).AddTicks(8213) });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 208, DateTimeKind.Utc).AddTicks(6352), new DateTime(2024, 10, 31, 11, 21, 10, 208, DateTimeKind.Utc).AddTicks(6352) });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 300, DateTimeKind.Utc).AddTicks(5037), new DateTime(2024, 10, 31, 11, 21, 10, 300, DateTimeKind.Utc).AddTicks(5037) });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 392, DateTimeKind.Utc).AddTicks(667), new DateTime(2024, 10, 31, 11, 21, 10, 392, DateTimeKind.Utc).AddTicks(667) });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 467, DateTimeKind.Utc).AddTicks(6546), new DateTime(2024, 10, 31, 11, 21, 10, 467, DateTimeKind.Utc).AddTicks(6546) });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 541, DateTimeKind.Utc).AddTicks(8738), new DateTime(2024, 10, 31, 11, 21, 10, 541, DateTimeKind.Utc).AddTicks(8738) });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 617, DateTimeKind.Utc).AddTicks(9145), new DateTime(2024, 10, 31, 11, 21, 10, 617, DateTimeKind.Utc).AddTicks(9147) });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(3951), new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(3951) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 776, DateTimeKind.Utc).AddTicks(4413), new DateTime(2024, 10, 31, 11, 21, 10, 776, DateTimeKind.Utc).AddTicks(4414) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 851, DateTimeKind.Utc).AddTicks(6981), new DateTime(2024, 10, 31, 11, 21, 10, 851, DateTimeKind.Utc).AddTicks(6981) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 10, 935, DateTimeKind.Utc).AddTicks(9248), new DateTime(2024, 10, 31, 11, 21, 10, 935, DateTimeKind.Utc).AddTicks(9249) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 11, 14, DateTimeKind.Utc).AddTicks(3394), new DateTime(2024, 10, 31, 11, 21, 11, 14, DateTimeKind.Utc).AddTicks(3395) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 11, 106, DateTimeKind.Utc).AddTicks(7896), new DateTime(2024, 10, 31, 11, 21, 11, 106, DateTimeKind.Utc).AddTicks(7896) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 11, 196, DateTimeKind.Utc).AddTicks(5551), new DateTime(2024, 10, 31, 11, 21, 11, 196, DateTimeKind.Utc).AddTicks(5551) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 11, 283, DateTimeKind.Utc).AddTicks(5150), new DateTime(2024, 10, 31, 11, 21, 11, 283, DateTimeKind.Utc).AddTicks(5151) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 11, 370, DateTimeKind.Utc).AddTicks(9744), new DateTime(2024, 10, 31, 11, 21, 11, 370, DateTimeKind.Utc).AddTicks(9744) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 11, 447, DateTimeKind.Utc).AddTicks(260), new DateTime(2024, 10, 31, 11, 21, 11, 447, DateTimeKind.Utc).AddTicks(261) });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "LastEditedDate" },
                values: new object[] { new DateTime(2024, 10, 31, 11, 21, 11, 521, DateTimeKind.Utc).AddTicks(6790), new DateTime(2024, 10, 31, 11, 21, 11, 521, DateTimeKind.Utc).AddTicks(6790) });
        }
    }
}
