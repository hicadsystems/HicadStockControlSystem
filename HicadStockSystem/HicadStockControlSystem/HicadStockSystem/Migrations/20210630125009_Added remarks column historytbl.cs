using Microsoft.EntityFrameworkCore.Migrations;

namespace HicadStockSystem.Migrations
{
    public partial class Addedremarkscolumnhistorytbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "st_history",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "st_history");
        }
    }
}
