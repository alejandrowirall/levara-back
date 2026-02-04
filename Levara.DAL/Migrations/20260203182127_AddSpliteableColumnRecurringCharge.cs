using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Levara.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddSpliteableColumnRecurringCharge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Spliteable",
                table: "RecurringCharges",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Spliteable",
                table: "RecurringCharges");
        }
    }
}
