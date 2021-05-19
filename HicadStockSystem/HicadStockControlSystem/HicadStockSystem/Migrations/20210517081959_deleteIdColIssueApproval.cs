using Microsoft.EntityFrameworkCore.Migrations;

namespace HicadStockSystem.Migrations
{
    public partial class deleteIdColIssueApproval : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_st_issueapprove",
                table: "st_issueapprove");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "st_issueapprove");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "st_issueapprove",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_st_issueapprove",
                table: "st_issueapprove",
                column: "Id");
        }
    }
}
