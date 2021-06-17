using Microsoft.EntityFrameworkCore.Migrations;

namespace HicadStockSystem.Migrations
{
    public partial class DropIssAppDocCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IssAppDocCode",
                table: "st_recordtable");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IssAppDocCode",
                table: "st_recordtable",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
