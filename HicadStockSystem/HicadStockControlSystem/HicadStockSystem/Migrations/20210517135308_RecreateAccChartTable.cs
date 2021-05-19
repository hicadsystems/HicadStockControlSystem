using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HicadStockSystem.Migrations
{
    public partial class RecreateAccChartTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "accchart",
                columns: table => new
                {
                    AcctNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    AcctCode1 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    AcctCode2 = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    AcctCode3 = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    AcctCode4 = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    AcctCode5 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    AcctCode6 = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    AcctCode7 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    OldNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    AccType = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    AcctSubtype = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EffDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    LedgerPasswd = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LedgerPasswd2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Subcode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    BLGroup1 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    BLGroup2 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    BLGroup3 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    BLGroup4 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    BLGroupDes1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BLGroupDes2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BLGroupDes3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BLGroupDes4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BLSum1 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    BLSum2 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    BLSum3 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    BLSum4 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    BLSumDesc1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BLSumDesc2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BLSumDesc3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BLSumDesc4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CFGroup1 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    CFGroup2 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    CFGroup3 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    CFGroup4 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    CFGroupDes1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CFGroupDes2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CFGroupDes3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CFGroupDes4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CFSumDesc1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CFSumDesc2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CFSumDesc3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CFSumDesc4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Trade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateBlocked = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accchart", x => x.AcctNumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accchart");
        }
    }
}
