using Microsoft.EntityFrameworkCore.Migrations;

namespace HicadStockSystem.Migrations
{
    public partial class setDeleteFlag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "st_supplier",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "st_stockmaster",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "st_stockclass",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "st_stksystems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "st_stkjournal",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "st_requisition",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "st_recordtable",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "st_itemmaster",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "st_issuereq",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "st_issueapprove",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "st_history",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "st_costcentre",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "st_buyerguide",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "st_businessline",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "st_supplier");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "st_stockmaster");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "st_stockclass");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "st_stksystems");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "st_stkjournal");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "st_requisition");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "st_recordtable");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "st_itemmaster");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "st_issuereq");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "st_issueapprove");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "st_history");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "st_costcentre");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "st_buyerguide");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "st_businessline");
        }
    }
}
