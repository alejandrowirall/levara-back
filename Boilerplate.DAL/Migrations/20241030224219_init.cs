using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Boilerplate.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    AdditionalLine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    LastEditorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Identification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentificationType = table.Column<int>(type: "int", nullable: false),
                    PersonType = table.Column<int>(type: "int", nullable: false),
                    MobilePhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    LastEditorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Owners_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Owners_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Identification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentificationType = table.Column<int>(type: "int", nullable: false),
                    PersonType = table.Column<int>(type: "int", nullable: false),
                    MobilePhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    LastEditorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tenants_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tenants_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OwnerBankAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumberMasked = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaidAccountId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    LastEditorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerBankAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OwnerBankAccounts_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    LastEditorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Properties_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Properties_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PropertyTenants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    LastEditorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyTenants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyTenants_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyTenants_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "AdditionalLine", "City", "CreatedDate", "CreatorId", "Deleted", "LastEditedDate", "LastEditorId", "Number", "PostalCode", "State", "Street" },
                values: new object[,]
                {
                    { 1, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 145, DateTimeKind.Utc).AddTicks(232), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 145, DateTimeKind.Utc).AddTicks(234), null, 1660, "10029", "New York", "Madison Ave" },
                    { 2, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 222, DateTimeKind.Utc).AddTicks(966), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 222, DateTimeKind.Utc).AddTicks(969), null, 1660, "10029", "New York", "Madison Ave" },
                    { 3, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 298, DateTimeKind.Utc).AddTicks(3992), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 298, DateTimeKind.Utc).AddTicks(3993), null, 1660, "10029", "New York", "Madison Ave" },
                    { 4, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 377, DateTimeKind.Utc).AddTicks(9412), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 377, DateTimeKind.Utc).AddTicks(9414), null, 1660, "10029", "New York", "Madison Ave" },
                    { 5, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 454, DateTimeKind.Utc).AddTicks(3485), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 454, DateTimeKind.Utc).AddTicks(3487), null, 1660, "10029", "New York", "Madison Ave" },
                    { 6, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 530, DateTimeKind.Utc).AddTicks(5969), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 530, DateTimeKind.Utc).AddTicks(5971), null, 1660, "10029", "New York", "Madison Ave" },
                    { 7, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 605, DateTimeKind.Utc).AddTicks(5043), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 605, DateTimeKind.Utc).AddTicks(5044), null, 1660, "10029", "New York", "Madison Ave" },
                    { 8, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 679, DateTimeKind.Utc).AddTicks(8765), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 679, DateTimeKind.Utc).AddTicks(8766), null, 1660, "10029", "New York", "Madison Ave" },
                    { 9, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 754, DateTimeKind.Utc).AddTicks(9677), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 754, DateTimeKind.Utc).AddTicks(9678), null, 1660, "10029", "New York", "Madison Ave" },
                    { 10, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(3791), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(3792), null, 1660, "10029", "New York", "Madison Ave" },
                    { 11, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4090), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4090), null, 1660, "10029", "New York", "Madison Ave" },
                    { 12, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4137), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4137), null, 1660, "10029", "New York", "Madison Ave" },
                    { 13, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4139), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4139), null, 1660, "10029", "New York", "Madison Ave" },
                    { 14, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4141), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4141), null, 1660, "10029", "New York", "Madison Ave" },
                    { 15, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4142), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4143), null, 1660, "10029", "New York", "Madison Ave" },
                    { 16, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4149), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4149), null, 1660, "10029", "New York", "Madison Ave" },
                    { 17, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4151), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4151), null, 1660, "10029", "New York", "Madison Ave" },
                    { 18, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4153), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4153), null, 1660, "10029", "New York", "Madison Ave" },
                    { 19, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4154), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4155), null, 1660, "10029", "New York", "Madison Ave" },
                    { 20, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4156), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4157), null, 1660, "10029", "New York", "Madison Ave" },
                    { 21, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4189), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4189), null, 1660, "10029", "New York", "Madison Ave" },
                    { 22, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4191), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4192), null, 1660, "10029", "New York", "Madison Ave" },
                    { 23, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4293), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4293), null, 1660, "10029", "New York", "Madison Ave" },
                    { 24, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4295), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4295), null, 1660, "10029", "New York", "Madison Ave" },
                    { 25, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4296), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4296), null, 1660, "10029", "New York", "Madison Ave" },
                    { 26, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4297), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4298), null, 1660, "10029", "New York", "Madison Ave" },
                    { 27, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4299), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4299), null, 1660, "10029", "New York", "Madison Ave" },
                    { 28, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4302), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4302), null, 1660, "10029", "New York", "Madison Ave" },
                    { 29, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4304), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4304), null, 1660, "10029", "New York", "Madison Ave" },
                    { 30, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4305), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4305), null, 1660, "10029", "New York", "Madison Ave" },
                    { 31, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4306), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4307), null, 1660, "10029", "New York", "Madison Ave" },
                    { 32, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4308), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4309), null, 1660, "10029", "New York", "Madison Ave" },
                    { 33, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4310), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4310), null, 1660, "10029", "New York", "Madison Ave" },
                    { 34, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4312), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4312), null, 1660, "10029", "New York", "Madison Ave" },
                    { 35, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4313), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4313), null, 1660, "10029", "New York", "Madison Ave" },
                    { 36, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4314), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4314), null, 1660, "10029", "New York", "Madison Ave" },
                    { 37, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4315), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4316), null, 1660, "10029", "New York", "Madison Ave" },
                    { 38, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4317), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4317), null, 1660, "10029", "New York", "Madison Ave" },
                    { 39, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4318), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4318), null, 1660, "10029", "New York", "Madison Ave" },
                    { 40, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4319), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4320), null, 1660, "10029", "New York", "Madison Ave" },
                    { 41, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4321), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4321), null, 1660, "10029", "New York", "Madison Ave" },
                    { 42, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4323), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4323), null, 1660, "10029", "New York", "Madison Ave" },
                    { 43, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4324), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4324), null, 1660, "10029", "New York", "Madison Ave" },
                    { 44, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4326), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4326), null, 1660, "10029", "New York", "Madison Ave" },
                    { 45, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4327), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4328), null, 1660, "10029", "New York", "Madison Ave" },
                    { 46, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4329), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4329), null, 1660, "10029", "New York", "Madison Ave" },
                    { 47, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4330), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4330), null, 1660, "10029", "New York", "Madison Ave" },
                    { 48, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4331), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4331), null, 1660, "10029", "New York", "Madison Ave" },
                    { 49, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4332), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4333), null, 1660, "10029", "New York", "Madison Ave" },
                    { 50, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4334), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4334), null, 1660, "10029", "New York", "Madison Ave" },
                    { 51, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4335), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4335), null, 1660, "10029", "New York", "Madison Ave" },
                    { 52, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4338), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4338), null, 1660, "10029", "New York", "Madison Ave" },
                    { 53, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4339), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4339), null, 1660, "10029", "New York", "Madison Ave" },
                    { 54, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4340), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4341), null, 1660, "10029", "New York", "Madison Ave" },
                    { 55, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4342), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4342), null, 1660, "10029", "New York", "Madison Ave" },
                    { 56, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4343), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4343), null, 1660, "10029", "New York", "Madison Ave" },
                    { 57, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4344), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4345), null, 1660, "10029", "New York", "Madison Ave" },
                    { 58, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4346), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4346), null, 1660, "10029", "New York", "Madison Ave" },
                    { 59, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4375), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4375), null, 1660, "10029", "New York", "Madison Ave" },
                    { 60, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4376), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4376), null, 1660, "10029", "New York", "Madison Ave" },
                    { 61, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4378), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4378), null, 1660, "10029", "New York", "Madison Ave" },
                    { 62, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4379), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4380), null, 1660, "10029", "New York", "Madison Ave" },
                    { 63, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4381), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4381), null, 1660, "10029", "New York", "Madison Ave" },
                    { 64, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4382), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4382), null, 1660, "10029", "New York", "Madison Ave" },
                    { 65, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4383), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4383), null, 1660, "10029", "New York", "Madison Ave" },
                    { 66, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4385), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4385), null, 1660, "10029", "New York", "Madison Ave" },
                    { 67, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4386), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4387), null, 1660, "10029", "New York", "Madison Ave" },
                    { 68, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4388), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4388), null, 1660, "10029", "New York", "Madison Ave" },
                    { 69, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4389), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4389), null, 1660, "10029", "New York", "Madison Ave" },
                    { 70, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4390), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4390), null, 1660, "10029", "New York", "Madison Ave" },
                    { 71, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4392), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4392), null, 1660, "10029", "New York", "Madison Ave" },
                    { 72, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4393), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4394), null, 1660, "10029", "New York", "Madison Ave" },
                    { 73, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4395), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4395), null, 1660, "10029", "New York", "Madison Ave" },
                    { 74, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4396), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4396), null, 1660, "10029", "New York", "Madison Ave" },
                    { 75, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4397), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4397), null, 1660, "10029", "New York", "Madison Ave" },
                    { 76, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4399), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4399), null, 1660, "10029", "New York", "Madison Ave" },
                    { 77, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4400), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4400), null, 1660, "10029", "New York", "Madison Ave" },
                    { 78, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4401), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4402), null, 1660, "10029", "New York", "Madison Ave" },
                    { 79, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4403), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4403), null, 1660, "10029", "New York", "Madison Ave" },
                    { 80, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4404), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4404), null, 1660, "10029", "New York", "Madison Ave" },
                    { 81, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4406), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4406), null, 1660, "10029", "New York", "Madison Ave" },
                    { 82, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4407), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4408), null, 1660, "10029", "New York", "Madison Ave" },
                    { 83, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4409), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4409), null, 1660, "10029", "New York", "Madison Ave" },
                    { 84, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4410), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4410), null, 1660, "10029", "New York", "Madison Ave" },
                    { 85, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4411), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4411), null, 1660, "10029", "New York", "Madison Ave" },
                    { 86, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4412), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4413), null, 1660, "10029", "New York", "Madison Ave" },
                    { 87, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4414), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4414), null, 1660, "10029", "New York", "Madison Ave" },
                    { 88, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4415), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4415), null, 1660, "10029", "New York", "Madison Ave" },
                    { 89, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4416), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4416), null, 1660, "10029", "New York", "Madison Ave" },
                    { 90, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4444), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4445), null, 1660, "10029", "New York", "Madison Ave" },
                    { 91, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4446), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4446), null, 1660, "10029", "New York", "Madison Ave" },
                    { 92, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4447), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4447), null, 1660, "10029", "New York", "Madison Ave" },
                    { 93, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4448), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4449), null, 1660, "10029", "New York", "Madison Ave" },
                    { 94, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4450), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4450), null, 1660, "10029", "New York", "Madison Ave" },
                    { 95, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4451), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4451), null, 1660, "10029", "New York", "Madison Ave" },
                    { 96, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4452), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4452), null, 1660, "10029", "New York", "Madison Ave" },
                    { 97, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4453), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4454), null, 1660, "10029", "New York", "Madison Ave" },
                    { 98, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4455), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4455), null, 1660, "10029", "New York", "Madison Ave" },
                    { 99, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4456), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4456), null, 1660, "10029", "New York", "Madison Ave" },
                    { 100, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4457), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4457), null, 1660, "10029", "New York", "Madison Ave" },
                    { 101, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4458), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4459), null, 1660, "10029", "New York", "Madison Ave" },
                    { 102, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4460), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4460), null, 1660, "10029", "New York", "Madison Ave" },
                    { 103, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4461), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4461), null, 1660, "10029", "New York", "Madison Ave" },
                    { 104, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4462), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4462), null, 1660, "10029", "New York", "Madison Ave" },
                    { 105, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4464), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4464), null, 1660, "10029", "New York", "Madison Ave" },
                    { 106, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4465), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4465), null, 1660, "10029", "New York", "Madison Ave" },
                    { 107, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4466), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4466), null, 1660, "10029", "New York", "Madison Ave" },
                    { 108, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4467), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4468), null, 1660, "10029", "New York", "Madison Ave" },
                    { 109, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4469), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4469), null, 1660, "10029", "New York", "Madison Ave" },
                    { 110, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4470), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(4470), null, 1660, "10029", "New York", "Madison Ave" },
                    { 501, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 904, DateTimeKind.Utc).AddTicks(3718), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 904, DateTimeKind.Utc).AddTicks(3722), null, 1660, "10029", "New York", "Madison Ave" },
                    { 502, null, "New York", new DateTime(2024, 10, 30, 22, 42, 17, 979, DateTimeKind.Utc).AddTicks(5008), null, false, new DateTime(2024, 10, 30, 22, 42, 17, 979, DateTimeKind.Utc).AddTicks(5010), null, 1660, "10029", "New York", "Madison Ave" },
                    { 503, null, "New York", new DateTime(2024, 10, 30, 22, 42, 18, 57, DateTimeKind.Utc).AddTicks(1555), null, false, new DateTime(2024, 10, 30, 22, 42, 18, 57, DateTimeKind.Utc).AddTicks(1557), null, 1660, "10029", "New York", "Madison Ave" },
                    { 504, null, "New York", new DateTime(2024, 10, 30, 22, 42, 18, 138, DateTimeKind.Utc).AddTicks(4761), null, false, new DateTime(2024, 10, 30, 22, 42, 18, 138, DateTimeKind.Utc).AddTicks(4763), null, 1660, "10029", "New York", "Madison Ave" },
                    { 505, null, "New York", new DateTime(2024, 10, 30, 22, 42, 18, 213, DateTimeKind.Utc).AddTicks(9104), null, false, new DateTime(2024, 10, 30, 22, 42, 18, 213, DateTimeKind.Utc).AddTicks(9106), null, 1660, "10029", "New York", "Madison Ave" },
                    { 506, null, "New York", new DateTime(2024, 10, 30, 22, 42, 18, 293, DateTimeKind.Utc).AddTicks(633), null, false, new DateTime(2024, 10, 30, 22, 42, 18, 293, DateTimeKind.Utc).AddTicks(637), null, 1660, "10029", "New York", "Madison Ave" },
                    { 507, null, "New York", new DateTime(2024, 10, 30, 22, 42, 18, 373, DateTimeKind.Utc).AddTicks(4644), null, false, new DateTime(2024, 10, 30, 22, 42, 18, 373, DateTimeKind.Utc).AddTicks(4646), null, 1660, "10029", "New York", "Madison Ave" },
                    { 508, null, "New York", new DateTime(2024, 10, 30, 22, 42, 18, 449, DateTimeKind.Utc).AddTicks(9175), null, false, new DateTime(2024, 10, 30, 22, 42, 18, 449, DateTimeKind.Utc).AddTicks(9179), null, 1660, "10029", "New York", "Madison Ave" },
                    { 509, null, "New York", new DateTime(2024, 10, 30, 22, 42, 18, 525, DateTimeKind.Utc).AddTicks(6920), null, false, new DateTime(2024, 10, 30, 22, 42, 18, 525, DateTimeKind.Utc).AddTicks(6922), null, 1660, "10029", "New York", "Madison Ave" },
                    { 510, null, "New York", new DateTime(2024, 10, 30, 22, 42, 18, 600, DateTimeKind.Utc).AddTicks(7644), null, false, new DateTime(2024, 10, 30, 22, 42, 18, 600, DateTimeKind.Utc).AddTicks(7646), null, 1660, "10029", "New York", "Madison Ave" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "Admin", "ADMIN" },
                    { 2, null, "Owner", "OWNER" },
                    { 3, null, "Tenant", "TENANT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "3c10c6b8-1cd3-4948-95e5-3b5c8493da6f", "owner1@levara.com", true, false, null, "OWNER1@LEVARA.COM", "OWNER1@LEVARA.COM", "AQAAAAIAAYagAAAAEPAA4yK+0d1IV9MlnAvJqtyGFnkQGzWfYxecHo4fqD+Zd8NvR5vgHoTBDN8qe/KGPQ==", null, false, "48bb6e4d-7d99-442f-8952-bf44c4149fd1", "790dff5c-5f9b-4092-b79a-5e869f259540", false, "owner1@levara.com" },
                    { 2, 0, "06924511-f541-499b-8aed-ecfac5977a5d", "owner2@levara.com", true, false, null, "OWNER2@LEVARA.COM", "OWNER2@LEVARA.COM", "AQAAAAIAAYagAAAAEITD/QjlXBAqoUWHJhC7R0zVB/j4g8MwKWHV9gX6fYvZef6IUi7oPpo+iOr+qvyndg==", null, false, "2b8de0fc-f8d7-4c63-a81b-1252ffb1d908", "8c1b0a5a-0722-4a16-8abc-c9a677a2c285", false, "owner2@levara.com" },
                    { 3, 0, "b17cdd1d-4ede-4e63-8666-234f5ba1b6aa", "owner3@levara.com", true, false, null, "OWNER3@LEVARA.COM", "OWNER3@LEVARA.COM", "AQAAAAIAAYagAAAAEIC0tOuk7SDINTEQuqYS6vvEI0a752jnY92xsG4hkH7AQldEXLz7ZRTthwX5tg0kaw==", null, false, "58c388f4-6174-4657-a26e-42a9eb904bb4", "cf3ab7b8-fd34-4f53-9ed5-bf37ca616333", false, "owner3@levara.com" },
                    { 4, 0, "35cada88-2d5d-4836-9bbf-13cdaed9d9e8", "owner4@levara.com", true, false, null, "OWNER4@LEVARA.COM", "OWNER4@LEVARA.COM", "AQAAAAIAAYagAAAAELnmw3ZnRWuwAOwqDsMBPFYVmdrN5v2yuuBwLZwTDR7tHSoNyvSZYJ982JQi/T3ZHg==", null, false, "c3c776b5-5ed9-40c7-9a55-09bb20cb198d", "35936d30-0ca9-4f1c-a82a-685dd2142ad4", false, "owner4@levara.com" },
                    { 5, 0, "a462bac3-da04-4fe7-ab38-36da62a0afe2", "owner5@levara.com", true, false, null, "OWNER5@LEVARA.COM", "OWNER5@LEVARA.COM", "AQAAAAIAAYagAAAAEBs72n6N5rn5px49m9yGivbjXHMZ3ufp42I7if/9N7/+pdqhjT54AeWWnErbHjV/8Q==", null, false, "680956c6-606a-4151-86ae-0cf0a6e33f1f", "95781472-e77d-4127-b52a-4edbe7cfef17", false, "owner5@levara.com" },
                    { 6, 0, "88f7c9c2-a345-4299-89b3-7021c4387329", "owner6@levara.com", true, false, null, "OWNER6@LEVARA.COM", "OWNER6@LEVARA.COM", "AQAAAAIAAYagAAAAEF/aNyxo31soYqd/Q7zv7FrfeAWEFIHqin+cXG0ZoGQ2+Pw7t8feXtKG3B337s+FQA==", null, false, "40bcb5e4-3b41-4a22-82cc-cb85c73d5e85", "481a1c4f-aa25-45e0-98cc-f75816f831dd", false, "owner6@levara.com" },
                    { 7, 0, "9f30515e-edb4-472b-a5c3-0d80dbb1541c", "owner7@levara.com", true, false, null, "OWNER7@LEVARA.COM", "OWNER7@LEVARA.COM", "AQAAAAIAAYagAAAAEJH/2JTG++k/pq+W77eP5CHXidrf2AiiZG3/HQGrEq6puGSY7db+QYr5M4dDG8jkEA==", null, false, "dbc7b887-68ef-4708-81e7-88b477feff4c", "477a5b09-12af-43fb-b8e0-1e5631c004df", false, "owner7@levara.com" },
                    { 8, 0, "e4a18aad-44f1-42f2-9f76-0c977bf196b8", "owner8@levara.com", true, false, null, "OWNER8@LEVARA.COM", "OWNER8@LEVARA.COM", "AQAAAAIAAYagAAAAEPwKE3K8LOQ2JlcPH4zbIA3yUnya32P8etiWdvQA75zJQ2hUyhXX8cncvtABcODdYw==", null, false, "5e0d6181-8072-4e39-b24b-e59433918dbc", "f1d93b2c-276b-400a-a8c6-12b1545ab3b4", false, "owner8@levara.com" },
                    { 9, 0, "2760f0dd-a4da-4e60-91f5-961cd0a33194", "owner9@levara.com", true, false, null, "OWNER9@LEVARA.COM", "OWNER9@LEVARA.COM", "AQAAAAIAAYagAAAAEHivVVLWFlrXxrMv0IxXCK1s9cT/a7yvMsI9hGbWrS8hhzKR6E6Vnmpo8sN+tIhLPg==", null, false, "b964b1b6-c1b7-4928-aaea-48d237ed9e80", "a18586f1-6f4d-4909-8e58-f8a8d35dfac8", false, "owner9@levara.com" },
                    { 10, 0, "aa52556d-d1e5-4af1-9d16-67539a0cf34e", "owner10@levara.com", true, false, null, "OWNER10@LEVARA.COM", "OWNER10@LEVARA.COM", "AQAAAAIAAYagAAAAEHkAWMRXUDYVIYi+4ZaEPW5+MDeATSHUAeKRzaL3807WhIQ/CFsX9AFQmScGbn8qTQ==", null, false, "b5f780bb-5eb6-4642-b77f-2b3f7dce6198", "dca5cac8-a1a1-4d1b-a8ed-3735b149887e", false, "owner10@levara.com" },
                    { 51, 0, "cb8dbf33-3512-4955-add8-474bf5645b2e", "tenant1@levara.com", true, false, null, "TENANT1@LEVARA.COM", "TENANT1@LEVARA.COM", "AQAAAAIAAYagAAAAEPAv5M4J8iTDQv2cVq1xicOh/oRyoR+dRZ8X0Pj4WHR5gnz0CqbQNjXIoH3Bamcjpw==", null, false, "291f2882-cbbb-413d-8359-62dbbc8fdfac", "a963bc42-359d-4969-aa64-272eeb2103d2", false, "tenant1@levara.com" },
                    { 52, 0, "7ebf8a48-4e97-4315-ad93-8a83d049cf51", "tenant2@levara.com", true, false, null, "TENANT2@LEVARA.COM", "TENANT2@LEVARA.COM", "AQAAAAIAAYagAAAAEJfVkr9fz5uJSwYX8VrdSlPfw5ALXBctOXXTwR7HkESPpZTxmZcXENbET5Aj0bn6bA==", null, false, "b6bc7ae1-a6f3-4bbc-bf7a-d1f542a30277", "34fb09c5-b6b1-43f4-be2a-358dd4749500", false, "tenant2@levara.com" },
                    { 53, 0, "e3415e83-c602-47db-ad54-20803ecd69d0", "tenant3@levara.com", true, false, null, "TENANT3@LEVARA.COM", "TENANT3@LEVARA.COM", "AQAAAAIAAYagAAAAEM15ThiW5xxheWXhdvRmiNA+y5A74slpZ2lOuX2WFuYnWjm3R83CEvuPYLiwEGNf+g==", null, false, "61126718-b1a6-4904-9276-ce282c6f7990", "c4b45a7f-4581-4940-a206-b3375ae262c6", false, "tenant3@levara.com" },
                    { 54, 0, "f7dc8001-784f-4a2d-869e-39f36183e276", "tenant4@levara.com", true, false, null, "TENANT4@LEVARA.COM", "TENANT4@LEVARA.COM", "AQAAAAIAAYagAAAAEN89r1bNigVVySJcKcimQT5pn37gc9sHL45CQhSc52fArruFGD/8ccS3vtg4dTiqcw==", null, false, "167188a9-f226-477e-9c4c-d6cbeeddb8d7", "be952dd8-b9c0-4ddf-810c-88a252cec045", false, "tenant4@levara.com" },
                    { 55, 0, "620bb3a4-40bf-4921-a3fa-4d5de4a6c73d", "tenant5@levara.com", true, false, null, "TENANT5@LEVARA.COM", "TENANT5@LEVARA.COM", "AQAAAAIAAYagAAAAEAAItKludQxvHZWB9MfbrOMK9zUQtcI+C3qWTNZ/NX/NEGo6xrdukZU0kCI35DdFmg==", null, false, "09c8239d-1050-423a-baed-1ade47093080", "0f8655d4-f53c-4ddf-b300-e91fa3917d87", false, "tenant5@levara.com" },
                    { 56, 0, "4e50d124-67e8-471c-a590-e6dfd1a4c874", "tenant6@levara.com", true, false, null, "TENANT6@LEVARA.COM", "TENANT6@LEVARA.COM", "AQAAAAIAAYagAAAAEP4Ni2NCoX2R/7ExI9cYDL0l+x0vblDWKYd/5pGF5VSXvARRk+TpqdAaRWjhsktLTA==", null, false, "310c691d-7ca7-440c-a2d3-9c42842dd063", "85e5b03e-f858-4164-b692-b08c4b949700", false, "tenant6@levara.com" },
                    { 57, 0, "4794cf09-5fab-40b1-95ac-a69769da2219", "tenant7@levara.com", true, false, null, "TENANT7@LEVARA.COM", "TENANT7@LEVARA.COM", "AQAAAAIAAYagAAAAEF5j+cHanYGicplR3wVBeaTE9kpMkkqtEpwSr0/+c0FDSrOkmOrVKaR9gm3KlP0HDg==", null, false, "e9e7e566-30e3-4e9d-923c-fdac709864d2", "0fad6fd9-7390-4e3e-8f90-981db57ced38", false, "tenant7@levara.com" },
                    { 58, 0, "541b210b-03b9-4319-bfef-27308e329a66", "tenant8@levara.com", true, false, null, "TENANT8@LEVARA.COM", "TENANT8@LEVARA.COM", "AQAAAAIAAYagAAAAEDB1FWoCuqAaymyjVH87YhZ7fTFyry6d3mzW2Q1tmNw4rup+RPVnUMg+LqKmsaqazQ==", null, false, "edc1f74f-d761-4917-ac5b-453202e7b517", "ab7731d6-c70d-454b-bd49-21c71e32b1ee", false, "tenant8@levara.com" },
                    { 59, 0, "d930dcc9-8b76-4c3c-9c7a-ac71249f2cfc", "tenant9@levara.com", true, false, null, "TENANT9@LEVARA.COM", "TENANT9@LEVARA.COM", "AQAAAAIAAYagAAAAEDS8lkH2XzForYcjxROm7bPkJtQ2WJ5WF5djUM7UxviEGPgD3cESRQjJ4QnW8ytJVw==", null, false, "7b55dc1d-115a-4f62-ba5d-caa3b398f336", "440d6d0e-2855-470c-8cf7-40f0a9ae9c05", false, "tenant9@levara.com" },
                    { 60, 0, "705a2039-5824-4bc1-a5ac-8d7303938f62", "tenant10@levara.com", true, false, null, "TENANT10@LEVARA.COM", "TENANT10@LEVARA.COM", "AQAAAAIAAYagAAAAEPiw4ZQnkih5SdBLJQ88aGDJIVkUJEHhALj6ek631F+dx/nVOFz6zl6ug4+dnKHpGw==", null, false, "c351769a-01eb-4273-b22b-545e1ff0723d", "88b7763d-8bda-457c-8e49-1d312084ea46", false, "tenant10@levara.com" },
                    { 1000, 0, "89e1aea7-827f-4acf-9f4d-c8a30cad890d", "admin@levara.com", true, false, null, "ADMIN@LEVARA.COM", "ADMIN@LEVARA.COM", "AQAAAAIAAYagAAAAEKcw1MaAOpIBq3P/gEXllz13EHJWeUv8AlOErPHnnoP6geXIJiFWAxrCv3RDVHzvDA==", null, false, "bf63b043-e073-4d85-8b5f-9ac024ad878d", "71e212dd-48fc-46a0-b4db-a601eac0a90d", false, "admin@levara.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "OwnerId", "1", 1 },
                    { 2, "OwnerId", "2", 2 },
                    { 3, "OwnerId", "3", 3 },
                    { 4, "OwnerId", "4", 4 },
                    { 5, "OwnerId", "5", 5 },
                    { 6, "OwnerId", "6", 6 },
                    { 7, "OwnerId", "7", 7 },
                    { 8, "OwnerId", "8", 8 },
                    { 9, "OwnerId", "9", 9 },
                    { 10, "OwnerId", "10", 10 },
                    { 51, "TenantId", "1", 51 },
                    { 52, "TenantId", "2", 52 },
                    { 53, "TenantId", "3", 53 },
                    { 54, "TenantId", "4", 54 },
                    { 55, "TenantId", "5", 55 },
                    { 56, "TenantId", "6", 56 },
                    { 57, "TenantId", "7", 57 },
                    { 58, "TenantId", "8", 58 },
                    { 59, "TenantId", "9", 59 },
                    { 60, "TenantId", "10", 60 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 2, 6 },
                    { 2, 7 },
                    { 2, 8 },
                    { 2, 9 },
                    { 2, 10 },
                    { 3, 51 },
                    { 3, 52 },
                    { 3, 53 },
                    { 3, 54 },
                    { 3, 55 },
                    { 3, 56 },
                    { 3, 57 },
                    { 3, 58 },
                    { 3, 59 },
                    { 3, 60 }
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "AddressId", "ApplicationUserId", "CompanyName", "CreatedDate", "CreatorId", "Deleted", "Email", "Identification", "IdentificationType", "LastEditedDate", "LastEditorId", "MobilePhone", "Name", "PersonType", "Surname" },
                values: new object[,]
                {
                    { 1, 1, 1, "owner1", new DateTime(2024, 10, 30, 22, 42, 17, 145, DateTimeKind.Utc).AddTicks(398), null, false, "owner1@levara.com", "50000001", 1, new DateTime(2024, 10, 30, 22, 42, 17, 145, DateTimeKind.Utc).AddTicks(398), null, "+14844760170", "owner1", 1, "owner1" },
                    { 2, 2, 2, "owner2", new DateTime(2024, 10, 30, 22, 42, 17, 222, DateTimeKind.Utc).AddTicks(987), null, false, "owner2@levara.com", "50000002", 1, new DateTime(2024, 10, 30, 22, 42, 17, 222, DateTimeKind.Utc).AddTicks(988), null, "+14844760170", "owner2", 1, "owner2" },
                    { 3, 3, 3, "owner3", new DateTime(2024, 10, 30, 22, 42, 17, 298, DateTimeKind.Utc).AddTicks(4014), null, false, "owner3@levara.com", "50000003", 1, new DateTime(2024, 10, 30, 22, 42, 17, 298, DateTimeKind.Utc).AddTicks(4014), null, "+14844760170", "owner3", 1, "owner3" },
                    { 4, 4, 4, "owner4", new DateTime(2024, 10, 30, 22, 42, 17, 377, DateTimeKind.Utc).AddTicks(9436), null, false, "owner4@levara.com", "50000004", 1, new DateTime(2024, 10, 30, 22, 42, 17, 377, DateTimeKind.Utc).AddTicks(9436), null, "+14844760170", "owner4", 1, "owner4" },
                    { 5, 5, 5, "owner5", new DateTime(2024, 10, 30, 22, 42, 17, 454, DateTimeKind.Utc).AddTicks(3510), null, false, "owner5@levara.com", "50000005", 1, new DateTime(2024, 10, 30, 22, 42, 17, 454, DateTimeKind.Utc).AddTicks(3510), null, "+14844760170", "owner5", 1, "owner5" },
                    { 6, 6, 6, "owner6", new DateTime(2024, 10, 30, 22, 42, 17, 530, DateTimeKind.Utc).AddTicks(5993), null, false, "owner6@levara.com", "50000006", 1, new DateTime(2024, 10, 30, 22, 42, 17, 530, DateTimeKind.Utc).AddTicks(5993), null, "+14844760170", "owner6", 1, "owner6" },
                    { 7, 7, 7, "owner7", new DateTime(2024, 10, 30, 22, 42, 17, 605, DateTimeKind.Utc).AddTicks(5056), null, false, "owner7@levara.com", "50000007", 1, new DateTime(2024, 10, 30, 22, 42, 17, 605, DateTimeKind.Utc).AddTicks(5056), null, "+14844760170", "owner7", 1, "owner7" },
                    { 8, 8, 8, "owner8", new DateTime(2024, 10, 30, 22, 42, 17, 679, DateTimeKind.Utc).AddTicks(8861), null, false, "owner8@levara.com", "50000008", 1, new DateTime(2024, 10, 30, 22, 42, 17, 679, DateTimeKind.Utc).AddTicks(8861), null, "+14844760170", "owner8", 1, "owner8" },
                    { 9, 9, 9, "owner9", new DateTime(2024, 10, 30, 22, 42, 17, 754, DateTimeKind.Utc).AddTicks(9701), null, false, "owner9@levara.com", "50000009", 1, new DateTime(2024, 10, 30, 22, 42, 17, 754, DateTimeKind.Utc).AddTicks(9701), null, "+14844760170", "owner9", 1, "owner9" },
                    { 10, 10, 10, "owner10", new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(3809), null, false, "owner10@levara.com", "50000010", 1, new DateTime(2024, 10, 30, 22, 42, 17, 829, DateTimeKind.Utc).AddTicks(3809), null, "+14844760170", "owner10", 1, "owner10" }
                });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "Id", "AddressId", "ApplicationUserId", "CompanyName", "CreatedDate", "CreatorId", "Deleted", "Email", "Identification", "IdentificationType", "LastEditedDate", "LastEditorId", "MobilePhone", "Name", "PersonType", "Surname" },
                values: new object[,]
                {
                    { 1, 501, 51, "tenant1", new DateTime(2024, 10, 30, 22, 42, 17, 904, DateTimeKind.Utc).AddTicks(3741), null, false, "tenant1@levara.com", "60000001", 1, new DateTime(2024, 10, 30, 22, 42, 17, 904, DateTimeKind.Utc).AddTicks(3741), null, "+14844760170", "tenant1", 1, "tenant1" },
                    { 2, 502, 52, "tenant2", new DateTime(2024, 10, 30, 22, 42, 17, 979, DateTimeKind.Utc).AddTicks(5030), null, false, "tenant2@levara.com", "60000002", 1, new DateTime(2024, 10, 30, 22, 42, 17, 979, DateTimeKind.Utc).AddTicks(5030), null, "+14844760170", "tenant2", 1, "tenant2" },
                    { 3, 503, 53, "tenant3", new DateTime(2024, 10, 30, 22, 42, 18, 57, DateTimeKind.Utc).AddTicks(1583), null, false, "tenant3@levara.com", "60000003", 1, new DateTime(2024, 10, 30, 22, 42, 18, 57, DateTimeKind.Utc).AddTicks(1583), null, "+14844760170", "tenant3", 1, "tenant3" },
                    { 4, 504, 54, "tenant4", new DateTime(2024, 10, 30, 22, 42, 18, 138, DateTimeKind.Utc).AddTicks(4784), null, false, "tenant4@levara.com", "60000004", 1, new DateTime(2024, 10, 30, 22, 42, 18, 138, DateTimeKind.Utc).AddTicks(4784), null, "+14844760170", "tenant4", 1, "tenant4" },
                    { 5, 505, 55, "tenant5", new DateTime(2024, 10, 30, 22, 42, 18, 213, DateTimeKind.Utc).AddTicks(9128), null, false, "tenant5@levara.com", "60000005", 1, new DateTime(2024, 10, 30, 22, 42, 18, 213, DateTimeKind.Utc).AddTicks(9128), null, "+14844760170", "tenant5", 1, "tenant5" },
                    { 6, 506, 56, "tenant6", new DateTime(2024, 10, 30, 22, 42, 18, 293, DateTimeKind.Utc).AddTicks(658), null, false, "tenant6@levara.com", "60000006", 1, new DateTime(2024, 10, 30, 22, 42, 18, 293, DateTimeKind.Utc).AddTicks(659), null, "+14844760170", "tenant6", 1, "tenant6" },
                    { 7, 507, 57, "tenant7", new DateTime(2024, 10, 30, 22, 42, 18, 373, DateTimeKind.Utc).AddTicks(4668), null, false, "tenant7@levara.com", "60000007", 1, new DateTime(2024, 10, 30, 22, 42, 18, 373, DateTimeKind.Utc).AddTicks(4668), null, "+14844760170", "tenant7", 1, "tenant7" },
                    { 8, 508, 58, "tenant8", new DateTime(2024, 10, 30, 22, 42, 18, 449, DateTimeKind.Utc).AddTicks(9199), null, false, "tenant8@levara.com", "60000008", 1, new DateTime(2024, 10, 30, 22, 42, 18, 449, DateTimeKind.Utc).AddTicks(9200), null, "+14844760170", "tenant8", 1, "tenant8" },
                    { 9, 509, 59, "tenant9", new DateTime(2024, 10, 30, 22, 42, 18, 525, DateTimeKind.Utc).AddTicks(6944), null, false, "tenant9@levara.com", "60000009", 1, new DateTime(2024, 10, 30, 22, 42, 18, 525, DateTimeKind.Utc).AddTicks(6944), null, "+14844760170", "tenant9", 1, "tenant9" },
                    { 10, 510, 60, "tenant10", new DateTime(2024, 10, 30, 22, 42, 18, 600, DateTimeKind.Utc).AddTicks(7664), null, false, "tenant10@levara.com", "60000010", 1, new DateTime(2024, 10, 30, 22, 42, 18, 600, DateTimeKind.Utc).AddTicks(7665), null, "+14844760170", "tenant10", 1, "tenant10" }
                });

            migrationBuilder.InsertData(
                table: "OwnerBankAccounts",
                columns: new[] { "Id", "AccountNumberMasked", "BankName", "CreatedDate", "CreatorId", "Deleted", "LastEditedDate", "LastEditorId", "OwnerId", "PlaidAccountId" },
                values: new object[,]
                {
                    { 1, "****1234", "Chase", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "account-abc123" },
                    { 2, "****1235", "Chase", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, "account-abc124" },
                    { 3, "****1236", "Chase", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, "account-abc125" },
                    { 4, "****1237", "Chase", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, "account-abc126" },
                    { 5, "****1238", "Chase", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, "account-abc127" },
                    { 6, "****1239", "Chase", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, "account-abc128" },
                    { 7, "****1240", "Chase", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, "account-abc129" },
                    { 8, "****1241", "Chase", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, "account-abc130" },
                    { 9, "****1242", "Chase", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, "account-abc131" },
                    { 10, "****1243", "Chase", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, "account-abc132" }
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "AddressId", "CreatedDate", "CreatorId", "Deleted", "LastEditedDate", "LastEditorId", "Number", "OwnerId" },
                values: new object[,]
                {
                    { 1, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 1 },
                    { 2, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 1 },
                    { 3, 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 1 },
                    { 4, 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, 1 },
                    { 5, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, 1 },
                    { 6, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, 1 },
                    { 7, 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, 1 },
                    { 8, 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, 1 },
                    { 9, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, 1 },
                    { 10, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, 1 },
                    { 11, 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 2 },
                    { 12, 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 2 },
                    { 13, 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 2 },
                    { 14, 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, 2 },
                    { 15, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, 2 },
                    { 16, 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, 2 },
                    { 17, 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, 2 },
                    { 18, 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, 2 },
                    { 19, 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, 2 },
                    { 20, 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, 2 },
                    { 21, 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 3 },
                    { 22, 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 3 },
                    { 23, 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 3 },
                    { 24, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, 3 },
                    { 25, 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, 3 },
                    { 26, 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, 3 },
                    { 27, 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, 3 },
                    { 28, 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, 3 },
                    { 29, 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, 3 },
                    { 30, 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, 3 },
                    { 31, 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 4 },
                    { 32, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 4 },
                    { 33, 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 4 },
                    { 34, 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, 4 },
                    { 35, 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, 4 },
                    { 36, 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, 4 },
                    { 37, 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, 4 },
                    { 38, 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, 4 },
                    { 39, 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, 4 },
                    { 40, 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, 4 },
                    { 41, 51, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 5 },
                    { 42, 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 5 },
                    { 43, 53, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 5 },
                    { 44, 54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, 5 },
                    { 45, 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, 5 },
                    { 46, 56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, 5 },
                    { 47, 57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, 5 },
                    { 48, 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, 5 },
                    { 49, 59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, 5 },
                    { 50, 60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, 5 },
                    { 51, 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 6 },
                    { 52, 62, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 6 },
                    { 53, 63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 6 },
                    { 54, 64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, 6 },
                    { 55, 65, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, 6 },
                    { 56, 66, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, 6 },
                    { 57, 67, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, 6 },
                    { 58, 68, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, 6 },
                    { 59, 69, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, 6 },
                    { 60, 70, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, 6 },
                    { 61, 71, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 7 },
                    { 62, 72, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 7 },
                    { 63, 73, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 7 },
                    { 64, 74, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, 7 },
                    { 65, 75, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, 7 },
                    { 66, 76, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, 7 },
                    { 67, 77, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, 7 },
                    { 68, 78, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, 7 },
                    { 69, 79, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, 7 },
                    { 70, 80, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, 7 },
                    { 71, 81, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 8 },
                    { 72, 82, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 8 },
                    { 73, 83, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 8 },
                    { 74, 84, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, 8 },
                    { 75, 85, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, 8 },
                    { 76, 86, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, 8 },
                    { 77, 87, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, 8 },
                    { 78, 88, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, 8 },
                    { 79, 89, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, 8 },
                    { 80, 90, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, 8 },
                    { 81, 91, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 9 },
                    { 82, 92, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 9 },
                    { 83, 93, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 9 },
                    { 84, 94, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, 9 },
                    { 85, 95, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, 9 },
                    { 86, 96, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, 9 },
                    { 87, 97, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, 9 },
                    { 88, 98, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, 9 },
                    { 89, 99, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, 9 },
                    { 90, 100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, 9 },
                    { 91, 101, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 10 },
                    { 92, 102, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 10 },
                    { 93, 103, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 10 },
                    { 94, 104, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, 10 },
                    { 95, 105, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, 10 },
                    { 96, 106, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, 10 },
                    { 97, 107, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, 10 },
                    { 98, 108, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, 10 },
                    { 99, 109, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, 10 },
                    { 100, 110, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerBankAccounts_OwnerId",
                table: "OwnerBankAccounts",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Owners_AddressId",
                table: "Owners",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Owners_ApplicationUserId",
                table: "Owners",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_AddressId",
                table: "Properties",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_OwnerId",
                table: "Properties",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyTenants_PropertyId",
                table: "PropertyTenants",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyTenants_TenantId",
                table: "PropertyTenants",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_AddressId",
                table: "Tenants",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_ApplicationUserId",
                table: "Tenants",
                column: "ApplicationUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "OwnerBankAccounts");

            migrationBuilder.DropTable(
                name: "PropertyTenants");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
