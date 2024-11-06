using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Levara.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
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
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
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
                    { 1, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 176, DateTimeKind.Utc).AddTicks(5877), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 176, DateTimeKind.Utc).AddTicks(5880), null, 1660, "10029", "New York", "Madison Ave" },
                    { 2, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 260, DateTimeKind.Utc).AddTicks(7601), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 260, DateTimeKind.Utc).AddTicks(7602), null, 1660, "10029", "New York", "Madison Ave" },
                    { 3, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 357, DateTimeKind.Utc).AddTicks(9125), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 357, DateTimeKind.Utc).AddTicks(9128), null, 1660, "10029", "New York", "Madison Ave" },
                    { 4, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 448, DateTimeKind.Utc).AddTicks(4014), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 448, DateTimeKind.Utc).AddTicks(4017), null, 1660, "10029", "New York", "Madison Ave" },
                    { 5, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 531, DateTimeKind.Utc).AddTicks(4412), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 531, DateTimeKind.Utc).AddTicks(4414), null, 1660, "10029", "New York", "Madison Ave" },
                    { 6, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 610, DateTimeKind.Utc).AddTicks(2646), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 610, DateTimeKind.Utc).AddTicks(2649), null, 1660, "10029", "New York", "Madison Ave" },
                    { 7, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 702, DateTimeKind.Utc).AddTicks(1618), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 702, DateTimeKind.Utc).AddTicks(1620), null, 1660, "10029", "New York", "Madison Ave" },
                    { 8, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 783, DateTimeKind.Utc).AddTicks(612), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 783, DateTimeKind.Utc).AddTicks(614), null, 1660, "10029", "New York", "Madison Ave" },
                    { 9, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 858, DateTimeKind.Utc).AddTicks(249), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 858, DateTimeKind.Utc).AddTicks(251), null, 1660, "10029", "New York", "Madison Ave" },
                    { 10, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(7616), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(7619), null, 1660, "10029", "New York", "Madison Ave" },
                    { 11, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(7881), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(7881), null, 1660, "10029", "New York", "Madison Ave" },
                    { 12, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8019), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8019), null, 1660, "10029", "New York", "Madison Ave" },
                    { 13, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8021), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8021), null, 1660, "10029", "New York", "Madison Ave" },
                    { 14, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8023), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8023), null, 1660, "10029", "New York", "Madison Ave" },
                    { 15, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8024), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8024), null, 1660, "10029", "New York", "Madison Ave" },
                    { 16, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8033), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8033), null, 1660, "10029", "New York", "Madison Ave" },
                    { 17, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8035), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8036), null, 1660, "10029", "New York", "Madison Ave" },
                    { 18, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8038), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8039), null, 1660, "10029", "New York", "Madison Ave" },
                    { 19, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8040), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8041), null, 1660, "10029", "New York", "Madison Ave" },
                    { 20, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8042), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8043), null, 1660, "10029", "New York", "Madison Ave" },
                    { 21, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8081), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8081), null, 1660, "10029", "New York", "Madison Ave" },
                    { 22, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8083), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8084), null, 1660, "10029", "New York", "Madison Ave" },
                    { 23, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8085), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8085), null, 1660, "10029", "New York", "Madison Ave" },
                    { 24, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8086), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8086), null, 1660, "10029", "New York", "Madison Ave" },
                    { 25, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8087), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8088), null, 1660, "10029", "New York", "Madison Ave" },
                    { 26, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8089), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8089), null, 1660, "10029", "New York", "Madison Ave" },
                    { 27, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8090), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8090), null, 1660, "10029", "New York", "Madison Ave" },
                    { 28, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8092), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8093), null, 1660, "10029", "New York", "Madison Ave" },
                    { 29, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8094), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8094), null, 1660, "10029", "New York", "Madison Ave" },
                    { 30, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8194), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8194), null, 1660, "10029", "New York", "Madison Ave" },
                    { 31, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8196), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8196), null, 1660, "10029", "New York", "Madison Ave" },
                    { 32, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8198), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8198), null, 1660, "10029", "New York", "Madison Ave" },
                    { 33, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8199), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8199), null, 1660, "10029", "New York", "Madison Ave" },
                    { 34, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8202), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8202), null, 1660, "10029", "New York", "Madison Ave" },
                    { 35, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8204), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8204), null, 1660, "10029", "New York", "Madison Ave" },
                    { 36, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8205), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8205), null, 1660, "10029", "New York", "Madison Ave" },
                    { 37, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8206), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8207), null, 1660, "10029", "New York", "Madison Ave" },
                    { 38, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8208), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8208), null, 1660, "10029", "New York", "Madison Ave" },
                    { 39, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8209), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8209), null, 1660, "10029", "New York", "Madison Ave" },
                    { 40, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8210), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8211), null, 1660, "10029", "New York", "Madison Ave" },
                    { 41, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8212), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8212), null, 1660, "10029", "New York", "Madison Ave" },
                    { 42, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8214), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8214), null, 1660, "10029", "New York", "Madison Ave" },
                    { 43, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8215), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8215), null, 1660, "10029", "New York", "Madison Ave" },
                    { 44, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8217), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8217), null, 1660, "10029", "New York", "Madison Ave" },
                    { 45, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8218), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8219), null, 1660, "10029", "New York", "Madison Ave" },
                    { 46, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8220), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8220), null, 1660, "10029", "New York", "Madison Ave" },
                    { 47, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8221), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8221), null, 1660, "10029", "New York", "Madison Ave" },
                    { 48, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8222), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8223), null, 1660, "10029", "New York", "Madison Ave" },
                    { 49, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8224), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8224), null, 1660, "10029", "New York", "Madison Ave" },
                    { 50, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8225), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8225), null, 1660, "10029", "New York", "Madison Ave" },
                    { 51, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8227), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8227), null, 1660, "10029", "New York", "Madison Ave" },
                    { 52, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8229), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8229), null, 1660, "10029", "New York", "Madison Ave" },
                    { 53, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8231), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8231), null, 1660, "10029", "New York", "Madison Ave" },
                    { 54, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8232), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8232), null, 1660, "10029", "New York", "Madison Ave" },
                    { 55, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8233), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8233), null, 1660, "10029", "New York", "Madison Ave" },
                    { 56, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8234), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8235), null, 1660, "10029", "New York", "Madison Ave" },
                    { 57, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8236), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8236), null, 1660, "10029", "New York", "Madison Ave" },
                    { 58, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8237), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8237), null, 1660, "10029", "New York", "Madison Ave" },
                    { 59, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8239), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8239), null, 1660, "10029", "New York", "Madison Ave" },
                    { 60, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8240), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8240), null, 1660, "10029", "New York", "Madison Ave" },
                    { 61, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8241), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8242), null, 1660, "10029", "New York", "Madison Ave" },
                    { 62, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8243), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8243), null, 1660, "10029", "New York", "Madison Ave" },
                    { 63, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8277), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8278), null, 1660, "10029", "New York", "Madison Ave" },
                    { 64, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8279), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8279), null, 1660, "10029", "New York", "Madison Ave" },
                    { 65, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8280), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8280), null, 1660, "10029", "New York", "Madison Ave" },
                    { 66, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8282), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8282), null, 1660, "10029", "New York", "Madison Ave" },
                    { 67, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8283), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8284), null, 1660, "10029", "New York", "Madison Ave" },
                    { 68, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8285), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8285), null, 1660, "10029", "New York", "Madison Ave" },
                    { 69, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8286), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8286), null, 1660, "10029", "New York", "Madison Ave" },
                    { 70, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8287), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8288), null, 1660, "10029", "New York", "Madison Ave" },
                    { 71, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8289), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8289), null, 1660, "10029", "New York", "Madison Ave" },
                    { 72, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8291), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8291), null, 1660, "10029", "New York", "Madison Ave" },
                    { 73, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8292), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8292), null, 1660, "10029", "New York", "Madison Ave" },
                    { 74, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8293), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8294), null, 1660, "10029", "New York", "Madison Ave" },
                    { 75, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8295), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8295), null, 1660, "10029", "New York", "Madison Ave" },
                    { 76, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8297), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8297), null, 1660, "10029", "New York", "Madison Ave" },
                    { 77, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8298), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8298), null, 1660, "10029", "New York", "Madison Ave" },
                    { 78, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8299), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8299), null, 1660, "10029", "New York", "Madison Ave" },
                    { 79, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8300), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8301), null, 1660, "10029", "New York", "Madison Ave" },
                    { 80, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8302), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8302), null, 1660, "10029", "New York", "Madison Ave" },
                    { 81, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8303), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8303), null, 1660, "10029", "New York", "Madison Ave" },
                    { 82, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8305), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8305), null, 1660, "10029", "New York", "Madison Ave" },
                    { 83, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8306), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8307), null, 1660, "10029", "New York", "Madison Ave" },
                    { 84, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8308), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8308), null, 1660, "10029", "New York", "Madison Ave" },
                    { 85, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8309), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8309), null, 1660, "10029", "New York", "Madison Ave" },
                    { 86, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8310), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8311), null, 1660, "10029", "New York", "Madison Ave" },
                    { 87, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8312), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8312), null, 1660, "10029", "New York", "Madison Ave" },
                    { 88, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8313), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8313), null, 1660, "10029", "New York", "Madison Ave" },
                    { 89, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8315), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8315), null, 1660, "10029", "New York", "Madison Ave" },
                    { 90, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8316), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8316), null, 1660, "10029", "New York", "Madison Ave" },
                    { 91, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8349), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8349), null, 1660, "10029", "New York", "Madison Ave" },
                    { 92, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8350), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8351), null, 1660, "10029", "New York", "Madison Ave" },
                    { 93, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8352), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8352), null, 1660, "10029", "New York", "Madison Ave" },
                    { 94, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8353), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8353), null, 1660, "10029", "New York", "Madison Ave" },
                    { 95, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8354), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8355), null, 1660, "10029", "New York", "Madison Ave" },
                    { 96, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8356), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8356), null, 1660, "10029", "New York", "Madison Ave" },
                    { 97, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8357), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8357), null, 1660, "10029", "New York", "Madison Ave" },
                    { 98, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8359), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8359), null, 1660, "10029", "New York", "Madison Ave" },
                    { 99, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8360), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8360), null, 1660, "10029", "New York", "Madison Ave" },
                    { 100, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8361), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8361), null, 1660, "10029", "New York", "Madison Ave" },
                    { 101, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8363), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8363), null, 1660, "10029", "New York", "Madison Ave" },
                    { 102, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8364), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8364), null, 1660, "10029", "New York", "Madison Ave" },
                    { 103, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8365), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8365), null, 1660, "10029", "New York", "Madison Ave" },
                    { 104, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8366), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8367), null, 1660, "10029", "New York", "Madison Ave" },
                    { 105, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8368), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8368), null, 1660, "10029", "New York", "Madison Ave" },
                    { 106, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8369), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8369), null, 1660, "10029", "New York", "Madison Ave" },
                    { 107, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8370), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8371), null, 1660, "10029", "New York", "Madison Ave" },
                    { 108, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8372), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8372), null, 1660, "10029", "New York", "Madison Ave" },
                    { 109, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8373), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8373), null, 1660, "10029", "New York", "Madison Ave" },
                    { 110, null, "New York", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8374), null, false, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(8375), null, 1660, "10029", "New York", "Madison Ave" },
                    { 501, null, "New York", new DateTime(2024, 11, 6, 23, 30, 44, 7, DateTimeKind.Utc).AddTicks(8602), null, false, new DateTime(2024, 11, 6, 23, 30, 44, 7, DateTimeKind.Utc).AddTicks(8603), null, 1660, "10029", "New York", "Madison Ave" },
                    { 502, null, "New York", new DateTime(2024, 11, 6, 23, 30, 44, 83, DateTimeKind.Utc).AddTicks(6801), null, false, new DateTime(2024, 11, 6, 23, 30, 44, 83, DateTimeKind.Utc).AddTicks(6803), null, 1660, "10029", "New York", "Madison Ave" },
                    { 503, null, "New York", new DateTime(2024, 11, 6, 23, 30, 44, 159, DateTimeKind.Utc).AddTicks(726), null, false, new DateTime(2024, 11, 6, 23, 30, 44, 159, DateTimeKind.Utc).AddTicks(727), null, 1660, "10029", "New York", "Madison Ave" },
                    { 504, null, "New York", new DateTime(2024, 11, 6, 23, 30, 44, 234, DateTimeKind.Utc).AddTicks(1652), null, false, new DateTime(2024, 11, 6, 23, 30, 44, 234, DateTimeKind.Utc).AddTicks(1654), null, 1660, "10029", "New York", "Madison Ave" },
                    { 505, null, "New York", new DateTime(2024, 11, 6, 23, 30, 44, 308, DateTimeKind.Utc).AddTicks(8052), null, false, new DateTime(2024, 11, 6, 23, 30, 44, 308, DateTimeKind.Utc).AddTicks(8053), null, 1660, "10029", "New York", "Madison Ave" },
                    { 506, null, "New York", new DateTime(2024, 11, 6, 23, 30, 44, 384, DateTimeKind.Utc).AddTicks(6594), null, false, new DateTime(2024, 11, 6, 23, 30, 44, 384, DateTimeKind.Utc).AddTicks(6596), null, 1660, "10029", "New York", "Madison Ave" },
                    { 507, null, "New York", new DateTime(2024, 11, 6, 23, 30, 44, 459, DateTimeKind.Utc).AddTicks(3919), null, false, new DateTime(2024, 11, 6, 23, 30, 44, 459, DateTimeKind.Utc).AddTicks(3921), null, 1660, "10029", "New York", "Madison Ave" },
                    { 508, null, "New York", new DateTime(2024, 11, 6, 23, 30, 44, 534, DateTimeKind.Utc).AddTicks(2539), null, false, new DateTime(2024, 11, 6, 23, 30, 44, 534, DateTimeKind.Utc).AddTicks(2546), null, 1660, "10029", "New York", "Madison Ave" },
                    { 509, null, "New York", new DateTime(2024, 11, 6, 23, 30, 44, 612, DateTimeKind.Utc).AddTicks(1464), null, false, new DateTime(2024, 11, 6, 23, 30, 44, 612, DateTimeKind.Utc).AddTicks(1468), null, 1660, "10029", "New York", "Madison Ave" },
                    { 510, null, "New York", new DateTime(2024, 11, 6, 23, 30, 44, 690, DateTimeKind.Utc).AddTicks(6540), null, false, new DateTime(2024, 11, 6, 23, 30, 44, 690, DateTimeKind.Utc).AddTicks(6542), null, 1660, "10029", "New York", "Madison Ave" }
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
                    { 1, 0, "cc14179b-7dc7-4893-8cc7-bdb555df94c2", "owner1@levara.com", true, false, null, "OWNER1@LEVARA.COM", "OWNER1@LEVARA.COM", "AQAAAAIAAYagAAAAEAgyaN/vZ70cNWC/B3byJa7ki0kRXZAxL7fQZ99fgDzFhVWtW9WpefP49j+lfO6RPw==", null, false, "2b05d283-71d0-4111-ac81-7bede65d2c79", "cd055ea9-8db0-43e0-b654-46e4a507127d", false, "owner1@levara.com" },
                    { 2, 0, "fa832c4e-644d-4ac2-92cf-cb9acd2d5ca0", "owner2@levara.com", true, false, null, "OWNER2@LEVARA.COM", "OWNER2@LEVARA.COM", "AQAAAAIAAYagAAAAEI/4FmXxXI9LeQAYlBzErBJQYrDo4DVZaRLU06YtVFL4FCzKzVBJ2DDj6xai6Atp5Q==", null, false, "757c846f-6c55-4869-a0d0-1b39df0aa11d", "8fffbfda-ceaf-4bdf-bad8-8731d3460245", false, "owner2@levara.com" },
                    { 3, 0, "e250e028-5c2c-410b-9aa4-1bb76f659b76", "owner3@levara.com", true, false, null, "OWNER3@LEVARA.COM", "OWNER3@LEVARA.COM", "AQAAAAIAAYagAAAAEEal3KlUM7WM3or8YlOR7PVkkKCUvTK4vnT7zo1WI80kPqgzT+2xSAoDgwbcgqNAYg==", null, false, "dc42725c-23d1-4209-8c03-d2cb719374c0", "458909fe-d3e9-4965-bd6c-66c023a18716", false, "owner3@levara.com" },
                    { 4, 0, "de8a7cc6-5850-4c43-a805-dd21f17912d0", "owner4@levara.com", true, false, null, "OWNER4@LEVARA.COM", "OWNER4@LEVARA.COM", "AQAAAAIAAYagAAAAELaKSvZeTAT17VIyiuQttAeypaVDVTt3pl9xkC+GjxkgDUfYBY+CdBodZoais6dl9A==", null, false, "acf4c2de-a151-4faf-a6e6-5cb96f0aa4f3", "65c8ba0a-f483-4da7-b362-f4d731347489", false, "owner4@levara.com" },
                    { 5, 0, "a4b32b6c-87df-44d9-8b38-c6ca5445ace0", "owner5@levara.com", true, false, null, "OWNER5@LEVARA.COM", "OWNER5@LEVARA.COM", "AQAAAAIAAYagAAAAEIYQ57SX1pTFEMlIRhK/WfU7kDLqyy6GSFqKnc29Ts4AU082DicEnzGJ0S1KHDTKqA==", null, false, "a9508d41-b385-4f25-900f-7327831d0324", "07ccceee-7a60-4856-9ff5-793577e23269", false, "owner5@levara.com" },
                    { 6, 0, "88994344-0bc8-486d-ae6e-2769e143b990", "owner6@levara.com", true, false, null, "OWNER6@LEVARA.COM", "OWNER6@LEVARA.COM", "AQAAAAIAAYagAAAAEFxNWJ99Az5RRpsHy+Do+HErRnMxqCFDoAlOwvX4dwc4JI2Z4BuT06yqupaQCLGYcg==", null, false, "331690f5-111c-4988-8e74-ae23a1701b29", "3b4c6842-bbde-49e6-abe7-59918174542b", false, "owner6@levara.com" },
                    { 7, 0, "75c344a2-89c4-41e5-b963-cd7a8b9d7659", "owner7@levara.com", true, false, null, "OWNER7@LEVARA.COM", "OWNER7@LEVARA.COM", "AQAAAAIAAYagAAAAEDAK63CDieUmZ34GLHA2kbNoBG2jOHY9CPf7eJD6kFC0B6XW5cRKSRFeVQu66eSV3Q==", null, false, "5c0b39ee-49ae-44a9-a262-4499ddfec428", "75764885-1cd5-4840-a314-1465cba6509a", false, "owner7@levara.com" },
                    { 8, 0, "a6cb6672-a5cd-40ec-aa89-d3ee822e167d", "owner8@levara.com", true, false, null, "OWNER8@LEVARA.COM", "OWNER8@LEVARA.COM", "AQAAAAIAAYagAAAAEDvq8ISUCnZ4e0CsotKWh3dxlEZlmBM5kp7btCmy/OGj6wOsNTervCLmcTo4KsaYeQ==", null, false, "d137c4bf-62bd-4e1b-a212-ce29d4891165", "cc34fef2-6ee9-4e84-888f-03b6ac8ae722", false, "owner8@levara.com" },
                    { 9, 0, "237be24d-d4f7-4bda-85f7-b83f0cbe8c0e", "owner9@levara.com", true, false, null, "OWNER9@LEVARA.COM", "OWNER9@LEVARA.COM", "AQAAAAIAAYagAAAAELxUDfS0bNS2FWsgqXBhRDk0xFCglcC96V3L4NI+68KsguN2/ZpIYS7bIk80DcdR5g==", null, false, "5a68618f-1324-4093-8c79-6c067ba2fcfe", "33dcb078-793c-4702-84d3-ca393fc1d6b2", false, "owner9@levara.com" },
                    { 10, 0, "b6d32c5d-e536-4709-b8ad-6acbe6b5a6dc", "owner10@levara.com", true, false, null, "OWNER10@LEVARA.COM", "OWNER10@LEVARA.COM", "AQAAAAIAAYagAAAAECiXGadpGeEtd7mEEsBB1ThlIr79VSBvqSPryCWPTvgMCRURISvXA5y+Pa2XDGjoUg==", null, false, "e714a0e3-58a5-48ad-a4cb-fc342f7c3226", "ef69f59b-d8f2-4d68-9b7d-b0c176f36912", false, "owner10@levara.com" },
                    { 51, 0, "b3490d1f-baa2-406e-9ed6-c16eabb7cd09", "tenant1@levara.com", true, false, null, "TENANT1@LEVARA.COM", "TENANT1@LEVARA.COM", "AQAAAAIAAYagAAAAEPCjGRIYRMK/u/CFRrSjwCDNWeYbco3SD2fewiIMx8hHtYRMmTu5+W0VfDkSF+4/2w==", null, false, "749641cb-fe19-49bf-8b4a-94bb74c6e71d", "3268a494-45f0-4844-b6fd-eeba5ff9be2c", false, "tenant1@levara.com" },
                    { 52, 0, "d1f5f371-693a-49f0-bf55-dfb5eda25a83", "tenant2@levara.com", true, false, null, "TENANT2@LEVARA.COM", "TENANT2@LEVARA.COM", "AQAAAAIAAYagAAAAEJ4z5qZ5MbanUy+EvBpdvFbVXwww2K4sJ3HYa1pgpQ2WqPxFanh3jvXCpP5xWeimLw==", null, false, "2d801a03-805b-4160-b52a-39a7381e5fba", "6fd1f63e-2a12-49db-bdac-7e7b6133d6ba", false, "tenant2@levara.com" },
                    { 53, 0, "12a5efb2-7502-4d5e-add7-2f65fdb302bf", "tenant3@levara.com", true, false, null, "TENANT3@LEVARA.COM", "TENANT3@LEVARA.COM", "AQAAAAIAAYagAAAAEBrybzAAOMrVNVXGnhmpr/qIXE8zk1LVI4SyJPNiWF7Nz5AXJUs5rcZ1TsciOJQFug==", null, false, "ba7f20cc-b7e2-471f-938f-17f079de8f14", "0c7de2ac-ed65-4d33-9df5-f7999b230d48", false, "tenant3@levara.com" },
                    { 54, 0, "53871d6b-b09a-4911-bd82-1177b05c480b", "tenant4@levara.com", true, false, null, "TENANT4@LEVARA.COM", "TENANT4@LEVARA.COM", "AQAAAAIAAYagAAAAEJbGYZaoanHqaqO+JXzwPWT65dwlXFZ08ioL5ZZQU3eofGflrDzaWS48ZO6+7U7F3w==", null, false, "1bff10b6-55df-48e1-8261-7211d3d79004", "dcd24b52-47d9-4ab0-8f99-4e8f1756a9a8", false, "tenant4@levara.com" },
                    { 55, 0, "16093d8a-31e9-42b2-9157-a2486a7653c1", "tenant5@levara.com", true, false, null, "TENANT5@LEVARA.COM", "TENANT5@LEVARA.COM", "AQAAAAIAAYagAAAAEGJF9alZ90wExVe+hot5a3OiBqakYLo84EmRiHoYgGCmPFgRtGbHAYau4KiqXPs7qQ==", null, false, "2284dd40-7fbc-49f2-8ca5-a2315fe268ed", "afee3f33-078c-4312-b2e6-dada6ec80baf", false, "tenant5@levara.com" },
                    { 56, 0, "8cb1cff1-40d5-4100-a2a2-a5dff471bc5d", "tenant6@levara.com", true, false, null, "TENANT6@LEVARA.COM", "TENANT6@LEVARA.COM", "AQAAAAIAAYagAAAAEFMw5ksYG0vac2R9qqCYmOC2DhKZaOWuCDIl4t4E+X5VsX7mKZzFSv8XcZy0UTYBNg==", null, false, "3ee8e85f-9a65-4e71-80bc-a1b922850693", "c810a354-5c60-439a-b9dc-c4b39dd800ba", false, "tenant6@levara.com" },
                    { 57, 0, "b6d07634-3d61-45be-9820-4142bf23b3b1", "tenant7@levara.com", true, false, null, "TENANT7@LEVARA.COM", "TENANT7@LEVARA.COM", "AQAAAAIAAYagAAAAEEGjY/zUcvs/c1yXTmwarB6xK4C2po3K3dOF2d38a+/E0nVIPdEPz29ju+BnRp+gvA==", null, false, "d9a9b99c-a15b-48eb-9903-e7a39abee85c", "abcc3f87-12db-4edf-8f81-d889c780ce20", false, "tenant7@levara.com" },
                    { 58, 0, "02774829-a9df-473e-9957-82508c65a0bd", "tenant8@levara.com", true, false, null, "TENANT8@LEVARA.COM", "TENANT8@LEVARA.COM", "AQAAAAIAAYagAAAAEIhWhNKNdj8GUgtwKim9x+iOmisfL4nahrOW1hIa8gwmVLJ42TEI2QWnCrK1VGhLrg==", null, false, "ace59c39-3360-410b-9542-9f467b346dda", "f6eed9e2-cc57-44eb-a662-21764ed05cee", false, "tenant8@levara.com" },
                    { 59, 0, "b43720e0-0237-4d48-aac1-9b092487c80f", "tenant9@levara.com", true, false, null, "TENANT9@LEVARA.COM", "TENANT9@LEVARA.COM", "AQAAAAIAAYagAAAAEHUIAIYDjIaSukR9I6K9yM/EtTyh2DsM92TzGx12qhX1Kf8KCSz2ENqg15TPGQKpfw==", null, false, "d9385663-f2cf-443c-b24f-ce64c2221614", "029da657-a9e2-4aea-ad0a-2338951b7e6e", false, "tenant9@levara.com" },
                    { 60, 0, "14a1f6e4-63f2-40c3-b9da-688a0e222f76", "tenant10@levara.com", true, false, null, "TENANT10@LEVARA.COM", "TENANT10@LEVARA.COM", "AQAAAAIAAYagAAAAEOLawdOGRc2hzsu5yeLEDokf5q0J+DrtXgTFv2/KWceWIa+ljwJJ8Z3ClD+p6QREkg==", null, false, "0312aaca-4bc9-419f-abb1-8e895cc71f4b", "b6258869-08df-4d7d-bd16-e617327f2922", false, "tenant10@levara.com" },
                    { 100, 0, "75b2b537-0dd7-4cfa-af58-b771ecd2bcaa", "admin@levara.com", true, false, null, "ADMIN@LEVARA.COM", "ADMIN@LEVARA.COM", "AQAAAAIAAYagAAAAEKZAqjlW3Yd72RDmYn9UelrQIv7OwWHNUOa7mDS/dfnHyANi88qRcpUFwhBmzdXbNg==", null, false, "18d125c1-1855-4cc5-a22d-96d89ca69a1c", "34afef56-d76b-4be8-81a4-2e6999c345bd", false, "admin@levara.com" }
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
                    { 1, 1, 1, "owner1", new DateTime(2024, 11, 6, 23, 30, 43, 176, DateTimeKind.Utc).AddTicks(6224), null, false, "owner1@levara.com", "50000001", 1, new DateTime(2024, 11, 6, 23, 30, 43, 176, DateTimeKind.Utc).AddTicks(6226), null, "+14844760170", "owner1", 1, "owner1" },
                    { 2, 2, 2, "owner2", new DateTime(2024, 11, 6, 23, 30, 43, 260, DateTimeKind.Utc).AddTicks(7670), null, false, "owner2@levara.com", "50000002", 1, new DateTime(2024, 11, 6, 23, 30, 43, 260, DateTimeKind.Utc).AddTicks(7670), null, "+14844760170", "owner2", 1, "owner2" },
                    { 3, 3, 3, "owner3", new DateTime(2024, 11, 6, 23, 30, 43, 357, DateTimeKind.Utc).AddTicks(9152), null, false, "owner3@levara.com", "50000003", 1, new DateTime(2024, 11, 6, 23, 30, 43, 357, DateTimeKind.Utc).AddTicks(9153), null, "+14844760170", "owner3", 1, "owner3" },
                    { 4, 4, 4, "owner4", new DateTime(2024, 11, 6, 23, 30, 43, 448, DateTimeKind.Utc).AddTicks(4043), null, false, "owner4@levara.com", "50000004", 1, new DateTime(2024, 11, 6, 23, 30, 43, 448, DateTimeKind.Utc).AddTicks(4044), null, "+14844760170", "owner4", 1, "owner4" },
                    { 5, 5, 5, "owner5", new DateTime(2024, 11, 6, 23, 30, 43, 531, DateTimeKind.Utc).AddTicks(4549), null, false, "owner5@levara.com", "50000005", 1, new DateTime(2024, 11, 6, 23, 30, 43, 531, DateTimeKind.Utc).AddTicks(4550), null, "+14844760170", "owner5", 1, "owner5" },
                    { 6, 6, 6, "owner6", new DateTime(2024, 11, 6, 23, 30, 43, 610, DateTimeKind.Utc).AddTicks(2681), null, false, "owner6@levara.com", "50000006", 1, new DateTime(2024, 11, 6, 23, 30, 43, 610, DateTimeKind.Utc).AddTicks(2681), null, "+14844760170", "owner6", 1, "owner6" },
                    { 7, 7, 7, "owner7", new DateTime(2024, 11, 6, 23, 30, 43, 702, DateTimeKind.Utc).AddTicks(1646), null, false, "owner7@levara.com", "50000007", 1, new DateTime(2024, 11, 6, 23, 30, 43, 702, DateTimeKind.Utc).AddTicks(1647), null, "+14844760170", "owner7", 1, "owner7" },
                    { 8, 8, 8, "owner8", new DateTime(2024, 11, 6, 23, 30, 43, 783, DateTimeKind.Utc).AddTicks(638), null, false, "owner8@levara.com", "50000008", 1, new DateTime(2024, 11, 6, 23, 30, 43, 783, DateTimeKind.Utc).AddTicks(638), null, "+14844760170", "owner8", 1, "owner8" },
                    { 9, 9, 9, "owner9", new DateTime(2024, 11, 6, 23, 30, 43, 858, DateTimeKind.Utc).AddTicks(275), null, false, "owner9@levara.com", "50000009", 1, new DateTime(2024, 11, 6, 23, 30, 43, 858, DateTimeKind.Utc).AddTicks(276), null, "+14844760170", "owner9", 1, "owner9" },
                    { 10, 10, 10, "owner10", new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(7642), null, false, "owner10@levara.com", "50000010", 1, new DateTime(2024, 11, 6, 23, 30, 43, 932, DateTimeKind.Utc).AddTicks(7643), null, "+14844760170", "owner10", 1, "owner10" }
                });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "Id", "AddressId", "ApplicationUserId", "CompanyName", "CreatedDate", "CreatorId", "Deleted", "Email", "Identification", "IdentificationType", "LastEditedDate", "LastEditorId", "MobilePhone", "Name", "PersonType", "Surname" },
                values: new object[,]
                {
                    { 1, 501, 51, "tenant1", new DateTime(2024, 11, 6, 23, 30, 44, 7, DateTimeKind.Utc).AddTicks(8621), null, false, "tenant1@levara.com", "60000001", 1, new DateTime(2024, 11, 6, 23, 30, 44, 7, DateTimeKind.Utc).AddTicks(8621), null, "+14844760170", "tenant1", 1, "tenant1" },
                    { 2, 502, 52, "tenant2", new DateTime(2024, 11, 6, 23, 30, 44, 83, DateTimeKind.Utc).AddTicks(6822), null, false, "tenant2@levara.com", "60000002", 1, new DateTime(2024, 11, 6, 23, 30, 44, 83, DateTimeKind.Utc).AddTicks(6822), null, "+14844760170", "tenant2", 1, "tenant2" },
                    { 3, 503, 53, "tenant3", new DateTime(2024, 11, 6, 23, 30, 44, 159, DateTimeKind.Utc).AddTicks(745), null, false, "tenant3@levara.com", "60000003", 1, new DateTime(2024, 11, 6, 23, 30, 44, 159, DateTimeKind.Utc).AddTicks(746), null, "+14844760170", "tenant3", 1, "tenant3" },
                    { 4, 504, 54, "tenant4", new DateTime(2024, 11, 6, 23, 30, 44, 234, DateTimeKind.Utc).AddTicks(1671), null, false, "tenant4@levara.com", "60000004", 1, new DateTime(2024, 11, 6, 23, 30, 44, 234, DateTimeKind.Utc).AddTicks(1671), null, "+14844760170", "tenant4", 1, "tenant4" },
                    { 5, 505, 55, "tenant5", new DateTime(2024, 11, 6, 23, 30, 44, 308, DateTimeKind.Utc).AddTicks(8070), null, false, "tenant5@levara.com", "60000005", 1, new DateTime(2024, 11, 6, 23, 30, 44, 308, DateTimeKind.Utc).AddTicks(8071), null, "+14844760170", "tenant5", 1, "tenant5" },
                    { 6, 506, 56, "tenant6", new DateTime(2024, 11, 6, 23, 30, 44, 384, DateTimeKind.Utc).AddTicks(6613), null, false, "tenant6@levara.com", "60000006", 1, new DateTime(2024, 11, 6, 23, 30, 44, 384, DateTimeKind.Utc).AddTicks(6613), null, "+14844760170", "tenant6", 1, "tenant6" },
                    { 7, 507, 57, "tenant7", new DateTime(2024, 11, 6, 23, 30, 44, 459, DateTimeKind.Utc).AddTicks(4066), null, false, "tenant7@levara.com", "60000007", 1, new DateTime(2024, 11, 6, 23, 30, 44, 459, DateTimeKind.Utc).AddTicks(4066), null, "+14844760170", "tenant7", 1, "tenant7" },
                    { 8, 508, 58, "tenant8", new DateTime(2024, 11, 6, 23, 30, 44, 534, DateTimeKind.Utc).AddTicks(2560), null, false, "tenant8@levara.com", "60000008", 1, new DateTime(2024, 11, 6, 23, 30, 44, 534, DateTimeKind.Utc).AddTicks(2560), null, "+14844760170", "tenant8", 1, "tenant8" },
                    { 9, 509, 59, "tenant9", new DateTime(2024, 11, 6, 23, 30, 44, 612, DateTimeKind.Utc).AddTicks(1489), null, false, "tenant9@levara.com", "60000009", 1, new DateTime(2024, 11, 6, 23, 30, 44, 612, DateTimeKind.Utc).AddTicks(1489), null, "+14844760170", "tenant9", 1, "tenant9" },
                    { 10, 510, 60, "tenant10", new DateTime(2024, 11, 6, 23, 30, 44, 690, DateTimeKind.Utc).AddTicks(6567), null, false, "tenant10@levara.com", "60000010", 1, new DateTime(2024, 11, 6, 23, 30, 44, 690, DateTimeKind.Utc).AddTicks(6567), null, "+14844760170", "tenant10", 1, "tenant10" }
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
                columns: new[] { "Id", "AddressId", "CreatedDate", "CreatorId", "Deleted", "LastEditedDate", "LastEditorId", "Number", "OwnerId", "Price" },
                values: new object[,]
                {
                    { 1, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 1, null },
                    { 2, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 1, null },
                    { 3, 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 1, null },
                    { 4, 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, 1, null },
                    { 5, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, 1, null },
                    { 6, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, 1, null },
                    { 7, 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, 1, null },
                    { 8, 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, 1, null },
                    { 9, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, 1, null },
                    { 10, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, 1, null },
                    { 11, 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 2, null },
                    { 12, 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 2, null },
                    { 13, 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 2, null },
                    { 14, 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, 2, null },
                    { 15, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, 2, null },
                    { 16, 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, 2, null },
                    { 17, 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, 2, null },
                    { 18, 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, 2, null },
                    { 19, 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, 2, null },
                    { 20, 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, 2, null },
                    { 21, 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 3, null },
                    { 22, 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 3, null },
                    { 23, 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 3, null },
                    { 24, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, 3, null },
                    { 25, 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, 3, null },
                    { 26, 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, 3, null },
                    { 27, 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, 3, null },
                    { 28, 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, 3, null },
                    { 29, 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, 3, null },
                    { 30, 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, 3, null },
                    { 31, 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 4, null },
                    { 32, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 4, null },
                    { 33, 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 4, null },
                    { 34, 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, 4, null },
                    { 35, 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, 4, null },
                    { 36, 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, 4, null },
                    { 37, 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, 4, null },
                    { 38, 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, 4, null },
                    { 39, 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, 4, null },
                    { 40, 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, 4, null },
                    { 41, 51, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 5, null },
                    { 42, 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 5, null },
                    { 43, 53, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 5, null },
                    { 44, 54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, 5, null },
                    { 45, 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, 5, null },
                    { 46, 56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, 5, null },
                    { 47, 57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, 5, null },
                    { 48, 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, 5, null },
                    { 49, 59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, 5, null },
                    { 50, 60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, 5, null },
                    { 51, 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 6, null },
                    { 52, 62, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 6, null },
                    { 53, 63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 6, null },
                    { 54, 64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, 6, null },
                    { 55, 65, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, 6, null },
                    { 56, 66, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, 6, null },
                    { 57, 67, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, 6, null },
                    { 58, 68, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, 6, null },
                    { 59, 69, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, 6, null },
                    { 60, 70, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, 6, null },
                    { 61, 71, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 7, null },
                    { 62, 72, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 7, null },
                    { 63, 73, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 7, null },
                    { 64, 74, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, 7, null },
                    { 65, 75, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, 7, null },
                    { 66, 76, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, 7, null },
                    { 67, 77, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, 7, null },
                    { 68, 78, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, 7, null },
                    { 69, 79, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, 7, null },
                    { 70, 80, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, 7, null },
                    { 71, 81, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 8, null },
                    { 72, 82, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 8, null },
                    { 73, 83, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 8, null },
                    { 74, 84, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, 8, null },
                    { 75, 85, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, 8, null },
                    { 76, 86, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, 8, null },
                    { 77, 87, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, 8, null },
                    { 78, 88, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, 8, null },
                    { 79, 89, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, 8, null },
                    { 80, 90, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, 8, null },
                    { 81, 91, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 9, null },
                    { 82, 92, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 9, null },
                    { 83, 93, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 9, null },
                    { 84, 94, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, 9, null },
                    { 85, 95, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, 9, null },
                    { 86, 96, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, 9, null },
                    { 87, 97, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, 9, null },
                    { 88, 98, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, 9, null },
                    { 89, 99, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, 9, null },
                    { 90, 100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, 9, null },
                    { 91, 101, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 10, null },
                    { 92, 102, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 10, null },
                    { 93, 103, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 10, null },
                    { 94, 104, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, 10, null },
                    { 95, 105, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, 10, null },
                    { 96, 106, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, 10, null },
                    { 97, 107, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, 10, null },
                    { 98, 108, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, 10, null },
                    { 99, 109, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, 10, null },
                    { 100, 110, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, 10, null }
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
                name: "Leases");

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
