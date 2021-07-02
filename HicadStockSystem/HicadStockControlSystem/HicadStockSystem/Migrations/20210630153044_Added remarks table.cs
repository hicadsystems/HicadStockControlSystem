using Microsoft.EntityFrameworkCore.Migrations;

namespace HicadStockSystem.Migrations
{
    public partial class Addedremarkstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "st_remark",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "st_remark");
        }
    }
}
