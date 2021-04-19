using Microsoft.EntityFrameworkCore.Migrations;

namespace HicadStockSystem.Migrations
{
    public partial class NewProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApprovedDay",
                table: "St_StkSystems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusLine",
                table: "St_StkSystems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreditorsCode",
                table: "St_StkSystems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExpenseCode",
                table: "St_StkSystems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HoldDays",
                table: "St_StkSystems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProcessMonth",
                table: "St_StkSystems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProcessYear",
                table: "St_StkSystems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "WriteoffLoc",
                table: "St_StkSystems",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedDay",
                table: "St_StkSystems");

            migrationBuilder.DropColumn(
                name: "BusLine",
                table: "St_StkSystems");

            migrationBuilder.DropColumn(
                name: "CreditorsCode",
                table: "St_StkSystems");

            migrationBuilder.DropColumn(
                name: "ExpenseCode",
                table: "St_StkSystems");

            migrationBuilder.DropColumn(
                name: "HoldDays",
                table: "St_StkSystems");

            migrationBuilder.DropColumn(
                name: "ProcessMonth",
                table: "St_StkSystems");

            migrationBuilder.DropColumn(
                name: "ProcessYear",
                table: "St_StkSystems");

            migrationBuilder.DropColumn(
                name: "WriteoffLoc",
                table: "St_StkSystems");
        }
    }
}
