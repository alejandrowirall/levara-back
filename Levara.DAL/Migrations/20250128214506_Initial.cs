using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Street = table.Column<string>(type: "text", nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    AdditionalLine = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false),
                    PostalCode = table.Column<string>(type: "text", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastEditedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<int>(type: "integer", nullable: true),
                    LastEditorId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RefreshToken = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DomainEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventId = table.Column<Guid>(type: "uuid", nullable: false),
                    EntityId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Body = table.Column<Dictionary<string, string>>(type: "jsonb", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastEditedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<int>(type: "integer", nullable: true),
                    LastEditorId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expense",
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
                    table.PrimaryKey("PK_Expense", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceTypes",
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
                    table.PrimaryKey("PK_MaintenanceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false)
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
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false)
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
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
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
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Link = table.Column<string>(type: "text", nullable: false),
                    ReceiverId = table.Column<int>(type: "integer", nullable: false),
                    ClickedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ShownAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Data = table.Column<Dictionary<string, object>>(type: "jsonb", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastEditedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<int>(type: "integer", nullable: true),
                    LastEditorId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_AspNetUsers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    CompanyName = table.Column<string>(type: "text", nullable: false),
                    Identification = table.Column<string>(type: "text", nullable: false),
                    IdentificationType = table.Column<int>(type: "integer", nullable: false),
                    PersonType = table.Column<int>(type: "integer", nullable: false),
                    MobilePhone = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    AddressId = table.Column<int>(type: "integer", nullable: false),
                    ApplicationUserId = table.Column<int>(type: "integer", nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastEditedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<int>(type: "integer", nullable: true),
                    LastEditorId = table.Column<int>(type: "integer", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    CompanyName = table.Column<string>(type: "text", nullable: false),
                    Identification = table.Column<string>(type: "text", nullable: false),
                    IdentificationType = table.Column<int>(type: "integer", nullable: false),
                    PersonType = table.Column<int>(type: "integer", nullable: false),
                    MobilePhone = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    AddressId = table.Column<int>(type: "integer", nullable: false),
                    ApplicationUserId = table.Column<int>(type: "integer", nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastEditedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<int>(type: "integer", nullable: true),
                    LastEditorId = table.Column<int>(type: "integer", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BankName = table.Column<string>(type: "text", nullable: false),
                    AccountNumberMasked = table.Column<string>(type: "text", nullable: false),
                    PlaidAccountId = table.Column<string>(type: "text", nullable: false),
                    OwnerId = table.Column<int>(type: "integer", nullable: false),
                    LastSyncId = table.Column<string>(type: "text", nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastEditedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<int>(type: "integer", nullable: true),
                    LastEditorId = table.Column<int>(type: "integer", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    AddressId = table.Column<int>(type: "integer", nullable: false),
                    OwnerId = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true),
                    RoomsQuantity = table.Column<int>(type: "integer", nullable: true),
                    BathroomQuantity = table.Column<int>(type: "integer", nullable: true),
                    AreaQuantity = table.Column<decimal>(type: "numeric", nullable: true),
                    HasPool = table.Column<bool>(type: "boolean", nullable: true),
                    HasBalcony = table.Column<bool>(type: "boolean", nullable: true),
                    HasGarage = table.Column<bool>(type: "boolean", nullable: true),
                    DetailDepositAndAdittionalInfo = table.Column<string>(type: "text", nullable: true),
                    PetsPoliticAndRate = table.Column<string>(type: "text", nullable: true),
                    TenantRequirements = table.Column<string>(type: "text", nullable: true),
                    AvaliableFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Img = table.Column<byte[]>(type: "bytea", nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastEditedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<int>(type: "integer", nullable: true),
                    LastEditorId = table.Column<int>(type: "integer", nullable: true)
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
                name: "PlaidTransaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TransactionId = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<double>(type: "double precision", precision: 18, scale: 2, nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    OwnerBankAccountId = table.Column<int>(type: "integer", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastEditedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<int>(type: "integer", nullable: true),
                    LastEditorId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaidTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaidTransaction_OwnerBankAccounts_OwnerBankAccountId",
                        column: x => x.OwnerBankAccountId,
                        principalTable: "OwnerBankAccounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Leases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OwnerId = table.Column<int>(type: "integer", nullable: false),
                    TenantId = table.Column<int>(type: "integer", nullable: false),
                    PropertyId = table.Column<int>(type: "integer", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Frequency = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    StatusLease = table.Column<int>(type: "integer", nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastEditedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<int>(type: "integer", nullable: true),
                    LastEditorId = table.Column<int>(type: "integer", nullable: true)
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
                name: "Maintenances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    TypeId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PropertyId = table.Column<int>(type: "integer", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastEditedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<int>(type: "integer", nullable: true),
                    LastEditorId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintenances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maintenances_MaintenanceTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "MaintenanceTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Maintenances_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id");
                });

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
                name: "BankTransaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TransactionId = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<double>(type: "double precision", nullable: true),
                    PropertyId = table.Column<int>(type: "integer", nullable: false),
                    LeaseId = table.Column<int>(type: "integer", nullable: true),
                    OwnerBankAccountId = table.Column<int>(type: "integer", nullable: false),
                    RunningBalance = table.Column<double>(type: "double precision", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    PlaidIdTransaction = table.Column<int>(type: "integer", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastEditedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<int>(type: "integer", nullable: true),
                    LastEditorId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankTransaction_Leases_LeaseId",
                        column: x => x.LeaseId,
                        principalTable: "Leases",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BankTransaction_OwnerBankAccounts_OwnerBankAccountId",
                        column: x => x.OwnerBankAccountId,
                        principalTable: "OwnerBankAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BankTransaction_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseCharge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TransactionId = table.Column<int>(type: "integer", nullable: false),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExpenseId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastEditedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<int>(type: "integer", nullable: true),
                    LastEditorId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseCharge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenseCharge_Expense_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expense",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpenseCharge_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "MaintenanceCharges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TransactionId = table.Column<int>(type: "integer", nullable: false),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MaintenanceId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastEditedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<int>(type: "integer", nullable: true),
                    LastEditorId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceCharges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceCharges_Maintenances_MaintenanceId",
                        column: x => x.MaintenanceId,
                        principalTable: "Maintenances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MaintenanceCharges_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MaintenancePayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TransactionId = table.Column<int>(type: "integer", nullable: false),
                    MaintenanceId = table.Column<int>(type: "integer", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastEditedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<int>(type: "integer", nullable: true),
                    LastEditorId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenancePayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenancePayments_Maintenances_MaintenanceId",
                        column: x => x.MaintenanceId,
                        principalTable: "Maintenances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MaintenancePayments_Transactions_TransactionId",
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
                        name: "FK_TransactionApplications_BankTransaction_BankTransactionId",
                        column: x => x.BankTransactionId,
                        principalTable: "BankTransaction",
                        principalColumn: "Id");
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

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "AdditionalLine", "City", "CreatedDate", "CreatorId", "Deleted", "LastEditedDate", "LastEditorId", "Number", "PostalCode", "State", "Street" },
                values: new object[,]
                {
                    { 1, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 2, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 3, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 4, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 5, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 6, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 7, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 8, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 9, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 10, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 11, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 12, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 13, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 14, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 15, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 16, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 17, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 18, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 19, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 20, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 21, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 22, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 23, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 24, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 25, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 26, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 27, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 28, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 29, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 30, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 31, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 32, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 33, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 34, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 35, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 36, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 37, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 38, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 39, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 40, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 41, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 42, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 43, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 44, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 45, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 46, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 47, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 48, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 49, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 50, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 51, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 52, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 53, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 54, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 55, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 56, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 57, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 58, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 59, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 60, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 61, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 62, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 63, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 64, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 65, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 66, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 67, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 68, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 69, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 70, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 71, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 72, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 73, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 74, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 75, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 76, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 77, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 78, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 79, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 80, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 81, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 82, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 83, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 84, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 85, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 86, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 87, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 88, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 89, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 90, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 91, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 92, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 93, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 94, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 95, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 96, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 97, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 98, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 99, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 100, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 101, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 102, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 103, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 104, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 105, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 106, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 107, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 108, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 109, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 110, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 501, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 502, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 503, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 504, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 505, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 506, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 507, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 508, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 509, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" },
                    { 510, null, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1660, "10029", "New York", "Madison Ave" }
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
                    { 1, 0, "c231efea-6e8c-40e5-ae33-f15bc5cfb2a0", "owner1@levara.com", true, false, null, "OWNER1@LEVARA.COM", "OWNER1@LEVARA.COM", "AQAAAAIAAYagAAAAEPeAV1996kkE+Il+HPFULI7rRDpVhoP89dglukaO/NrGgGDZi0dOyA4AT3rtnrzfrQ==", null, false, "e030be4a-c6ed-46a5-9e86-4ad6db062ed6", "eca8a667-056e-4622-9ff6-88cd57ca4b44", false, "owner1@levara.com" },
                    { 2, 0, "c231efea-6e8c-40e5-ae33-f15bc5cfb2a0", "owner2@levara.com", true, false, null, "OWNER2@LEVARA.COM", "OWNER2@LEVARA.COM", "AQAAAAIAAYagAAAAEPeAV1996kkE+Il+HPFULI7rRDpVhoP89dglukaO/NrGgGDZi0dOyA4AT3rtnrzfrQ==", null, false, "e030be4a-c6ed-46a5-9e86-4ad6db062ed6", "eca8a667-056e-4622-9ff6-88cd57ca4b44", false, "owner2@levara.com" },
                    { 3, 0, "c231efea-6e8c-40e5-ae33-f15bc5cfb2a0", "owner3@levara.com", true, false, null, "OWNER3@LEVARA.COM", "OWNER3@LEVARA.COM", "AQAAAAIAAYagAAAAEPeAV1996kkE+Il+HPFULI7rRDpVhoP89dglukaO/NrGgGDZi0dOyA4AT3rtnrzfrQ==", null, false, "e030be4a-c6ed-46a5-9e86-4ad6db062ed6", "eca8a667-056e-4622-9ff6-88cd57ca4b44", false, "owner3@levara.com" },
                    { 4, 0, "c231efea-6e8c-40e5-ae33-f15bc5cfb2a0", "owner4@levara.com", true, false, null, "OWNER4@LEVARA.COM", "OWNER4@LEVARA.COM", "AQAAAAIAAYagAAAAEPeAV1996kkE+Il+HPFULI7rRDpVhoP89dglukaO/NrGgGDZi0dOyA4AT3rtnrzfrQ==", null, false, "e030be4a-c6ed-46a5-9e86-4ad6db062ed6", "eca8a667-056e-4622-9ff6-88cd57ca4b44", false, "owner4@levara.com" },
                    { 5, 0, "c231efea-6e8c-40e5-ae33-f15bc5cfb2a0", "owner5@levara.com", true, false, null, "OWNER5@LEVARA.COM", "OWNER5@LEVARA.COM", "AQAAAAIAAYagAAAAEPeAV1996kkE+Il+HPFULI7rRDpVhoP89dglukaO/NrGgGDZi0dOyA4AT3rtnrzfrQ==", null, false, "e030be4a-c6ed-46a5-9e86-4ad6db062ed6", "eca8a667-056e-4622-9ff6-88cd57ca4b44", false, "owner5@levara.com" },
                    { 6, 0, "c231efea-6e8c-40e5-ae33-f15bc5cfb2a0", "owner6@levara.com", true, false, null, "OWNER6@LEVARA.COM", "OWNER6@LEVARA.COM", "AQAAAAIAAYagAAAAEPeAV1996kkE+Il+HPFULI7rRDpVhoP89dglukaO/NrGgGDZi0dOyA4AT3rtnrzfrQ==", null, false, "e030be4a-c6ed-46a5-9e86-4ad6db062ed6", "eca8a667-056e-4622-9ff6-88cd57ca4b44", false, "owner6@levara.com" },
                    { 7, 0, "c231efea-6e8c-40e5-ae33-f15bc5cfb2a0", "owner7@levara.com", true, false, null, "OWNER7@LEVARA.COM", "OWNER7@LEVARA.COM", "AQAAAAIAAYagAAAAEPeAV1996kkE+Il+HPFULI7rRDpVhoP89dglukaO/NrGgGDZi0dOyA4AT3rtnrzfrQ==", null, false, "e030be4a-c6ed-46a5-9e86-4ad6db062ed6", "eca8a667-056e-4622-9ff6-88cd57ca4b44", false, "owner7@levara.com" },
                    { 8, 0, "c231efea-6e8c-40e5-ae33-f15bc5cfb2a0", "owner8@levara.com", true, false, null, "OWNER8@LEVARA.COM", "OWNER8@LEVARA.COM", "AQAAAAIAAYagAAAAEPeAV1996kkE+Il+HPFULI7rRDpVhoP89dglukaO/NrGgGDZi0dOyA4AT3rtnrzfrQ==", null, false, "e030be4a-c6ed-46a5-9e86-4ad6db062ed6", "eca8a667-056e-4622-9ff6-88cd57ca4b44", false, "owner8@levara.com" },
                    { 9, 0, "c231efea-6e8c-40e5-ae33-f15bc5cfb2a0", "owner9@levara.com", true, false, null, "OWNER9@LEVARA.COM", "OWNER9@LEVARA.COM", "AQAAAAIAAYagAAAAEPeAV1996kkE+Il+HPFULI7rRDpVhoP89dglukaO/NrGgGDZi0dOyA4AT3rtnrzfrQ==", null, false, "e030be4a-c6ed-46a5-9e86-4ad6db062ed6", "eca8a667-056e-4622-9ff6-88cd57ca4b44", false, "owner9@levara.com" },
                    { 10, 0, "c231efea-6e8c-40e5-ae33-f15bc5cfb2a0", "owner10@levara.com", true, false, null, "OWNER10@LEVARA.COM", "OWNER10@LEVARA.COM", "AQAAAAIAAYagAAAAEPeAV1996kkE+Il+HPFULI7rRDpVhoP89dglukaO/NrGgGDZi0dOyA4AT3rtnrzfrQ==", null, false, "e030be4a-c6ed-46a5-9e86-4ad6db062ed6", "eca8a667-056e-4622-9ff6-88cd57ca4b44", false, "owner10@levara.com" },
                    { 51, 0, "c231efea-6e8c-40e5-ae33-f15bc5cfb2a0", "tenant1@levara.com", true, false, null, "TENANT1@LEVARA.COM", "TENANT1@LEVARA.COM", "AQAAAAIAAYagAAAAEPeAV1996kkE+Il+HPFULI7rRDpVhoP89dglukaO/NrGgGDZi0dOyA4AT3rtnrzfrQ==", null, false, "e030be4a-c6ed-46a5-9e86-4ad6db062ed6", "eca8a667-056e-4622-9ff6-88cd57ca4b44", false, "tenant1@levara.com" },
                    { 52, 0, "c231efea-6e8c-40e5-ae33-f15bc5cfb2a0", "tenant2@levara.com", true, false, null, "TENANT2@LEVARA.COM", "TENANT2@LEVARA.COM", "AQAAAAIAAYagAAAAEPeAV1996kkE+Il+HPFULI7rRDpVhoP89dglukaO/NrGgGDZi0dOyA4AT3rtnrzfrQ==", null, false, "e030be4a-c6ed-46a5-9e86-4ad6db062ed6", "eca8a667-056e-4622-9ff6-88cd57ca4b44", false, "tenant2@levara.com" },
                    { 53, 0, "c231efea-6e8c-40e5-ae33-f15bc5cfb2a0", "tenant3@levara.com", true, false, null, "TENANT3@LEVARA.COM", "TENANT3@LEVARA.COM", "AQAAAAIAAYagAAAAEPeAV1996kkE+Il+HPFULI7rRDpVhoP89dglukaO/NrGgGDZi0dOyA4AT3rtnrzfrQ==", null, false, "e030be4a-c6ed-46a5-9e86-4ad6db062ed6", "eca8a667-056e-4622-9ff6-88cd57ca4b44", false, "tenant3@levara.com" },
                    { 54, 0, "c231efea-6e8c-40e5-ae33-f15bc5cfb2a0", "tenant4@levara.com", true, false, null, "TENANT4@LEVARA.COM", "TENANT4@LEVARA.COM", "AQAAAAIAAYagAAAAEPeAV1996kkE+Il+HPFULI7rRDpVhoP89dglukaO/NrGgGDZi0dOyA4AT3rtnrzfrQ==", null, false, "e030be4a-c6ed-46a5-9e86-4ad6db062ed6", "eca8a667-056e-4622-9ff6-88cd57ca4b44", false, "tenant4@levara.com" },
                    { 55, 0, "c231efea-6e8c-40e5-ae33-f15bc5cfb2a0", "tenant5@levara.com", true, false, null, "TENANT5@LEVARA.COM", "TENANT5@LEVARA.COM", "AQAAAAIAAYagAAAAEPeAV1996kkE+Il+HPFULI7rRDpVhoP89dglukaO/NrGgGDZi0dOyA4AT3rtnrzfrQ==", null, false, "e030be4a-c6ed-46a5-9e86-4ad6db062ed6", "eca8a667-056e-4622-9ff6-88cd57ca4b44", false, "tenant5@levara.com" },
                    { 56, 0, "c231efea-6e8c-40e5-ae33-f15bc5cfb2a0", "tenant6@levara.com", true, false, null, "TENANT6@LEVARA.COM", "TENANT6@LEVARA.COM", "AQAAAAIAAYagAAAAEPeAV1996kkE+Il+HPFULI7rRDpVhoP89dglukaO/NrGgGDZi0dOyA4AT3rtnrzfrQ==", null, false, "e030be4a-c6ed-46a5-9e86-4ad6db062ed6", "eca8a667-056e-4622-9ff6-88cd57ca4b44", false, "tenant6@levara.com" },
                    { 57, 0, "c231efea-6e8c-40e5-ae33-f15bc5cfb2a0", "tenant7@levara.com", true, false, null, "TENANT7@LEVARA.COM", "TENANT7@LEVARA.COM", "AQAAAAIAAYagAAAAEPeAV1996kkE+Il+HPFULI7rRDpVhoP89dglukaO/NrGgGDZi0dOyA4AT3rtnrzfrQ==", null, false, "e030be4a-c6ed-46a5-9e86-4ad6db062ed6", "eca8a667-056e-4622-9ff6-88cd57ca4b44", false, "tenant7@levara.com" },
                    { 58, 0, "c231efea-6e8c-40e5-ae33-f15bc5cfb2a0", "tenant8@levara.com", true, false, null, "TENANT8@LEVARA.COM", "TENANT8@LEVARA.COM", "AQAAAAIAAYagAAAAEPeAV1996kkE+Il+HPFULI7rRDpVhoP89dglukaO/NrGgGDZi0dOyA4AT3rtnrzfrQ==", null, false, "e030be4a-c6ed-46a5-9e86-4ad6db062ed6", "eca8a667-056e-4622-9ff6-88cd57ca4b44", false, "tenant8@levara.com" },
                    { 59, 0, "c231efea-6e8c-40e5-ae33-f15bc5cfb2a0", "tenant9@levara.com", true, false, null, "TENANT9@LEVARA.COM", "TENANT9@LEVARA.COM", "AQAAAAIAAYagAAAAEPeAV1996kkE+Il+HPFULI7rRDpVhoP89dglukaO/NrGgGDZi0dOyA4AT3rtnrzfrQ==", null, false, "e030be4a-c6ed-46a5-9e86-4ad6db062ed6", "eca8a667-056e-4622-9ff6-88cd57ca4b44", false, "tenant9@levara.com" },
                    { 60, 0, "c231efea-6e8c-40e5-ae33-f15bc5cfb2a0", "tenant10@levara.com", true, false, null, "TENANT10@LEVARA.COM", "TENANT10@LEVARA.COM", "AQAAAAIAAYagAAAAEPeAV1996kkE+Il+HPFULI7rRDpVhoP89dglukaO/NrGgGDZi0dOyA4AT3rtnrzfrQ==", null, false, "e030be4a-c6ed-46a5-9e86-4ad6db062ed6", "eca8a667-056e-4622-9ff6-88cd57ca4b44", false, "tenant10@levara.com" },
                    { 100, 0, "c231efea-6e8c-40e5-ae33-f15bc5cfb2a0", "admin@levara.com", true, false, null, "ADMIN@LEVARA.COM", "ADMIN@LEVARA.COM", "AQAAAAIAAYagAAAAEPeAV1996kkE+Il+HPFULI7rRDpVhoP89dglukaO/NrGgGDZi0dOyA4AT3rtnrzfrQ==", null, false, "e030be4a-c6ed-46a5-9e86-4ad6db062ed6", "eca8a667-056e-4622-9ff6-88cd57ca4b44", false, "admin@levara.com" }
                });

            migrationBuilder.InsertData(
                table: "Expense",
                columns: new[] { "Id", "CreatedDate", "CreatorId", "Deleted", "Description", "LastEditedDate", "LastEditorId", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Cleaning service", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cleaning" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Gardening Service", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gardening" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Security Service", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Security" }
                });

            migrationBuilder.InsertData(
                table: "MaintenanceTypes",
                columns: new[] { "Id", "CreatedDate", "CreatorId", "Deleted", "Description", "LastEditedDate", "LastEditorId", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Plumber Service", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Plumber" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Electrician Service", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Electrician" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Other Service", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OtherService" }
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
                table: "Notifications",
                columns: new[] { "Id", "ClickedAt", "CreatedDate", "CreatorId", "Data", "Deleted", "LastEditedDate", "LastEditorId", "Link", "ReceiverId", "ShownAt", "Type" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 1", ["Date"] = new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 1, null, 2 },
                    { 2, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 1", ["DueDate"] = new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 1, null, 1 },
                    { 3, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 2", ["Date"] = new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 1, null, 2 },
                    { 4, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 2", ["DueDate"] = new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 1, null, 1 },
                    { 5, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 3", ["Date"] = new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 1, null, 2 },
                    { 6, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 3", ["DueDate"] = new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 1, null, 1 },
                    { 7, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 4", ["Date"] = new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 1, null, 2 },
                    { 8, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 4", ["DueDate"] = new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 1, null, 1 },
                    { 9, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 5", ["Date"] = new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 1, null, 2 },
                    { 10, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 5", ["DueDate"] = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 1, null, 1 },
                    { 11, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 6", ["Date"] = new DateTime(2023, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 1, null, 2 },
                    { 12, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 6", ["DueDate"] = new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 1, null, 1 },
                    { 13, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 7", ["Date"] = new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 1, null, 2 },
                    { 14, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 7", ["DueDate"] = new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 1, null, 1 },
                    { 15, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 8", ["Date"] = new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 1, null, 2 },
                    { 16, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 8", ["DueDate"] = new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 1, null, 1 },
                    { 17, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 9", ["Date"] = new DateTime(2023, 12, 23, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 1, null, 2 },
                    { 18, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 9", ["DueDate"] = new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 1, null, 1 },
                    { 19, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 10", ["Date"] = new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 1, null, 2 },
                    { 20, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 10", ["DueDate"] = new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 1, null, 1 },
                    { 21, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 1", ["Date"] = new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 2, null, 2 },
                    { 22, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 1", ["DueDate"] = new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 2, null, 1 },
                    { 23, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 2", ["Date"] = new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 2, null, 2 },
                    { 24, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 2", ["DueDate"] = new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 2, null, 1 },
                    { 25, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 3", ["Date"] = new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 2, null, 2 },
                    { 26, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 3", ["DueDate"] = new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 2, null, 1 },
                    { 27, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 4", ["Date"] = new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 2, null, 2 },
                    { 28, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 4", ["DueDate"] = new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 2, null, 1 },
                    { 29, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 5", ["Date"] = new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 2, null, 2 },
                    { 30, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 5", ["DueDate"] = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 2, null, 1 },
                    { 31, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 6", ["Date"] = new DateTime(2023, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 2, null, 2 },
                    { 32, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 6", ["DueDate"] = new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 2, null, 1 },
                    { 33, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 7", ["Date"] = new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 2, null, 2 },
                    { 34, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 7", ["DueDate"] = new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 2, null, 1 },
                    { 35, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 8", ["Date"] = new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 2, null, 2 },
                    { 36, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 8", ["DueDate"] = new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 2, null, 1 },
                    { 37, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 9", ["Date"] = new DateTime(2023, 12, 23, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 2, null, 2 },
                    { 38, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 9", ["DueDate"] = new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 2, null, 1 },
                    { 39, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 10", ["Date"] = new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 2, null, 2 },
                    { 40, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 10", ["DueDate"] = new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 2, null, 1 },
                    { 41, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 1", ["Date"] = new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 3, null, 2 },
                    { 42, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 1", ["DueDate"] = new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 3, null, 1 },
                    { 43, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 2", ["Date"] = new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 3, null, 2 },
                    { 44, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 2", ["DueDate"] = new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 3, null, 1 },
                    { 45, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 3", ["Date"] = new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 3, null, 2 },
                    { 46, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 3", ["DueDate"] = new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 3, null, 1 },
                    { 47, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 4", ["Date"] = new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 3, null, 2 },
                    { 48, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 4", ["DueDate"] = new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 3, null, 1 },
                    { 49, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 5", ["Date"] = new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 3, null, 2 },
                    { 50, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 5", ["DueDate"] = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 3, null, 1 },
                    { 51, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 6", ["Date"] = new DateTime(2023, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 3, null, 2 },
                    { 52, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 6", ["DueDate"] = new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 3, null, 1 },
                    { 53, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 7", ["Date"] = new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 3, null, 2 },
                    { 54, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 7", ["DueDate"] = new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 3, null, 1 },
                    { 55, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 8", ["Date"] = new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 3, null, 2 },
                    { 56, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 8", ["DueDate"] = new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 3, null, 1 },
                    { 57, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 9", ["Date"] = new DateTime(2023, 12, 23, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 3, null, 2 },
                    { 58, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 9", ["DueDate"] = new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 3, null, 1 },
                    { 59, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 10", ["Date"] = new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 3, null, 2 },
                    { 60, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 10", ["DueDate"] = new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 3, null, 1 },
                    { 61, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 1", ["Date"] = new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 4, null, 2 },
                    { 62, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 1", ["DueDate"] = new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 4, null, 1 },
                    { 63, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 2", ["Date"] = new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 4, null, 2 },
                    { 64, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 2", ["DueDate"] = new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 4, null, 1 },
                    { 65, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 3", ["Date"] = new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 4, null, 2 },
                    { 66, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 3", ["DueDate"] = new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 4, null, 1 },
                    { 67, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 4", ["Date"] = new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 4, null, 2 },
                    { 68, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 4", ["DueDate"] = new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 4, null, 1 },
                    { 69, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 5", ["Date"] = new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 4, null, 2 },
                    { 70, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 5", ["DueDate"] = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 4, null, 1 },
                    { 71, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 6", ["Date"] = new DateTime(2023, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 4, null, 2 },
                    { 72, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 6", ["DueDate"] = new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 4, null, 1 },
                    { 73, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 7", ["Date"] = new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 4, null, 2 },
                    { 74, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 7", ["DueDate"] = new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 4, null, 1 },
                    { 75, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 8", ["Date"] = new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 4, null, 2 },
                    { 76, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 8", ["DueDate"] = new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 4, null, 1 },
                    { 77, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 9", ["Date"] = new DateTime(2023, 12, 23, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 4, null, 2 },
                    { 78, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 9", ["DueDate"] = new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 4, null, 1 },
                    { 79, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 10", ["Date"] = new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 4, null, 2 },
                    { 80, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 10", ["DueDate"] = new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 4, null, 1 },
                    { 81, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 1", ["Date"] = new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 5, null, 2 },
                    { 82, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 1", ["DueDate"] = new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 5, null, 1 },
                    { 83, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 2", ["Date"] = new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 5, null, 2 },
                    { 84, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 2", ["DueDate"] = new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 5, null, 1 },
                    { 85, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 3", ["Date"] = new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 5, null, 2 },
                    { 86, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 3", ["DueDate"] = new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 5, null, 1 },
                    { 87, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 4", ["Date"] = new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 5, null, 2 },
                    { 88, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 4", ["DueDate"] = new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 5, null, 1 },
                    { 89, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 5", ["Date"] = new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 5, null, 2 },
                    { 90, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 5", ["DueDate"] = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 5, null, 1 },
                    { 91, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 6", ["Date"] = new DateTime(2023, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 5, null, 2 },
                    { 92, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 6", ["DueDate"] = new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 5, null, 1 },
                    { 93, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 7", ["Date"] = new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 5, null, 2 },
                    { 94, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 7", ["DueDate"] = new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 5, null, 1 },
                    { 95, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 8", ["Date"] = new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 5, null, 2 },
                    { 96, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 8", ["DueDate"] = new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 5, null, 1 },
                    { 97, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 9", ["Date"] = new DateTime(2023, 12, 23, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 5, null, 2 },
                    { 98, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 9", ["DueDate"] = new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 5, null, 1 },
                    { 99, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 10", ["Date"] = new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 5, null, 2 },
                    { 100, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 10", ["DueDate"] = new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 5, null, 1 },
                    { 101, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 1", ["Date"] = new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 6, null, 2 },
                    { 102, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 1", ["DueDate"] = new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 6, null, 1 },
                    { 103, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 2", ["Date"] = new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 6, null, 2 },
                    { 104, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 2", ["DueDate"] = new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 6, null, 1 },
                    { 105, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 3", ["Date"] = new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 6, null, 2 },
                    { 106, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 3", ["DueDate"] = new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 6, null, 1 },
                    { 107, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 4", ["Date"] = new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 6, null, 2 },
                    { 108, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 4", ["DueDate"] = new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 6, null, 1 },
                    { 109, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 5", ["Date"] = new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 6, null, 2 },
                    { 110, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 5", ["DueDate"] = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 6, null, 1 },
                    { 111, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 6", ["Date"] = new DateTime(2023, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 6, null, 2 },
                    { 112, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 6", ["DueDate"] = new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 6, null, 1 },
                    { 113, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 7", ["Date"] = new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 6, null, 2 },
                    { 114, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 7", ["DueDate"] = new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 6, null, 1 },
                    { 115, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 8", ["Date"] = new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 6, null, 2 },
                    { 116, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 8", ["DueDate"] = new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 6, null, 1 },
                    { 117, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 9", ["Date"] = new DateTime(2023, 12, 23, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 6, null, 2 },
                    { 118, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 9", ["DueDate"] = new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 6, null, 1 },
                    { 119, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 10", ["Date"] = new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 6, null, 2 },
                    { 120, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 10", ["DueDate"] = new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 6, null, 1 },
                    { 121, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 1", ["Date"] = new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 7, null, 2 },
                    { 122, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 1", ["DueDate"] = new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 7, null, 1 },
                    { 123, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 2", ["Date"] = new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 7, null, 2 },
                    { 124, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 2", ["DueDate"] = new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 7, null, 1 },
                    { 125, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 3", ["Date"] = new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 7, null, 2 },
                    { 126, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 3", ["DueDate"] = new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 7, null, 1 },
                    { 127, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 4", ["Date"] = new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 7, null, 2 },
                    { 128, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 4", ["DueDate"] = new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 7, null, 1 },
                    { 129, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 5", ["Date"] = new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 7, null, 2 },
                    { 130, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 5", ["DueDate"] = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 7, null, 1 },
                    { 131, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 6", ["Date"] = new DateTime(2023, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 7, null, 2 },
                    { 132, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 6", ["DueDate"] = new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 7, null, 1 },
                    { 133, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 7", ["Date"] = new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 7, null, 2 },
                    { 134, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 7", ["DueDate"] = new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 7, null, 1 },
                    { 135, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 8", ["Date"] = new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 7, null, 2 },
                    { 136, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 8", ["DueDate"] = new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 7, null, 1 },
                    { 137, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 9", ["Date"] = new DateTime(2023, 12, 23, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 7, null, 2 },
                    { 138, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 9", ["DueDate"] = new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 7, null, 1 },
                    { 139, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 10", ["Date"] = new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 7, null, 2 },
                    { 140, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 10", ["DueDate"] = new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 7, null, 1 },
                    { 141, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 1", ["Date"] = new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 8, null, 2 },
                    { 142, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 1", ["DueDate"] = new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 8, null, 1 },
                    { 143, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 2", ["Date"] = new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 8, null, 2 },
                    { 144, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 2", ["DueDate"] = new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 8, null, 1 },
                    { 145, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 3", ["Date"] = new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 8, null, 2 },
                    { 146, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 3", ["DueDate"] = new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 8, null, 1 },
                    { 147, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 4", ["Date"] = new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 8, null, 2 },
                    { 148, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 4", ["DueDate"] = new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 8, null, 1 },
                    { 149, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 5", ["Date"] = new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 8, null, 2 },
                    { 150, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 5", ["DueDate"] = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 8, null, 1 },
                    { 151, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 6", ["Date"] = new DateTime(2023, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 8, null, 2 },
                    { 152, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 6", ["DueDate"] = new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 8, null, 1 },
                    { 153, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 7", ["Date"] = new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 8, null, 2 },
                    { 154, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 7", ["DueDate"] = new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 8, null, 1 },
                    { 155, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 8", ["Date"] = new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 8, null, 2 },
                    { 156, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 8", ["DueDate"] = new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 8, null, 1 },
                    { 157, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 9", ["Date"] = new DateTime(2023, 12, 23, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 8, null, 2 },
                    { 158, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 9", ["DueDate"] = new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 8, null, 1 },
                    { 159, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 10", ["Date"] = new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 8, null, 2 },
                    { 160, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 10", ["DueDate"] = new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 8, null, 1 },
                    { 161, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 1", ["Date"] = new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 9, null, 2 },
                    { 162, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 1", ["DueDate"] = new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 9, null, 1 },
                    { 163, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 2", ["Date"] = new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 9, null, 2 },
                    { 164, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 2", ["DueDate"] = new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 9, null, 1 },
                    { 165, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 3", ["Date"] = new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 9, null, 2 },
                    { 166, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 3", ["DueDate"] = new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 9, null, 1 },
                    { 167, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 4", ["Date"] = new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 9, null, 2 },
                    { 168, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 4", ["DueDate"] = new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 9, null, 1 },
                    { 169, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 5", ["Date"] = new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 9, null, 2 },
                    { 170, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 5", ["DueDate"] = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 9, null, 1 },
                    { 171, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 6", ["Date"] = new DateTime(2023, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 9, null, 2 },
                    { 172, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 6", ["DueDate"] = new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 9, null, 1 },
                    { 173, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 7", ["Date"] = new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 9, null, 2 },
                    { 174, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 7", ["DueDate"] = new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 9, null, 1 },
                    { 175, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 8", ["Date"] = new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 9, null, 2 },
                    { 176, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 8", ["DueDate"] = new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 9, null, 1 },
                    { 177, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 9", ["Date"] = new DateTime(2023, 12, 23, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 9, null, 2 },
                    { 178, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 9", ["DueDate"] = new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 9, null, 1 },
                    { 179, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 10", ["Date"] = new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 9, null, 2 },
                    { 180, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 10", ["DueDate"] = new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 9, null, 1 },
                    { 181, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 1", ["Date"] = new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 10, null, 2 },
                    { 182, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 1", ["DueDate"] = new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 10, null, 1 },
                    { 183, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 2", ["Date"] = new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 10, null, 2 },
                    { 184, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 2", ["DueDate"] = new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 10, null, 1 },
                    { 185, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 3", ["Date"] = new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 10, null, 2 },
                    { 186, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 3", ["DueDate"] = new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 10, null, 1 },
                    { 187, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 4", ["Date"] = new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 10, null, 2 },
                    { 188, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 4", ["DueDate"] = new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 10, null, 1 },
                    { 189, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 5", ["Date"] = new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 10, null, 2 },
                    { 190, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 5", ["DueDate"] = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 10, null, 1 },
                    { 191, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 6", ["Date"] = new DateTime(2023, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 10, null, 2 },
                    { 192, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 6", ["DueDate"] = new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 10, null, 1 },
                    { 193, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 7", ["Date"] = new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 10, null, 2 },
                    { 194, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 7", ["DueDate"] = new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 10, null, 1 },
                    { 195, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 8", ["Date"] = new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 10, null, 2 },
                    { 196, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 8", ["DueDate"] = new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 10, null, 1 },
                    { 197, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 9", ["Date"] = new DateTime(2023, 12, 23, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "General maintenance scheduled" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 10, null, 2 },
                    { 198, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 9", ["DueDate"] = new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Paid" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 10, null, 1 },
                    { 199, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 10", ["Date"] = new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Utc), ["Detail"] = "End date to renewal" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 10, null, 2 },
                    { 200, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new Dictionary<string, object> { ["Property"] = "Property 10", ["DueDate"] = new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), ["Status"] = "Overdue" }, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/owner", 10, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "AddressId", "ApplicationUserId", "CompanyName", "CreatedDate", "CreatorId", "Deleted", "Email", "Identification", "IdentificationType", "LastEditedDate", "LastEditorId", "MobilePhone", "Name", "PersonType", "Surname" },
                values: new object[,]
                {
                    { 1, 1, 1, "owner1", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, "owner1@levara.com", "50000001", 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "+14844760170", "owner1", 1, "owner1" },
                    { 2, 2, 2, "owner2", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, "owner2@levara.com", "50000002", 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "+14844760170", "owner2", 1, "owner2" },
                    { 3, 3, 3, "owner3", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, "owner3@levara.com", "50000003", 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "+14844760170", "owner3", 1, "owner3" },
                    { 4, 4, 4, "owner4", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, "owner4@levara.com", "50000004", 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "+14844760170", "owner4", 1, "owner4" },
                    { 5, 5, 5, "owner5", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, "owner5@levara.com", "50000005", 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "+14844760170", "owner5", 1, "owner5" },
                    { 6, 6, 6, "owner6", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, "owner6@levara.com", "50000006", 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "+14844760170", "owner6", 1, "owner6" },
                    { 7, 7, 7, "owner7", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, "owner7@levara.com", "50000007", 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "+14844760170", "owner7", 1, "owner7" },
                    { 8, 8, 8, "owner8", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, "owner8@levara.com", "50000008", 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "+14844760170", "owner8", 1, "owner8" },
                    { 9, 9, 9, "owner9", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, "owner9@levara.com", "50000009", 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "+14844760170", "owner9", 1, "owner9" },
                    { 10, 10, 10, "owner10", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, "owner10@levara.com", "50000010", 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "+14844760170", "owner10", 1, "owner10" }
                });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "Id", "AddressId", "ApplicationUserId", "CompanyName", "CreatedDate", "CreatorId", "Deleted", "Email", "Identification", "IdentificationType", "LastEditedDate", "LastEditorId", "MobilePhone", "Name", "PersonType", "Surname" },
                values: new object[,]
                {
                    { 1, 501, 51, "tenant1", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, "tenant1@levara.com", "60000001", 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "+14844760170", "tenant1", 1, "tenant1" },
                    { 2, 502, 52, "tenant2", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, "tenant2@levara.com", "60000002", 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "+14844760170", "tenant2", 1, "tenant2" },
                    { 3, 503, 53, "tenant3", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, "tenant3@levara.com", "60000003", 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "+14844760170", "tenant3", 1, "tenant3" },
                    { 4, 504, 54, "tenant4", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, "tenant4@levara.com", "60000004", 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "+14844760170", "tenant4", 1, "tenant4" },
                    { 5, 505, 55, "tenant5", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, "tenant5@levara.com", "60000005", 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "+14844760170", "tenant5", 1, "tenant5" },
                    { 6, 506, 56, "tenant6", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, "tenant6@levara.com", "60000006", 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "+14844760170", "tenant6", 1, "tenant6" },
                    { 7, 507, 57, "tenant7", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, "tenant7@levara.com", "60000007", 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "+14844760170", "tenant7", 1, "tenant7" },
                    { 8, 508, 58, "tenant8", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, "tenant8@levara.com", "60000008", 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "+14844760170", "tenant8", 1, "tenant8" },
                    { 9, 509, 59, "tenant9", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, "tenant9@levara.com", "60000009", 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "+14844760170", "tenant9", 1, "tenant9" },
                    { 10, 510, 60, "tenant10", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, "tenant10@levara.com", "60000010", 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "+14844760170", "tenant10", 1, "tenant10" }
                });

            migrationBuilder.InsertData(
                table: "OwnerBankAccounts",
                columns: new[] { "Id", "AccountNumberMasked", "BankName", "CreatedDate", "CreatorId", "Deleted", "LastEditedDate", "LastEditorId", "LastSyncId", "OwnerId", "PlaidAccountId" },
                values: new object[,]
                {
                    { 1, "****1234", "Chase", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, null, 1, "account-abc123" },
                    { 2, "****1235", "Chase", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, null, 2, "account-abc124" },
                    { 3, "****1236", "Chase", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, null, 3, "account-abc125" },
                    { 4, "****1237", "Chase", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, null, 4, "account-abc126" },
                    { 5, "****1238", "Chase", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, null, 5, "account-abc127" },
                    { 6, "****1239", "Chase", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, null, 6, "account-abc128" },
                    { 7, "****1240", "Chase", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, null, 7, "account-abc129" },
                    { 8, "****1241", "Chase", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, null, 8, "account-abc130" },
                    { 9, "****1242", "Chase", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, null, 9, "account-abc131" },
                    { 10, "****1243", "Chase", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, null, 10, "account-abc132" }
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "AddressId", "AreaQuantity", "AvaliableFrom", "BathroomQuantity", "CreatedDate", "CreatorId", "Deleted", "DetailDepositAndAdittionalInfo", "HasBalcony", "HasGarage", "HasPool", "Img", "LastEditedDate", "LastEditorId", "Number", "OwnerId", "PetsPoliticAndRate", "Price", "RoomsQuantity", "TenantRequirements" },
                values: new object[,]
                {
                    { 1, 11, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 1, null, 100000m, null, null },
                    { 2, 12, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 2, 1, null, 200000m, null, null },
                    { 3, 13, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 3, 1, null, 300000m, null, null },
                    { 4, 14, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 4, 1, null, 400000m, null, null },
                    { 5, 15, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 5, 1, null, 500000m, null, null },
                    { 6, 16, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 6, 1, null, 600000m, null, null },
                    { 7, 17, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 7, 1, null, 700000m, null, null },
                    { 8, 18, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 8, 1, null, 800000m, null, null },
                    { 9, 19, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 9, 1, null, 900000m, null, null },
                    { 10, 20, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 10, 1, null, 1000000m, null, null },
                    { 11, 21, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 2, null, 100000m, null, null },
                    { 12, 22, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 2, 2, null, 200000m, null, null },
                    { 13, 23, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 3, 2, null, 300000m, null, null },
                    { 14, 24, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 4, 2, null, 400000m, null, null },
                    { 15, 25, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 5, 2, null, 500000m, null, null },
                    { 16, 26, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 6, 2, null, 600000m, null, null },
                    { 17, 27, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 7, 2, null, 700000m, null, null },
                    { 18, 28, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 8, 2, null, 800000m, null, null },
                    { 19, 29, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 9, 2, null, 900000m, null, null },
                    { 20, 30, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 10, 2, null, 1000000m, null, null },
                    { 21, 31, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 3, null, 100000m, null, null },
                    { 22, 32, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 2, 3, null, 200000m, null, null },
                    { 23, 33, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 3, 3, null, 300000m, null, null },
                    { 24, 34, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 4, 3, null, 400000m, null, null },
                    { 25, 35, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 5, 3, null, 500000m, null, null },
                    { 26, 36, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 6, 3, null, 600000m, null, null },
                    { 27, 37, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 7, 3, null, 700000m, null, null },
                    { 28, 38, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 8, 3, null, 800000m, null, null },
                    { 29, 39, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 9, 3, null, 900000m, null, null },
                    { 30, 40, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 10, 3, null, 1000000m, null, null },
                    { 31, 41, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 4, null, 100000m, null, null },
                    { 32, 42, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 2, 4, null, 200000m, null, null },
                    { 33, 43, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 3, 4, null, 300000m, null, null },
                    { 34, 44, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 4, 4, null, 400000m, null, null },
                    { 35, 45, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 5, 4, null, 500000m, null, null },
                    { 36, 46, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 6, 4, null, 600000m, null, null },
                    { 37, 47, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 7, 4, null, 700000m, null, null },
                    { 38, 48, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 8, 4, null, 800000m, null, null },
                    { 39, 49, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 9, 4, null, 900000m, null, null },
                    { 40, 50, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 10, 4, null, 1000000m, null, null },
                    { 41, 51, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 5, null, 100000m, null, null },
                    { 42, 52, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 2, 5, null, 200000m, null, null },
                    { 43, 53, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 3, 5, null, 300000m, null, null },
                    { 44, 54, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 4, 5, null, 400000m, null, null },
                    { 45, 55, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 5, 5, null, 500000m, null, null },
                    { 46, 56, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 6, 5, null, 600000m, null, null },
                    { 47, 57, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 7, 5, null, 700000m, null, null },
                    { 48, 58, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 8, 5, null, 800000m, null, null },
                    { 49, 59, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 9, 5, null, 900000m, null, null },
                    { 50, 60, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 10, 5, null, 1000000m, null, null },
                    { 51, 61, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 6, null, 100000m, null, null },
                    { 52, 62, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 2, 6, null, 200000m, null, null },
                    { 53, 63, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 3, 6, null, 300000m, null, null },
                    { 54, 64, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 4, 6, null, 400000m, null, null },
                    { 55, 65, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 5, 6, null, 500000m, null, null },
                    { 56, 66, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 6, 6, null, 600000m, null, null },
                    { 57, 67, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 7, 6, null, 700000m, null, null },
                    { 58, 68, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 8, 6, null, 800000m, null, null },
                    { 59, 69, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 9, 6, null, 900000m, null, null },
                    { 60, 70, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 10, 6, null, 1000000m, null, null },
                    { 61, 71, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 7, null, 100000m, null, null },
                    { 62, 72, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 2, 7, null, 200000m, null, null },
                    { 63, 73, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 3, 7, null, 300000m, null, null },
                    { 64, 74, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 4, 7, null, 400000m, null, null },
                    { 65, 75, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 5, 7, null, 500000m, null, null },
                    { 66, 76, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 6, 7, null, 600000m, null, null },
                    { 67, 77, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 7, 7, null, 700000m, null, null },
                    { 68, 78, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 8, 7, null, 800000m, null, null },
                    { 69, 79, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 9, 7, null, 900000m, null, null },
                    { 70, 80, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 10, 7, null, 1000000m, null, null },
                    { 71, 81, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 8, null, 100000m, null, null },
                    { 72, 82, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 2, 8, null, 200000m, null, null },
                    { 73, 83, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 3, 8, null, 300000m, null, null },
                    { 74, 84, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 4, 8, null, 400000m, null, null },
                    { 75, 85, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 5, 8, null, 500000m, null, null },
                    { 76, 86, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 6, 8, null, 600000m, null, null },
                    { 77, 87, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 7, 8, null, 700000m, null, null },
                    { 78, 88, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 8, 8, null, 800000m, null, null },
                    { 79, 89, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 9, 8, null, 900000m, null, null },
                    { 80, 90, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 10, 8, null, 1000000m, null, null },
                    { 81, 91, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 9, null, 100000m, null, null },
                    { 82, 92, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 2, 9, null, 200000m, null, null },
                    { 83, 93, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 3, 9, null, 300000m, null, null },
                    { 84, 94, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 4, 9, null, 400000m, null, null },
                    { 85, 95, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 5, 9, null, 500000m, null, null },
                    { 86, 96, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 6, 9, null, 600000m, null, null },
                    { 87, 97, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 7, 9, null, 700000m, null, null },
                    { 88, 98, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 8, 9, null, 800000m, null, null },
                    { 89, 99, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 9, 9, null, 900000m, null, null },
                    { 90, 100, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 10, 9, null, 1000000m, null, null },
                    { 91, 101, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 10, null, 100000m, null, null },
                    { 92, 102, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 2, 10, null, 200000m, null, null },
                    { 93, 103, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 3, 10, null, 300000m, null, null },
                    { 94, 104, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 4, 10, null, 400000m, null, null },
                    { 95, 105, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 5, 10, null, 500000m, null, null },
                    { 96, 106, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 6, 10, null, 600000m, null, null },
                    { 97, 107, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 7, 10, null, 700000m, null, null },
                    { 98, 108, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 8, 10, null, 800000m, null, null },
                    { 99, 109, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 9, 10, null, 900000m, null, null },
                    { 100, 110, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, null, null, null, null, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 10, 10, null, 1000000m, null, null }
                });

            migrationBuilder.InsertData(
                table: "Leases",
                columns: new[] { "Id", "Amount", "CreatedDate", "CreatorId", "DateFrom", "DateTo", "Deleted", "Frequency", "LastEditedDate", "LastEditorId", "OwnerId", "PropertyId", "StatusLease", "TenantId" },
                values: new object[,]
                {
                    { 1, 1100m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 1, null, 1 },
                    { 2, 1200m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 2, 2, null, 2 },
                    { 3, 1300m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 12, 3, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 3, 3, null, 3 },
                    { 4, 1400m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 12, 4, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 4, 4, null, 4 },
                    { 5, 1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 5, 5, null, 5 },
                    { 6, 1600m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 6, 6, null, 6 },
                    { 7, 1700m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 12, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 7, 7, null, 7 },
                    { 8, 1800m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 8, 8, null, 8 },
                    { 9, 1900m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 12, 9, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 9, 9, null, 9 },
                    { 10, 2000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 12, 10, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 10, 10, null, 10 }
                });

            migrationBuilder.InsertData(
                table: "Maintenances",
                columns: new[] { "Id", "CreatedDate", "CreatorId", "Deleted", "Description", "DueDate", "LastEditedDate", "LastEditorId", "PropertyId", "Status", "Title", "TypeId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, "Plumber Service in Property 1", new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 3, "Plumber Service", 1 },
                    { 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, "Plumber Service in Property 1", new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 3, "Plumber Service", 1 },
                    { 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, "Plumber Service in Property 1", new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 3, "Plumber Service", 1 },
                    { 4, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, "Plumber Service in Property 1", new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 3, "Plumber Service", 1 },
                    { 5, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, "Plumber Service in Property 1", new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 3, "Plumber Service", 1 },
                    { 6, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, "Plumber Service in Property 1", new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 3, "Plumber Service", 1 },
                    { 7, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, "Plumber Service in Property 1", new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 3, "Plumber Service", 1 },
                    { 8, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, "Plumber Service in Property 1", new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 3, "Plumber Service", 1 },
                    { 9, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, "Plumber Service in Property 1", new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 3, "Plumber Service", 1 },
                    { 10, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, "Plumber Service in Property 1", new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 3, "Plumber Service", 1 },
                    { 11, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, "Plumber Service in Property 1", new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 3, "Plumber Service", 1 },
                    { 12, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, "Plumber Service in Property 1", new DateTime(2024, 12, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 3, "Plumber Service", 1 }
                });

            migrationBuilder.InsertData(
                table: "PlaidTransaction",
                columns: new[] { "Id", "Amount", "CreatedDate", "CreatorId", "Date", "Deleted", "Description", "LastEditedDate", "LastEditorId", "OwnerBankAccountId", "Status", "TransactionId" },
                values: new object[,]
                {
                    { 1, -5.4000000000000004, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Uber 063015 SF**POOL**", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "f23b7228-7cbf-4c8a-a88b-617f9e03067f" },
                    { 2, 1500.0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 1, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "Payment rent 1/1/2024", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "0e9d91e4-2577-43eb-b4d9-a6cc5c4717c4" },
                    { 3, -800.0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 1, 11, 0, 0, 0, 0, DateTimeKind.Utc), false, "Payment maintenance charge 2/1/2024", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "4be96d3a-639c-4ba1-8f7c-ae870acccbcc" },
                    { 4, -150.0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), false, "Payment cleaning charge 3/1/2024", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "ac4d455f-5ffa-4432-a92b-e182d3231084" },
                    { 5, -5.4000000000000004, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Uber 063025 SF**POOL**", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "2b9c6270-2c42-408f-a076-e375f28df0ba" },
                    { 6, 1500.0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "Payment rent 1/2/2024", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "0b18fa02-0c67-46da-8939-aa0b835c2a12" },
                    { 7, -800.0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 2, 11, 0, 0, 0, 0, DateTimeKind.Utc), false, "Payment maintenance charge 2/2/2024", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "3c5240c7-21d7-47e9-8682-4ecce51b1ba4" },
                    { 8, -150.0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Utc), false, "Payment cleaning charge 3/2/2024", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "9617b40d-87ad-408b-bd47-83200a80d3fc" },
                    { 9, -5.4000000000000004, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 3, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Uber 063035 SF**POOL**", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "84839ef1-af4e-45ba-9a05-30e72d538a04" },
                    { 10, 1500.0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 3, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "Payment rent 1/3/2024", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "279af335-522f-4154-a4c5-1f2127c4e1a0" },
                    { 11, -800.0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 3, 11, 0, 0, 0, 0, DateTimeKind.Utc), false, "Payment maintenance charge 2/3/2024", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "a0ac645e-9ece-4910-a5c1-1f0874e2cabb" },
                    { 12, -150.0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Utc), false, "Payment cleaning charge 3/3/2024", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "c7395942-3692-4101-b51f-361abd132a4e" },
                    { 13, -5.4000000000000004, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 4, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Uber 063045 SF**POOL**", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "cb5078d5-3e51-4207-93d1-980e021372ee" },
                    { 14, 1500.0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 4, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "Payment rent 1/4/2024", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "62b3e806-4b7c-45b3-af36-11945cd8a97e" },
                    { 15, -800.0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Utc), false, "Payment maintenance charge 2/4/2024", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "6330cb1c-149b-486d-bea3-942b74a5c7a9" },
                    { 16, -150.0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Utc), false, "Payment cleaning charge 3/4/2024", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "d3e482da-4c58-46c6-ac3c-a455ab7de41a" },
                    { 17, -5.4000000000000004, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Uber 063055 SF**POOL**", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "6e2e76bd-d15e-495f-aaae-97cae837a3d7" },
                    { 18, 1500.0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "Payment rent 1/5/2024", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "1ad5ad31-1e9b-4cf3-a8b5-6468ec88c008" },
                    { 19, -800.0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 5, 11, 0, 0, 0, 0, DateTimeKind.Utc), false, "Payment maintenance charge 2/5/2024", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "38440e0b-30fe-4a77-90f4-0687fe1d60dc" },
                    { 20, -150.0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Utc), false, "Payment cleaning charge 3/5/2024", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "95d205bf-e544-4ea1-906f-98f88d43ed5d" },
                    { 21, -5.4000000000000004, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 6, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Uber 063065 SF**POOL**", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "93c2e12b-b53e-43db-a7d9-67ab5434b8a5" },
                    { 22, 1500.0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 6, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "Payment rent 1/6/2024", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "f3dde13d-3c27-441e-a65d-4a926859d411" },
                    { 23, -800.0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 6, 11, 0, 0, 0, 0, DateTimeKind.Utc), false, "Payment maintenance charge 2/6/2024", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "6dbd89fc-9f63-4437-a112-60794868dd4c" },
                    { 24, -150.0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), false, "Payment cleaning charge 3/6/2024", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "218f22dd-64eb-4a6d-8225-9f5c323cf18f" },
                    { 25, -5.4000000000000004, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Uber 063075 SF**POOL**", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "b9a0b96b-0976-493f-95db-dbc0a1bc3078" },
                    { 26, 1500.0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 7, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "Payment rent 1/7/2024", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "a94dd9e7-cc05-4d7e-9622-96ba00d496e5" },
                    { 27, -800.0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 7, 11, 0, 0, 0, 0, DateTimeKind.Utc), false, "Payment maintenance charge 2/7/2024", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "a70421ab-e037-4ec5-b49b-c19c77e687b6" },
                    { 28, -150.0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Utc), false, "Payment cleaning charge 3/7/2024", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "01dfdc64-b897-4ebb-8f84-312cd282b501" },
                    { 29, -5.4000000000000004, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 8, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Uber 063085 SF**POOL**", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "a5339888-0cd7-4d58-bb38-ae8d28ceb8cb" },
                    { 30, 1500.0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 8, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "Payment rent 1/8/2024", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "ad364d74-ce37-4d23-9fc7-86e669730d31" },
                    { 31, -800.0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 8, 11, 0, 0, 0, 0, DateTimeKind.Utc), false, "Payment maintenance charge 2/8/2024", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "dcac8f81-8299-4693-9863-fe0379043677" },
                    { 32, -150.0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 8, 12, 0, 0, 0, 0, DateTimeKind.Utc), false, "Payment cleaning charge 3/8/2024", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "ba8e589c-b83a-46a3-a319-4b8fd2844089" },
                    { 33, -5.4000000000000004, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 9, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Uber 063095 SF**POOL**", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "ec4ec0ca-2403-4529-9bd0-7856651265c4" },
                    { 34, 1500.0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 9, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "Payment rent 1/9/2024", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "cbad0536-1d69-4f6d-b55e-1834928211a1" },
                    { 35, -800.0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 9, 11, 0, 0, 0, 0, DateTimeKind.Utc), false, "Payment maintenance charge 2/9/2024", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "77879b69-70ab-4823-b905-ba9e1151943d" },
                    { 36, -150.0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Utc), false, "Payment cleaning charge 3/9/2024", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "ec4c3505-c584-4ef9-9d57-62fd3ece007e" },
                    { 37, -5.4000000000000004, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Uber 0630105 SF**POOL**", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "d838b829-2351-4793-bf50-5590d9df7d9b" },
                    { 38, 1500.0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 10, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "Payment rent 1/10/2024", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "0bfe4a36-ce51-4c9a-ac34-cb132e99179f" },
                    { 39, -800.0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Utc), false, "Payment maintenance charge 2/10/2024", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "9c285a91-b4ab-4d41-8208-eee21f82a535" },
                    { 40, -150.0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 10, 12, 0, 0, 0, 0, DateTimeKind.Utc), false, "Payment cleaning charge 3/10/2024", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "bfa9ea47-ad8f-4911-a841-55f09ccbb5b9" },
                    { 41, -5.4000000000000004, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 11, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Uber 0630115 SF**POOL**", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "8bd194a2-96ff-4534-857e-f36b0eddbae2" },
                    { 42, 1500.0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 11, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "Payment rent 1/11/2024", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "6bd3e2a0-ee2a-43cb-a846-27948e260b37" },
                    { 43, -800.0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 11, 11, 0, 0, 0, 0, DateTimeKind.Utc), false, "Payment maintenance charge 2/11/2024", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "c1989d80-4815-4480-9ff3-d634f83309cd" },
                    { 44, -150.0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 11, 12, 0, 0, 0, 0, DateTimeKind.Utc), false, "Payment cleaning charge 3/11/2024", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "1d0ecf59-9b1c-40db-b5e3-bf93c8520ffa" },
                    { 45, -5.4000000000000004, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Uber 0630125 SF**POOL**", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "6f729375-b5b0-4efb-93c5-a6d71e23bf55" },
                    { 46, 1500.0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, "Payment rent 1/12/2024", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "ca62c7c5-bd4b-4c72-beb4-76333810a1d3" },
                    { 47, -800.0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 12, 11, 0, 0, 0, 0, DateTimeKind.Utc), false, "Payment maintenance charge 2/12/2024", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "fef863d1-0df9-4914-8ba9-6c0b165c4e3a" },
                    { 48, -150.0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc), false, "Payment cleaning charge 3/12/2024", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0, "76ed32ea-f4f7-4ebd-8954-ba62a15eaa6f" }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "CreatedDate", "CreatorId", "Date", "Deleted", "Description", "EntityId", "EntityRunningBalance", "LastEditedDate", "LastEditorId", "PropertyId", "RunningBalance", "SubType", "Type" },
                values: new object[,]
                {
                    { 1, 1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Charge of rent 1/1/2024", 1, -1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -1500m, 1, 1 },
                    { 2, 800m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Maintenance of 2/1/2024", 1, -2300m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -2300m, 1, 2 },
                    { 3, 150m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Charge of cleaning 3/1/2024", 1, -2450m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -2450m, 1, 3 },
                    { 4, 1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Charge of rent 1/2/2024", 1, -3950m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -3950m, 1, 1 },
                    { 5, 800m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Maintenance of 2/2/2024", 1, -4750m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -4750m, 1, 2 },
                    { 6, 150m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Charge of cleaning 3/2/2024", 1, -4900m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -4900m, 1, 3 },
                    { 7, 1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 3, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Charge of rent 1/3/2024", 1, -6400m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -6400m, 1, 1 },
                    { 8, 800m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 3, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Maintenance of 2/3/2024", 1, -7200m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -7200m, 1, 2 },
                    { 9, 150m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Charge of cleaning 3/3/2024", 1, -7350m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -7350m, 1, 3 },
                    { 10, 1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 4, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Charge of rent 1/4/2024", 1, -8850m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -8850m, 1, 1 },
                    { 11, 800m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 4, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Maintenance of 2/4/2024", 1, -9650m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -9650m, 1, 2 },
                    { 12, 150m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Charge of cleaning 3/4/2024", 1, -9800m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -9800m, 1, 3 },
                    { 13, 1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Charge of rent 1/5/2024", 1, -11300m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -11300m, 1, 1 },
                    { 14, 800m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Maintenance of 2/5/2024", 1, -12100m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -12100m, 1, 2 },
                    { 15, 150m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Charge of cleaning 3/5/2024", 1, -12250m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -12250m, 1, 3 },
                    { 16, 1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 6, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Charge of rent 1/6/2024", 1, -13750m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -13750m, 1, 1 },
                    { 17, 800m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 6, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Maintenance of 2/6/2024", 1, -14550m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -14550m, 1, 2 },
                    { 18, 150m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Charge of cleaning 3/6/2024", 1, -14700m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -14700m, 1, 3 },
                    { 19, 1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Charge of rent 1/7/2024", 1, -16200m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -16200m, 1, 1 },
                    { 20, 800m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Maintenance of 2/7/2024", 1, -17000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -17000m, 1, 2 },
                    { 21, 150m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Charge of cleaning 3/7/2024", 1, -17150m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -17150m, 1, 3 },
                    { 22, 1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 8, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Charge of rent 1/8/2024", 1, -18650m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -18650m, 1, 1 },
                    { 23, 800m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 8, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Maintenance of 2/8/2024", 1, -19450m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -19450m, 1, 2 },
                    { 24, 150m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Charge of cleaning 3/8/2024", 1, -19600m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -19600m, 1, 3 },
                    { 25, 1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Charge of rent 1/9/2024", 1, -21100m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -21100m, 1, 1 },
                    { 26, 800m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Maintenance of 2/9/2024", 1, -21900m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -21900m, 1, 2 },
                    { 27, 150m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Charge of cleaning 3/9/2024", 1, -22050m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -22050m, 1, 3 },
                    { 28, 1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 10, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Charge of rent 1/10/2024", 1, -23550m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -23550m, 1, 1 },
                    { 29, 800m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 10, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Maintenance of 2/10/2024", 1, -24350m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -24350m, 1, 2 },
                    { 30, 150m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Charge of cleaning 3/10/2024", 1, -24500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -24500m, 1, 3 },
                    { 31, 1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 11, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Charge of rent 1/11/2024", 1, -26000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -26000m, 1, 1 },
                    { 32, 800m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 11, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Maintenance of 2/11/2024", 1, -26800m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -26800m, 1, 2 },
                    { 33, 150m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Charge of cleaning 3/11/2024", 1, -26950m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -26950m, 1, 3 },
                    { 34, 1500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Charge of rent 1/12/2024", 1, -28450m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -28450m, 1, 1 },
                    { 35, 800m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, "Maintenance of 2/12/2024", 1, -29250m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -29250m, 1, 2 },
                    { 36, 150m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, "Charge of cleaning 3/12/2024", 1, -29400m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, -29400m, 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "ExpenseCharge",
                columns: new[] { "Id", "CreatedDate", "CreatorId", "Deleted", "DueDate", "ExpenseId", "LastEditedDate", "LastEditorId", "Status", "TransactionId" },
                values: new object[,]
                {
                    { 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 3 },
                    { 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 6 },
                    { 4, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 9 },
                    { 5, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 4, 20, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 12 },
                    { 6, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 15 },
                    { 7, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 18 },
                    { 8, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 7, 20, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 21 },
                    { 9, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 8, 20, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 24 },
                    { 10, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 27 },
                    { 11, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 30 },
                    { 12, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 33 },
                    { 13, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 12, 20, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 36 }
                });

            migrationBuilder.InsertData(
                table: "LeaseCharges",
                columns: new[] { "Id", "CreatedDate", "CreatorId", "Deleted", "DueDate", "LastEditedDate", "LastEditorId", "LeaseId", "Status", "TransactionId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 1, 1 },
                    { 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 1, 4 },
                    { 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 1, 7 },
                    { 4, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 1, 10 },
                    { 5, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 1, 13 },
                    { 6, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 1, 16 },
                    { 7, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 1, 19 },
                    { 8, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 1, 22 },
                    { 9, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 1, 25 },
                    { 10, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 1, 28 },
                    { 11, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 1, 31 },
                    { 12, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 12, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 1, 34 }
                });

            migrationBuilder.InsertData(
                table: "MaintenanceCharges",
                columns: new[] { "Id", "CreatedDate", "CreatorId", "Deleted", "DueDate", "LastEditedDate", "LastEditorId", "MaintenanceId", "Status", "TransactionId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 1, 2 },
                    { 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 2, 1, 5 },
                    { 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 3, 1, 8 },
                    { 4, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 4, 1, 11 },
                    { 5, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 5, 1, 14 },
                    { 6, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 6, 1, 17 },
                    { 7, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 7, 1, 20 },
                    { 8, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 8, 1, 23 },
                    { 9, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 9, 1, 26 },
                    { 10, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 10, 1, 29 },
                    { 11, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 11, 1, 32 },
                    { 12, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, false, new DateTime(2024, 12, 15, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 12, 1, 35 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BankTransaction_LeaseId",
                table: "BankTransaction",
                column: "LeaseId");

            migrationBuilder.CreateIndex(
                name: "IX_BankTransaction_OwnerBankAccountId",
                table: "BankTransaction",
                column: "OwnerBankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_BankTransaction_PropertyId",
                table: "BankTransaction",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseCharge_ExpenseId",
                table: "ExpenseCharge",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseCharge_TransactionId",
                table: "ExpenseCharge",
                column: "TransactionId");

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
                name: "IX_MaintenanceCharges_MaintenanceId",
                table: "MaintenanceCharges",
                column: "MaintenanceId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceCharges_TransactionId",
                table: "MaintenanceCharges",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenancePayments_MaintenanceId",
                table: "MaintenancePayments",
                column: "MaintenanceId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenancePayments_TransactionId",
                table: "MaintenancePayments",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_PropertyId",
                table: "Maintenances",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_TypeId",
                table: "Maintenances",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_ReceiverId",
                table: "Notifications",
                column: "ReceiverId");

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
                name: "IX_PlaidTransaction_OwnerBankAccountId",
                table: "PlaidTransaction",
                column: "OwnerBankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_AddressId",
                table: "Properties",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_OwnerId",
                table: "Properties",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_AddressId",
                table: "Tenants",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_ApplicationUserId",
                table: "Tenants",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionApplications_BankTransactionId",
                table: "TransactionApplications",
                column: "BankTransactionId");

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
                name: "DomainEvents");

            migrationBuilder.DropTable(
                name: "ExpenseCharge");

            migrationBuilder.DropTable(
                name: "LeaseCharges");

            migrationBuilder.DropTable(
                name: "LeasePayments");

            migrationBuilder.DropTable(
                name: "MaintenanceCharges");

            migrationBuilder.DropTable(
                name: "MaintenancePayments");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "PlaidTransaction");

            migrationBuilder.DropTable(
                name: "TransactionApplications");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Expense");

            migrationBuilder.DropTable(
                name: "Maintenances");

            migrationBuilder.DropTable(
                name: "BankTransaction");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "MaintenanceTypes");

            migrationBuilder.DropTable(
                name: "Leases");

            migrationBuilder.DropTable(
                name: "OwnerBankAccounts");

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
