using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Levara.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddOwnerBankAccountToProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerBankAccountId",
                table: "Properties",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Properties_OwnerBankAccountId",
                table: "Properties",
                column: "OwnerBankAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_OwnerBankAccounts_OwnerBankAccountId",
                table: "Properties",
                column: "OwnerBankAccountId",
                principalTable: "OwnerBankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_OwnerBankAccounts_OwnerBankAccountId",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_OwnerBankAccountId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "OwnerBankAccountId",
                table: "Properties");
        }
    }
}
