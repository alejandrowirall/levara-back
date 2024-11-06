using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Levara.DAL.Migrations
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
                    { 1, null, "New York", new DateTime(2024, 10, 31, 11, 21, 9, 931, DateTimeKind.Utc).AddTicks(5060), null, false, new DateTime(2024, 10, 31, 11, 21, 9, 931, DateTimeKind.Utc).AddTicks(5063), null, 1660, "10029", "New York", "Madison Ave" },
                    { 2, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 38, DateTimeKind.Utc).AddTicks(5522), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 38, DateTimeKind.Utc).AddTicks(5526), null, 1660, "10029", "New York", "Madison Ave" },
                    { 3, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 122, DateTimeKind.Utc).AddTicks(8187), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 122, DateTimeKind.Utc).AddTicks(8190), null, 1660, "10029", "New York", "Madison Ave" },
                    { 4, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 208, DateTimeKind.Utc).AddTicks(6326), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 208, DateTimeKind.Utc).AddTicks(6329), null, 1660, "10029", "New York", "Madison Ave" },
                    { 5, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 300, DateTimeKind.Utc).AddTicks(5012), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 300, DateTimeKind.Utc).AddTicks(5015), null, 1660, "10029", "New York", "Madison Ave" },
                    { 6, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 392, DateTimeKind.Utc).AddTicks(640), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 392, DateTimeKind.Utc).AddTicks(642), null, 1660, "10029", "New York", "Madison Ave" },
                    { 7, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 467, DateTimeKind.Utc).AddTicks(6517), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 467, DateTimeKind.Utc).AddTicks(6520), null, 1660, "10029", "New York", "Madison Ave" },
                    { 8, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 541, DateTimeKind.Utc).AddTicks(8712), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 541, DateTimeKind.Utc).AddTicks(8715), null, 1660, "10029", "New York", "Madison Ave" },
                    { 9, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 617, DateTimeKind.Utc).AddTicks(9112), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 617, DateTimeKind.Utc).AddTicks(9115), null, 1660, "10029", "New York", "Madison Ave" },
                    { 10, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(3929), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(3930), null, 1660, "10029", "New York", "Madison Ave" },
                    { 11, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4323), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4324), null, 1660, "10029", "New York", "Madison Ave" },
                    { 12, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4399), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4399), null, 1660, "10029", "New York", "Madison Ave" },
                    { 13, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4402), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4402), null, 1660, "10029", "New York", "Madison Ave" },
                    { 14, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4404), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4404), null, 1660, "10029", "New York", "Madison Ave" },
                    { 15, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4405), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4406), null, 1660, "10029", "New York", "Madison Ave" },
                    { 16, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4414), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4414), null, 1660, "10029", "New York", "Madison Ave" },
                    { 17, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4416), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4416), null, 1660, "10029", "New York", "Madison Ave" },
                    { 18, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4419), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4419), null, 1660, "10029", "New York", "Madison Ave" },
                    { 19, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4420), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4420), null, 1660, "10029", "New York", "Madison Ave" },
                    { 20, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4521), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4521), null, 1660, "10029", "New York", "Madison Ave" },
                    { 21, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4567), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4568), null, 1660, "10029", "New York", "Madison Ave" },
                    { 22, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4570), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4571), null, 1660, "10029", "New York", "Madison Ave" },
                    { 23, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4572), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4572), null, 1660, "10029", "New York", "Madison Ave" },
                    { 24, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4573), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4573), null, 1660, "10029", "New York", "Madison Ave" },
                    { 25, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4574), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4575), null, 1660, "10029", "New York", "Madison Ave" },
                    { 26, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4576), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4576), null, 1660, "10029", "New York", "Madison Ave" },
                    { 27, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4577), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4577), null, 1660, "10029", "New York", "Madison Ave" },
                    { 28, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4580), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4580), null, 1660, "10029", "New York", "Madison Ave" },
                    { 29, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4581), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4581), null, 1660, "10029", "New York", "Madison Ave" },
                    { 30, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4582), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4583), null, 1660, "10029", "New York", "Madison Ave" },
                    { 31, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4584), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4584), null, 1660, "10029", "New York", "Madison Ave" },
                    { 32, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4586), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4586), null, 1660, "10029", "New York", "Madison Ave" },
                    { 33, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4587), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4587), null, 1660, "10029", "New York", "Madison Ave" },
                    { 34, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4589), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4589), null, 1660, "10029", "New York", "Madison Ave" },
                    { 35, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4591), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4591), null, 1660, "10029", "New York", "Madison Ave" },
                    { 36, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4592), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4592), null, 1660, "10029", "New York", "Madison Ave" },
                    { 37, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4593), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4594), null, 1660, "10029", "New York", "Madison Ave" },
                    { 38, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4595), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4595), null, 1660, "10029", "New York", "Madison Ave" },
                    { 39, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4596), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4596), null, 1660, "10029", "New York", "Madison Ave" },
                    { 40, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4597), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4598), null, 1660, "10029", "New York", "Madison Ave" },
                    { 41, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4599), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4599), null, 1660, "10029", "New York", "Madison Ave" },
                    { 42, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4701), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4701), null, 1660, "10029", "New York", "Madison Ave" },
                    { 43, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4702), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4702), null, 1660, "10029", "New York", "Madison Ave" },
                    { 44, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4705), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4705), null, 1660, "10029", "New York", "Madison Ave" },
                    { 45, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4706), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4706), null, 1660, "10029", "New York", "Madison Ave" },
                    { 46, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4707), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4708), null, 1660, "10029", "New York", "Madison Ave" },
                    { 47, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4709), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4709), null, 1660, "10029", "New York", "Madison Ave" },
                    { 48, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4710), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4710), null, 1660, "10029", "New York", "Madison Ave" },
                    { 49, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4711), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4712), null, 1660, "10029", "New York", "Madison Ave" },
                    { 50, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4713), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4713), null, 1660, "10029", "New York", "Madison Ave" },
                    { 51, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4715), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4715), null, 1660, "10029", "New York", "Madison Ave" },
                    { 52, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4717), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4717), null, 1660, "10029", "New York", "Madison Ave" },
                    { 53, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4718), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4718), null, 1660, "10029", "New York", "Madison Ave" },
                    { 54, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4845), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4845), null, 1660, "10029", "New York", "Madison Ave" },
                    { 55, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4847), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4848), null, 1660, "10029", "New York", "Madison Ave" },
                    { 56, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4849), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4849), null, 1660, "10029", "New York", "Madison Ave" },
                    { 57, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4850), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4850), null, 1660, "10029", "New York", "Madison Ave" },
                    { 58, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4852), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4852), null, 1660, "10029", "New York", "Madison Ave" },
                    { 59, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4853), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4853), null, 1660, "10029", "New York", "Madison Ave" },
                    { 60, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4854), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4855), null, 1660, "10029", "New York", "Madison Ave" },
                    { 61, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4857), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4857), null, 1660, "10029", "New York", "Madison Ave" },
                    { 62, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4858), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4859), null, 1660, "10029", "New York", "Madison Ave" },
                    { 63, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4860), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4860), null, 1660, "10029", "New York", "Madison Ave" },
                    { 64, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4861), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4861), null, 1660, "10029", "New York", "Madison Ave" },
                    { 65, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4862), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4863), null, 1660, "10029", "New York", "Madison Ave" },
                    { 66, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4865), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4865), null, 1660, "10029", "New York", "Madison Ave" },
                    { 67, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4866), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4867), null, 1660, "10029", "New York", "Madison Ave" },
                    { 68, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4868), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4868), null, 1660, "10029", "New York", "Madison Ave" },
                    { 69, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4869), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4869), null, 1660, "10029", "New York", "Madison Ave" },
                    { 70, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4870), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4871), null, 1660, "10029", "New York", "Madison Ave" },
                    { 71, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4872), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4872), null, 1660, "10029", "New York", "Madison Ave" },
                    { 72, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4874), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4874), null, 1660, "10029", "New York", "Madison Ave" },
                    { 73, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4875), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4875), null, 1660, "10029", "New York", "Madison Ave" },
                    { 74, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4876), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4877), null, 1660, "10029", "New York", "Madison Ave" },
                    { 75, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4878), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4878), null, 1660, "10029", "New York", "Madison Ave" },
                    { 76, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4880), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4880), null, 1660, "10029", "New York", "Madison Ave" },
                    { 77, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4881), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4881), null, 1660, "10029", "New York", "Madison Ave" },
                    { 78, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4882), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4882), null, 1660, "10029", "New York", "Madison Ave" },
                    { 79, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4883), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4884), null, 1660, "10029", "New York", "Madison Ave" },
                    { 80, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4885), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4885), null, 1660, "10029", "New York", "Madison Ave" },
                    { 81, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4886), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4887), null, 1660, "10029", "New York", "Madison Ave" },
                    { 82, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4888), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4888), null, 1660, "10029", "New York", "Madison Ave" },
                    { 83, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4890), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4890), null, 1660, "10029", "New York", "Madison Ave" },
                    { 84, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4891), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4891), null, 1660, "10029", "New York", "Madison Ave" },
                    { 85, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4892), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4893), null, 1660, "10029", "New York", "Madison Ave" },
                    { 86, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4950), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4951), null, 1660, "10029", "New York", "Madison Ave" },
                    { 87, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4952), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4952), null, 1660, "10029", "New York", "Madison Ave" },
                    { 88, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4953), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4953), null, 1660, "10029", "New York", "Madison Ave" },
                    { 89, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4955), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4955), null, 1660, "10029", "New York", "Madison Ave" },
                    { 90, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4956), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4956), null, 1660, "10029", "New York", "Madison Ave" },
                    { 91, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4957), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4958), null, 1660, "10029", "New York", "Madison Ave" },
                    { 92, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4959), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4959), null, 1660, "10029", "New York", "Madison Ave" },
                    { 93, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4960), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4960), null, 1660, "10029", "New York", "Madison Ave" },
                    { 94, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4961), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4962), null, 1660, "10029", "New York", "Madison Ave" },
                    { 95, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4963), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4963), null, 1660, "10029", "New York", "Madison Ave" },
                    { 96, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4964), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4964), null, 1660, "10029", "New York", "Madison Ave" },
                    { 97, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4965), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4965), null, 1660, "10029", "New York", "Madison Ave" },
                    { 98, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4967), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4967), null, 1660, "10029", "New York", "Madison Ave" },
                    { 99, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4968), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4968), null, 1660, "10029", "New York", "Madison Ave" },
                    { 100, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4969), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4969), null, 1660, "10029", "New York", "Madison Ave" },
                    { 101, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4972), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4972), null, 1660, "10029", "New York", "Madison Ave" },
                    { 102, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4973), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4973), null, 1660, "10029", "New York", "Madison Ave" },
                    { 103, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4975), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4975), null, 1660, "10029", "New York", "Madison Ave" },
                    { 104, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4976), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4976), null, 1660, "10029", "New York", "Madison Ave" },
                    { 105, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4977), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4977), null, 1660, "10029", "New York", "Madison Ave" },
                    { 106, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4978), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4979), null, 1660, "10029", "New York", "Madison Ave" },
                    { 107, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4980), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4980), null, 1660, "10029", "New York", "Madison Ave" },
                    { 108, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4981), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4981), null, 1660, "10029", "New York", "Madison Ave" },
                    { 109, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4982), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4983), null, 1660, "10029", "New York", "Madison Ave" },
                    { 110, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4984), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(4984), null, 1660, "10029", "New York", "Madison Ave" },
                    { 501, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 776, DateTimeKind.Utc).AddTicks(4389), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 776, DateTimeKind.Utc).AddTicks(4392), null, 1660, "10029", "New York", "Madison Ave" },
                    { 502, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 851, DateTimeKind.Utc).AddTicks(6958), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 851, DateTimeKind.Utc).AddTicks(6961), null, 1660, "10029", "New York", "Madison Ave" },
                    { 503, null, "New York", new DateTime(2024, 10, 31, 11, 21, 10, 935, DateTimeKind.Utc).AddTicks(9223), null, false, new DateTime(2024, 10, 31, 11, 21, 10, 935, DateTimeKind.Utc).AddTicks(9226), null, 1660, "10029", "New York", "Madison Ave" },
                    { 504, null, "New York", new DateTime(2024, 10, 31, 11, 21, 11, 14, DateTimeKind.Utc).AddTicks(3362), null, false, new DateTime(2024, 10, 31, 11, 21, 11, 14, DateTimeKind.Utc).AddTicks(3366), null, 1660, "10029", "New York", "Madison Ave" },
                    { 505, null, "New York", new DateTime(2024, 10, 31, 11, 21, 11, 106, DateTimeKind.Utc).AddTicks(7871), null, false, new DateTime(2024, 10, 31, 11, 21, 11, 106, DateTimeKind.Utc).AddTicks(7874), null, 1660, "10029", "New York", "Madison Ave" },
                    { 506, null, "New York", new DateTime(2024, 10, 31, 11, 21, 11, 196, DateTimeKind.Utc).AddTicks(5525), null, false, new DateTime(2024, 10, 31, 11, 21, 11, 196, DateTimeKind.Utc).AddTicks(5528), null, 1660, "10029", "New York", "Madison Ave" },
                    { 507, null, "New York", new DateTime(2024, 10, 31, 11, 21, 11, 283, DateTimeKind.Utc).AddTicks(5122), null, false, new DateTime(2024, 10, 31, 11, 21, 11, 283, DateTimeKind.Utc).AddTicks(5126), null, 1660, "10029", "New York", "Madison Ave" },
                    { 508, null, "New York", new DateTime(2024, 10, 31, 11, 21, 11, 370, DateTimeKind.Utc).AddTicks(9714), null, false, new DateTime(2024, 10, 31, 11, 21, 11, 370, DateTimeKind.Utc).AddTicks(9722), null, 1660, "10029", "New York", "Madison Ave" },
                    { 509, null, "New York", new DateTime(2024, 10, 31, 11, 21, 11, 447, DateTimeKind.Utc).AddTicks(235), null, false, new DateTime(2024, 10, 31, 11, 21, 11, 447, DateTimeKind.Utc).AddTicks(238), null, 1660, "10029", "New York", "Madison Ave" },
                    { 510, null, "New York", new DateTime(2024, 10, 31, 11, 21, 11, 521, DateTimeKind.Utc).AddTicks(6769), null, false, new DateTime(2024, 10, 31, 11, 21, 11, 521, DateTimeKind.Utc).AddTicks(6772), null, 1660, "10029", "New York", "Madison Ave" }
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
                    { 1, 0, "710947cf-545b-4fa5-9a60-2fa3a964354b", "owner1@levara.com", true, false, null, "OWNER1@LEVARA.COM", "OWNER1@LEVARA.COM", "AQAAAAIAAYagAAAAEAYyKMgwu/onpZ0ww+glhN0Jwan+7NNj8wA8za7UsOCrJPYUu8DkcE4Z412/MGA+VQ==", null, false, "cd97d5d8-0513-4954-bdc9-b08987b666db", "942398b4-1eb2-4b07-a6c9-7ab899ac4c5e", false, "owner1@levara.com" },
                    { 2, 0, "c6774f4b-b43d-4690-be37-ee205ebc23d3", "owner2@levara.com", true, false, null, "OWNER2@LEVARA.COM", "OWNER2@LEVARA.COM", "AQAAAAIAAYagAAAAEBJpw8O/QFiVKZ5YTadieyNaWnKXIALTOBEdC5LOC8O+g7LbTOzD2tUeyuw55G+lBQ==", null, false, "c80a1309-60b4-4588-8250-9d0f9f6b45ab", "7225284c-6ddf-4850-8b5d-1d37afb4aed3", false, "owner2@levara.com" },
                    { 3, 0, "e904a25d-5e2a-4407-a942-40ece5db484b", "owner3@levara.com", true, false, null, "OWNER3@LEVARA.COM", "OWNER3@LEVARA.COM", "AQAAAAIAAYagAAAAEOS7x5SwXjiuxhhbfAf1N0mA3Tvm2AVRC84PAYSTIGRoMkpv3ZPBPOZQYVQfBrfT8w==", null, false, "04dbfb9f-d80d-4f24-88a4-3f2c4a912cf7", "7ecd0653-5d69-4ed8-b3e8-30c7c4033953", false, "owner3@levara.com" },
                    { 4, 0, "933b99eb-55ec-499d-8582-0a4c20dc841f", "owner4@levara.com", true, false, null, "OWNER4@LEVARA.COM", "OWNER4@LEVARA.COM", "AQAAAAIAAYagAAAAELWHEjL1XCbTICtCxLLrOJE+W+OsrZDHiTesrhc8yrio4cgMkO3GQboXPxY/Kz92sw==", null, false, "45d4fa33-46ed-4bf2-aa4d-39b48d598fa2", "617d12ae-7c5f-40a2-94f5-3abbfb53c1ba", false, "owner4@levara.com" },
                    { 5, 0, "027ec3e4-c06e-4990-8407-c8459f82e5aa", "owner5@levara.com", true, false, null, "OWNER5@LEVARA.COM", "OWNER5@LEVARA.COM", "AQAAAAIAAYagAAAAEKfnFMz7C1qoY+zGiO22thLyPELqJ8VBTLRoJTmJrpflpvhLe5DnncN83/QfJb2Qxg==", null, false, "450ae751-6a81-4939-93aa-bbc8362e3cb7", "23f0357f-b41e-4f84-8982-9cc5f2fa83e0", false, "owner5@levara.com" },
                    { 6, 0, "15b6b44b-3f26-4ce9-a1df-cb007e3f794a", "owner6@levara.com", true, false, null, "OWNER6@LEVARA.COM", "OWNER6@LEVARA.COM", "AQAAAAIAAYagAAAAEA8t9zHER+GDwsQc+4fhf7KyMVWNxkagxFIobpsuPpjsQwKa7tqek4YZMzMSby+SaQ==", null, false, "ced3673c-ee51-4a3e-9d77-9a30a9f2ced7", "928e2aa2-b843-4c73-95a5-8d15ab28aa8e", false, "owner6@levara.com" },
                    { 7, 0, "9785e30e-f5b1-4d8a-9f0f-435bb8317b19", "owner7@levara.com", true, false, null, "OWNER7@LEVARA.COM", "OWNER7@LEVARA.COM", "AQAAAAIAAYagAAAAEEYg59bTgZ2yrsw3rHvbWk9SqKWCI1dHlwAeIwM44W9ewEW9D9eCT/0ev2H3/lfrXQ==", null, false, "436fc913-2baf-4f96-a3ef-d2588f02f196", "53a996c0-c18e-47b2-a029-07ba28fecda9", false, "owner7@levara.com" },
                    { 8, 0, "3dd2ab06-13b3-4994-9b1a-f235afae1872", "owner8@levara.com", true, false, null, "OWNER8@LEVARA.COM", "OWNER8@LEVARA.COM", "AQAAAAIAAYagAAAAEEJl+nR+G7k4Pp3N8ms7Qvo4yTYIbjuWfPIWbz0kqrHVZDlLxb9isTo8H/aRvw438g==", null, false, "54789cbf-ff2c-41b7-a8cf-f0ac7532b5f7", "ff2e2c31-718e-4781-b2db-be82942b9f9e", false, "owner8@levara.com" },
                    { 9, 0, "527c227f-5a73-4748-899b-f5f28d9ec749", "owner9@levara.com", true, false, null, "OWNER9@LEVARA.COM", "OWNER9@LEVARA.COM", "AQAAAAIAAYagAAAAEFPf7gHVf/B4cI+TNqhbvGyZoHQYlHXRWdCwSKPbFSzZJveylkJ6ldko8hzSsNv+bQ==", null, false, "53e00a10-6ce2-424c-9fe7-9705e15e29e6", "7a99ea27-3de2-495f-9d6d-316d24e4f57c", false, "owner9@levara.com" },
                    { 10, 0, "2b9c4b05-902c-4fc9-8439-ea27357d241c", "owner10@levara.com", true, false, null, "OWNER10@LEVARA.COM", "OWNER10@LEVARA.COM", "AQAAAAIAAYagAAAAEAMBhaVtaljOlmEQebdUwmoE2V2PyJ2oCblJiUg8G9j0IaJ1bP1/r9Lunux+pSeAoA==", null, false, "28e94a04-5e76-4a6b-810e-ae12904b4818", "01daee87-b280-4911-9f45-e9fe53a3b263", false, "owner10@levara.com" },
                    { 51, 0, "f83f0804-1601-44c6-b3d5-dc25019fb6af", "tenant1@levara.com", true, false, null, "TENANT1@LEVARA.COM", "TENANT1@LEVARA.COM", "AQAAAAIAAYagAAAAEHlzZH2+BnCMDXHA5SVo2+7JtOAA5/48cDC9eAhDmfsnhe+VSsqBlRxNAb794HZaTQ==", null, false, "a32a2abf-9f29-4094-b565-710d7d3df44f", "ff7752b7-0f62-4192-9acf-550dc7d6f96c", false, "tenant1@levara.com" },
                    { 52, 0, "bebc3056-57f0-4895-9635-7a6c3ce04bef", "tenant2@levara.com", true, false, null, "TENANT2@LEVARA.COM", "TENANT2@LEVARA.COM", "AQAAAAIAAYagAAAAEMec7Gcxy98S2/KBmp+HyaFhqu0cLjRresofHgexv+j45F+D22cYI0ML3nWTx5aTgQ==", null, false, "be8548c1-ce90-4807-8809-b8e9c3571b77", "2a8cd81b-c1d5-420b-9ddf-9cf8e6542e9d", false, "tenant2@levara.com" },
                    { 53, 0, "c7c87dd9-f03c-47dd-ae44-149058a9fe8a", "tenant3@levara.com", true, false, null, "TENANT3@LEVARA.COM", "TENANT3@LEVARA.COM", "AQAAAAIAAYagAAAAEE8cORjSRfESlOpUu2+v2Kb/00aRBhxtRztJpHcM0HvRX4qvnhb40BaOoIBitnyOzQ==", null, false, "208000f9-226d-4158-9c7a-cbb52b888a29", "c1df97ca-8495-4931-8312-95c977405529", false, "tenant3@levara.com" },
                    { 54, 0, "ad9b8480-7d9e-468a-8491-4b9a7c301cc2", "tenant4@levara.com", true, false, null, "TENANT4@LEVARA.COM", "TENANT4@LEVARA.COM", "AQAAAAIAAYagAAAAEDe9kNjIk9z2Htah01izWAS02m+4QARkW2OQIrywwtdPa6RYwNbbDUZIUSFcCQtB5g==", null, false, "874fb122-2d41-4abc-bf42-12ad73afce67", "48bd169f-371a-47a7-9f67-64701611a492", false, "tenant4@levara.com" },
                    { 55, 0, "8b593bee-7397-48c4-8298-75b6b2d1703b", "tenant5@levara.com", true, false, null, "TENANT5@LEVARA.COM", "TENANT5@LEVARA.COM", "AQAAAAIAAYagAAAAEFl+1P8LfR0yf1nKj88301XATU8e8mGoYMj3x7T3g75hOty4ac6gSlAOHUT/fXkFMw==", null, false, "cb075322-3742-4940-b66a-029e7360f5a9", "d31e2fc1-7800-4a86-a7d5-0a87385d1d3b", false, "tenant5@levara.com" },
                    { 56, 0, "0425aa04-e080-41ba-9673-ff9ae0fc44b3", "tenant6@levara.com", true, false, null, "TENANT6@LEVARA.COM", "TENANT6@LEVARA.COM", "AQAAAAIAAYagAAAAEJ2bqVVYJGuxmWD6tBcQI5BsX78IOcVTRjWUURsw/0QzfHrDVa6lLBx1HhIBbfvUvw==", null, false, "734bb173-1fc9-4168-bb69-d81cb1056662", "9171f768-c84e-49e5-909e-5cf176c3fdf1", false, "tenant6@levara.com" },
                    { 57, 0, "7e3560f9-05d5-452f-aa13-4eacd0577b25", "tenant7@levara.com", true, false, null, "TENANT7@LEVARA.COM", "TENANT7@LEVARA.COM", "AQAAAAIAAYagAAAAEE8mVbLv7URZv+8c8EkmZ0GBgQlZ5sFaVQYwgYHPBty0vdzM3abhrr0zIvxZWmFzQg==", null, false, "543a8bdf-3eb3-47db-8126-3ce1a1e7ff21", "9b344d9b-8410-476c-912b-993eac958aa2", false, "tenant7@levara.com" },
                    { 58, 0, "746aee05-9d6b-4c8c-b36b-540a16ca06d3", "tenant8@levara.com", true, false, null, "TENANT8@LEVARA.COM", "TENANT8@LEVARA.COM", "AQAAAAIAAYagAAAAEOJ2ry+JSMN9IZZ7poEbXNQF4BSZ/9DrKcbkGuAoLWkeXjmZGYgiQCxD5K7H/XogEA==", null, false, "b9d729dd-6807-466c-9ab2-9725fbc1ece7", "1dcc38d0-19ba-463c-8976-a4df6713fe3e", false, "tenant8@levara.com" },
                    { 59, 0, "9d98408d-43a7-4999-9459-57a8cb1c7697", "tenant9@levara.com", true, false, null, "TENANT9@LEVARA.COM", "TENANT9@LEVARA.COM", "AQAAAAIAAYagAAAAEDC1C5lbjTtKNcMvyD9EskOLdI0fjl4GoR7P/ZP1Uz3ivx2lTVdjPT6a7E7tw2uojw==", null, false, "27558da6-67bf-4db9-87cf-b3352d9976b5", "cbd12396-1909-4564-b8d5-e1055fc1e560", false, "tenant9@levara.com" },
                    { 60, 0, "061ed649-3ab8-4ca1-9778-ce26be908d69", "tenant10@levara.com", true, false, null, "TENANT10@LEVARA.COM", "TENANT10@LEVARA.COM", "AQAAAAIAAYagAAAAEFhE7ORUSUfHrc8f9su0irvfbEOqL2QLue7KCbUEGB00jHBIg1j6lp+xYo59lLAkQQ==", null, false, "20d0411d-6c6d-4293-861c-e20d151fc91a", "de78af48-116e-495d-8b15-bedd9f3fde11", false, "tenant10@levara.com" },
                    { 100, 0, "66c7da64-7767-437c-99eb-42642a56e646", "admin@levara.com", true, false, null, "ADMIN@LEVARA.COM", "ADMIN@LEVARA.COM", "AQAAAAIAAYagAAAAEMVL92VhbCaRQTMvRVnE8u2ZqyiZMCwY7ZsMO8yhVrM518zAH3LWKvUYu52TcmNKIg==", null, false, "07985248-0152-49f0-b550-369516d942f4", "5fa82276-0db6-406e-a73f-903666ed6ca1", false, "admin@levara.com" }
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
                    { 3, 60 },
                    { 1, 100 }
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "AddressId", "ApplicationUserId", "CompanyName", "CreatedDate", "CreatorId", "Deleted", "Email", "Identification", "IdentificationType", "LastEditedDate", "LastEditorId", "MobilePhone", "Name", "PersonType", "Surname" },
                values: new object[,]
                {
                    { 1, 1, 1, "owner1", new DateTime(2024, 10, 31, 11, 21, 9, 931, DateTimeKind.Utc).AddTicks(5348), null, false, "owner1@levara.com", "50000001", 1, new DateTime(2024, 10, 31, 11, 21, 9, 931, DateTimeKind.Utc).AddTicks(5348), null, "+14844760170", "owner1", 1, "owner1" },
                    { 2, 2, 2, "owner2", new DateTime(2024, 10, 31, 11, 21, 10, 38, DateTimeKind.Utc).AddTicks(5586), null, false, "owner2@levara.com", "50000002", 1, new DateTime(2024, 10, 31, 11, 21, 10, 38, DateTimeKind.Utc).AddTicks(5587), null, "+14844760170", "owner2", 1, "owner2" },
                    { 3, 3, 3, "owner3", new DateTime(2024, 10, 31, 11, 21, 10, 122, DateTimeKind.Utc).AddTicks(8212), null, false, "owner3@levara.com", "50000003", 1, new DateTime(2024, 10, 31, 11, 21, 10, 122, DateTimeKind.Utc).AddTicks(8213), null, "+14844760170", "owner3", 1, "owner3" },
                    { 4, 4, 4, "owner4", new DateTime(2024, 10, 31, 11, 21, 10, 208, DateTimeKind.Utc).AddTicks(6352), null, false, "owner4@levara.com", "50000004", 1, new DateTime(2024, 10, 31, 11, 21, 10, 208, DateTimeKind.Utc).AddTicks(6352), null, "+14844760170", "owner4", 1, "owner4" },
                    { 5, 5, 5, "owner5", new DateTime(2024, 10, 31, 11, 21, 10, 300, DateTimeKind.Utc).AddTicks(5037), null, false, "owner5@levara.com", "50000005", 1, new DateTime(2024, 10, 31, 11, 21, 10, 300, DateTimeKind.Utc).AddTicks(5037), null, "+14844760170", "owner5", 1, "owner5" },
                    { 6, 6, 6, "owner6", new DateTime(2024, 10, 31, 11, 21, 10, 392, DateTimeKind.Utc).AddTicks(667), null, false, "owner6@levara.com", "50000006", 1, new DateTime(2024, 10, 31, 11, 21, 10, 392, DateTimeKind.Utc).AddTicks(667), null, "+14844760170", "owner6", 1, "owner6" },
                    { 7, 7, 7, "owner7", new DateTime(2024, 10, 31, 11, 21, 10, 467, DateTimeKind.Utc).AddTicks(6546), null, false, "owner7@levara.com", "50000007", 1, new DateTime(2024, 10, 31, 11, 21, 10, 467, DateTimeKind.Utc).AddTicks(6546), null, "+14844760170", "owner7", 1, "owner7" },
                    { 8, 8, 8, "owner8", new DateTime(2024, 10, 31, 11, 21, 10, 541, DateTimeKind.Utc).AddTicks(8738), null, false, "owner8@levara.com", "50000008", 1, new DateTime(2024, 10, 31, 11, 21, 10, 541, DateTimeKind.Utc).AddTicks(8738), null, "+14844760170", "owner8", 1, "owner8" },
                    { 9, 9, 9, "owner9", new DateTime(2024, 10, 31, 11, 21, 10, 617, DateTimeKind.Utc).AddTicks(9145), null, false, "owner9@levara.com", "50000009", 1, new DateTime(2024, 10, 31, 11, 21, 10, 617, DateTimeKind.Utc).AddTicks(9147), null, "+14844760170", "owner9", 1, "owner9" },
                    { 10, 10, 10, "owner10", new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(3951), null, false, "owner10@levara.com", "50000010", 1, new DateTime(2024, 10, 31, 11, 21, 10, 692, DateTimeKind.Utc).AddTicks(3951), null, "+14844760170", "owner10", 1, "owner10" }
                });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "Id", "AddressId", "ApplicationUserId", "CompanyName", "CreatedDate", "CreatorId", "Deleted", "Email", "Identification", "IdentificationType", "LastEditedDate", "LastEditorId", "MobilePhone", "Name", "PersonType", "Surname" },
                values: new object[,]
                {
                    { 1, 501, 51, "tenant1", new DateTime(2024, 10, 31, 11, 21, 10, 776, DateTimeKind.Utc).AddTicks(4413), null, false, "tenant1@levara.com", "60000001", 1, new DateTime(2024, 10, 31, 11, 21, 10, 776, DateTimeKind.Utc).AddTicks(4414), null, "+14844760170", "tenant1", 1, "tenant1" },
                    { 2, 502, 52, "tenant2", new DateTime(2024, 10, 31, 11, 21, 10, 851, DateTimeKind.Utc).AddTicks(6981), null, false, "tenant2@levara.com", "60000002", 1, new DateTime(2024, 10, 31, 11, 21, 10, 851, DateTimeKind.Utc).AddTicks(6981), null, "+14844760170", "tenant2", 1, "tenant2" },
                    { 3, 503, 53, "tenant3", new DateTime(2024, 10, 31, 11, 21, 10, 935, DateTimeKind.Utc).AddTicks(9248), null, false, "tenant3@levara.com", "60000003", 1, new DateTime(2024, 10, 31, 11, 21, 10, 935, DateTimeKind.Utc).AddTicks(9249), null, "+14844760170", "tenant3", 1, "tenant3" },
                    { 4, 504, 54, "tenant4", new DateTime(2024, 10, 31, 11, 21, 11, 14, DateTimeKind.Utc).AddTicks(3394), null, false, "tenant4@levara.com", "60000004", 1, new DateTime(2024, 10, 31, 11, 21, 11, 14, DateTimeKind.Utc).AddTicks(3395), null, "+14844760170", "tenant4", 1, "tenant4" },
                    { 5, 505, 55, "tenant5", new DateTime(2024, 10, 31, 11, 21, 11, 106, DateTimeKind.Utc).AddTicks(7896), null, false, "tenant5@levara.com", "60000005", 1, new DateTime(2024, 10, 31, 11, 21, 11, 106, DateTimeKind.Utc).AddTicks(7896), null, "+14844760170", "tenant5", 1, "tenant5" },
                    { 6, 506, 56, "tenant6", new DateTime(2024, 10, 31, 11, 21, 11, 196, DateTimeKind.Utc).AddTicks(5551), null, false, "tenant6@levara.com", "60000006", 1, new DateTime(2024, 10, 31, 11, 21, 11, 196, DateTimeKind.Utc).AddTicks(5551), null, "+14844760170", "tenant6", 1, "tenant6" },
                    { 7, 507, 57, "tenant7", new DateTime(2024, 10, 31, 11, 21, 11, 283, DateTimeKind.Utc).AddTicks(5150), null, false, "tenant7@levara.com", "60000007", 1, new DateTime(2024, 10, 31, 11, 21, 11, 283, DateTimeKind.Utc).AddTicks(5151), null, "+14844760170", "tenant7", 1, "tenant7" },
                    { 8, 508, 58, "tenant8", new DateTime(2024, 10, 31, 11, 21, 11, 370, DateTimeKind.Utc).AddTicks(9744), null, false, "tenant8@levara.com", "60000008", 1, new DateTime(2024, 10, 31, 11, 21, 11, 370, DateTimeKind.Utc).AddTicks(9744), null, "+14844760170", "tenant8", 1, "tenant8" },
                    { 9, 509, 59, "tenant9", new DateTime(2024, 10, 31, 11, 21, 11, 447, DateTimeKind.Utc).AddTicks(260), null, false, "tenant9@levara.com", "60000009", 1, new DateTime(2024, 10, 31, 11, 21, 11, 447, DateTimeKind.Utc).AddTicks(261), null, "+14844760170", "tenant9", 1, "tenant9" },
                    { 10, 510, 60, "tenant10", new DateTime(2024, 10, 31, 11, 21, 11, 521, DateTimeKind.Utc).AddTicks(6790), null, false, "tenant10@levara.com", "60000010", 1, new DateTime(2024, 10, 31, 11, 21, 11, 521, DateTimeKind.Utc).AddTicks(6790), null, "+14844760170", "tenant10", 1, "tenant10" }
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
