using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HicadStockSystem.Migrations
{
    public partial class NewPptyrecordTble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "st_history");

            migrationBuilder.AddColumn<int>(
                name: "ReceiptNo",
                table: "st_recordtable",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiptNo",
                table: "st_recordtable");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "st_history",
                type: "datetime2",
                nullable: true);
        }
    }
}
