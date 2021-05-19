using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HicadStockSystem.Migrations
{
    public partial class DropAccChartTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accchart");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "accchart",
                columns: table => new
                {
                    acctnumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    acctcode1 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    acctcode2 = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    acctcode3 = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    acctcode4 = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    acctcode5 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    acctcode6 = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    acctcode7 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    acctsubtype = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    acctype = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    address1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    address2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    address3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    blgroup1 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    blgroup2 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    blgroup3 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    blgroup4 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    blgroupdes1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    blgroupdes2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    blgroupdes3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    blgroupdes4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    blsum1 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    blsum2 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    blsum3 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    blsum4 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    blsumdesc1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    blsumdesc2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    blsumdesc3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    blsumdesc4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    cfgroup1 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    cfgroup2 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    cfgroup3 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    cfgroup4 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    cfgroupdes1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    cfgroupdes2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    cfgroupdes3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    cfgroupdes4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    cfsumdesc1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    cfsumdesc2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    cfsumdesc3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    cfsumdesc4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    createdby = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    dateblocked = table.Column<DateTime>(type: "datetime2", nullable: true),
                    datecreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    description = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    effdate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ledgerpasswd = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ledgerpasswd2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    oldnumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    subcode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    telephone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    trade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accchart", x => x.acctnumber);
                });
        }
    }
}
