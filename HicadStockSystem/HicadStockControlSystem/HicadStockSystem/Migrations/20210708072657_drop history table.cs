using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HicadStockSystem.Migrations
{
    public partial class drophistorytable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "st_history");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "st_history",
                columns: table => new
                {
                    ItemCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    DocNo = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    DocType = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DocDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Period = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    RemarkId = table.Column<int>(type: "int", nullable: true),
                    St_RemarkId = table.Column<int>(type: "int", nullable: true),
                    St_RemarkRemark = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Supplier = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_st_history", x => new { x.ItemCode, x.DocNo, x.DocType });
                    table.ForeignKey(
                        name: "FK_st_history_st_remark_St_RemarkId_St_RemarkRemark",
                        columns: x => new { x.St_RemarkId, x.St_RemarkRemark },
                        principalTable: "st_remark",
                        principalColumns: new[] { "Id", "Remark" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_st_history_St_RemarkId_St_RemarkRemark",
                table: "st_history",
                columns: new[] { "St_RemarkId", "St_RemarkRemark" });
        }
    }
}
