using Microsoft.EntityFrameworkCore.Migrations;

namespace HicadStockSystem.Migrations
{
    public partial class changeTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_  ac_costcentre",
                table: "  ac_costcentre");

            migrationBuilder.RenameTable(
                name: "  ac_costcentre",
                newName: "ac_costcentre");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ac_costcentre",
                table: "ac_costcentre",
                column: "UnitCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ac_costcentre",
                table: "ac_costcentre");

            migrationBuilder.RenameTable(
                name: "ac_costcentre",
                newName: "  ac_costcentre");

            migrationBuilder.AddPrimaryKey(
                name: "PK_  ac_costcentre",
                table: "  ac_costcentre",
                column: "UnitCode");
        }
    }
}
