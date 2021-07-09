using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HicadStockSystem.Migrations
{
    public partial class createhistorytable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "st_history",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    DocNo = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    DocType = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    DocDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Period = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: true),
                    Supplier = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RemarkId = table.Column<int>(type: "int", nullable: true),
                    St_RemarkId = table.Column<int>(type: "int", nullable: true),
                    St_RemarkRemark = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_st_history", x => x.Id);
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "st_history");
        }
    }
}
