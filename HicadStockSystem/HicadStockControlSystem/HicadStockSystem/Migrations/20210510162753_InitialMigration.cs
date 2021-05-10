using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HicadStockSystem.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ac_businessline",
                columns: table => new
                {
                    BusinessLine = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    BusinessDesc = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Business_Year = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Business_Month = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Cashier_Ac = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ac_businessline", x => x.BusinessLine);
                });

            migrationBuilder.CreateTable(
                name: "ac_costcentre",
                columns: table => new
                {
                    UnitCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    UnitDesc = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    UnitDiv = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    UnitDivDesc = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ac_costcentre", x => x.UnitCode);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Datecreated = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                name: "GroupMenus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupMenus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "st_businessline",
                columns: table => new
                {
                    BusinessLine = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    BusinessDesc = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Business_Year = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Business_Month = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Cashier_Ac = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_st_businessline", x => x.BusinessLine);
                });

            migrationBuilder.CreateTable(
                name: "st_buyerguide",
                columns: table => new
                {
                    ItemCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    ItemDesc = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Supplier1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Supplier2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Supplier3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Supplier4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Supplier5 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Code1 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Code2 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Code3 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Code4 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Code5 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_st_buyerguide", x => x.ItemCode);
                });

            migrationBuilder.CreateTable(
                name: "st_costcentre",
                columns: table => new
                {
                    UnitCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    UnitDesc = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    UnitDiv = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    UnitDivDesc = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_st_costcentre", x => x.UnitCode);
                });

            migrationBuilder.CreateTable(
                name: "st_history",
                columns: table => new
                {
                    ItemCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    DocNo = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    DocType = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    DocDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Period = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: true),
                    Supplier = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_st_history", x => new { x.ItemCode, x.DocNo, x.DocType });
                });

            migrationBuilder.CreateTable(
                name: "st_issueapprove",
                columns: table => new
                {
                    ItemCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    DocNo = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Quantity = table.Column<float>(type: "real", nullable: true),
                    ApprovedQty = table.Column<float>(type: "real", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "st_issuereq",
                columns: table => new
                {
                    ItemCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    DocNo = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Quantity = table.Column<float>(type: "real", nullable: true),
                    SupplyQty = table.Column<float>(type: "real", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "st_itemmaster",
                columns: table => new
                {
                    ItemCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    ItemDesc = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    StoreLoc = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Storerack = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Storebin = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    ReOrderLevel = table.Column<int>(type: "int", nullable: false),
                    ReOrderQty = table.Column<int>(type: "int", nullable: false),
                    Units = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    XRef = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Supplier1 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Supplier2 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Supplier3 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Supplier4 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Supplier5 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Supplier6 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Class = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    BusLine = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_st_itemmaster", x => x.ItemCode);
                });

            migrationBuilder.CreateTable(
                name: "st_recordtable",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    RequsitionNo = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_st_recordtable", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "st_requisition",
                columns: table => new
                {
                    RequisitionNo = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    ItemCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LocationCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Quantity = table.Column<float>(type: "real", nullable: true),
                    RequisitionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SupplyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SupplyQty = table.Column<float>(type: "real", nullable: true),
                    SupplyBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ApprovedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_st_requisition", x => new { x.RequisitionNo, x.ItemCode });
                });

            migrationBuilder.CreateTable(
                name: "st_stkjournal",
                columns: table => new
                {
                    Stk_Company = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Stk_Branch = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Stk_Year = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Stk_Month = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Stk_Location = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Stk_Type = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Stk_Account = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Stk_Debit = table.Column<decimal>(type: "money", nullable: true),
                    Stk_Credit = table.Column<decimal>(type: "money", nullable: true),
                    Stk_Rem = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Stk_Update = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Stk_Period = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_st_stkjournal", x => new { x.Stk_Company, x.Stk_Branch, x.Stk_Year, x.Stk_Month, x.Stk_Location, x.Stk_Type, x.Stk_Account });
                });

            migrationBuilder.CreateTable(
                name: "st_stksystems",
                columns: table => new
                {
                    CompanyCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CompanyAddress = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Town_City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstallDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    GLCode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ProcessYear = table.Column<int>(type: "int", nullable: false),
                    ProcessMonth = table.Column<int>(type: "int", nullable: false),
                    ExpenseCode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    WriteoffLoc = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    CreditorsCode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    BusLine = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    HoldDays = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    ApprovedDay = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_st_stksystems", x => x.CompanyCode);
                });

            migrationBuilder.CreateTable(
                name: "st_stockclass",
                columns: table => new
                {
                    SktClass = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_st_stockclass", x => x.SktClass);
                });

            migrationBuilder.CreateTable(
                name: "st_stockmaster",
                columns: table => new
                {
                    ItemCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OpenBalance = table.Column<float>(type: "real", nullable: true),
                    Receipts = table.Column<float>(type: "real", nullable: true),
                    Issues = table.Column<float>(type: "real", nullable: true),
                    StockPrice = table.Column<decimal>(type: "money", nullable: true),
                    Physical = table.Column<float>(type: "real", nullable: true),
                    LastIssueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastReceiptDay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastPhysicalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    QtyInTransaction = table.Column<float>(type: "real", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_st_stockmaster", x => x.ItemCode);
                });

            migrationBuilder.CreateTable(
                name: "st_supplier",
                columns: table => new
                {
                    SupplierCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Sup_Last_Num = table.Column<int>(type: "int", nullable: true),
                    Sup_Start_Date = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_st_supplier", x => x.SupplierCode);
                });

            migrationBuilder.CreateTable(
                name: "StateLists",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateLists", x => x.Id);
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
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RoleId1 = table.Column<int>(type: "int", nullable: true),
                    UserId1 = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId1",
                        column: x => x.RoleId1,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Controller = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupMenuId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menus_GroupMenus_GroupMenuId",
                        column: x => x.GroupMenuId,
                        principalTable: "GroupMenus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleMenus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleMenus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleMenus_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleMenus_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "StateLists",
                columns: new[] { "Id", "StateName" },
                values: new object[,]
                {
                    { (byte)1, "Abia" },
                    { (byte)21, "Katsina" },
                    { (byte)22, "Kebbi" },
                    { (byte)23, "Kogi" },
                    { (byte)24, "Kwara" },
                    { (byte)25, "Lagos" },
                    { (byte)26, "Nasarawa" },
                    { (byte)27, "Niger" },
                    { (byte)28, "Ogun" },
                    { (byte)29, "Ondo" },
                    { (byte)30, "Osun" },
                    { (byte)31, "Oyo" },
                    { (byte)32, "Plateau" },
                    { (byte)33, "Rivers" },
                    { (byte)34, "Sokoto" },
                    { (byte)35, "Taraba" },
                    { (byte)20, "Kano" },
                    { (byte)36, "Yobe" },
                    { (byte)19, "Kaduna" },
                    { (byte)17, "Imo" },
                    { (byte)2, "Adamawa" },
                    { (byte)3, "Akwa Ibom" },
                    { (byte)4, "Anambra" },
                    { (byte)5, "Bauchi" },
                    { (byte)6, "Bayelsa" },
                    { (byte)7, "Benue" },
                    { (byte)8, "Borno" },
                    { (byte)9, "Cross River" },
                    { (byte)10, "Delta" },
                    { (byte)11, "Ebonyi" },
                    { (byte)12, "Edo" },
                    { (byte)13, "Ekiti" },
                    { (byte)14, "Enugu" },
                    { (byte)15, "FCT - Abuja" },
                    { (byte)16, "Gombe" },
                    { (byte)18, "Jigawa" },
                    { (byte)37, "Zamfara" }
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
                name: "IX_AspNetUserRoles_RoleId1",
                table: "AspNetUserRoles",
                column: "RoleId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId1",
                table: "AspNetUserRoles",
                column: "UserId1");

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
                name: "IX_Menus_GroupMenuId",
                table: "Menus",
                column: "GroupMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleMenus_MenuId",
                table: "RoleMenus",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleMenus_RoleId",
                table: "RoleMenus",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ac_businessline");

            migrationBuilder.DropTable(
                name: "ac_costcentre");

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
                name: "RoleMenus");

            migrationBuilder.DropTable(
                name: "st_businessline");

            migrationBuilder.DropTable(
                name: "st_buyerguide");

            migrationBuilder.DropTable(
                name: "st_costcentre");

            migrationBuilder.DropTable(
                name: "st_history");

            migrationBuilder.DropTable(
                name: "st_issueapprove");

            migrationBuilder.DropTable(
                name: "st_issuereq");

            migrationBuilder.DropTable(
                name: "st_itemmaster");

            migrationBuilder.DropTable(
                name: "st_recordtable");

            migrationBuilder.DropTable(
                name: "st_requisition");

            migrationBuilder.DropTable(
                name: "st_stkjournal");

            migrationBuilder.DropTable(
                name: "st_stksystems");

            migrationBuilder.DropTable(
                name: "st_stockclass");

            migrationBuilder.DropTable(
                name: "st_stockmaster");

            migrationBuilder.DropTable(
                name: "st_supplier");

            migrationBuilder.DropTable(
                name: "StateLists");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "GroupMenus");
        }
    }
}
