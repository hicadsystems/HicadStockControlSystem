using Microsoft.EntityFrameworkCore.Migrations;

namespace HicadStockSystem.Migrations
{
    public partial class IdentityKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_st_issuereq",
                table: "st_issuereq");

            migrationBuilder.DropPrimaryKey(
                name: "PK_st_issueapprove",
                table: "st_issueapprove");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "st_issuereq");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "st_issueapprove");

            migrationBuilder.AddColumn<string>(
                name: "RequisitionNo",
                table: "st_issuereq",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RequisitionNo",
                table: "st_issueapprove",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_st_issuereq",
                table: "st_issuereq",
                column: "RequisitionNo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_st_issueapprove",
                table: "st_issueapprove",
                column: "RequisitionNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_st_issuereq",
                table: "st_issuereq");

            migrationBuilder.DropPrimaryKey(
                name: "PK_st_issueapprove",
                table: "st_issueapprove");

            migrationBuilder.DropColumn(
                name: "RequisitionNo",
                table: "st_issuereq");

            migrationBuilder.DropColumn(
                name: "RequisitionNo",
                table: "st_issueapprove");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "st_issuereq",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "st_issueapprove",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_st_issuereq",
                table: "st_issuereq",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_st_issueapprove",
                table: "st_issueapprove",
                column: "Id");
        }
    }
}
