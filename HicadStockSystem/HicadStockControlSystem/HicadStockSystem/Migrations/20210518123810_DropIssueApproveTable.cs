using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HicadStockSystem.Migrations
{
    public partial class DropIssueApproveTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "st_issueapprove");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "st_issueapprove",
                columns: table => new
                {
                    RequisitionNo = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    ApprovedQty = table.Column<float>(type: "real", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    DocNo = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    ItemCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Quantity = table.Column<float>(type: "real", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_st_issueapprove", x => x.RequisitionNo);
                });
        }
    }
}
