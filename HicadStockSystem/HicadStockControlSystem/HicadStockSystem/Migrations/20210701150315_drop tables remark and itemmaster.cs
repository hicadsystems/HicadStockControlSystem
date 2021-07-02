using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HicadStockSystem.Migrations
{
    public partial class droptablesremarkanditemmaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_st_history_st_remark_St_RemarkId",
                table: "st_history");

            migrationBuilder.DropTable(
                name: "st_itemmaster");

            migrationBuilder.DropTable(
                name: "st_remark");

            migrationBuilder.DropIndex(
                name: "IX_st_history_St_RemarkId",
                table: "st_history");

            migrationBuilder.DropColumn(
                name: "St_RemarkId",
                table: "st_history");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "St_RemarkId",
                table: "st_history",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "st_itemmaster",
                columns: table => new
                {
                    ItemCode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    BusLine = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Class = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ItemDesc = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    PartNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ReOrderLevel = table.Column<int>(type: "int", nullable: true),
                    ReOrderQty = table.Column<int>(type: "int", nullable: true),
                    StoreLoc = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Storebin = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Storerack = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Supplier1 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Supplier2 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Supplier3 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Supplier4 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Supplier5 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Supplier6 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Units = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    XRef = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_st_itemmaster", x => x.ItemCode);
                });

            migrationBuilder.CreateTable(
                name: "st_remark",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_st_remark", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_st_history_St_RemarkId",
                table: "st_history",
                column: "St_RemarkId");

            migrationBuilder.AddForeignKey(
                name: "FK_st_history_st_remark_St_RemarkId",
                table: "st_history",
                column: "St_RemarkId",
                principalTable: "st_remark",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
