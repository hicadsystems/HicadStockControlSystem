using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HicadStockSystem.Migrations
{
    public partial class deletestateandsystemtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "st_stksystems");

            migrationBuilder.DropTable(
                name: "StateLists");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "st_stksystems",
                columns: table => new
                {
                    CompanyCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ApprovedDay = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    BusLine = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    CompanyAddress = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreditorsCode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ExpenseCode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    GLCode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    HoldDays = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    InstallDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ProcessMonth = table.Column<int>(type: "int", nullable: true),
                    ProcessYear = table.Column<int>(type: "int", nullable: true),
                    SerialNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Town_City = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WriteoffLoc = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_st_stksystems", x => x.CompanyCode);
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
        }
    }
}
